using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyWinFormsApp
{
    public partial class Form1 : Form
    {
        private string inputFilePath;
        private string outputFilePath;
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnInFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputFilePath = openFileDialog.FileName;
                }
            }
        }

        private void btnOutFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    outputFilePath = saveFileDialog.FileName;
                }
            }
        }

        private async void btnPack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputFilePath) && !string.IsNullOrEmpty(outputFilePath))
            {
                cancellationTokenSource = new CancellationTokenSource();
                try
                {
                    await Task.Run(() => CompressFile(inputFilePath, outputFilePath, cancellationTokenSource.Token));
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Operation was cancelled.");
                }
            }
        }

        private async void btnUnPack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputFilePath) && !string.IsNullOrEmpty(outputFilePath))
            {
                cancellationTokenSource = new CancellationTokenSource();
                try
                {
                    await Task.Run(() => DecompressFile(inputFilePath, outputFilePath, cancellationTokenSource.Token));
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Operation was cancelled.");
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputFilePath) && !string.IsNullOrEmpty(outputFilePath))
            {
                bool filesAreEqual = CompareFiles(inputFilePath, outputFilePath);
                if (filesAreEqual)
                {
                    MessageBox.Show("Files are identical.");
                }
                else
                {
                    MessageBox.Show("Files are not identical.");
                }
            }
            else
            {
                MessageBox.Show("Both input and output files must be selected.");
            }
        }

        private bool CompareFiles(string filePath1, string filePath2)
        {
            try
            {
                FileInfo fileInfo1 = new FileInfo(filePath1);
                FileInfo fileInfo2 = new FileInfo(filePath2);

                // Сравнение по размеру
                if (fileInfo1.Length != fileInfo2.Length)
                {
                    return false;
                }

                // Сравнение по содержимому
                using (FileStream fs1 = fileInfo1.OpenRead())
                using (FileStream fs2 = fileInfo2.OpenRead())
                {
                    int file1Byte;
                    int file2Byte;
                    do
                    {
                        file1Byte = fs1.ReadByte();
                        file2Byte = fs2.ReadByte();
                    }
                    while ((file1Byte == file2Byte) && (file1Byte != -1));

                    return file1Byte == file2Byte;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        private void CompressFile(string inputFile, string outputFile, CancellationToken cancellationToken)
        {
            try
            {
                using (FileStream originalFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream compressedFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    long totalBytesRead = 0;
                    long totalLength = originalFileStream.Length;

                    while ((bytesRead = originalFileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                        }

                        compressionStream.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;

                        int progress = (int)((double)totalBytesRead / totalLength * 100);
                        Invoke(new Action(() => progressBar.Value = Math.Min(progress, 100)));
                    }

                    Invoke(new Action(() => progressBar.Value = 100));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void DecompressFile(string inputFile, string outputFile, CancellationToken cancellationToken)
        {
            try
            {
                using (FileStream compressedFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream decompressedFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (GZipStream decompressionStream = new GZipStream(compressedFileStream, CompressionMode.Decompress))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    long totalBytesRead = 0;
                    long totalLength = compressedFileStream.Length;

                    while ((bytesRead = decompressionStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                        }

                        decompressedFileStream.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;

                        int progress = (int)((double)totalBytesRead / totalLength * 100);
                        Invoke(new Action(() => progressBar.Value = Math.Min(progress, 100)));
                    }

                    Invoke(new Action(() => progressBar.Value = 100));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsApp
{
    public partial class Form1 : Form
    {
        private string inputFilePath;
        private string outputFilePath;
        private bool stopRequested = false;
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
                stopRequested = false;
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
                stopRequested = false;
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
            stopRequested = true;
            cancellationTokenSource?.Cancel();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CompressFile(string inputFile, string outputFile, CancellationToken cancellationToken)
        {
            try
            {
                var input = File.ReadAllText(inputFile);
                var output = new StringBuilder();

                for (int i = 0; i < input.Length;)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }

                    int count = 1;
                    char currentChar = input[i];

                    while (i + count < input.Length && input[i + count] == currentChar)
                    {
                        count++;
                    }

                    if (count > 1)
                    {
                        output.Append(count).Append(currentChar);
                        i += count;
                    }
                    else
                    {
                        int start = i;
                        while (i < input.Length && (i == start || input[i] != input[i - 1]))
                        {
                            i++;
                        }

                        output.Append('0').Append(i - start);
                        output.Append(input.Substring(start, i - start));
                    }

                    int progress = (int)((double)i / input.Length * 100);
                    Invoke(new Action(() => progressBar.Value = progress));
                }

                File.WriteAllText(outputFile, output.ToString());
                Invoke(new Action(() => progressBar.Value = 100));
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
                var input = File.ReadAllText(inputFile);
                var output = new StringBuilder();

                for (int i = 0; i < input.Length;)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }

                    if (char.IsDigit(input[i]) && input[i] != '0')
                    {
                        int count = int.Parse(input[i].ToString());
                        char currentChar = input[i + 1];
                        output.Append(new string(currentChar, count));
                        i += 2;
                    }
                    else if (input[i] == '0')
                    {
                        int count = int.Parse(input[i + 1].ToString());
                        output.Append(input.Substring(i + 2, count));
                        i += 2 + count;
                    }

                    int progress = (int)((double)i / input.Length * 100);
                    Invoke(new Action(() => progressBar.Value = progress));
                }

                File.WriteAllText(outputFile, output.ToString());
                Invoke(new Action(() => progressBar.Value = 100));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}

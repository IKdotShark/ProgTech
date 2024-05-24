using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace Archiver_win
{
    public partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnInFile;
        private Button btnOutFile;
        private Button btnPack;
        private Button btnUnPack;
        private Button btnStop;
        private Button btnExit;
        private ProgressBar progressBar;

        private string inputFilePath;
        private string outputFilePath;
        private bool stopRequested = false;
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnInFile = new System.Windows.Forms.Button();
            this.btnOutFile = new System.Windows.Forms.Button();
            this.btnPack = new System.Windows.Forms.Button();
            this.btnUnPack = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();

            // btnInFile

            this.btnInFile.Location = new System.Drawing.Point(12, 12);
            this.btnInFile.Name = "btnInFile";
            this.btnInFile.Size = new System.Drawing.Size(260, 40);
            this.btnInFile.TabIndex = 0;
            this.btnInFile.Text = "In File";
            this.btnInFile.UseVisualStyleBackColor = true;
            this.btnInFile.Click += new System.EventHandler(this.btnInFile_Click);

            // btnOutFile

            this.btnOutFile.Location = new System.Drawing.Point(12, 58);
            this.btnOutFile.Name = "btnOutFile";
            this.btnOutFile.Size = new System.Drawing.Size(260, 40);
            this.btnOutFile.TabIndex = 1;
            this.btnOutFile.Text = "Out File";
            this.btnOutFile.UseVisualStyleBackColor = true;
            this.btnOutFile.Click += new System.EventHandler(this.btnOutFile_Click);
            // btnPack

            this.btnPack.Location = new System.Drawing.Point(12, 104);
            this.btnPack.Name = "btnPack";
            this.btnPack.Size = new System.Drawing.Size(260, 40);
            this.btnPack.TabIndex = 2;
            this.btnPack.Text = "Pack";
            this.btnPack.UseVisualStyleBackColor = true;
            this.btnPack.Click += new System.EventHandler(this.btnPack_Click);

            // btnUnPack
            this.btnUnPack.Location = new System.Drawing.Point(12, 150);
            this.btnUnPack.Name = "btnUnPack";
            this.btnUnPack.Size = new System.Drawing.Size(260, 40);
            this.btnUnPack.TabIndex = 3;
            this.btnUnPack.Text = "UnPack";
            this.btnUnPack.UseVisualStyleBackColor = true;
            this.btnUnPack.Click += new System.EventHandler(this.btnUnPack_Click);

            // btnStop

            this.btnStop.Location = new System.Drawing.Point(12, 196);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(260, 40);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // btnExit
            this.btnExit.Location = new System.Drawing.Point(12, 242);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(260, 40);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // progressBar

            this.progressBar.Location = new System.Drawing.Point(12, 288);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(260, 40);
            this.progressBar.TabIndex = 6;

            // Form1

            this.ClientSize = new System.Drawing.Size(284, 341);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnUnPack);
            this.Controls.Add(this.btnPack);
            this.Controls.Add(this.btnOutFile);
            this.Controls.Add(this.btnInFile);
            this.Name = "Form1";
            this.Text = "Archiver";
            this.ResumeLayout(false);
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


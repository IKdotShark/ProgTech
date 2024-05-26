using System.Windows.Forms;

namespace MyWinFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnInFile;
        private Button btnOutFile;
        private Button btnPack;
        private Button btnUnPack;
        private Button btnStop;
        private Button btnExit;
        private ProgressBar progressBar;

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
    }
}

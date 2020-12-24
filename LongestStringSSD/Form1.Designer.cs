namespace LongestStringSSD
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxFilePath = new System.Windows.Forms.GroupBox();
            this.buttonCompute = new System.Windows.Forms.Button();
            this.labelSelectFile = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.labelElapsedTime = new System.Windows.Forms.Label();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelResultDescription = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxFilePath.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilePath
            // 
            this.groupBoxFilePath.Controls.Add(this.buttonCompute);
            this.groupBoxFilePath.Controls.Add(this.labelSelectFile);
            this.groupBoxFilePath.Controls.Add(this.textBoxFilePath);
            this.groupBoxFilePath.Controls.Add(this.buttonSelectFile);
            this.groupBoxFilePath.Location = new System.Drawing.Point(12, 3);
            this.groupBoxFilePath.Name = "groupBoxFilePath";
            this.groupBoxFilePath.Size = new System.Drawing.Size(557, 122);
            this.groupBoxFilePath.TabIndex = 2;
            this.groupBoxFilePath.TabStop = false;
            this.groupBoxFilePath.Text = "File Path";
            // 
            // buttonCompute
            // 
            this.buttonCompute.Location = new System.Drawing.Point(463, 80);
            this.buttonCompute.Name = "buttonCompute";
            this.buttonCompute.Size = new System.Drawing.Size(75, 23);
            this.buttonCompute.TabIndex = 1;
            this.buttonCompute.Text = "Compute";
            this.buttonCompute.UseVisualStyleBackColor = true;
            // 
            // labelSelectFile
            // 
            this.labelSelectFile.AutoSize = true;
            this.labelSelectFile.Location = new System.Drawing.Point(16, 27);
            this.labelSelectFile.Name = "labelSelectFile";
            this.labelSelectFile.Size = new System.Drawing.Size(137, 13);
            this.labelSelectFile.TabIndex = 2;
            this.labelSelectFile.Text = "Upload file with list of words";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(19, 43);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(519, 20);
            this.textBoxFilePath.TabIndex = 1;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(373, 80);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 0;
            this.buttonSelectFile.Text = "Select File";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.labelProgress);
            this.groupBoxResult.Controls.Add(this.labelElapsedTime);
            this.groupBoxResult.Controls.Add(this.buttonClipboard);
            this.groupBoxResult.Controls.Add(this.labelResult);
            this.groupBoxResult.Controls.Add(this.labelResultDescription);
            this.groupBoxResult.Location = new System.Drawing.Point(12, 131);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(557, 313);
            this.groupBoxResult.TabIndex = 3;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(16, 280);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 13);
            this.labelProgress.TabIndex = 5;
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.AutoSize = true;
            this.labelElapsedTime.Location = new System.Drawing.Point(16, 258);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(70, 13);
            this.labelElapsedTime.TabIndex = 4;
            this.labelElapsedTime.Text = "Elapsed time:";
            this.labelElapsedTime.Visible = false;
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Image = global::LongestStringSSD.Properties.Resources.clipboard;
            this.buttonClipboard.Location = new System.Drawing.Point(504, 65);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(34, 23);
            this.buttonClipboard.TabIndex = 3;
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Visible = false;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(16, 65);
            this.labelResult.MaximumSize = new System.Drawing.Size(450, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(46, 16);
            this.labelResult.TabIndex = 2;
            this.labelResult.Text = "Result";
            this.labelResult.Visible = false;
            // 
            // labelResultDescription
            // 
            this.labelResultDescription.AutoSize = true;
            this.labelResultDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultDescription.Location = new System.Drawing.Point(16, 29);
            this.labelResultDescription.Name = "labelResultDescription";
            this.labelResultDescription.Size = new System.Drawing.Size(324, 13);
            this.labelResultDescription.TabIndex = 1;
            this.labelResultDescription.Text = "The longest word that can be shown on seven segment display is...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 450);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxFilePath);
            this.Name = "Form1";
            this.Text = "Seven Segment Display";
            this.groupBoxFilePath.ResumeLayout(false);
            this.groupBoxFilePath.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxFilePath;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.Button buttonCompute;
        private System.Windows.Forms.Label labelSelectFile;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelResultDescription;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelElapsedTime;
        private System.Windows.Forms.Label labelProgress;
    }
}


namespace ProjectXML {
    partial class XPathEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.tbExpression = new System.Windows.Forms.TextBox();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.btExecute = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "XML File Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "XPath Expression:";
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(94, 22);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(559, 20);
            this.tbPath.TabIndex = 2;
            // 
            // tbExpression
            // 
            this.tbExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExpression.Location = new System.Drawing.Point(111, 57);
            this.tbExpression.Name = "tbExpression";
            this.tbExpression.Size = new System.Drawing.Size(542, 20);
            this.tbExpression.TabIndex = 3;
            this.tbExpression.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExpression_KeyPress);
            // 
            // btSelectFile
            // 
            this.btSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectFile.Location = new System.Drawing.Point(659, 20);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btSelectFile.TabIndex = 4;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // btExecute
            // 
            this.btExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExecute.Location = new System.Drawing.Point(659, 55);
            this.btExecute.Name = "btExecute";
            this.btExecute.Size = new System.Drawing.Size(75, 23);
            this.btExecute.TabIndex = 5;
            this.btExecute.Text = "Execute";
            this.btExecute.UseVisualStyleBackColor = true;
            this.btExecute.Click += new System.EventHandler(this.btExecute_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(15, 90);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(719, 350);
            this.tbOutput.TabIndex = 6;
            this.tbOutput.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // XPathEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 452);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.btExecute);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.tbExpression);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "XPathEditor";
            this.Text = "XPathEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.TextBox tbExpression;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.Button btExecute;
        private System.Windows.Forms.RichTextBox tbOutput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
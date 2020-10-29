namespace ficha5_ClientBookstore {
    partial class Form1 {
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
            this.btGetBooks = new System.Windows.Forms.Button();
            this.lbBooks = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFilterTtitle = new System.Windows.Forms.TextBox();
            this.btFilterCategory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btFilterTitle = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.tbInfoTitle = new System.Windows.Forms.TextBox();
            this.tbInfoAuthor = new System.Windows.Forms.TextBox();
            this.tbInfoYear = new System.Windows.Forms.TextBox();
            this.tbInfoPrice = new System.Windows.Forms.TextBox();
            this.cbFilterCategory = new System.Windows.Forms.ComboBox();
            this.cbInfoCategory = new System.Windows.Forms.ComboBox();
            this.btAddBook = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGetBooks
            // 
            this.btGetBooks.Location = new System.Drawing.Point(12, 12);
            this.btGetBooks.Name = "btGetBooks";
            this.btGetBooks.Size = new System.Drawing.Size(100, 23);
            this.btGetBooks.TabIndex = 0;
            this.btGetBooks.Text = "Get Books";
            this.btGetBooks.UseVisualStyleBackColor = true;
            this.btGetBooks.Click += new System.EventHandler(this.btGetBooks_Click);
            // 
            // lbBooks
            // 
            this.lbBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.ItemHeight = 16;
            this.lbBooks.Location = new System.Drawing.Point(12, 41);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(363, 132);
            this.lbBooks.TabIndex = 1;
            this.lbBooks.SelectedIndexChanged += new System.EventHandler(this.lbBooks_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbFilterCategory);
            this.groupBox1.Controls.Add(this.btFilterCategory);
            this.groupBox1.Controls.Add(this.tbFilterTtitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btFilterTitle);
            this.groupBox1.Location = new System.Drawing.Point(381, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 161);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title:";
            // 
            // tbFilterTtitle
            // 
            this.tbFilterTtitle.Location = new System.Drawing.Point(14, 116);
            this.tbFilterTtitle.Name = "tbFilterTtitle";
            this.tbFilterTtitle.Size = new System.Drawing.Size(336, 22);
            this.tbFilterTtitle.TabIndex = 2;
            // 
            // btFilterCategory
            // 
            this.btFilterCategory.Location = new System.Drawing.Point(275, 22);
            this.btFilterCategory.Name = "btFilterCategory";
            this.btFilterCategory.Size = new System.Drawing.Size(75, 23);
            this.btFilterCategory.TabIndex = 3;
            this.btFilterCategory.Text = "Filter";
            this.btFilterCategory.UseVisualStyleBackColor = true;
            this.btFilterCategory.Click += new System.EventHandler(this.btFilterCategory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btAddBook);
            this.groupBox2.Controls.Add(this.cbInfoCategory);
            this.groupBox2.Controls.Add(this.tbInfoPrice);
            this.groupBox2.Controls.Add(this.tbInfoYear);
            this.groupBox2.Controls.Add(this.tbInfoAuthor);
            this.groupBox2.Controls.Add(this.tbInfoTitle);
            this.groupBox2.Controls.Add(this.btDelete);
            this.groupBox2.Controls.Add(this.btClear);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(725, 112);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Book info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Title:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Author:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Year:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Price:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Category:";
            // 
            // btFilterTitle
            // 
            this.btFilterTitle.Location = new System.Drawing.Point(275, 89);
            this.btFilterTitle.Name = "btFilterTitle";
            this.btFilterTitle.Size = new System.Drawing.Size(75, 23);
            this.btFilterTitle.TabIndex = 6;
            this.btFilterTitle.Text = "Filter";
            this.btFilterTitle.UseVisualStyleBackColor = true;
            this.btFilterTitle.Click += new System.EventHandler(this.btFilterTitle_Click);
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(622, 21);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(97, 23);
            this.btClear.TabIndex = 7;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(622, 50);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(97, 23);
            this.btDelete.TabIndex = 8;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // tbInfoTitle
            // 
            this.tbInfoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfoTitle.Location = new System.Drawing.Point(57, 22);
            this.tbInfoTitle.Name = "tbInfoTitle";
            this.tbInfoTitle.Size = new System.Drawing.Size(559, 22);
            this.tbInfoTitle.TabIndex = 9;
            // 
            // tbInfoAuthor
            // 
            this.tbInfoAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfoAuthor.Location = new System.Drawing.Point(69, 50);
            this.tbInfoAuthor.Name = "tbInfoAuthor";
            this.tbInfoAuthor.Size = new System.Drawing.Size(547, 22);
            this.tbInfoAuthor.TabIndex = 10;
            // 
            // tbInfoYear
            // 
            this.tbInfoYear.Location = new System.Drawing.Point(60, 78);
            this.tbInfoYear.Name = "tbInfoYear";
            this.tbInfoYear.Size = new System.Drawing.Size(100, 22);
            this.tbInfoYear.TabIndex = 11;
            // 
            // tbInfoPrice
            // 
            this.tbInfoPrice.Location = new System.Drawing.Point(214, 78);
            this.tbInfoPrice.Name = "tbInfoPrice";
            this.tbInfoPrice.Size = new System.Drawing.Size(100, 22);
            this.tbInfoPrice.TabIndex = 12;
            // 
            // cbFilterCategory
            // 
            this.cbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterCategory.FormattingEnabled = true;
            this.cbFilterCategory.Location = new System.Drawing.Point(14, 48);
            this.cbFilterCategory.Name = "cbFilterCategory";
            this.cbFilterCategory.Size = new System.Drawing.Size(336, 24);
            this.cbFilterCategory.TabIndex = 4;
            // 
            // cbInfoCategory
            // 
            this.cbInfoCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInfoCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInfoCategory.FormattingEnabled = true;
            this.cbInfoCategory.Location = new System.Drawing.Point(392, 78);
            this.cbInfoCategory.Name = "cbInfoCategory";
            this.cbInfoCategory.Size = new System.Drawing.Size(224, 24);
            this.cbInfoCategory.TabIndex = 13;
            // 
            // btAddBook
            // 
            this.btAddBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddBook.Location = new System.Drawing.Point(622, 77);
            this.btAddBook.Name = "btAddBook";
            this.btAddBook.Size = new System.Drawing.Size(97, 23);
            this.btAddBook.TabIndex = 14;
            this.btAddBook.Text = "Add Book";
            this.btAddBook.UseVisualStyleBackColor = true;
            this.btAddBook.Click += new System.EventHandler(this.btAddBook_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 304);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbBooks);
            this.Controls.Add(this.btGetBooks);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Bookstore Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btGetBooks;
        private System.Windows.Forms.ListBox lbBooks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbFilterCategory;
        private System.Windows.Forms.Button btFilterCategory;
        private System.Windows.Forms.TextBox tbFilterTtitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFilterTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btAddBook;
        private System.Windows.Forms.ComboBox cbInfoCategory;
        private System.Windows.Forms.TextBox tbInfoPrice;
        private System.Windows.Forms.TextBox tbInfoYear;
        private System.Windows.Forms.TextBox tbInfoAuthor;
        private System.Windows.Forms.TextBox tbInfoTitle;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}


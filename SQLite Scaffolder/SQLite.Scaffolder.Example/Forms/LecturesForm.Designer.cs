namespace SQLite.Scaffolder.Example.Forms
{
    partial class LecturesForm
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
            this.ListboxLectures = new System.Windows.Forms.ListBox();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextboxName = new System.Windows.Forms.TextBox();
            this.TextboxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PictureboxLectureImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureboxLectureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ListboxLectures
            // 
            this.ListboxLectures.FormattingEnabled = true;
            this.ListboxLectures.Location = new System.Drawing.Point(12, 12);
            this.ListboxLectures.Name = "ListboxLectures";
            this.ListboxLectures.Size = new System.Drawing.Size(155, 212);
            this.ListboxLectures.TabIndex = 0;
            this.ListboxLectures.SelectedIndexChanged += new System.EventHandler(this.OnLectureChanged);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(164, 230);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(108, 23);
            this.ButtonDelete.TabIndex = 1;
            this.ButtonDelete.Text = "Delete lecture";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // textBox1
            // 
            this.TextboxName.Location = new System.Drawing.Point(173, 28);
            this.TextboxName.Name = "textBox1";
            this.TextboxName.Size = new System.Drawing.Size(156, 20);
            this.TextboxName.TabIndex = 3;
            // 
            // textBox2
            // 
            this.TextboxDescription.Location = new System.Drawing.Point(172, 67);
            this.TextboxDescription.Name = "textBox2";
            this.TextboxDescription.Size = new System.Drawing.Size(157, 20);
            this.TextboxDescription.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Image";
            // 
            // pictureBox1
            // 
            this.PictureboxLectureImage.Location = new System.Drawing.Point(173, 106);
            this.PictureboxLectureImage.Name = "pictureBox1";
            this.PictureboxLectureImage.Size = new System.Drawing.Size(156, 118);
            this.PictureboxLectureImage.TabIndex = 7;
            this.PictureboxLectureImage.TabStop = false;
            // 
            // LecturesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 262);
            this.Controls.Add(this.PictureboxLectureImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextboxDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextboxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ListboxLectures);
            this.Name = "LecturesForm";
            this.Text = "LecturesForm";
            ((System.ComponentModel.ISupportInitialize)(this.PictureboxLectureImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListboxLectures;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextboxName;
        private System.Windows.Forms.TextBox TextboxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PictureboxLectureImage;
    }
}
namespace SQLite.Scaffolder.Example.Forms
{
    partial class InsertLecture
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
            this.TextboxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextboxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PictureBoxLectureImage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonSelectPicture = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLectureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TextboxName
            // 
            this.TextboxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxName.Location = new System.Drawing.Point(11, 25);
            this.TextboxName.Name = "TextboxName";
            this.TextboxName.Size = new System.Drawing.Size(260, 20);
            this.TextboxName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name:";
            // 
            // TextboxDescription
            // 
            this.TextboxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxDescription.Location = new System.Drawing.Point(11, 64);
            this.TextboxDescription.Name = "TextboxDescription";
            this.TextboxDescription.Size = new System.Drawing.Size(260, 20);
            this.TextboxDescription.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Description:";
            // 
            // PictureBoxLectureImage
            // 
            this.PictureBoxLectureImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBoxLectureImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBoxLectureImage.Location = new System.Drawing.Point(15, 103);
            this.PictureBoxLectureImage.Name = "PictureBoxLectureImage";
            this.PictureBoxLectureImage.Size = new System.Drawing.Size(175, 147);
            this.PictureBoxLectureImage.TabIndex = 17;
            this.PictureBoxLectureImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Picture:";
            // 
            // ButtonSelectPicture
            // 
            this.ButtonSelectPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelectPicture.Location = new System.Drawing.Point(196, 103);
            this.ButtonSelectPicture.Name = "ButtonSelectPicture";
            this.ButtonSelectPicture.Size = new System.Drawing.Size(75, 147);
            this.ButtonSelectPicture.TabIndex = 19;
            this.ButtonSelectPicture.Text = "Select picture";
            this.ButtonSelectPicture.UseVisualStyleBackColor = true;
            this.ButtonSelectPicture.Click += new System.EventHandler(this.ButtonSelectPicture_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.Location = new System.Drawing.Point(196, 285);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 20;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // InsertLecture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 320);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonSelectPicture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PictureBoxLectureImage);
            this.Controls.Add(this.TextboxDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextboxName);
            this.Controls.Add(this.label1);
            this.Name = "InsertLecture";
            this.Text = "InsertLecture";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLectureImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextboxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextboxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PictureBoxLectureImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonSelectPicture;
        private System.Windows.Forms.Button ButtonSave;
    }
}
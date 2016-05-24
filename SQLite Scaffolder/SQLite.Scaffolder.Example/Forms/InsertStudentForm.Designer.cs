namespace SQLite.Scaffolder.Example.Forms
{
    partial class InsertStudentForm
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
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonEditLectures = new System.Windows.Forms.Button();
            this.ListboxLectures = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.TextboxLastname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextboxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(196, 384);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 19;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonEditLectures
            // 
            this.ButtonEditLectures.Location = new System.Drawing.Point(10, 137);
            this.ButtonEditLectures.Name = "ButtonEditLectures";
            this.ButtonEditLectures.Size = new System.Drawing.Size(263, 23);
            this.ButtonEditLectures.TabIndex = 18;
            this.ButtonEditLectures.Text = "Edit students lectures";
            this.ButtonEditLectures.UseVisualStyleBackColor = true;
            this.ButtonEditLectures.Click += new System.EventHandler(this.ButtonEditLectures_Click);
            // 
            // ListboxLectures
            // 
            this.ListboxLectures.FormattingEnabled = true;
            this.ListboxLectures.Location = new System.Drawing.Point(10, 166);
            this.ListboxLectures.Name = "ListboxLectures";
            this.ListboxLectures.Size = new System.Drawing.Size(263, 212);
            this.ListboxLectures.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Birthday:";
            // 
            // DateTimePickerBirthday
            // 
            this.DateTimePickerBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePickerBirthday.Location = new System.Drawing.Point(11, 103);
            this.DateTimePickerBirthday.Name = "DateTimePickerBirthday";
            this.DateTimePickerBirthday.Size = new System.Drawing.Size(263, 20);
            this.DateTimePickerBirthday.TabIndex = 15;
            // 
            // TextboxLastname
            // 
            this.TextboxLastname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxLastname.Location = new System.Drawing.Point(11, 64);
            this.TextboxLastname.Name = "TextboxLastname";
            this.TextboxLastname.Size = new System.Drawing.Size(260, 20);
            this.TextboxLastname.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Lastname:";
            // 
            // TextboxName
            // 
            this.TextboxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxName.Location = new System.Drawing.Point(11, 25);
            this.TextboxName.Name = "TextboxName";
            this.TextboxName.Size = new System.Drawing.Size(260, 20);
            this.TextboxName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name:";
            // 
            // InsertStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 413);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonEditLectures);
            this.Controls.Add(this.ListboxLectures);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateTimePickerBirthday);
            this.Controls.Add(this.TextboxLastname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextboxName);
            this.Controls.Add(this.label1);
            this.Name = "InsertStudentForm";
            this.Text = "New student";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonEditLectures;
        private System.Windows.Forms.ListBox ListboxLectures;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DateTimePickerBirthday;
        private System.Windows.Forms.TextBox TextboxLastname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextboxName;
        private System.Windows.Forms.Label label1;
    }
}
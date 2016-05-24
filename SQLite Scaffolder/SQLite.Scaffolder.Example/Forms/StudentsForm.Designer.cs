namespace SQLite.Scaffolder.Example.Forms
{
    partial class StudentsForm
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
            this.ListboxStudents = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextboxName = new System.Windows.Forms.TextBox();
            this.TextboxLastname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ListboxLectures = new System.Windows.Forms.ListBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListboxStudents
            // 
            this.ListboxStudents.FormattingEnabled = true;
            this.ListboxStudents.Location = new System.Drawing.Point(12, 15);
            this.ListboxStudents.Name = "ListboxStudents";
            this.ListboxStudents.Size = new System.Drawing.Size(213, 368);
            this.ListboxStudents.TabIndex = 0;
            this.ListboxStudents.SelectedIndexChanged += new System.EventHandler(this.OnStudentSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // TextboxName
            // 
            this.TextboxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxName.Location = new System.Drawing.Point(231, 31);
            this.TextboxName.Name = "TextboxName";
            this.TextboxName.ReadOnly = true;
            this.TextboxName.Size = new System.Drawing.Size(197, 20);
            this.TextboxName.TabIndex = 2;
            // 
            // TextboxLastname
            // 
            this.TextboxLastname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxLastname.Location = new System.Drawing.Point(231, 70);
            this.TextboxLastname.Name = "TextboxLastname";
            this.TextboxLastname.ReadOnly = true;
            this.TextboxLastname.Size = new System.Drawing.Size(197, 20);
            this.TextboxLastname.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lastname:";
            // 
            // DateTimePickerBirthday
            // 
            this.DateTimePickerBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePickerBirthday.Enabled = false;
            this.DateTimePickerBirthday.Location = new System.Drawing.Point(231, 109);
            this.DateTimePickerBirthday.Name = "DateTimePickerBirthday";
            this.DateTimePickerBirthday.Size = new System.Drawing.Size(200, 20);
            this.DateTimePickerBirthday.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Birthday:";
            // 
            // ListboxLectures
            // 
            this.ListboxLectures.FormattingEnabled = true;
            this.ListboxLectures.Location = new System.Drawing.Point(231, 159);
            this.ListboxLectures.Name = "ListboxLectures";
            this.ListboxLectures.Size = new System.Drawing.Size(200, 225);
            this.ListboxLectures.TabIndex = 8;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(356, 390);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 10;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Lectures:";
            // 
            // StudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 421);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ListboxLectures);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateTimePickerBirthday);
            this.Controls.Add(this.TextboxLastname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextboxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListboxStudents);
            this.Name = "StudentsForm";
            this.Text = "StudentsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListboxStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextboxName;
        private System.Windows.Forms.TextBox TextboxLastname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DateTimePickerBirthday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListboxLectures;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label label4;
    }
}
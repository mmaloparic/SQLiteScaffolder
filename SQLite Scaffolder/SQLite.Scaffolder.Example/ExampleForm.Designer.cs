namespace SQLite.Scaffolder.Example
{
    partial class ExampleForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolstripStudents = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolstripAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolstripLectures = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolstripInsertLecture = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolstripStudents,
            this.ToolstripLectures});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // ToolstripStudents
            // 
            this.ToolstripStudents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolstripAddStudent});
            this.ToolstripStudents.Name = "ToolstripStudents";
            this.ToolstripStudents.Size = new System.Drawing.Size(152, 22);
            this.ToolstripStudents.Text = "Students";
            this.ToolstripStudents.Click += new System.EventHandler(this.ToolstripStudents_Click);
            // 
            // ToolstripAddStudent
            // 
            this.ToolstripAddStudent.Name = "ToolstripAddStudent";
            this.ToolstripAddStudent.Size = new System.Drawing.Size(152, 22);
            this.ToolstripAddStudent.Text = "Add new";
            this.ToolstripAddStudent.Click += new System.EventHandler(this.ToolstripAddStudent_Click);
            // 
            // ToolstripLectures
            // 
            this.ToolstripLectures.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolstripInsertLecture});
            this.ToolstripLectures.Name = "ToolstripLectures";
            this.ToolstripLectures.Size = new System.Drawing.Size(152, 22);
            this.ToolstripLectures.Text = "Lectures";
            this.ToolstripLectures.Click += new System.EventHandler(this.ToolstripLectures_Click);
            // 
            // ToolstripInsertLecture
            // 
            this.ToolstripInsertLecture.Name = "ToolstripInsertLecture";
            this.ToolstripInsertLecture.Size = new System.Drawing.Size(121, 22);
            this.ToolstripInsertLecture.Text = "Add new";
            this.ToolstripInsertLecture.Click += new System.EventHandler(this.ToolstripInsertLecture_Click);
            // 
            // ExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 467);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ExampleForm";
            this.Text = "Example";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolstripStudents;
        private System.Windows.Forms.ToolStripMenuItem ToolstripLectures;
        private System.Windows.Forms.ToolStripMenuItem ToolstripAddStudent;
        private System.Windows.Forms.ToolStripMenuItem ToolstripInsertLecture;
    }
}
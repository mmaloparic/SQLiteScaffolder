namespace SQLite.Scaffolder.Example.Forms
{
    partial class LecturesSelector
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
            this.CheckedListBoxLectures = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // CheckedListBoxLectures
            // 
            this.CheckedListBoxLectures.CheckOnClick = true;
            this.CheckedListBoxLectures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckedListBoxLectures.FormattingEnabled = true;
            this.CheckedListBoxLectures.Location = new System.Drawing.Point(0, 0);
            this.CheckedListBoxLectures.Name = "CheckedListBoxLectures";
            this.CheckedListBoxLectures.Size = new System.Drawing.Size(284, 262);
            this.CheckedListBoxLectures.TabIndex = 0;
            // 
            // LecturesSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.CheckedListBoxLectures);
            this.Name = "LecturesSelector";
            this.Text = "Lectures";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LecturesSelector_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CheckedListBoxLectures;
    }
}
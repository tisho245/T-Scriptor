using System.Drawing;
using System;
using System.Windows.Forms;

namespace T_Scriptor
{
    partial class FindForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxFind;
        private Button buttonFind;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(60, 12);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(200, 22);
            this.textBoxFind.TabIndex = 1;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(180, 45);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 2;
            this.buttonFind.Text = "Find";
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find:";
            // 
            // FindForm
            // 
            this.ClientSize = new System.Drawing.Size(280, 80);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.buttonFind);
            this.Name = "FindForm";
            this.Text = "Find";
            this.Load += new System.EventHandler(this.FindForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

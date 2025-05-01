using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_Scriptor
{
    public partial class FormReplace : Form
    {

        private TextBox txtFind;
        private TextBox txtReplace;
        private Label lblFind;
        private Label lblReplace;
        private Button btnOK;
        private Button btnCancel;

        public string FindText => txtFind.Text;
        public string ReplaceText => txtReplace.Text;

        public FormReplace(bool showReplace)
        {
            InitializeComponent();

            lblReplace.Visible = txtReplace.Visible = showReplace;
            if (!showReplace)
                this.Height -= 40;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFind.Text))
            {
                MessageBox.Show("Please enter text to find.");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void InitializeComponent()
        {
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.lblReplace = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(80, 12);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(200, 22);
            this.txtFind.TabIndex = 0;
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(80, 42);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(200, 22);
            this.txtReplace.TabIndex = 1;
            // 
            // lblFind
            // 
            this.lblFind.Location = new System.Drawing.Point(12, 15);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(60, 20);
            this.lblFind.TabIndex = 2;
            this.lblFind.Text = "Find:";
            // 
            // lblReplace
            // 
            this.lblReplace.Location = new System.Drawing.Point(12, 45);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(60, 20);
            this.lblReplace.TabIndex = 3;
            this.lblReplace.Text = "Replace:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(80, 75);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(160, 75);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormReplace
            // 
            this.ClientSize = new System.Drawing.Size(300, 110);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find and Replace";
            this.Load += new System.EventHandler(this.FormReplace_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FormReplace_Load(object sender, EventArgs e)
        {

        }
    }
}

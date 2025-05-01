using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_Scriptor
{
    public partial class Form1 : Form
    {
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private string currentFilePath = null;
        private string FileSaved;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            toolStripStatusLabel1.ForeColor = Color.Blue;
            toolStripStatusLabel2.ForeColor = Color.Red;
            toolStripStatusLabel3.ForeColor = Color.Blue;
          
            timer2.Interval = 1000;
            timer2.Tick += timer1_Tick;
            timer2.Start();

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDLG.Filter = "All Files (*.*)|*.*";
            if (openFileDLG.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileText = File.ReadAllText(openFileDLG.FileName);
                    richTextBox1.Text = fileText;
                    currentFilePath = openFileDLG.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}", "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            FileSaved = richTextBox1.Text;

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                try
                {
                    File.WriteAllText(currentFilePath, richTextBox1.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            FileSaved = richTextBox1.Text;
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDLG.Filter = "Rich Text Format Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|Word Files (*.doc)|*.doc|Word Files (*.docx)|*.docx|HTML Files(*.html)|*.html|JavaScript Files(*.js)|*.js|" +
                "CSS Files(*.css)|*.css|C++ Files(*.cpp)|*.cpp|Python Files(*.py)|*.py|SQL Files(*.sql)|*.sql|" +
                "C# Files(*.cs)|*.cs|Visual Basic Files(*.vba)|*.vba|Java Files(*.jar)|*.jar|PHP Files(*.php)|*.php|" +
                "Batch Files(*.bat)|*.bat|Info Files(*.md)|*.md|Bash scripts (*.sh)|*.sh|Subtitle Files (*.srt)|*.srt|All Files (*.*)|*.*";

            if (saveFileDLG.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDLG.FileName, richTextBox1.Text);
                    currentFilePath = saveFileDLG.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            FileSaved = richTextBox1.Text;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            printDocument1.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, ev.MarginBounds.Left, ev.MarginBounds.Top);

            };



            if (printDLG.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument1.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error printing: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, ev.MarginBounds.Left, ev.MarginBounds.Top);
            };

            printPreviewDLG.Document = printDocument1;
            printPreviewDLG.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.Paste();

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void replaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var replaceForm = new FormReplace(true))
            {
                if (replaceForm.ShowDialog() == DialogResult.OK)
                {
                    string searchText = replaceForm.FindText;
                    string replaceText = replaceForm.ReplaceText;

                    int index = 0;
                    bool replaced = false;

                    // Loop through the entire text to find and replace all occurrences
                    while ((index = richTextBox1.Find(searchText, index, RichTextBoxFinds.None)) != -1)
                    {
                        // Select the found text
                        richTextBox1.Select(index, searchText.Length);

                        // Replace the selected text with the replacement text
                        richTextBox1.SelectedText = replaceText;

                        // Update the index to continue searching after the replacement
                        index += replaceText.Length;

                        replaced = true;
                    }

                    if (!replaced)
                    {
                        MessageBox.Show("Text not found.", "Replace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Color color = richTextBox1.BackColor;
            FindForm findForm = new FindForm(richTextBox1);
            findForm.ShowDialog();
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = color;
            richTextBox1.DeselectAll();

        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (fontDLG.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDLG.Font;
                richTextBox1.SelectionColor = fontDLG.Color;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDLG.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDLG.Color;
            }

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {


        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int wordCount = richTextBox1.Text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int lineCount = richTextBox1.Lines.Length;
            int charCount = richTextBox1.Text.Replace("\r", "").Replace("\n", "").Length;
            toolStripStatusLabel1.Text = $"Symbols: {charCount} | Words: {wordCount} | Lines: {lineCount}";
                        
            string fileStatus;
            if (string.IsNullOrEmpty(currentFilePath))
            {
                fileStatus = "No file saved.";
            }
            else
            {
                fileStatus = $"File: {Path.GetFileName(currentFilePath)}";
            }
            if (FileSaved!=richTextBox1.Text)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
            else 
            {
                toolStripStatusLabel2.ForeColor = Color.Green;
            }
            toolStripStatusLabel2.Text = fileStatus;
            toolStripStatusLabel3.Text = DateTime.Now.ToString("HH:mm:ss");
            var currentProcess = Process.GetCurrentProcess();
            var ramUsed = currentProcess.WorkingSet64 / (1024 * 1024);
            toolStripStatusLabel4.Text = $"RAM: {ramUsed} MB";
            


        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            float cpuUsage = (float)cpuCounter.NextValue();
            toolStripStatusLabel5.Text = $"CPU: {cpuUsage:f1}%";
        }
    }
}

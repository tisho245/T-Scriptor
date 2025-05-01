using System;
using System.Drawing;
using System.Windows.Forms;

namespace T_Scriptor
{

    public partial class FindForm : Form
    {
        private RichTextBox _richTextBox;
        private int _lastSearchIndex = 0;

        public FindForm(RichTextBox rtb)
        {
            InitializeComponent();
            _richTextBox = rtb;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string search = textBoxFind.Text;

            if (string.IsNullOrEmpty(search)) return;

            // Премахваме предишните оцветявания
            _richTextBox.SelectionBackColor = _richTextBox.BackColor; // Възстановяваме нормалния фон

            // Намираме и боядисваме текста
            int index = _richTextBox.Find(search, _lastSearchIndex, RichTextBoxFinds.None);

            if (index >= 0)
            {
                // Оцветяваме текста с избран цвят
                _richTextBox.SelectionBackColor = Color.Yellow;

                // Преместваме последната позиция за търсене
                _lastSearchIndex = index + search.Length;
                _richTextBox.ScrollToCaret(); // Скролваме до намереното място
            }
            else
            {
                MessageBox.Show("Текстът не беше намерен.", "Няма намерен текст", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _lastSearchIndex = 0;
            }
        }


        private void FindForm_Load(object sender, EventArgs e)
        {

        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XMLandDTD
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            if (File.Exists("main.dtd"))
            {
                richTextBox1.LoadFile("main.dtd", RichTextBoxStreamType.PlainText);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile("main.dtd", RichTextBoxStreamType.PlainText);
        }
    }
}

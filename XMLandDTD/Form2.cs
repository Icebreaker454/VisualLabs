using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace XMLandDTD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (File.Exists("main.xml"))
            {
                richTextBox1.LoadFile("main.xml", RichTextBoxStreamType.PlainText);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile("main.xml", RichTextBoxStreamType.PlainText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlTextReader r = new XmlTextReader("main.xml");
            XmlValidatingReader v = new XmlValidatingReader(r);
            v.ValidationType = ValidationType.DTD;
            v.XmlResolver = new XmlUrlResolver();

            try
            {
                while (v.Read())
                {

                }
                v.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to Validate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}

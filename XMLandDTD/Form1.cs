using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLandDTD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var XMLEditForm = new Form2();
            XMLEditForm.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var DTDEditForm = new Form3();
            DTDEditForm.ShowDialog(this);
        }
    }
}

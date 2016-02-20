using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Calc
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            resultTextBox.Enabled = false;
        }

        private Control _focusedControl;

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            _focusedControl = (Control)sender;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IEnumerable<Control> numpad = new Control[11] {
                num0, num1, num2, num3, num4, num5, num6, num7, num8, num9, numPoint
            };
            foreach(var ctl in numpad) {
                ctl.Click += InputClick;
            }
            foreach (var c in GetAll(this, typeof(MetroTextBox)))
            {
                c.GotFocus += TextBox_GotFocus;
                c.KeyPress += numberValidation;
            }
        }

        private void InputClick(object sender, EventArgs e)
        {
            if (_focusedControl != null)
            {
                _focusedControl.Text += ((Control)sender).Text;                
            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach (var c in GetAll(this, typeof(MetroTextBox)))
            {
                c.Text = "";
            }
        }

        private void numberValidation(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            var textBox = sender as MetroTextBox;
            if (textBox != null && ((e.KeyChar == ',') && (textBox.Text.IndexOf(',') > -1)))
            {
                e.Handled = true;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var result = Result(shapeSelect.SelectedTab.Text);
            var s = result.ToString();
            resultTextBox.Text = s;
        }

        public double Result(string tabName)
        {
            try
            {
                switch (tabName)
                {
                    case "Any": return AnyArea.Area(
                            double.Parse(metroTextBox1.Text),
                            double.Parse(metroTextBox2.Text), 
                            int.Parse(metroTextBox3.Text)
                        );
                    case "Square": return RectangleArea.Area(
                            double.Parse(sqSideTextBox.Text),
                            double.Parse(sqSideTextBox.Text)
                        );
                    case "Rectangle": return RectangleArea.Area(
                            double.Parse(rctSideATextBox.Text),
                            double.Parse(rctSideBTextBox.Text)
                        );
                    case "Paralellogram": return paralSAARadio.Checked ? 
                            ParalellogramArea.Area(
                                double.Parse(paralSideATextBox.Text),
                                double.Parse(paralSideBTextBox.Text),
                                int.Parse(paralAngleTextBox.Text)
                            ) : ParalellogramArea.Area(
                                double.Parse(paralSideTextBox.Text),
                                double.Parse(paralHeightTextBox.Text)
                            );
                    case "Rhomb": return RhombArea.Area(
                            double.Parse(rhmbD1TextBox.Text),
                            double.Parse(rhmbD2TextBox.Text)
                        );
                    case "Trapeze": return TrapezeArea.Area(
                        double.Parse(tzFirstBasisTextBox.Text),
                        double.Parse(tzSecondBasisTextBox.Text),
                        double.Parse(tzHeightTextBox.Text)
                    );
                    default: return 0.0;
                }
            }
            catch
            {
                // Raise Validation Errors ?
                return 0.0;
            };
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }
}

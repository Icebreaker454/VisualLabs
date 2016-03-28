using System.Windows.Forms;


namespace FunctionPlotterDataGrid
{
    internal static class Validators
    {
        public static void DoubleInputValidator(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            var textBox = sender as TextBox;
            if (textBox != null && ((e.KeyChar == ',') && (textBox.Text.IndexOf(',') > -1)))
            {
                e.Handled = true;
            }
            if (textBox != null && ((e.KeyChar == '-') && (textBox.Text != "")))
            {
                e.Handled = true;
            }
        }

        public static void IntInputValidator(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

using System.Linq;
using System.Windows.Forms;

namespace Nhtid.WinForms.Controls
{
    public static class ControlExtensions
    {
        public static void EnsureRadioGroupChecked(this Control.ControlCollection controls)
        {
            var radioButtons = controls.OfType<RadioButton>().ToArray();
            if (radioButtons.All(r => !r.Checked))
                radioButtons.First(r => r.Enabled).Checked = true;
            else if (radioButtons.Single(r => r.Checked).Enabled == false)
                radioButtons.First(r => r.Enabled).Checked = true;

        }
    }
}
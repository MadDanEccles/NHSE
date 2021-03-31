using System;
using System.Windows.Forms;

namespace NHSE.WinForms.Zebra.Controls
{
    class CheckedListBoxEx : CheckedListBox
    {
        private string searchString = "";
        private Timer timer;

        public CheckedListBoxEx()
        {
            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick += timer_Tick;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                timer.Dispose();
            
            base.Dispose(disposing);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            searchString = "";
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Add || e.KeyData == Keys.Oemplus)
            {
                var selectedIndex = SelectedIndex;
                if (selectedIndex >= 0)
                {
                    bool isChecked = GetItemChecked(selectedIndex);
                    SetItemChecked(selectedIndex, !isChecked);
                }

                e.SuppressKeyPress = true;
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                timer.Stop();
                timer.Start();
                searchString += e.KeyChar;

                var index = FindString(searchString);

                if (index >= 0)
                {
                    ClearSelected();
                    SelectedIndex = index;
                }
            }
            else
            {
                base.OnKeyPress(e);
                searchString = "";
            }
        }
    }

    class ListBoxEx : ListBox
    {
        private string searchString = "";
        private Timer timer;

        public ListBoxEx()
        {
            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick += timer_Tick;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                timer.Dispose();

            base.Dispose(disposing);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            searchString = "";
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                timer.Stop();
                timer.Start();
                searchString += e.KeyChar;

                var index = FindString(searchString);

                if (index >= 0)
                {
                    ClearSelected();
                    SelectedIndex = index;
                }
            }
            else
            {
                base.OnKeyPress(e);
                searchString = "";
            }
        }
    }
}
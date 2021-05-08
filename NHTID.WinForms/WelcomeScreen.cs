using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace Nhtid.WinForms
{
    public partial class WelcomeScreen : UserControl
    {
        private RecentFilesManager recentFileManager;
        private IDocumentContainer documentContainer;
        private Font titleFont;

        public WelcomeScreen()
        {
            InitializeComponent();

            this.titleFont = new Font(lbRecent.Font, FontStyle.Bold);
        }

        public void AutoWire(RecentFilesManager recentFilesManager, IDocumentContainer documentContainer)
        {
            this.documentContainer = documentContainer;
            this.recentFileManager = recentFilesManager;
            this.recentFileRecordBindingSource.DataSource = this.recentFileManager.RecentFiles;
            lbRecent.SelectedIndex = -1;
        }
        
        private void OpenProjectClick(object sender, EventArgs e)
        {
            documentContainer.ShowOpenDocumentUi();
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            documentContainer.ShowNewDocumentUi();
        }

        private void lbRecent_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight =
                (int)(e.Graphics.MeasureString("abc", titleFont).Height +
                e.Graphics.MeasureString("abc", lbRecent.Font).Height) + 6;
        }

        private void lbRecent_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            using Brush b = new SolidBrush(e.ForeColor);
            RecentFileRecord record = (RecentFileRecord)recentFileRecordBindingSource[e.Index];
            SizeF titleSize = e.Graphics.MeasureString(record.Title, titleFont);
            e.Graphics.DrawString(record.Title, titleFont, b, e.Bounds.X, e.Bounds.Y + 3);
            e.Graphics.DrawString(record.FileName, lbRecent.Font, b, e.Bounds.X, e.Bounds.Y + titleSize.Height + 3);
        }

        

        private void lbRecent_MouseMove(object sender, MouseEventArgs e)
        {
            if (lbRecent.IndexFromPoint(e.Location) < 0)
                lbRecent.Cursor = Cursors.Default;
            else
                lbRecent.Cursor = Cursors.Hand;
        }

        private void lbRecent_MouseClick(object sender, MouseEventArgs e)
        {
            var index = lbRecent.IndexFromPoint(e.Location);
            if (index >= 0)
            {
                var recentFile = (RecentFileRecord)recentFileRecordBindingSource[index];
                documentContainer.OpenFile(recentFile.FileName);
            }
        }
    }
}

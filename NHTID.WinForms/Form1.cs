using System;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace Nhtid.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenProjectClick(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            if (selectSaveGameDialog.ShowDialog(this) == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(selectSaveGameDialog.FileName);
                HorizonSave save = new HorizonSave(folderPath);
                /*var prompt = MessageBox.Show(this, MessageStrings.MsgSaveDataSizeMismatch + "\r\n\r\n" +  MessageStrings.MsgAskContinue, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (prompt != DialogResult.Yes)
                    return;*/
                this.Close();

            }
        }
    }
}

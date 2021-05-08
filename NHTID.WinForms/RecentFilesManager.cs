using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Nhtid.WinForms.Documents;

namespace Nhtid.WinForms
{
    public class RecentFilesManager
    {
        public BindingList<RecentFileRecord> RecentFiles { get; } = new BindingList<RecentFileRecord>();

        private static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "recentfiles.json");

        public RecentFilesManager()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    string recentFilesJson = File.ReadAllText(FilePath);
                    var recentFileRecords = JsonConvert.DeserializeObject<RecentFileRecord[]>(recentFilesJson);
                    foreach (var record in recentFileRecords)
                        RecentFiles.Add(record);
                }
                catch
                {
                    // Do nothing...
                }
            }
        }

        public void AddRecentFile(Document document)
        {
            var fileName = document.OriginalFileName;
            int index = RecentFiles.IndexOfFirst(i => i.FileName.Equals(fileName, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                RecentFiles.RemoveAt(index);
            }

            var record = new RecentFileRecord
            {
                FileName = fileName,
                Title = document.Title,
                LastAccessed = DateTime.Now
            };

            if (RecentFiles.Count == 0)
                RecentFiles.Add(record);
            else
                RecentFiles.Insert(0, record);

            string json = JsonConvert.SerializeObject(RecentFiles.ToArray());
            File.WriteAllText(FilePath, json);
            OnRecentFilesChanged();
        }

        public event EventHandler RecentFilesChanged;

        protected virtual void OnRecentFilesChanged()
        {
            RecentFilesChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
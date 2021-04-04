using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Nhtid.WinForms
{
    public class RecentFilesManager
    {
        private List<string> recentFilePaths = new List<string>();

        private static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "recentfiles.json");

        public RecentFilesManager()
        {
            if (File.Exists(FilePath))
            {
                string recentFilesJson = File.ReadAllText(FilePath);
                recentFilePaths.AddRange(JsonConvert.DeserializeObject<string[]>(recentFilesJson));
            }
        }

        public IEnumerable<string> RecentFiles => recentFilePaths.AsEnumerable().Reverse();

        public void AddRecentFile(string value)
        {
            int index = recentFilePaths.FindIndex(i => i.Equals(value, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                recentFilePaths.RemoveAt(index);
            }
            recentFilePaths.Add(value);

            string json = JsonConvert.SerializeObject(recentFilePaths.ToArray());
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
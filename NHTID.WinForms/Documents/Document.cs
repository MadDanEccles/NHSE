using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHSE.Core;

namespace Nhtid.WinForms.Documents
{
    public class Document
    {
        public string OriginalFileName { get; set; }
        public string TempFolderPath { get; }
        public HorizonSave HorizonSave { get; }
        public MapManager MapManager { get; }
        public PersistentTemplate PersistentTemplate { get; }

        public Document(string originalFileName, string tempFolderPath, string title)
        {
            Title = title;
            OriginalFileName = originalFileName;
            this.TempFolderPath = tempFolderPath;
            HorizonSave = new HorizonSave(tempFolderPath);
            this.MapManager = new MapManager(HorizonSave.Main);
            if (File.Exists(PersistentTemplatePath))
            {
                string persistentTemplateJson = File.ReadAllText(PersistentTemplatePath);
                PersistentTemplate = JsonConvert.DeserializeObject<PersistentTemplate>(persistentTemplateJson);
            }
            else
            {
                PersistentTemplate = new PersistentTemplate();
            }
        }

        public void SaveToTemp(bool savePersistentTemplate)
        {
            MapManager.Items.Save();
            HorizonSave.Main.SetTerrainTiles(MapManager.Terrain.Tiles);

            HorizonSave.Main.SetAcreBytes(MapManager.Terrain.BaseAcres);
            // save.OutsideFieldTemplateUniqueId = (ushort)NUD_MapAcreTemplateOutside.Value;
            // save.MainFieldParamUniqueID = (ushort)NUD_MapAcreTemplateField.Value;

            HorizonSave.Main.Buildings = MapManager.Buildings;
            HorizonSave.Main.EventPlazaLeftUpX = MapManager.PlazaX;
            HorizonSave.Main.EventPlazaLeftUpZ = MapManager.PlazaY;

            HorizonSave.Save((uint)DateTime.Now.Ticks);

            if (savePersistentTemplate)
            {
                string persistentTemplateJson = JsonConvert.SerializeObject(PersistentTemplate);
                File.WriteAllText(PersistentTemplatePath, persistentTemplateJson);
            }
            else
            {
                File.Delete(PersistentTemplatePath);
            }
        }

        private string PersistentTemplatePath => Path.Combine(TempFolderPath, "PersistentTemplate.json");

        public string Title { get; set; }

        public MapManager GetMapManager() => MapManager;
    }
}

public class PersistentTemplate
{
    public bool IsPopulated => Areas.Any();

    public List<TemplateArea> Areas { get; set; } = new List<TemplateArea>();
}

public class TemplateArea
{
    public Guid Id { get; set; }
    public Rectangle TileBounds { get; set; }
    public Guid LinkPrevId { get; set; }
    public TemplateConfig? TemplateConfig { get; set; }
}

public class TemplateConfig
{
    public string Name { get; set; }
    public Color Color { get; set; }
    public string MacroTemplateName { get; set; }
    public JObject? MacroTemplateOptions { get; set; }
    public string MicroTemplateName { get; set; }
    public JObject? MicroTemplateOptions { get; set; }

}
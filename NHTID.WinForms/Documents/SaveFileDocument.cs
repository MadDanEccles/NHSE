using System;
using System.IO;
using NHSE.Core;

namespace Nhtid.WinForms.Documents
{
    class SaveFileDocument : IDocument
    {
        private readonly string folderPath;
        private readonly HorizonSave horizonSave;
        private readonly MapManager mapManager;

        public SaveFileDocument(string folderPath)
        {
            this.folderPath = folderPath;
            horizonSave = new HorizonSave(folderPath);
            this.mapManager = new MapManager(horizonSave.Main);
        }

        public void Save()
        {
            mapManager.Items.Save();
            horizonSave.Main.SetTerrainTiles(mapManager.Terrain.Tiles);

            horizonSave.Main.SetAcreBytes(mapManager.Terrain.BaseAcres);
            // save.OutsideFieldTemplateUniqueId = (ushort)NUD_MapAcreTemplateOutside.Value;
            // save.MainFieldParamUniqueID = (ushort)NUD_MapAcreTemplateField.Value;

            horizonSave.Main.Buildings = mapManager.Buildings;
            horizonSave.Main.EventPlazaLeftUpX = mapManager.PlazaX;
            horizonSave.Main.EventPlazaLeftUpZ = mapManager.PlazaY;

            horizonSave.Save((uint)DateTime.Now.Ticks);
        }

        public string Title => Path.GetFileName(folderPath);

        public MapManager GetMapManager() => mapManager;
    }
}

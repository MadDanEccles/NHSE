using System.Drawing;
using NHSE.Core;
using NHSE.WinForms.Zebra.Tools;

namespace NHSE.WinForms.Zebra.Renderers
{
    class BuildingLayerRenderer : MapLayerRendererBase
    {
        private readonly MapManager map;
        private readonly Font font;

        public BuildingLayerRenderer(MapManager map)
        {
            this.map = map;
            this.font = new Font("Calibri", 9.25f);
        }

        public override void Dispose()
        {
            this.font.Dispose();
            base.Dispose();
        }

        public override void Paint(Graphics gfx, MapRenderContext context)
        {
            using (var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                using (Pen pen = new Pen(Color.Coral, 1))
                {
                    using (Brush brush = new SolidBrush(Color.Coral))
                    {
                        foreach (var building in map.Buildings)
                        {
                            Size buildingSize = GetBuildingSize(building);

                            // From observation, a building is centered on its coordinate...
                            var buildingRect = context.ToViewport(building.X - 32 - buildingSize.Width / 2,
                                building.Y - 32 - buildingSize.Height / 2, buildingSize.Width, buildingSize.Height);
                            buildingRect = buildingRect.Shrink(4, 4, 3, 3);

                            gfx.FillRectangle(brush, buildingRect);
                            gfx.DrawString(building.BuildingType.ToString(), font, Brushes.White, buildingRect, stringFormat);
                        }
                    }
                }
            }
        }

        Size GetBuildingSize(Building building)
        {
            switch (building.BuildingType)
            {
                case BuildingType.Villager1:
                case BuildingType.Villager2:
                case BuildingType.Villager3:
                case BuildingType.Villager4:
                case BuildingType.Villager5:
                case BuildingType.Villager6:
                case BuildingType.Villager7:
                case BuildingType.Villager8:
                case BuildingType.Villager9:
                case BuildingType.Villager10:
                    return new Size(8, 8);
                case BuildingType.PlayerHouse1:
                case BuildingType.PlayerHouse2:
                case BuildingType.PlayerHouse3:
                case BuildingType.PlayerHouse4:
                case BuildingType.PlayerHouse5:
                case BuildingType.PlayerHouse6:
                case BuildingType.PlayerHouse7:
                case BuildingType.PlayerHouse8:
                    return new Size(10, 8);
                case BuildingType.Museum:
                    return new Size(14, 8);
                case BuildingType.NooksCranny:
                    return new Size(14, 12);
                case BuildingType.AblesSisters:
                    return new Size(10, 10);
                case BuildingType.Campsite:
                    return new Size(8, 8);
                case BuildingType.Airport:
                    return new Size(22, 22);
                default:
                    return new Size(1, 1);
            }
        }
    }
}
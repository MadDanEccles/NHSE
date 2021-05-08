using System;
using System.Windows.Forms;
using Autofac;
using Nhtid.WinForms.Documents;
using Nhtid.WinForms.SegmentLayouts;
using Nhtid.WinForms.Validation;

namespace Nhtid.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();

            // Register validation providers...
            builder.RegisterType<UnsupportedItemMapValidation>().As<IMapValidation>();
            builder.RegisterType<ItemIntegrityMapValidation>().As<IMapValidation>();

            // Register macro-layout factories...
            builder.RegisterType<MinWidthMultiSegmentLayoutFactory>().As<IMultiSegmentLayoutFactory>();
            builder.RegisterType<JustifiedMultiSegmentLayoutFactory>().As<IMultiSegmentLayoutFactory>();

            // Register micro-layout factories...
            builder.RegisterType<DisplaySegmentLayoutFactory>().As<ISegmentLayoutFactory>();
            builder.RegisterType<DiyLoayoutFactory>().As<ISegmentLayoutFactory>();

            // Register document factories...
            builder.RegisterType<SaveFileDocumentFactory>().As<IDocumentFactory>();
            builder.RegisterType<NhtidProjectDocumentFactory>().As<IDocumentFactory>();

            builder.RegisterType<ItemSource>().SingleInstance().AsSelf();
            builder.RegisterType<ItemConvertor>().SingleInstance().AsSelf();
            builder.RegisterType<JsonFileItemCollectionStore>().SingleInstance().As<IItemCollectionStore>();

            builder.RegisterType<HistoryService>().SingleInstance().As<IHistoryService>();
            builder.RegisterType<RecentFilesManager>().SingleInstance().AsSelf();

            builder.RegisterType<MapEditorForm>().InstancePerLifetimeScope().AsSelf().As<IDocumentContainer>();

            using (var root = builder.Build())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(root.Resolve<MapEditorForm>());
            }
        }
    }
}

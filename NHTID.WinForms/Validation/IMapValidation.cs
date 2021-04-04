using NHSE.Core;

namespace Nhtid.WinForms.Validation
{
    public interface IMapValidation
    {
        void Validate(MapManager map, ValidationResult result);
    }
}
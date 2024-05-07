using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage3._0.Services
{
    public interface IGetVehicleTypesService
    {
        Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync();
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage3._0.Services
{
    public interface IGetDataService
    {
        //Task<IEnumerable<SelectListItem>> GetDataAsync(Func<IQueryable<T>, //IQueryable<SelectListItem>> selector);

        Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync();

        Task<IEnumerable<SelectListItem>> GetMemberIdsAsync();
    }
}

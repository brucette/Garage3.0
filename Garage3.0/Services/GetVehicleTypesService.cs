using Garage3._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Garage3._0.Services
{
    public class GetVehicleTypesService : IGetVehicleTypesService
    {
        private readonly Garage3_0Context context;

        public GetVehicleTypesService(Garage3_0Context context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync()
        {
            return await context.VehicleTypes.Select(v => new SelectListItem
            {
                Text = v.Type,
                Value = v.VehicleTypeId.ToString()
            }).ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectListItem>> GetMemberIdsAsync()
        {
            return await context.Members.Select(m => new SelectListItem
            {
                Text = m.Id,
                Value = m.Id.ToString()
            }).ToListAsync();
            //throw new NotImplementedException();
        }
    }
}

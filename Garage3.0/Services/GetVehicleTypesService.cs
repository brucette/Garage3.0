using Garage3._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Garage3._0.Services
{
    public class GetVehicleTypesService
    {
        private readonly Garage3_0Context context;

        public GetVehicleTypesService(Garage3_0Context context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync()
        {
            //return await context.VehicleType.Select(v => new SelectListItem
            //{
                //    Text = $"Member id: {o.MemberId.ToString()} | Vehicle id: {o.VehicleId.ToString()}"
                //   // Value = 
            //    Text = v.Type,
            //    Value = v.VehicleTypeId.ToString()

            //}).ToListAsync();
            throw new NotImplementedException();
        }
    }
}

using Garage3._0.Entites;
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.ModelView
{
    public class MembersViewModel
    {
        //public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public ICollection<Ownership>? Ownerships { get; set; }

        public int NumberOfVehicles { get; set; }
    }
}

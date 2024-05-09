﻿using System.ComponentModel.DataAnnotations;

namespace Garage3._0.ModelView
{
    public class MemberIndexViewModel
    {
        [Display(Name = "Person Number")]
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool Membership { get; set; }

        [Display(Name = "Vehicles")]
        public int NumberOfVehicles { get; set; }
    }
}

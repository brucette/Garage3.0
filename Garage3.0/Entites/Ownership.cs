using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3._0.Entites
{
    public class Ownership
    {
        // Foregin key
        [ForeignKey("PersonNumber")]
        public string PersonNumberEntity { get; set; }
        // Foregin key
        [ForeignKey("RegisterNumber")]
        public string RegisterNumberEntity { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FlightModel
    {
        [Required]
        public string searchAirportPL { get; set; }

        [Required]
        public string searchAirportGR { get; set; }
    }
}

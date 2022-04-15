using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettaFishDTOs
{
    public class RegistrationDTO
    {
        public int registration_ID { get; set; }
        public string? fName { get; set; }
        public string? lName { get; set; }
        public string? email { get; set; }

    }
}

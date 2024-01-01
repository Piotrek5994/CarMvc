using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMvc.Models;

namespace Core.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public int? AdrId { get; set; }
        public Address? Address { get; set; }
        public Car? car { get; set; }
    }
}

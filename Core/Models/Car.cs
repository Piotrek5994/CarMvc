using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CarMvc.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Producer { get; set; }
        public double Capacity { get; set; }
        public int Power { get; set; }
        public string Motor { get; set; }
        public string RegistrationNumber { get; set; }
        public int OrganizationId { get; set; }
        public Organization Owner { get; set; }
        public Priority Priority { get; set; }
    }
    public enum Priority
    {
        [Display(Name = "Niski")] Low = 1,
        [Display(Name = "Normalny")] Normal = 2,
        [Display(Name = "Wysoki")] High = 3,
        [Display(Name = "Pilny")] Urgent = 4
    }
}

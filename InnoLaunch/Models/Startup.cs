using System.ComponentModel.DataAnnotations;

namespace InnoLaunch.Models
{
    public class Startup
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Startup name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Startup industry is required")]
        public string Industry { get; set; }

        [Required(ErrorMessage = "Startup HeadquartersLocation is required")]
        public string HeadquartersLocation { get; set; }

        [Required(ErrorMessage = "Startup Date Founded is required")]
        public DateTime DateFounded { get; set; }

        [Required(ErrorMessage = "Startup Employee Count is required")]
        public int EmployeeCount { get; set; }

    }
}

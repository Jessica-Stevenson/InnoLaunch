using System.ComponentModel.DataAnnotations;

namespace InnoLaunch.Models
{
    public class Founder
    {
        public int FounderId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

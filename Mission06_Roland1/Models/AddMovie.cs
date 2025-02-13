using System.ComponentModel.DataAnnotations;

namespace Mission06_Roland.Models
{
    public class AddMovie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        public string title { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public int year { get; set; }
        public string director { get; set; } = string.Empty;
        public string rating { get; set; } = string.Empty;
        public bool? edited { get; set; }
        public string? lentTo { get; set; } = string.Empty;
        public string? notes { get; set; } = string.Empty;
    }
}

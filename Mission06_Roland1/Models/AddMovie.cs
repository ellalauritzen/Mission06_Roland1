using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mission06_Roland1.Models;

namespace Mission06_Roland1.Models
{
    public class AddMovie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        
        [Required]
        public string title { get; set; } = string.Empty;
        
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }    
        public Category? Category { get; set; }

        [Required]
        [Range(1888, 2025, ErrorMessage = "Must Enter a valid year")]
        public int year { get; set; }
        
        public string? director { get; set; } = string.Empty;
       
        public string? rating { get; set; } = string.Empty;
        
        [Required]
        public bool edited { get; set; }
       
        public string? lentTo { get; set; } = string.Empty;
        
        [Required]
        public bool copiedToPlex { get; set;} = false;
       
        public string? notes { get; set; } = string.Empty;
    }
}

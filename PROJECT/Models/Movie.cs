using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string? Description { get; set; }

        public string? PictureUrl { get; set; }
        public string? Name { get; set; }
        public string? price { get; set; }
        public string? SectineId { get; set; } = string.Empty;
        
        


        public Sectine s1 { get; set; } = null!;
    }
}
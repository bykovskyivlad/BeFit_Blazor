using System.ComponentModel.DataAnnotations;

namespace BeFit_Blazor.Models
{
    public class ExerciseType
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [Display(Name = "Exercise Type")]
        public string Description { get; set; }
    }
}

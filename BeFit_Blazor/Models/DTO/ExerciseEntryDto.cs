using System.ComponentModel.DataAnnotations;

namespace BeFit_Blazor.Models.DTO
{
    public class ExerciseEntryDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sesja treningowa")]
        public int TrainingSessionId { get; set; }

        [Required]
        [Display(Name = "Typ ćwiczenia")]
        public int ExerciseTypeId { get; set; }

        [Range(0, 1000, ErrorMessage = "Obciążenie musi być między 0 a 1000 kg")]
        [Display(Name = "Obciążenie (kg)")]
        public double Load { get; set; }

        [Range(1, 20, ErrorMessage = "Liczba serii musi być między 1 a 20")]
        [Display(Name = "Serie")]
        public int Sets { get; set; }

        [Range(1, 100, ErrorMessage = "Liczba powtórzeń musi być między 1 a 100")]
        [Display(Name = "Powtórzenia w serii")]
        public int Reps { get; set; }

        
        public string? TrainingSessionLabel { get; set; }
        public string? ExerciseTypeName { get; set; }
    }
}

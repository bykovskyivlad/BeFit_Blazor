using System.ComponentModel.DataAnnotations;

namespace BeFit_Blazor.Models
{
    public class TrainingSession
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;   
        public ApplicationUser? User { get; set; }    

        [Required]
        [Display(Name = "Czas rozpoczęcia")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Czas zakończenia")]
        public DateTime EndTime { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;

namespace VoraFilms.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Full Name")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please enter a valid Indian phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Event type is required")]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        public DateTime? EventDate { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(1000, ErrorMessage = "Message cannot be longer than 1000 characters")]
        public string Message { get; set; }

        [Display(Name = "How did you hear about us?")]
        public string ReferralSource { get; set; }
    }

    public enum EventType
    {
        Wedding,
        PreWedding,
        Engagement,
        Portrait,
        Corporate,
        Birthday,
        Other
    }
}
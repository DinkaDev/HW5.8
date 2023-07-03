using System.ComponentModel.DataAnnotations;

namespace HW5._8.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "The fild FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The fild LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The fild Email is required")]
        [EmailAddress(ErrorMessage = "Input the correct Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The fild DesiredDate is required")]
        [FutureDate(ErrorMessage = "The fild DesiredDate should be in the future")]
        [NotWeekend(ErrorMessage = "The fild DesiredDate should be not on the weekend")]
        public DateTime DesiredDate { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date > DateTime.Now;
        }
    }

    public class NotWeekendAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}

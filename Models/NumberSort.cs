using System.ComponentModel.DataAnnotations;

namespace Number_Sorter.Models
{
    public class NumberSort
    {
        public int Id { get; set; }

        // This is a required field and has to be at least two numbers separated by commas otherwise the error message will be shown.
        [Required]
        [RegularExpression(@"[0-9]+(,[0-9]+)+", ErrorMessage = "Please enter at least two numbers separated by a comma.")]
        public string SortedNumbers { get; set; }

        // This is a required field and the user has to choose one sort direction so the sorting can be done in the controller.
        [Required]
        [RegularExpression("Ascending|Descending", ErrorMessage = "Please choose either 'Ascending' or 'Descending'.")]
        public string SortedDirection { get; set; }

        public double SortTime { get; set; }

       
    }
}

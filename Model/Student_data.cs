using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Model
{
    public class Student_data
    {
        public int id { get; set; }
        [Key] public string? gid { get; set; }
        [Required] public string? name { get; set; }
        [Required] public string? surname { get;set; }
        [Required] public string? father { get;set; }
        [Required] public string? stndard { get;set; }
        [Required] public string? village { get; set; }   
        [Required] public string? room { get; set; }
        [Required] public string cup_no { get; set; }

    }
    public class Final_student_data : Student_data
    {
        [Required] public Uri? url { get; set; }
    }
}


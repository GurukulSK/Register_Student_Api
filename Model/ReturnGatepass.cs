using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Model
{
    public class ReturnGatepass
    {
        [Required]
        public string gid { get; set; }
        public string? late_permission { get; set; }
        public string? late_reason { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Model
{
    public class OtpModel
    {
       [Key]public int Id { get; set; }

        public string gid { get; set; }
        public Int64 otp { get; set; }
        public bool verified { get; set; }

    }
}

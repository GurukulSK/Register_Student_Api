using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Model
{
    public class SabhaModel
    {
        public int id { get; set; }
        [Key] public string? gid { get; set; }
        [Required] public string? name { get; set; }
        [Required] public string? surname { get; set; }
        [Required] public string? father { get; set; }
        [Required] public string? stndard { get; set; }
        [Required] public string? village { get; set; }
        [Required] public string? room { get; set; }
        [Required] public string cup_no { get; set; }
        public string? deparment { get; set; }

        public string? permit { get; set; }

        public DateTime? date { get; set; }



    }
    public class SevaList
    {
        [Key] public int id { get; set; }
        public string? deparment {get; set;}
        public string? hod { get; set; }
        public string? telegram_chat_id { get; set;}
    }
}

using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Model
{
    public class Gatepass
    {
        [Key] 
        public int id { get; set; }
        public string? gid { get; set; }
        public string? name { get; set; }
        public string? father { get; set;}
        public string? surname { get; set; }
        public string? standard { get; set; }
        public string? room { get; set; }
        public bool group { get; set; }
        public bool monitar { get; set; }
        public Guid group_id { get; set; }
        public string? place { get; set; } 
        public string? area { get; set; } 
        public string? reason { get; set; } 
        public string? with { get; set; }
        public string? with_name { get; set; } 
        public string? with_number { get; set; } 
        public string? going_time { get; set; }
        public string? commited_time { get; set; }
        public DateTime date { get; set; }
        public string? permission { get; set; } 
        public string? comming_time { get; set; }
        public bool late { get; set; }
        public string? late_permission { get; set; }
        public string? late_reason { get; set; }
        public bool returned { get; set; }
    }

   
}

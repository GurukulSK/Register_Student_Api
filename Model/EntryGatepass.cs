using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Model
{
    public class EntryGatepass
    {
        [Required]
        [MaxLength(5)]
        public IList<string> gid { get; set; }
        [Key]
        public Guid group_id { get; set; }
        [Required]
        public string? place { get; set; }
        [Required]
        public string? area { get; set; }
        [Required]
        public string? reason { get; set; }
        [Required]
        public string? with { get; set; }
        public string? with_name { get; set; }
        public string? with_number { get; set; }
        [Required]
        public string? commited_time { get; set; }
        [Required]
        public string? permission { get; set; }
       }
}

using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Model
{
    public class SpecialEntryModel
    {
        [Key]
        public int Id { get; set; }
        public string gid { get; set; }
        public string place { get; set; }
        public string area { get; set; }
    }
    public class areaModel
    {
        [Key]
        public string area { get; set; }
    }
    public class PlaceModel
    {
        [Key]
        public string place { get; set; }
    }
    public class ReasonModel
    {
        [Key]
        public string reason { get; set; }
    }
}

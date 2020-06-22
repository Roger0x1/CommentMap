using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CommentMap.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(7, ErrorMessage ="Value too large for field")]
        [Display(Name ="Report Type")]
        public string ReportType { get; set; }

        [MaxLength(2000, ErrorMessage ="Too long, summarize")]
        public string Comment { get; set; }

        [MaxLength(7, ErrorMessage ="Lat too long, truncate to 7 spaces")]
        [Display(Name ="Latitude")]
        public string Lat { get; set;}

        [MaxLength(7, ErrorMessage ="Longitude too long, truncate to 7 spaces")]
        [Display(Name ="Longitude")]
        public string Lng { get; set; }

        //  Because this is designed to be publically viewed and entered, there may be "inappropriate" entries.
        [Display(Name ="Do Not Display")]
        public bool DoNotDisplay { get; set; }
    }
}

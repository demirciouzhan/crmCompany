using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crmCompany.Models
{
    [Table("Services_Details")]
    public class Services_Details
    {
        [Key]

        public int ID { get; set; }

        public int Service_ID { get; set; }

        public string access_address { get; set; }  
    }
}

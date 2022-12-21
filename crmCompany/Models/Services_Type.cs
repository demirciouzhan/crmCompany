using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crmCompany.Models
{
    [Table("Services_Type")]
    public class Services_Type
    {
        [Key]
        public int ID { get; set; }

        public int Service_Type_ID { get; set; }


    }
}

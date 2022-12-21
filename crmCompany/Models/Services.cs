using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crmCompany.Models
{
    [Table("Services")]
    public class Services
    {
        [Key]
        public int Services_Id { get; set; }
       
        public string Serve { get; set; }
    }
}

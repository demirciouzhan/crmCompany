using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crmCompany.Models
{
    [Table("Companies")]
    public class Companys
    {

        [Key]
        public int Id { get; set; }

        public string Company_Name { get; set; }


        public int SaveDetails() 
        {
            SqlConnection con =new SqlConnection(GetConString.ConString());
            string query="INSERT INTO Companies(Company_Name) values('"+Company_Name+"')";
            SqlCommand cmd= new SqlCommand(query, con);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}

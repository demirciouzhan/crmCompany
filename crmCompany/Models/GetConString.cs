using Microsoft.Extensions.Configuration;
using System.IO;


namespace crmCompany.Models
{
    public class GetConString
    {
        public static string ConString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            string constring = config.GetConnectionString("DefaulConnection");
            return constring;
        }
    }
}

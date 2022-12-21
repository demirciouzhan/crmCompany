using crmCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace crmCompany.Controllers
{
    public class HomeController : Controller
    {
        companyContext db= new companyContext();
        private readonly ILogger<HomeController> _logger;
        private readonly companyContext _context;
        private companyContext Context { get; }

        public HomeController(ILogger<HomeController> logger,companyContext context)
        {
            _logger = logger;
            _context = context;
            this.Context = context;
        }
        
        public IActionResult Index()
        {
           
            using (companyContext context = new companyContext())
            {

                ViewBag.Companys = _context.Companies.Select(w =>
                new SelectListItem
                {
                    Text = w.Company_Name,
                    Value = w.Id.ToString(),
                }).ToList();

            }

            SqlConnection con = new SqlConnection("Server=localhost;Database=Company;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            SqlCommand cmd = new SqlCommand("select * from Companies", con);

            List<Companys> companys = new List<Companys>();

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                companys.Add(
                    new Companys
                    {
                        Id = (int)rd["Id"],
                        Company_Name = (string)rd["Company_Name"],
                        //CRM = (string)rd["CRM"],
                        //Santral = (string)rd["Santral"],
                        //Web = (string)rd["Web"],
                        //Mail = (string)rd["Mail"]
                    });
            }
            companys = companys.ToList();
            con.Close();

            return View(companys);
            
          
           
        }
      
        [HttpPost]
        public IActionResult AddServices(string[] featuresIds)
        {
            SelectList features = new SelectList(this.Context.Service.ToList(), "Services_Id", "Serve");
            ViewBag.Message = "";
            foreach (string featureId in featuresIds) 
            {
                SelectListItem selectedItem =features.ToList().Find(p=>p.Value==featureId);
                ViewBag.Message += "Name: " + selectedItem.Text;
                ViewBag.Message += "\\nID: " + selectedItem.Value;
                ViewBag.Message += "\\n";
            }
            return View(features);
        }
       
        public IActionResult AddCompany() 
        {
            return View();
        }
        public IActionResult Privacy()
        {
          
            return View();
        }
        public IActionResult AddServices()
        {
            SelectList features = new SelectList(this.Context.Service.ToList(), "Services_Id", "Serve");
            return View(features);
        }
        public IActionResult Save()
        {
            return View();
        }
        public IActionResult AddServicesDetail() 
        {
            return View();
        }    
        [HttpPost]
        public IActionResult GetDetails()
        {
            Companys umodel = new Companys();
            umodel.Company_Name = HttpContext.Request.Form["txtName"].ToString();
            int result = umodel.SaveDetails();
            if (result > 0 )
            {
                ViewBag.Result = "Data Saved Successfully";
            }
            else
            {
                ViewBag.Result = "Something Went Wrong";
            }
            return RedirectToAction("AddServices");
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
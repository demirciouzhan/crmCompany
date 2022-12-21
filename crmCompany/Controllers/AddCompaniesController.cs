using crmCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace crmCompany.Controllers
{
    public class AddCompaniesController : Controller
    {

        private readonly companyContext _context;

        public AddCompaniesController(companyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var lisofCompanies=_context.Companies.ToList();
            //return View(lisofCompanies);
            return View();

        }
        
    }
}

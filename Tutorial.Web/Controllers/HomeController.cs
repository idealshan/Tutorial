using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;
using Tutorial.Web.Model;
using Tutorial.Web.Services;
using Tutorial.Web.ViewModels;

namespace Tutorial.Web.Controllers
{
    public  class HomeController : Controller
    {
        private readonly IRepository<Student> _repository;

        public HomeController(IRepository<Student> repository)
        {
            _repository = repository;
        }


        public IActionResult Index()
        {
            var list = _repository.GetAll();
            var vms = list.Select(x => new HomeIndexViewModel
            {
                Name = $"{x.FirstName} {x.LastName}",
                Age = DateTime.Now.Subtract(x.BirthDate).Days / 365

            });
            return View(vms);
        }
    }
}

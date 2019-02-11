using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial.Web.Controllers
{
    /// <summary>
    /// 基于属性的路由
    /// </summary>
   [Route("[controller]/[action]")]
    public class AboutController
    {
    
        public string Me()
        {
            return "Dave";
        }
     
        public string Company()
        {
            return "No Company";
        }
    }
}

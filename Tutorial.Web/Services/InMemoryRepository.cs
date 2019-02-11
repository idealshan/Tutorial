using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using Tutorial.Web.Model;

namespace Tutorial.Web.Services
{
    public class InMemoryRepository:IRepository<Student>
    {
     
        public IEnumerable<Student> GetAll()
        {
            return new List<Student>
            {
                new Student
                {
                    Id=1,
                    FirstName = "张",
                    LastName = "无忌",
                    BirthDate = new DateTime(1980,1,4)
                },     new Student
                {
                    Id=2,
                    FirstName = "杨",
                    LastName = "不悔",
                    BirthDate = new DateTime(1974,6,4)
                },     new Student
                {
                    Id=3,
                    FirstName = "赵",
                    LastName = "敏",
                    BirthDate = new DateTime(1978,12,5)
                }


        };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        // 1-3的課後作業 - 參考Index4 & Index5
        public ActionResult Details()
        {
            // ↓New write
            PersonData pd = new PersonData
            {
                PersonName = "Miss Lin",
                PersonSex = "Female",
                PersonMobilePhone = "0988888888"
            };

            //// ↓Old write
            //PersonData pd = new PersonData();
            //pd.PersonName = "Miss Lin";
            //pd.PersonSex = "Female";
            //pd.PersonMobilePhone = "0988888888";

            return View(pd);
        }
        public ActionResult List()
        {
            // New write ↓
            List<PersonData> pdList = new List<PersonData>
            {
                new PersonData { PersonName = "Miss A", PersonSex = "Female", PersonMobilePhone = "0988888888" },
                new PersonData { PersonName = "Mister B", PersonSex = "male", PersonMobilePhone = "09111111111" },
                new PersonData { PersonName = "Miss C", PersonSex = "Female", PersonMobilePhone = "0966666666" }
            };

            //// Old write ↓
            //List<PersonData> pdList = new List<PersonData>();
            //pdList.Add(new PersonData { PersonName = "Miss A", PersonSex = "Female", PersonMobilePhone = "0988888888" });
            //pdList.Add(new PersonData { PersonName = "Mister B", PersonSex = "male", PersonMobilePhone = "09111111111" });
            //pdList.Add(new PersonData { PersonName = "Miss C", PersonSex = "Female", PersonMobilePhone = "0966666666" });

            return View(pdList);

        }
    }
}
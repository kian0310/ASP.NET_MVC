using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class Lesson1Controller : Controller
    {
        // GET: Lesson1
        public ActionResult Index()
        {
            return View();
            //產生檢視(View)時，不使用任何「版面配置頁」(類似Web Form的 MasterPage 母版頁面)
        }

        public ActionResult Index1A()
        {   //***不要產生view screen !  ***Please itself input 網址URL來 watch result.
            return View("IndexHello");
            //在View()內强制write view screen 的「檔名file name」
            //當你瀏覽 http://你的網站/Lesson1/Index1A 時，會自動跳去IndexHello View screen (注意!沒有撰寫IndexHello動作)
        }
        public ActionResult Index1B()
        {   //***不要產生view screen !  ***Please itself input 網址URL來 watch result.
            return View("~/Views/Lesson1/IndexHello.cshtml");
            //在View()內强制write view screen 的「完整路徑 & 檔名file name」
            //當你瀏覽 http://你的網站/Lesson1/Index1B 時，會自動跳去IndexHello View screen (注意!沒有撰寫IndexHello動作)
        }

        //重點！傳回值的data型態改為字串(string)
        public string Index1C()
        {   //**不要產生view screen !   ***Please itself input 網址URL來watch result.
            return "傳回一句後，字串 -- <h3>string</h3>";
        }

        public ActionResult Index1D()
        {   //**不要產生view screen !   ***Please itself input 網址URL來watch result.
            return Content ("用Content傳回一句， <h3>Content()</h3>");
            //另一種寫法
            // return Content ("用Content傳回一句， <h3>Content()</h3>", "text/Plain",System.Text.Encoding.UTF8);  // 最後需要 System.Text 命名空間

            //參考資料  ActionResult  https://msdn.microsoft.com/zh-tw/library/system.web.mvc.actionresult(v=vs.118).aspx
            //            ContentResult
            //            EmptyResult
            //            FileResult
            //            HttpUnauthorizedResult
            //            JavaScriptResult
            //            JsonResult
            //            RedirectResult
            //            RedirectToRouteResult
            //            ViewResultBase
        }
    
        public ActionResult Index1E()
        {   //**不要產生view screen !   ***Please itself input 網址URL來watch result.
            return Redirect("http://www.yahoo.com.tw/");  //input URL網址，連至other 網站
        }

        //--- 補充教材 ------------------------------------------------------------------------------------------(start)
        // 如果找不到動作（Action）或是輸入錯誤的動作名稱，一律跳回首頁
        // Controller的 HandleUnknownAction方法為 virtual，所以可用override覆寫。https://msdn.microsoft.com/zh-tw/library/dd492730(v=vs.118).aspx

        //protected override void HandleUnknownAction(string actionName)
        //{
        //    Response.Redirect("http://公司首頁(網址)/");    // 自訂結果 -- 找不到動作就跳回首頁
        //    base.HandleUnknownAction(actionName);
        //}
        //--- 補充教材 ------------------------------------------------------------------------------------------(end)

        //--------------------------------------------------------------------------------------------------------
        public ActionResult Index2()
        {
            return View();
            // 產生檢視（View）的時候，搭配「版面配置頁」（類似Web Form的 MasterPage 母版頁面）
            // itself setting「版面配置頁」，file 位於 ~/Views/Shared/_LayoutPage1.cshtml

            // 完成後，可搭配 Index8 一起學習。
        }

        //--------------------------------------------------------------------------------------------------------
        //---- ViewBag、ViewData、TempData
        //--------------------------------------------------------------------------------------------------------
        public ActionResult Index3()
        {
            ViewData["A"] = "(1). string A. I am ViewData[]";
            ViewBag.B = "(2). string B. I am ViewBag";
            TempData["C"] = "(3). string C. I am TempData[]";

            return View();
            // 產生view時，not use any 「版面配置page」
        }

        // 如果ViewData & ViewBag 變數相同命名，會出現什麼情況？？show lastly one 變數 result.
        // 例如：ViewData["XYZ"] & ViewBag.XYZ  ？？？？
        public ActionResult Index3A()
        {
            ViewData["XYZ"] = "** Hello: I am ViewData[] **";
            ViewBag.XYZ = "sorry! 改了content, I am ViewBag.";

            return View();
            // 產生view時，not use any 「版面配置page」

            // 補充教材：https://www.c-sharpcorner.com/UploadFile/db2972/datatable-in-viewdata-sample-in-mvc-day-3/
            // DataTable，透過 ViewBag傳遞給 檢視畫面使用
        }

        //--------------------------------------------------------------------------------------------------------
        //-- 搭配第一個類別檔 (~/Models/Class1.cs) 當作Model，但沒有連結資料庫。
        //--------------------------------------------------------------------------------------------------------
        public ActionResult Index4()
        {
            // 搭配Class file ~/Models/Class1.cs
            // ↓new write
            // var uname = new Models.Class1 { UserName = "(4). string D" };
            // 或是寫成 Models.Class1 uname = new Models.Class1 { UserName = "(4). string D" };

            // ↓old write
            // Models.Class1 uname = new Models.Class1();
            // ↑寫法1，front add Models.Class1
            // ↓寫法2
            var uname = new Models.Class1();
            uname.UserName = "(4). string D. 我躲在Class1類別的UserName屬性.";

            return View(uname);
            // 產生view時，not use any 「版面配置page」
            // Please use 「Details」範本。只傳遞「一筆」data 而已。
        }

        public ActionResult Index5()
        {
            // 搭配一個簡單的Class file, 當作Model and View screen 互動
            List<Models.Class1> myList = new List<Models.Class1>
            {
                new Models.Class1 {UserName = "(5). string ASP.NET."},
                new Models.Class1 {UserName = "(6). string Web Form."},
                new Models.Class1 {UserName = "(7). string MVC."},
                new Models.Class1 {UserName = "(8). string ASP.NET project 實務"}
            };

            // //↑上面是簡化的寫法。也可以寫成這樣（舊寫法↓）
            //List<Models.Class1> myList = new List<Models.Class1>();
            //    myList.Add(new Models.Class1 { UserName = "(5). 字串 ASP.NET" });
            //    myList.Add(new Models.Class1 { UserName = "(6). 字串 Web Form" });
            //    myList.Add(new Models.Class1 { UserName = "(7). 字串 MVC" });
            //    myList.Add(new Models.Class1 { UserName = "(8). 字串 ASP.NET專題實務" });

            return View(myList);
            // 產生view時，not use any 「版面配置page」
            // Please use "List" 範本。Because need 傳遞「多筆」data.
        }


        //--------------------------------------------------------------------------------------------------------
        //---- 以下範例，將練習「檢視畫面」的 Razor。  控制器不需額外的程式碼。
        //--------------------------------------------------------------------------------------------------------
        public ActionResult Index6() 
        {  //產生view時，「範本」請選Empty(沒有模型)
            return View();
            // 產生view時，not use any 「版面配置page」
        }

    }
}
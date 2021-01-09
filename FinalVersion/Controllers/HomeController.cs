using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalVersion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult JobInfo()
        {
            return View();
        }

        public ActionResult JobInfo_CN()
        {
            return View();
        }

        //public ActionResult EventSearch()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult EventSearch(String datePicker, String Location, Nullable<int> categories)
        {
            Debug.WriteLine(datePicker + " " + Location + " " + categories);
            ViewBag.category = string.Concat("categories=", categories);
            Debug.WriteLine("categories=" + categories);


            if (Location != null)
            {
                String temp = Location.Replace(" ", "-");
                String temp2 = string.Concat("location.address=", temp);
                ViewBag.location = temp2;
                Debug.WriteLine("location.address=" + temp);
            }


            if (datePicker != null && datePicker.Length > 3)
            {
                String day = datePicker[3] + "" + datePicker[4];
                String month = datePicker[0] + "" + datePicker[1];
                String year = datePicker[6] + "" + datePicker[7] + "" + datePicker[8] + "" + datePicker[9];
                var datea = year + "-" + month + "-" + day + "T00%3A00%3A01Z";
                Debug.WriteLine(datea);
                String tempstring = string.Concat("start_date.range_start=", datea);
                ViewBag.date = tempstring;
                Debug.WriteLine("start_date.range_start=" + datea);
            }
            return View();
        }

        [HttpPost, ActionName("EventSearch")]
        public ActionResult EventSearchPost(String datePicker, String Location, Nullable<int> categories)
        {
            Debug.WriteLine(datePicker + " " + Location + " " + categories);
            ViewBag.category = string.Concat("categories=", categories);
            Debug.WriteLine("categories=" + categories);


            if (Location != null)
            {
                String temp = Location.Replace(" ", "+");
                String temp2 = string.Concat("location.address=", temp);
                ViewBag.location = temp2;
                Debug.WriteLine("location.address=" + temp);
            }


            if (datePicker != null && datePicker.Length > 3)
            {
                String day = datePicker[3] + "" + datePicker[4];
                String month = datePicker[0] + "" + datePicker[1];
                String year = datePicker[6] + "" + datePicker[7] + "" + datePicker[8] + "" + datePicker[9];
                var datea = year + "-" + month + "-" + day + "T00%3A00%3A01Z";
                Debug.WriteLine(datea);
                String tempstring = string.Concat("start_date.range_start=", datea);
                ViewBag.date = tempstring;
                Debug.WriteLine("start_date.range_start=" + datea);
            }
            return View();
        }

        public ActionResult Place()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Place(Nullable<int> School, Nullable<int> Crime, Nullable<int> Rent, Nullable<int> Hospital, Nullable<int> Distance, Nullable<int> Station, Nullable<int> Supermarket, Nullable<int> Parks,int bedroom,String Clinics, String Communities,String population)
        {
            Debug.WriteLine("In Place CSHTML");

            if (School == null)
                School = 0;
            if (Crime == null)
                Crime = 40;
            if (Rent == null)
                Rent = 0;
            if (Hospital == null)
                Hospital = 0;
            if (Distance == null)
                Distance = 40;
            if (Station == null)
                Station = 0;
            if (Supermarket == null)
                Supermarket = 0;
            if (Parks == null)
                Parks = 0;
            if (Clinics == null)
                Clinics = "No";
            if (Communities == null)
                Communities = "No";

            int[] valuesa = new int[] { School.Value, Crime.Value, Rent.Value, Hospital.Value, Distance.Value, Station.Value, Supermarket.Value, Parks.Value ,bedroom};

            //return RedirectToAction("Results", "Housings1", new { @values = valuesa });
            List<int> myList = valuesa.ToList();
            var list = HttpUtility.ParseQueryString("");
            myList.ForEach(x => list.Add("valuesa", x.ToString()));
            return Redirect("/Housings/ResultsA/?" + list+"&community="+Communities+"&clinics="+Clinics+"&population="+population);
            //Debug.WriteLine(Blanks[0] + "," + Blanks[1] + "," + Blanks[2] + "," + Blanks[3]);
            //TempData["preferences"] = Blanks;
            //return RedirectToAction("Results", "Housings", new { @bool0 = Blanks[0], @bool1 = Blanks[1], @bool2 = Blanks[2], @bool3 = Blanks[3] });
        }

        public ActionResult EventDesc(String eventid)
        {
            Debug.WriteLine(eventid);
            ViewBag.Eventid = eventid;
            return View();
        }



        public ActionResult Checklist()
        {
            return View();
        }

        public ActionResult Temp_Index()
        {
            return View();
        }

        /// <summary>
        /// Chinese Views
        /// </summary>
        /// <returns></returns>
        public ActionResult Events_CN()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult EventSearch()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult EventSearch_CN(String datePicker, String Location, Nullable<int> categories)
        {
            Debug.WriteLine(datePicker + " " + Location + " " + categories);
            ViewBag.category = string.Concat("categories=", categories);
            Debug.WriteLine("categories=" + categories);


            if (Location != null)
            {
                String temp = Location.Replace(" ", "-");
                String temp2 = string.Concat("location.address=", temp);
                ViewBag.location = temp2;
                Debug.WriteLine("location.address=" + temp);
            }


            if (datePicker != null && datePicker.Length > 3)
            {
                String day = datePicker[3] + "" + datePicker[4];
                String month = datePicker[0] + "" + datePicker[1];
                String year = datePicker[6] + "" + datePicker[7] + "" + datePicker[8] + "" + datePicker[9];
                var datea = year + "-" + month + "-" + day + "T00%3A00%3A01Z";
                Debug.WriteLine(datea);
                String tempstring = string.Concat("start_date.range_start=", datea);
                ViewBag.date = tempstring;
                Debug.WriteLine("start_date.range_start=" + datea);
            }
            return View();
        }

        [HttpPost, ActionName("EventSearch_CN")]
        public ActionResult EventSearchPost_CN(String datePicker, String Location, Nullable<int> categories)
        {
            Debug.WriteLine(datePicker + " " + Location + " " + categories);
            ViewBag.category = string.Concat("categories=", categories);
            Debug.WriteLine("categories=" + categories);


            if (Location != null)
            {
                String temp = Location.Replace(" ", "+");
                String temp2 = string.Concat("location.address=", temp);
                ViewBag.location = temp2;
                Debug.WriteLine("location.address=" + temp);
            }


            if (datePicker != null && datePicker.Length > 3)
            {
                String day = datePicker[3] + "" + datePicker[4];
                String month = datePicker[0] + "" + datePicker[1];
                String year = datePicker[6] + "" + datePicker[7] + "" + datePicker[8] + "" + datePicker[9];
                var datea = year + "-" + month + "-" + day + "T00%3A00%3A01Z";
                Debug.WriteLine(datea);
                String tempstring = string.Concat("start_date.range_start=", datea);
                ViewBag.date = tempstring;
                Debug.WriteLine("start_date.range_start=" + datea);
            }
            return View();
        }

        public ActionResult EventDesc_CN(String eventid)
        {
            Debug.WriteLine(eventid);
            ViewBag.Eventid = eventid;
            return View();
        }

        public ActionResult Place_CN()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Place_CN(Nullable<int> School, Nullable<int> Crime, Nullable<int> Rent, Nullable<int> Hospital, Nullable<int> Distance, Nullable<int> Station, Nullable<int> Supermarket, Nullable<int> Parks, int bedroom, String Clinics, String Communities, String population)
        {
            Debug.WriteLine("In Place CSHTML");

            if (School == null)
                School = 0;
            if (Crime == null)
                Crime = 40;
            if (Rent == null)
                Rent = 0;
            if (Hospital == null)
                Hospital = 0;
            if (Distance == null)
                Distance = 40;
            if (Station == null)
                Station = 0;
            if (Supermarket == null)
                Supermarket = 0;
            if (Parks == null)
                Parks = 0;
            if (Clinics == null)
                Clinics = "No";
            if (Communities == null)
                Communities = "No";

            int[] valuesa = new int[] { School.Value, Crime.Value, Rent.Value, Hospital.Value, Distance.Value, Station.Value, Supermarket.Value, Parks.Value, bedroom };

            //return RedirectToAction("Results", "Housings1", new { @values = valuesa });
            List<int> myList = valuesa.ToList();
            var list = HttpUtility.ParseQueryString("");
            myList.ForEach(x => list.Add("valuesa", x.ToString()));
            return Redirect("/Housings/ResultsA_CN/?" + list + "&community=" + Communities + "&clinics=" + Clinics + "&population=" + population);
            //Debug.WriteLine(Blanks[0] + "," + Blanks[1] + "," + Blanks[2] + "," + Blanks[3]);
            //TempData["preferences"] = Blanks;
            //return RedirectToAction("Results", "Housings", new { @bool0 = Blanks[0], @bool1 = Blanks[1], @bool2 = Blanks[2], @bool3 = Blanks[3] });
        }

        public ActionResult Index_CN()
        {
            return View();
        }

        public ActionResult Checklist_CN()
        {
            return View();
        }
    }
}
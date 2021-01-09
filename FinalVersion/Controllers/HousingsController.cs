using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalVersion.Models;

namespace FinalVersion.Controllers
{
    public class HousingsController : Controller
    {
        private NewestModels db = new NewestModels();

        // GET: Housings
        public ActionResult Index()
        {
            return View(db.Housings.ToList());
        }

        // GET: Housings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Housing housing = db.Housings.Find(id);
            if (housing == null)
            {
                return HttpNotFound();
            }
            return View(housing);
        }

        // GET: Housings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Housings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Suburb,Distance,SchoolNo,CrimeNo,Buy_Price,HospitalNo,Latitude,Longitude,Rent2br,Rent3br,Rent4br,RentAverageAll,Supermarket_No,BusStop_No,Tram_No,Train_No,Transport_No,Park_No,NormDistance,NormCrime,NormHospital,NormSchool,NormSupermarket,NormStation,NormPark,NormRent2br,NormRent3br,NormRent4br,Url,ChinesePopulation,ChineseCommunities,ChineseClinics")] Housing housing)
        {
            if (ModelState.IsValid)
            {
                db.Housings.Add(housing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(housing);
        }

        // GET: Housings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Housing housing = db.Housings.Find(id);
            if (housing == null)
            {
                return HttpNotFound();
            }
            return View(housing);
        }

        // POST: Housings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Suburb,Distance,SchoolNo,CrimeNo,Buy_Price,HospitalNo,Latitude,Longitude,Rent2br,Rent3br,Rent4br,RentAverageAll,Supermarket_No,BusStop_No,Tram_No,Train_No,Transport_No,Park_No,NormDistance,NormCrime,NormHospital,NormSchool,NormSupermarket,NormStation,NormPark,NormRent2br,NormRent3br,NormRent4br,Url,ChinesePopulation,ChineseCommunities,ChineseClinics")] Housing housing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(housing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(housing);
        }

        // GET: Housings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Housing housing = db.Housings.Find(id);
            if (housing == null)
            {
                return HttpNotFound();
            }
            return View(housing);
        }

        // POST: Housings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Housing housing = db.Housings.Find(id);
            db.Housings.Remove(housing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult ResultsA(List<int> valuesa,String community,String population,String clinics)
        {
            IQueryable<Housing> test1 = from p in db.Housings select p;
            /*var test1 = db.Housings.AsQueryable();
            var test1 = test1.Where(t => t.NormSchools >= values[0]);
            var test1 = test1.Where(t => t.NormCrime >= values[1]);*/
            /* var test2 = test1
                 .Select(s => new { s.Suburb, s.NormRent, s.NormDistance, s.NormHospital,s. })
                 .Where(c => c.NormRent >= values[1] && c.NormHospital >= values[2] && c.NormDistance >= values[2]);
             */
            
            int[] values = valuesa.ToArray();
            var temp = 0;
            var max = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (max < values[i])
                {
                    max = values[i];
                    temp = i;
                }
            }
            int School = values[0];
            int Crime = values[1];
            int Rent = values[2];
            int Hospital = values[3];
            int Distance = values[4];
            int Station = values[5];
            int Supermarket = values[6];
            int Parks = values[7];
            int bedroom = values[8];
            ////var test2 = test1.Where(c => c.NormCrime >= Crime && c.NormSchools >= School && c.NormRent >= Rent && c.NormHospital >= Hospital && c.NormDistance >= Distance && c.NormStation >= Station && c.NormSupermarket >= Supermarket);
            ////IEnumerable<Housing_Results> test3 = test2.Select(s => new { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList();
            ////Debug.WriteLine(test3.ToList());
            ///*IEnumerable<Housing> query = (from res in db.Housings
            //                              select
            //                                   {Suburb = res.Suburb,SchoolNo = res.SchoolNo,Rent = res.Rent,StationNo = res.StationNo,SupermarketNo = res.SupermarketNo,NormSupermarket = res.NormSupermarket, NormStation = res.NormStation, NormSchools = res.NormSchools, NormRent = res.NormRent, NormHospital = res.NormHospital, NormDistance = res.NormDistance, NormCrime = res.NormCrime, HospitalNo = res.HospitalNo, Distance = res.Distance, CrimeNo = res.CrimeNo, Buy_Price = res.Buy_Price })
            //                                   .Where(c => c.NormCrime >= Crime && c.NormSchools >= School && c.NormRent >= Rent && c.NormHospital >= Hospital && c.NormDistance >= Distance && c.NormStation >= Station && c.NormSupermarket >= Supermarket).ToList();
            //*/
            ///*IEnumerable<Housing> query = from res in db.Housings
            //                              .Select(res => res.Suburb,res.SchoolNo,res.Rent,res.StationNo, res.SupermarketNo, res.NormSupermarket,  res.NormStation,  res.NormSchools,  res.NormRent,  res.NormHospital,  res.NormDistance,  res.NormCrime,  res.HospitalNo,  res.Distance,  res.CrimeNo, res.Buy_Price )
            //                                   .where(c => c.NormCrime >= Crime && c.NormSchools >= School && c.NormRent >= Rent && c.NormHospital >= Hospital && c.NormDistance >= Distance && c.NormStation >= Station && c.NormSupermarket >= Supermarket).ToList();

            //IEnumerable<Housing_Results> test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo });
            //*/
            var query = from c in db.Housings
                        where (c.NormCrime >= Crime && c.NormSchool >= School && c.NormHospital >= Hospital && c.NormDistance >= Distance && c.NormStation >= Station && c.NormSupermarket >= Supermarket && c.NormPark >= Parks)
                        select c;
            switch(bedroom)
            {
                case 2:
                    query = query.Where(s => s.NormRent2br >= Rent);
                    break;
                case 3:
                    query = query.Where(s => s.NormRent3br >= Rent);
                    break;
                case 4:
                    query = query.Where(s => s.NormRent4br >= Rent);
                    break;
            }
            //switch(community)
            //{
            //    case "Yes":
            //        query = query.Where(s => s.ChineseCommunities > 0);
            //        break;
            //}
            //switch (clinics)
            //{
            //    case "Yes":
            //        query = query.Where(s => s.ChineseClinics > 0);
            //        break;
            //}

            if (community == "Yes")
            {
                TempData["Communities_EN"] = "true";
            }
            else
            {
                TempData["Communities_EN"] = "false";
            }
            if (clinics == "Yes")
            {
                TempData["Clinics_EN"] = "true";
            }
            else
            {
                TempData["Clinics_EN"] = "false";
            }
            switch (population)
            {
                case "High":
                    query = query.Where(s => s.ChinesePopulation == "High");
                    break;
                case "Medium":
                    query = query.Where(s => s.ChinesePopulation == "High" || s.ChinesePopulation == "Medium");
                    break;
                case "Low":
                    query = query.Where(s => s.ChinesePopulation == "High" || s.ChinesePopulation == "Medium" || s.ChinesePopulation == "Low");
                    break;
            }
            //var test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, StationNo = s.Station_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude}).ToList().Take(3);
            var test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, ChinesePopulation = s.ChinesePopulation, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No,Train_No = s.Train_No,Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().Take(3);
            switch (temp)
            {
                case 0:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderByDescending(t => t.SchoolNo).Take(3);
                    break;
                case 1:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderBy(s => s.CrimeNo).Take(3);
                    break;
                case 2:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderBy(t => t.Rent).Take(3);
                    break;
                case 3:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderByDescending(t => t.HospitalNo).Take(3);
                    break;
                case 4:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderBy(t => t.Distance).Take(3);
                    break;
                case 5:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderByDescending(t => t.BusStop_No).Take(3);
                    break;
                case 6:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderByDescending(t => t.SupermarketNo).Take(3);
                    break;
                case 7:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No }).ToList().OrderByDescending(t => t.ParkNo).Take(3);
                    break;
            }
            if(test3 == null || !test3.Any()) { ViewBag.noresults = true; }
            Session["Suburbs"] = test3.Select(t => t.Suburb).ToList();
            return View(test3);
        }

        [HttpPost]
        public ActionResult Results(String SchoolType)
        {
            Debug.WriteLine(SchoolType);
            return RedirectToAction("UpdateResults", "Housings1", new { @schooltype = SchoolType });
        }

        public ActionResult SuburbDetails(String suburb)
        {
            ViewBag.SchoolNoResults = false;
            ViewBag.ClinicNoResults = false;
            ViewBag.ClinicNoResults = false;
            ViewBag.HospitalNoResults = false;
            var list1 = new List<ChineseCommunity>();
            var list2 = new List<ChineseClinic>();
            String community = TempData["Communities_EN"] as String;
            String clinics = TempData["Clinics_EN"] as String;

            MyViewModel viewModel = new MyViewModel();
            switch (community)
            {
                case "true":
                    {
                        viewModel.Community_Details = (from c in db.ChineseCommunities
                                                       where (c.Suburb == suburb)
                                                       select c).OrderByDescending(k => k.Rating).ToList();
                        ViewBag.Communities_Display = true;
                        break;
                    }
                case "false":
                    {
                        ViewBag.Communities_Display = false;
                        viewModel.Community_Details = list1; break;
                    }
            }
            switch (clinics)
            {
                case "true":
                    {

                        viewModel.Clinic_Details = (from c in db.ChineseClinics
                                                    where (c.Suburb == suburb)
                                                    select c).OrderByDescending(k => k.Rating).ToList();
                        ViewBag.Clinics_Display = true;
                        break;
                    }
                case "false":
                    {
                        ViewBag.Clinics_Display = false;
                        viewModel.Clinic_Details = list2; break;
                    }
            }
            viewModel.Housing_Details = (from c in db.Housings
                        where (c.Suburb == suburb)
                        select c).ToList();
            viewModel.School_Details = (from c in db.SchoolDetails
                        where (c.Suburb == suburb)
                        select c).OrderByDescending(k => k.Rating).ToList();
            viewModel.Hospital_Details = (from c in db.HospitalDetails
                          where (c.Suburb == suburb)
                          select c).OrderByDescending(k => k.Rating).ToList();
            viewModel.Bus_Details = (from c in db.BusStations
                                     where (c.Suburb == suburb)
                                     select c).ToList();
            viewModel.Park_Details = (from c in db.Parks
                                     where (c.Suburb == suburb)
                                     select c).ToList();
            viewModel.Train_Details = (from c in db.TrainStations
                                     where (c.Suburb == suburb)
                                     select c).ToList();
            viewModel.Tram_Details = (from c in db.TramStations
                                      where (c.Suburb == suburb)
                                      select c).ToList();
            viewModel.Supermarket_Details = (from c in db.Supermarkets
                                             where (c.Suburb == suburb)
                                             select c).ToList();
            if (viewModel.School_Details == null || !viewModel.School_Details.Any())
            {
                ViewBag.SchoolNoResults = true;
            }
            if (viewModel.Clinic_Details == null || !viewModel.Clinic_Details.Any())
            {
                ViewBag.ClinicNoResults = true;
            }
            if (viewModel.Community_Details == null || !viewModel.Community_Details.Any())
            {
                ViewBag.CommunityNoResults = true;
            }
            if (viewModel.Hospital_Details == null || !viewModel.Hospital_Details.Any())
            {
                ViewBag.HospitalNoResults = true;
            }
            return View(viewModel);
        }

        //public ActionResult SuburbDetails(String Suburb)
        //{
        //    var query1 = from c in db.SchoolDetails
        //                 where (c.Suburb == Suburb)
        //                 select c;
        //    var test1 = query1.ToList().Select(s => new Suburb_Details { School_Name = s.School_Name, School_Address = s.Address, School_Type = s.School_Type, School_URL = s.URL, School_Rating = s.Rating }).ToList();

        //    var query2 = from c in db.HospitalDetails
        //                 where (c.Suburb == Suburb)
        //                 select c;
        //    var test2 = query2.ToList().Select(s => new Suburb_Details { Hospital_Name = s.Hospital_Name, Hospital_Address = s.Address, Hospital_Type = s.Hospital_Type, Hospital_URL = s.URL, Hospital_Rating = s.Rating }).ToList();

        //    var query3 = from c in db.Housings
        //                 where (c.Suburb == Suburb)
        //                 select c;
        //    var test3 = query3.ToList().Select(s => new Suburb_Details { Suburb = s.Suburb, Rent2br = s.Rent2br, Rent3br = s.Rent3br, Rent4br = s.Rent4br, RentAverageAll = s.RentAverageAll, SchoolNo = s.SchoolNo, StationNo = s.Station_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Suburb_Latitude = s.Latitude, Suburb_Longitude = s.Longitude }).ToList();
        //    var test4 = test1.Concat(test2).Concat(test3).ToList();
        //    var test5 = test4.Select(s => new Suburb_Details
        //    {
        //        Suburb = s.Suburb,
        //        Rent2br = s.Rent2br,
        //        Rent3br = s.Rent3br,
        //        Rent4br = s.Rent4br,
        //        RentAverageAll = s.RentAverageAll,
        //        SchoolNo = s.SchoolNo,
        //        StationNo = s.StationNo,
        //        SupermarketNo = s.SupermarketNo,
        //        HospitalNo = s.HospitalNo,
        //        Distance = s.Distance,
        //        CrimeNo = s.CrimeNo,
        //        ParkNo = s.ParkNo,
        //        Suburb_Latitude = s.Suburb_Latitude,
        //        Suburb_Longitude = s.Suburb_Longitude,
        //        School_Name = s.School_Name,
        //        School_Address = s.School_Address,
        //        School_Type = s.School_Type,
        //        School_URL = s.School_URL,
        //        School_Rating = s.School_Rating,
        //        Hospital_Name = s.Hospital_Name,
        //        Hospital_Address = s.Hospital_Address,
        //        Hospital_Type = s.Hospital_Type,
        //        Hospital_URL = s.Hospital_URL,
        //        Hospital_Rating = s.Hospital_Rating
        //    }).ToList();
        //    return View(test5);
        //}

        ///Chinese View Controllers
        [HttpGet]
        public ActionResult ResultsA_CN(List<int> valuesa, String community, String population, String clinics)
        {
            IQueryable<Housing> test1 = from p in db.Housings select p;
            /*var test1 = db.Housings.AsQueryable();
            var test1 = test1.Where(t => t.NormSchools >= values[0]);
            var test1 = test1.Where(t => t.NormCrime >= values[1]);*/
            /* var test2 = test1
                 .Select(s => new { s.Suburb, s.NormRent, s.NormDistance, s.NormHospital,s. })
                 .Where(c => c.NormRent >= values[1] && c.NormHospital >= values[2] && c.NormDistance >= values[2]);
             */

            int[] values = valuesa.ToArray();
            var temp = 0;
            var max = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (max < values[i])
                {
                    max = values[i];
                    temp = i;
                }
            }
            int School = values[0];
            int Crime = values[1];
            int Rent = values[2];
            int Hospital = values[3];
            int Distance = values[4];
            int Station = values[5];
            int Supermarket = values[6];
            int Parks = values[7];
            int bedroom = values[8];
      


            var query = from c in db.Housings
                        where (c.NormCrime >= Crime && c.NormSchool >= School && c.NormHospital >= Hospital && c.NormDistance >= Distance && c.NormStation >= Station && c.NormSupermarket >= Supermarket && c.NormPark >= Parks)
                        select c;
            switch (bedroom)
            {
                case 2:
                    query = query.Where(s => s.NormRent2br >= Rent);
                    break;
                case 3:
                    query = query.Where(s => s.NormRent3br >= Rent);
                    break;
                case 4:
                    query = query.Where(s => s.NormRent4br >= Rent);
                    break;
            }
            //switch (community)
            //{
            //    case "Yes":
            //        query = query.Where(s => s.ChineseCommunities > 0);
            //        break;
            //}
            //switch (clinics)
            //{
            //    case "Yes":
            //        query = query.Where(s => s.ChineseClinics > 0);
            //        break;
            //}

            if (community == "Yes")
            {
                TempData["Communities"] = "true";
            }
            else
            {
                TempData["Communities"] = "false";
            }
            if (clinics == "Yes")
            {
                TempData["Clinics"] = "true";
            }
            else
            {
                TempData["Clinics"] = "false";
            }

            switch (population)
            {
                case "High":
                    query = query.Where(s => s.ChinesePopulation == "High");
                    break;
                case "Medium":
                    query = query.Where(s => s.ChinesePopulation == "High" || s.ChinesePopulation == "Medium");
                    break;
                case "Low":
                    query = query.Where(s => s.ChinesePopulation == "High" || s.ChinesePopulation == "Medium" || s.ChinesePopulation == "Low");
                    break;
            }
            //var test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, StationNo = s.Station_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude}).ToList().Take(3);
            var test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, ChinesePopulation = s.ChinesePopulation, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().Take(3);
            switch (temp)
            {
                case 0:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderByDescending(t => t.SchoolNo).Take(3);
                    break;
                case 1:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderBy(s => s.CrimeNo).Take(3);
                    break;
                case 2:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderBy(t => t.Rent).Take(3);
                    break;
                case 3:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderByDescending(t => t.HospitalNo).Take(3);
                    break;
                case 4:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderBy(t => t.Distance).Take(3).OrderBy(t => t.Distance);
                    break;
                case 5:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderByDescending(t => t.BusStop_No).Take(3);
                    break;
                case 6:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No, Latitude = s.Latitude, Longitude = s.Longitude }).ToList().OrderByDescending(t => t.SupermarketNo).Take(3);
                    break;
                case 7:
                    test3 = query.ToList().Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.RentAverageAll, SchoolNo = s.SchoolNo, BusStop_No = s.BusStop_No, Train_No = s.Train_No, Tram_No = s.Tram_No, SupermarketNo = s.Supermarket_No, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo, ParkNo = s.Park_No }).ToList().OrderByDescending(t => t.ParkNo).Take(3);
                    break;
            }
            if (test3 == null || !test3.Any()) { ViewBag.noresults = true; }
            Session["Suburbs"] = test3.Select(t => t.Suburb).ToList();
            return View(test3);
        }

        public ActionResult SuburbDetails_CN(String suburb)
        {
            ViewBag.SchoolNoResults = false;
            ViewBag.ClinicNoResults = false;
            ViewBag.ClinicNoResults = false;
            ViewBag.HospitalNoResults = false;
            MyViewModel viewModel = new MyViewModel();
            var list1 = new List<ChineseCommunity>();
            var list2 = new List<ChineseClinic>();
            String community = TempData["Communities"] as String;
            String clinics = TempData["Clinics"] as String;
            switch (community)
            {
                case "true":
                    {
                        viewModel.Community_Details = (from c in db.ChineseCommunities
                                                       where (c.Suburb == suburb)
                                                       select c).OrderByDescending(k => k.Rating).ToList();
                        ViewBag.Communities_Display = true;
                        break;
                    }
                case "false":
                    {
                        ViewBag.Communities_Display = false;
                        viewModel.Community_Details = list1; break;
                    }
            }
            switch (clinics)
            {
                case "true":
                    {

                        viewModel.Clinic_Details = (from c in db.ChineseClinics
                                                    where (c.Suburb == suburb)
                                                    select c).OrderByDescending(k => k.Rating).ToList();
                        ViewBag.Clinics_Display = true;
                        break;
                    }
                case "false":
                    {
                        ViewBag.Clinics_Display = false;
                        viewModel.Clinic_Details = list2; break;
                    }
            }
            viewModel.Housing_Details = (from c in db.Housings
                                         where (c.Suburb == suburb)
                                         select c).ToList();
            viewModel.School_Details = (from c in db.SchoolDetails
                                        where (c.Suburb == suburb)
                                        select c).ToList().OrderByDescending(k => k.Rating).ToList();
            viewModel.Hospital_Details = (from c in db.HospitalDetails
                                          where (c.Suburb == suburb)
                                          select c).ToList().OrderByDescending(k => k.Rating).ToList();
            viewModel.Bus_Details = (from c in db.BusStations
                                     where (c.Suburb == suburb)
                                     select c).ToList();
            viewModel.Park_Details = (from c in db.Parks
                                      where (c.Suburb == suburb)
                                      select c).ToList();
            viewModel.Train_Details = (from c in db.TrainStations
                                       where (c.Suburb == suburb)
                                       select c).ToList();
            viewModel.Tram_Details = (from c in db.TramStations
                                      where (c.Suburb == suburb)
                                      select c).ToList();
            viewModel.Supermarket_Details = (from c in db.Supermarkets
                                             where (c.Suburb == suburb)
                                             select c).ToList();
            if (viewModel.School_Details == null || !viewModel.School_Details.Any())
            {
                ViewBag.SchoolNoResults = true;
            }
            if (viewModel.Clinic_Details == null || !viewModel.Clinic_Details.Any())
            {
                ViewBag.ClinicNoResults = true;
            }
            if (viewModel.Community_Details == null || !viewModel.Community_Details.Any())
            {
                ViewBag.CommunityNoResults = true;
            }
            if (viewModel.Hospital_Details == null || !viewModel.Hospital_Details.Any())
            {
                ViewBag.HospitalNoResults = true;
            }
            return View(viewModel);
        }
    }
}

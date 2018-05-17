using MvcJqGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using WareItsMade.com.Models;
using WareItsMade.com.Controllers;

namespace WareItsMade.com.Controllers
{
    //[RequireHttps]
    public class HomeController : BaseController
    {
        private WaresEntities db = new WaresEntities();

        /// GET: /Home/Index
        /// <summary>
        /// GET: /Home/Index
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult Index()
        {
            string selectedCountryId = (SessionData != null && SessionData.SelectedCountryId != null)
                ? SessionData.SelectedCountryId
                : "US";

            ViewBag.Countrys = new SelectList(db.Iso3166.OrderBy(c => c.CountryTitle), "CountryId", "CountryTitle", selectedCountryId);

            return View();
        }

        /// POST: /Home/Index
        /// <summary>
        /// POST: /Home/Index
        /// </summary>
        /// <returns>View()</returns>
        [HttpPost]
        public ActionResult Index(SessionData model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Discover", "Home", model);
            }
            return View(model);
        }

        /// GET: /Home/Discover
        /// <summary>
        /// GET: /Home/Discover
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult Discover()
        {
            ViewBag.Countrys = new SelectList(db.Iso3166.OrderBy(c => c.CountryTitle), "CountryId", "CountryTitle", SessionData.SelectedCountryId);

            ViewBag.Segments = new SelectList(db.Segments.OrderBy(s => s.SegmentTitle), "SegmentId", "SegmentTitle");
            ViewBag.Familys = new SelectList(db.Familys.OrderBy(f => f.FamilyTitle), "FamilyId", "FamilyTitle");
            ViewBag.Classes = new SelectList(db.Classes.OrderBy(c => c.ClassTitle), "ClassId", "ClassTitle");
            ViewBag.Commoditys = new SelectList(db.Commoditys.OrderBy(c => c.CommodityTitle), "CommodityId", "CommodityTitle");

            SessionData.WaresVisible = "false";

            return View();
        }

        /// GET: /Home/About
        /// <summary>
        /// GET: /Home/About
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult About()
        {
            ViewBag.Message = "We connect people with goods and services (wares) from any country.";

            return View();
        }

        /// GET: /Home/Contact
        /// <summary>
        /// GET: /Home/Contact
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Ware It's Made .com";

            return View();
        }


        public JsonResult GetFamilysJson(string segmentId = null, string selectedFamilyId = null)
        {
            return Json(GetFamilysSelectList(segmentId, selectedFamilyId), JsonRequestBehavior.AllowGet);
        }
        public SelectList GetFamilysSelectList(string segmentId = null, string selectedFamilyId = null)
        {
            SelectList familysSelectList;
            if (!string.IsNullOrWhiteSpace(segmentId))
                familysSelectList = new SelectList(db.Familys.OrderBy(f => f.FamilyTitle).Where(f => f.SegmentId == segmentId), "FamilyId", "FamilyTitle", selectedFamilyId);
            else
                familysSelectList = new SelectList(db.Familys.OrderBy(f => f.FamilyTitle), "FamilyId", "FamilyTitle", selectedFamilyId);
            return familysSelectList;
        }

        public JsonResult GetClassesJson(string familyId = null, string selectedClassId = null)
        {
            return Json(GetClassesSelectList(familyId, selectedClassId), JsonRequestBehavior.AllowGet);
        }
        public SelectList GetClassesSelectList(string familyId = null, string selectedClassId = null)
        {
            SelectList classesSelectList;
            if (!string.IsNullOrWhiteSpace(familyId))
                classesSelectList = new SelectList(db.Classes.OrderBy(c => c.ClassTitle).Where(c => c.FamilyId == familyId), "ClassId", "ClassTitle", selectedClassId);
            else
                classesSelectList = new SelectList(db.Classes.OrderBy(c => c.ClassTitle), "ClassId", "ClassTitle", selectedClassId);
            return classesSelectList;
        }

        public JsonResult GetCommoditysJson(string classId = null, string selectedCommodityId = null)
        {
            return Json(GetCommoditysSelectList(classId, selectedCommodityId), JsonRequestBehavior.AllowGet);
        }
        public SelectList GetCommoditysSelectList(string classId = null, string selectedCommodityId = null)
        {
            SelectList commoditysSelectList;
            if (!string.IsNullOrWhiteSpace(classId))
                commoditysSelectList = new SelectList(db.Commoditys.OrderBy(c => c.CommodityTitle).Where(c => c.ClassId == classId), "CommodityId", "CommodityTitle", selectedCommodityId);
            else
                commoditysSelectList = new SelectList(db.Commoditys.OrderBy(c => c.CommodityTitle), "CommodityId", "CommodityTitle", selectedCommodityId);
            return commoditysSelectList;
        }

        public JsonResult SearchCommoditysJson(string search = null)
        {
            return Json(SearchCommoditysSelectList(search), JsonRequestBehavior.AllowGet);
        }
        public SelectList SearchCommoditysSelectList(string search = null)
        {
            SelectList commoditysSelectList = new SelectList(new List<SelectListItem> { new SelectListItem() });
            if (!string.IsNullOrWhiteSpace(search))
                commoditysSelectList = new SelectList(db.Commoditys.OrderBy(c => c.CommodityTitle).Where(c => c.CommodityTitle.Contains(search)).Take(50), "CommodityId", "CommodityTitle");
            if (commoditysSelectList != null && commoditysSelectList.Count() > 100)
                commoditysSelectList = new SelectList(new List<SelectListItem> { new SelectListItem() });
            return commoditysSelectList;
        }


        /// <summary>
        /// AJAX request, retrieves data for basic grid
        /// </summary>
        /// <param name="gridSettings">Settings received from jqGrid request</param>
        /// <returns>JSON view containing data for basic grid</returns>
        public ActionResult GridDataBasic(GridSettings gridSettings)
        {
            List<GetWeightedCommodities_Result> wares = new List<GetWeightedCommodities_Result>();

            if (SessionData.WaresVisible == "true")
            {
                wares = db.GetWeightedCommodities(
                    SessionData.SelectedCommodityId,
                    SessionData.SelectedCountryId,
                    SessionData.OwnershipWeight,
                    SessionData.CapitalWeight,
                    SessionData.LaborWeight,
                    SessionData.LandWeight).ToList();
            }

            if (wares != null && wares.Count > 0)
                Session["caption"] = wares[0].CommodityTitle;

            var orderedWares = OrderWares(wares.AsQueryable(), gridSettings.SortColumn, gridSettings.SortOrder);

            if (gridSettings.IsSearch)
            {
                orderedWares = gridSettings.Where.rules.Aggregate(orderedWares, FilterWares);
            }

            wares = orderedWares.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize).ToList();

            var totalWares = CountWares(gridSettings, wares.AsQueryable());

            var jsonData = new
            {
                total = totalWares / gridSettings.PageSize + 1,
                page = gridSettings.PageIndex,
                records = totalWares,
                rows = (
                    from ware in wares
                    select new
                    {
                        id = ware.ID,
                        cell = new[] 
						{
							ware.ID.ToString(),
							ware.CountryId,
							ware.CommodityTitle,
							ware.ObjectId,
							ware.NameName,
							ware.WeightedPercentage.ToString(),
							ware.UserName,
							ware.CommodityId.ToString(),
						}
                    }
                ).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        public int CountWares(GridSettings gridSettings, IQueryable<GetWeightedCommodities_Result> wares)
        {
            return gridSettings.IsSearch ? gridSettings.Where.rules.Aggregate(wares, FilterWares).Count() : wares.Count();
        }

        private static IQueryable<GetWeightedCommodities_Result> FilterWares(IQueryable<GetWeightedCommodities_Result> wares, Rule rule)
        {
            switch (rule.field)
            {
                case "ID":
                    return wares.Where(w => w.ID.ToString() == rule.data);

                case "CountryId":
                    return wares.Where(w => w.CountryId.ToLower().Contains(rule.data.ToLower()));

                case "CommodityTitle":
                    return wares.Where(w => w.CommodityTitle.ToLower().Contains(rule.data.ToLower()));

                case "ObjectId":
                    return wares.Where(w => w.ObjectId.ToLower().Contains(rule.data.ToLower()));

                case "NameName":
                    return wares.Where(w => w.NameName.ToLower().Contains(rule.data.ToLower()));

                case "WeightedPercentage":
                    int intResult;
                    return !int.TryParse(rule.data, out intResult) ? wares : wares.Where(w => w.WeightedPercentage == intResult);

                case "UserName":
                    return wares.Where(w => w.UserName.ToLower().Contains(rule.data.ToLower()));

                case "CommodityId":
                    double doubleResult;
                    return !double.TryParse(rule.data, out doubleResult) ? wares : wares.Where(w => w.CommodityId == doubleResult);

                default:
                    return wares;
            }
        }

        private static IQueryable<GetWeightedCommodities_Result> OrderWares(IQueryable<GetWeightedCommodities_Result> wares, string sortColumn, string sortOrder)
        {
            switch (sortColumn)
            {
                case "ID":
                    return (sortOrder == "desc") ? wares.OrderByDescending(w => Convert.ToInt64(w.ID)) : wares.OrderBy(w => Convert.ToInt64(w.ID));

                case "CountryId":
                    return (sortOrder == "desc") ? wares.OrderByDescending(w => w.CountryId) : wares.OrderBy(w => w.CountryId);

                case "CommodityTitle":
                    return (sortOrder == "desc") ? wares.OrderByDescending(w => w.CommodityTitle) : wares.OrderBy(w => w.CommodityTitle);

                case "ObjectId":
                    return (sortOrder == "desc") ? wares.OrderByDescending(w => w.ObjectId) : wares.OrderBy(w => w.ObjectId);

                case "NameName":
                    return (sortOrder == "desc") ? wares.OrderByDescending(w => w.NameName) : wares.OrderBy(w => w.NameName);

                case "WeightedPercentage":
                    return (sortOrder == "desc") ? wares.OrderByDescending(w => Convert.ToInt64(w.WeightedPercentage)) : wares.OrderBy(w => Convert.ToInt64(w.WeightedPercentage));

                case "UserName":
                    return (sortOrder == "desc") ? wares.OrderByDescending(w => w.UserName) : wares.OrderBy(w => w.UserName);

                case "CommodityId":
                    return (sortOrder == "desc") ? wares.OrderByDescending(w => Convert.ToInt64(w.CommodityId)) : wares.OrderBy(w => Convert.ToInt64(w.CommodityId));

                default:
                    return wares;
            }
        }
    }
}
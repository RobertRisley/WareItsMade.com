using WareItsMade.com.Models;
using System.Web.Mvc;

namespace WareItsMade.com.Controllers
{
    public class SessionDataController : Controller
    {
        public static SessionData DefaultSessionData = new SessionData
        {
            SelectedCountryId = "US"
            , SelectedCommodityId = "43232309"

            , OwnershipWeight = 100
            , CapitalWeight = 50
            , LaborWeight = 25
            , LandWeight = 5

            , AddressVisible = "false"
            , OwnershipVisible = "true"
            , PasswordVisible = "false"
            , ToolingVisible = "false"
            , WaresVisible = "false"
            , WeightVisible = "false"

            , DefaultCommodityId = "43232309"
            , DefaultOwn = "US"
            , DefaultTool = "US"
        };

        public JsonResult Load()
        {
			if (Session["SessionData"] != null)
				DefaultSessionData = Session["SessionData"] as SessionData;
			else
				Session["SessionData"] = DefaultSessionData;

			return new JsonResult() { Data = DefaultSessionData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

		public JsonResult Save(SessionData sessionData)
		{
			Session["SessionData"] = sessionData;

			return new JsonResult() { Data = sessionData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

        public SessionData Get()
        {
            return Session["SessionData"] as SessionData;
        }

    }
}

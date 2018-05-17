
namespace WareItsMade.com.Models
{
	public class SessionData
	{
		public string SelectedCountryId { get; set; }
		public string SelectedCommodityId { get; set; }

		public int OwnershipWeight { get; set; }
		public int CapitalWeight { get; set; }
		public int LaborWeight { get; set; }
		public int LandWeight { get; set; }

		public string AddressVisible { get; set; }
		public string PasswordVisible { get; set; }
		public string OwnershipVisible { get; set; }
		public string ToolingVisible { get; set; }
		public string WaresVisible { get; set; }
		public string WeightVisible { get; set; }

		public string DefaultOwn { get; set; }
		public string DefaultTool { get; set; }
		public string DefaultCommodityId { get; set; }
	}
}
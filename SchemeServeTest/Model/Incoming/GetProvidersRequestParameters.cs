namespace SchemeServeTestModel.Incoming
{
	public class GetProvidersRequestParameters
	{
		public string[]? Constituency
		{
			get; set;
		}

		public string[]? LocalAuthority
		{
			get; set;
		}

		public string[]? InspectionDirectorate
		{
			get; set;
		}

		public string[]? NonPrimaryInspectionCategoryCode
		{
			get; set;
		}

		public string[]? NonPrimaryInspectionCategoryName
		{
			get; set;
		}

		public string[]? PrimaryInspectionCategoryCode
		{
			get; set;
		}

		public string[]? PrimaryInspectionCategoryName
		{
			get; set;
		}

		public string[]? OverallRating
		{
			get; set;
		}

		public string[]? Region
		{
			get; set;
		}

		public string[]? RegulatedActivity
		{
			get; set;
		}

		public string[]? ReportType
		{
			get; set;
		}

		public int? PerPage
		{
			get; set;
		}

		public int? Page
		{
			get; set;
		}
	}
}

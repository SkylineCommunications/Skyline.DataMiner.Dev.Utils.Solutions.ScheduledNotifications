namespace Skyline.DataMiner.Utils.ScheduledNotifications.Models
{
	using Skyline.DataMiner.SDM;

	/// <summary>
	/// Represents a Template for scheduled notifications.
	/// </summary>
	[GenerateExposers]
	[SdmDomStorage("(slc)schedulednotification")]
	public class Template : SdmObject<Template>
	{
		/// <summary>
		/// Gets or sets the template name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the Dashboard file path of the template.
		/// </summary>
		public string DashboardFilePath { get; set; }

		/// <summary>
		/// Gets or sets the notification type.
		/// </summary>
		public string OriginSolution { get; set; }
	}
}

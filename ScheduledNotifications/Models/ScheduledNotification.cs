namespace Skyline.DataMiner.Utils.ScheduledNotifications.Models
{
	using System;

	using Skyline.DataMiner.SDM;

	/// <summary>
	/// Represents the type of notification schedule.
	/// </summary>
	public enum NotificationType
	{
		Daily,
		Weekly,
		Monthly,
	}

	/// <summary>
	/// Represents a scheduled notification.
	/// </summary>
	[GenerateExposers]
	[SdmDomStorage("(slc)schedulednotification")]
	public class ScheduledNotification : SdmObject<ScheduledNotification>
	{
		/// <summary>
		/// Gets or sets the user's email address.
		/// </summary>
		public string UserEmail { get; set; }

		/// <summary>
		/// Gets or sets the item identifier.
		/// </summary>
		public string ItemId { get; set; }

		/// <summary>
		/// Gets or sets the notification type.
		/// </summary>
		public NotificationType NotificationType { get; set; }

		/// <summary>
		/// Gets or sets the origin solution of the notification.
		/// </summary>
		public string OriginSolution { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the notification is enabled or disabled.
		/// </summary>
		public bool Status { get; set; }

		/// <summary>
		/// Gets or sets the template identifier associated with the notification.
		/// </summary>
		public Guid TemplateId { get; set; } = Guid.Empty;
	}
}

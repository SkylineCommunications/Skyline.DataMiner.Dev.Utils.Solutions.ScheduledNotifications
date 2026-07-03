namespace Skyline.DataMiner.Utils.ScheduledNotifications.Models
{
	using System;

	using Skyline.DataMiner.SDM;

	/// <summary>
	/// Represents the type of notification schedule.
	/// </summary>
	public enum NotificationType
	{
		Instant,
		Daily,
		Weekly,
		Monthly,
	}

	/// <summary>
	/// Represents a scheduled notification.
	/// </summary>
	[GenerateExposers]
	[SdmDomStorage("schedulednotification")]
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
		/// Gets or sets the start time of the notification.
		/// </summary>
		public DateTime StartTime { get; set; }
	}
}

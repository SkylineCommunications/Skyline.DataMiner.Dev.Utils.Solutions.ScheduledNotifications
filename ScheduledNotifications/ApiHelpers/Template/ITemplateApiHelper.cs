namespace Skyline.DataMiner.Utils.Solutions.ScheduledNotifications.ApiHelpers.Template
{
	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.SDM;
	using Skyline.DataMiner.Utils.Solutions.ScheduledNotifications.Models;

	public interface ITemplateApiHelper
	{
		IConnection Connection { get; }

		IBulkRepository<Template> Templates { get; }
	}
}

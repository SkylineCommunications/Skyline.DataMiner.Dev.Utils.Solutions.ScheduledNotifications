namespace Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.ApiHelpers.Template
{
	using Skyline.DataMiner.Dev.Utils.Solutions.ScheduledNotifications.Models;
	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.SDM;

	public interface ITemplateApiHelper
	{
		IConnection Connection { get; }

		IBulkRepository<Template> Templates { get; }
	}
}

namespace Skyline.DataMiner.Utils.ScheduledNotifications.ApiHelpers
{
	using System;

	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.SDM;
	using Skyline.DataMiner.Utils.ScheduledNotifications.Models;

	using TemplateDomRepository = DataMiner.Utils.ScheduledNotifications.Repositories.TemplateDomRepository;

	/// <summary>
	/// Helper class for interacting with ScheduledNotifications in DataMiner.
	/// </summary>
	public class TemplateApiHelper : ITemplateApiHelper
	{
		private readonly IBulkRepository<Template> _templates;

		/// <summary>
		/// Initializes a new instance of the <see cref="TemplateApiHelper"/> class.
		/// </summary>
		/// <param name="connection">The connection to the DataMiner system.</param>
		/// <exception cref="ArgumentNullException">Thrown when the <paramref name="connection"/> is null.</exception>
		public TemplateApiHelper(IConnection connection)
		{
			Connection = connection ?? throw new ArgumentNullException(nameof(connection));

			_templates = new TemplateDomRepository(connection);
		}

		/// <summary>
		/// Gets the connection to the DataMiner system.
		/// </summary>
		public IConnection Connection { get; }

		/// <summary>
		/// Gets the repository for managing Templates.
		/// </summary>
		public IBulkRepository<Template> Templates { get { return _templates; } }
	}
}

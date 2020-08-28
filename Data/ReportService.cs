using System;
using System.Collections.Generic;

namespace ReportViewerWebsite.Data
{
    public class ReportService : IReportService
    {
        public IEnumerable<ReportEntry> Generate(int count = 100)
		{
			var rand = new Random();

			for (var i = 0; i < count; ++i)
			{
				var ch = i * 10;
				var temp = rand.Next(115, 150);
				var speed = (rand.NextDouble() * 5.0) + 1.0;

				yield return new ReportEntry
				{
					Chainage = ch,
					Temperature = temp,
					Speed = speed
				};
			}
		}
    }

    public interface IReportService
    {
        IEnumerable<ReportEntry> Generate(int count = 100);
    }
}
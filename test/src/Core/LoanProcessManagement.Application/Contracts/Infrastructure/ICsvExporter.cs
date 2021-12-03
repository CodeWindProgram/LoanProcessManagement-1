using LoanProcessManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}

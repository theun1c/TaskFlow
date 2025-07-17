namespace TaskFlow.Web.Contracts.Requests
{
    public record TaskItemsRequest(
         string Title,
         string Description,
         string Author,
         DateTime StartDate,
         DateTime EndDate
     );
}

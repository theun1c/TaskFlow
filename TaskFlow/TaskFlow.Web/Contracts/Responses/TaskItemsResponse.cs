namespace TaskFlow.Web.Contracts.Responses
{
    public record TaskItemsResponse(
        Guid Id,
        string Title,
        string Description,
        string Author,
        DateTime StartDate,
        DateTime EndDate
    );
}

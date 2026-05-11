namespace AVIASALES.Domain.Routing
{
    public interface IRouteComponent
    {
        string RouteSummary { get; }
        double TotalDistance { get; }
    }
}
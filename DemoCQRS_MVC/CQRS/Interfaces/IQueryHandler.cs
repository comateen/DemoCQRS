namespace DemoCQRS_MVC.CQRS.Interfaces
{
    public interface IQueryHandler <in TQuery, TQueryResult>
    {
        Task<TQueryResult> Handle(TQuery query, CancellationToken cancellation);
    }
}

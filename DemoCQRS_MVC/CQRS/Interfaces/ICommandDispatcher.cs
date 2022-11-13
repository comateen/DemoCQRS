namespace DemoCQRS_MVC.CQRS.Interfaces
{
    public interface ICommandDispatcher
    {
        Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation);
        //LE cancelletaionToken à voir s'il faut le laisser ou pas, c'est là pour envoyer des notifications en cas d'annulation

    }
}

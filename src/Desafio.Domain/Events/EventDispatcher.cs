using Serilog;

namespace Desafio.Domain.Events
{
    public static class EventDispatcher
    {
        public static void Dispatch(DomainEvent domainEvent)
        {
            Log.Information("Evento de domínio disparado: {EventName} em {Time} | Detalhes: {@EventData}",
                domainEvent.EventName,
                domainEvent.OccurredOn,
                domainEvent);
        }
    }
}

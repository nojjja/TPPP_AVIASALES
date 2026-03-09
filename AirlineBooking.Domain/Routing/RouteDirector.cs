using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Routing
{
    // Director — управляет процессом построения маршрута
    public class RouteDirector
    {
        // Строит простой маршрут из одного рейса
        public Route BuildDirectRoute(IRouteBuilder builder, Flight flight)
        {
            builder.AddFlight(flight); // добавляем сегмент
            return builder.Build();    // получаем готовый маршрут
        }
    }
}
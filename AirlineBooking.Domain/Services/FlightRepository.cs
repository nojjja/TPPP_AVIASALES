using AVIASALES.Domain.Entities;
using System;
using System.Collections.Generic;

public class FlightRepository
{
    // Хранит единственный экземпляр репозитория
    private static FlightRepository _instance;

    // Объект блокировки для потокобезопасности
    private static readonly object _lock = new object();

    // Список всех доступных рейсов
    public List<Flight> Flights { get; private set; }

    // Приватный конструктор запрещает создание объекта извне
    private FlightRepository()
    {
        // Инициализация тестовых рейсов
        Flights = new List<Flight>
        {
            new Flight("SU100", "Moscow", "Paris", DateTime.Now.AddHours(5), 200),
            new Flight("AF200", "Paris", "London", DateTime.Now.AddHours(8), 150),
            new Flight("BA300", "London", "New York", DateTime.Now.AddHours(10), 400)
        };
    }

    // Глобальная точка доступа к единственному экземпляру
    public static FlightRepository Instance
    {
        get
        {
            // Ленивая инициализация Singleton
            if (_instance == null)
            {
                lock (_lock) // защита от создания нескольких объектов в потоках
                {
                    if (_instance == null)
                        _instance = new FlightRepository();
                }
            }
            return _instance;
        }
    }
}
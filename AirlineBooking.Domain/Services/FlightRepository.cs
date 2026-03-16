using AVIASALES.Domain.Entities;
using System;
using System.Collections.Generic;

public class FlightRepository
{

    private static FlightRepository _instance;


    private static readonly object _lock = new object();


    public List<Flight> Flights { get; private set; }


    private FlightRepository()
    {
 
        Flights = new List<Flight>
        {
            new Flight("SU100", "Moscow", "Paris", DateTime.Now.AddHours(5), 200),
            new Flight("AF200", "Paris", "London", DateTime.Now.AddHours(8), 150),
            new Flight("BA300", "London", "New York", DateTime.Now.AddHours(10), 400)
        };
    }


    public static FlightRepository Instance
    {
        get
        {

            if (_instance == null)
            {
                lock (_lock) 
                {
                    if (_instance == null)
                        _instance = new FlightRepository();
                }
            }
            return _instance;
        }
    }
}
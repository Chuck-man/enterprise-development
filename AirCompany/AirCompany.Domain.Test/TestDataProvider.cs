namespace AirCompany.Domain.Test;

public class TestDataProvider
{
    
    public List<Aircraft> Aircrafts =
        [
            new() { Id = 1, Model = "Boeing 727", Capacity = 36560.0, Efficiency = 960.0, MaxPassenger = 189 },
            new() { Id = 2, Model = "Airbus A320", Capacity = 41800.0, Efficiency = 900.0, MaxPassenger = 180 },
            new() { Id = 3, Model = "Boeing 777", Capacity = 150000.0, Efficiency = 910.0, MaxPassenger = 500 },
            new() { Id = 4, Model = "ATR 42/72", Capacity = 11250.0, Efficiency = 450.0, MaxPassenger = 50 },
            new() { Id = 5, Model = "MD-80", Capacity = 60000.0, Efficiency = 811.0, MaxPassenger = 172 }
        ];

    public List<Passenger> Passengers =
        [
            new() { Id = 1, PassportNumber = "583471926", FullName = "Michael Robinson" },
            new() { Id = 2, PassportNumber = "129837456", FullName = "Charles Smith" },
            new() { Id = 3, PassportNumber = "937584216", FullName = "John Lawrence" },
            new() { Id = 4, PassportNumber = "621839457", FullName = "Kevin Williams" },
            new() { Id = 5, PassportNumber = "742918365", FullName = "Kevin Fitzgerald" },
        ];

    public List<Flight> Flights;

    public List<RegisteredPassenger> RegisteredPassengers;

    public TestDataProvider()
    {
        Flights =
        [
            new Flight
            {   
                Id = 1, Number = "DL2452", DeparturePoint = "Las Vegas", ArrivalPoint = "Detroit",
                DepartureDate = new DateTime(2022, 09, 11, 02, 00, 00),
                ArrivalDate = new DateTime(2022, 09, 11, 06, 00, 00),
                PlaneType = Aircrafts[1],
                Passengers =
                [
                    new RegisteredPassenger { Id = 1, Number = "RP001", SeatNumber = "12A", BaggageWeight = 0.0, Flight = null, Passenger = Passengers[0] },
                    new RegisteredPassenger { Id = 2, Number = "RP008", SeatNumber = "28C", BaggageWeight = 22.3, Flight = null, Passenger = Passengers[2] },
                    new RegisteredPassenger { Id = 3, Number = "RP023", SeatNumber = "15F", BaggageWeight = 12.3, Flight = null, Passenger = Passengers[1] }
                ]
            },

            new Flight
            {   
                Id = 2, Number = "DL1217", DeparturePoint = "Detroit", ArrivalPoint = "Las Vegas",
                DepartureDate = new DateTime(2023, 01, 22, 11, 30, 00),
                ArrivalDate = new DateTime(2023, 01, 22, 15, 42, 00),
                PlaneType = Aircrafts[0],
                Passengers =
                [
                    new RegisteredPassenger { Id = 4, Number = "RP015", SeatNumber = "31B", BaggageWeight = 10.2, Flight = null, Passenger = Passengers[1] },
                    new RegisteredPassenger { Id = 5, Number = "RP042", SeatNumber = "18D", BaggageWeight = 0, Flight = null, Passenger = Passengers[4] }
                ]
            },

            new Flight
            {   
                Id = 3, Number = "DL2060", DeparturePoint = "Fort Lauderdale", ArrivalPoint = "Orlando",
                DepartureDate = new DateTime(2024, 03, 13, 19, 40, 00),
                ArrivalDate = new DateTime(2024, 03, 20, 01, 13, 00),
                PlaneType = Aircrafts[2],
                Passengers =
                [
                    new RegisteredPassenger { Id = 6, Number = "RP067", SeatNumber = "24A", BaggageWeight = 12.9, Flight = null, Passenger = Passengers[2] }
                ]
            },

            new Flight
            {   
                Id = 4, Number = "DL2132", DeparturePoint = "Detroit", ArrivalPoint = "Atlanta",
                DepartureDate = new DateTime(2024, 07, 27, 21, 00, 00),
                ArrivalDate = new DateTime(2024, 07, 28, 00, 15, 00),
                PlaneType = Aircrafts[3],
                Passengers =
                [
                    new RegisteredPassenger { Id = 7, Number = "RP138", SeatNumber = "19H", BaggageWeight = 20.9, Flight = null, Passenger = Passengers[1] },
                    new RegisteredPassenger { Id = 8, Number = "RP164", SeatNumber = "30K", BaggageWeight = 14.8, Flight = null, Passenger = Passengers[4] },
                    new RegisteredPassenger { Id = 9, Number = "RP187", SeatNumber = "5A", BaggageWeight = 14.5, Flight = null, Passenger = Passengers[0] },
                    new RegisteredPassenger { Id = 10, Number = "RP203", SeatNumber = "29J", BaggageWeight = 23.2 , Flight =  null, Passenger = Passengers[2] }
                ]
            },

            new Flight
            {   
                Id =  5, Number = "DL1302", DeparturePoint = "New York", ArrivalPoint = "Chikago",
                DepartureDate = new DateTime(2023, 12, 26, 20, 15, 00),
                ArrivalDate = new DateTime(2023, 12, 26, 23, 20, 00),
                PlaneType = Aircrafts[4],
                Passengers =
                [
                    new RegisteredPassenger { Id = 11, Number = "RP221", SeatNumber = "12F", BaggageWeight = 17.9, Flight = null, Passenger = Passengers[1] },
                    new RegisteredPassenger { Id = 12, Number = "RP245", SeatNumber = "28B", BaggageWeight = 12.6, Flight = null, Passenger = Passengers[0] },
                    new RegisteredPassenger { Id = 13, Number = "RP269", SeatNumber = "19E", BaggageWeight = 25.3, Flight = null, Passenger = Passengers[4] },
                    new RegisteredPassenger { Id = 14, Number = "RP298", SeatNumber = "31D", BaggageWeight = 10.8, Flight = null, Passenger = Passengers[3] },
                    new RegisteredPassenger { Id = 15, Number = "RP317", SeatNumber = "23C", BaggageWeight = 21.4, Flight = null, Passenger = Passengers[2] }
                ]
            }
        ];

        RegisteredPassengers =
        [
            new RegisteredPassenger { Id = 1, Number = "RP001", SeatNumber = "12A", BaggageWeight = 0.0, Flight = Flights[0], Passenger = Passengers[0] },
            new RegisteredPassenger { Id = 2, Number = "RP008", SeatNumber = "28C", BaggageWeight = 22.3, Flight = Flights[0], Passenger = Passengers[2] },
            new RegisteredPassenger { Id = 3, Number = "RP023", SeatNumber = "15F", BaggageWeight = 15.7, Flight = Flights[1], Passenger = Passengers[0] },
            new RegisteredPassenger { Id = 4, Number = "RP015", SeatNumber = "31B", BaggageWeight = 10.2, Flight = Flights[1], Passenger = Passengers[1] },
            new RegisteredPassenger { Id =  5, Number = "RP042", SeatNumber = "18D", BaggageWeight = 28.1, Flight = Flights[1], Passenger = Passengers[4] },
            new RegisteredPassenger { Id =  6, Number = "RP067", SeatNumber = "24A", BaggageWeight = 12.9, Flight = Flights[2], Passenger = Passengers[2] },
            new RegisteredPassenger { Id =  7, Number = "RP099", SeatNumber = "10E", BaggageWeight = 25.4, Flight = Flights[2], Passenger = Passengers[3] },
            new RegisteredPassenger { Id =  8, Number = "RP112", SeatNumber = "27G", BaggageWeight = 17.6, Flight = Flights[2], Passenger = Passengers[1] },
            new RegisteredPassenger { Id =  9, Number = "RP138", SeatNumber = "19H", BaggageWeight = 20.9, Flight = Flights[3], Passenger = Passengers[1] },
            new RegisteredPassenger { Id =  10, Number = "RP164", SeatNumber = "30K", BaggageWeight = 14.8, Flight = Flights[3], Passenger = Passengers[4] },
            new RegisteredPassenger { Id =  11, Number = "RP187", SeatNumber = "5A", BaggageWeight = 14.5, Flight = Flights[3], Passenger = Passengers[0] },
            new RegisteredPassenger { Id =  12, Number = "RP203", SeatNumber = "29J", BaggageWeight = 23.2, Flight = Flights[3], Passenger = Passengers[2] },
            new RegisteredPassenger { Id =  13, Number = "RP221", SeatNumber = "12F", BaggageWeight = 17.9, Flight = Flights[4], Passenger = Passengers[1] },
            new RegisteredPassenger { Id =  14, Number = "RP245", SeatNumber = "28B", BaggageWeight = 12.6, Flight = Flights[4], Passenger = Passengers[0] },
            new RegisteredPassenger { Id =  15, Number = "RP269", SeatNumber = "19E", BaggageWeight = 25.3, Flight = Flights[4], Passenger = Passengers[4] },
            new RegisteredPassenger { Id =  16, Number = "RP298", SeatNumber = "31D", BaggageWeight = 10.8, Flight = Flights[4], Passenger = Passengers[3] },
            new RegisteredPassenger { Id =  17, Number = "RP317", SeatNumber = "23C", BaggageWeight = 21.4, Flight = Flights[4], Passenger = Passengers[2] }
        ];
    }
}
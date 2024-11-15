using System;
using System.Collections.Generic;
using AirCompany.Domain;

namespace AirCompany.Domain.Test;

public class TestDataProvider
{
    public List<Aircraft> aircrafts = 
        [
            new (1, "Boeing 727", 36560.0, 960.0, 189) { Id = 1 },
            new (2, "Airbus A320", 41800.0, 900.0, 180) { Id = 2 },
            new (3, "Boeing 777", 150000.0, 910.0, 500) { Id = 3 },
            new (4, "ATR 42/72", 11250.0, 450.0, 50) { Id = 4 },
            new (5, "MD-80", 60000.0, 811.0, 172) { Id = 5 }
        ];

    public List<Passenger> passengers =
        [
            new (1, "583471926", "Michael Robinson") { Id = 1 },
            new (2, "129837456", "Charles Smith") { Id = 2 },
            new (3, "937584216", "John Lawrence") { Id = 3 },
            new (4, "621839457", "Kevin Williams") { Id = 4 },
            new (5, "742918365", "Kevin Fitzgerald") { Id = 5 },
        ];

    public List<Flight> flights;
    public List<RegisteredPassenger> registeredPassengers;

    public TestDataProvider()
    {
        flights = new List<Flight>
        {
            new(1, "DL2452", "Las Vegas", "Detroit", new DateTime(2022, 09, 11, 02, 00, 00), new DateTime(2022, 09, 11, 06, 00, 00), aircrafts[1],
            new List<RegisteredPassenger>
                {
                    new (1, "RP001", "12A", 18.5, null, passengers[0]) { Id = 1 },
                    new (2, "RP008", "28C", 22.3, null, passengers[2]) { Id = 2 }
                }

            ) { Id = 1 },

            new(2, "DL1217", "Detroit", "Las Vegas", new DateTime(2023, 01, 22, 11, 30, 00), new DateTime(2023, 01, 22, 15, 42, 00), aircrafts[0],
            new List<RegisteredPassenger>
                {
                    new (3, "RP023", "15F", 15.7, null, passengers[0]) { Id = 3 },
                    new (4, "RP015", "31B", 10.2, null, passengers[1]) { Id = 4 },
                    new (5, "RP042", "18D", 28.1, null, passengers[4]) { Id = 5 }
                }

            ) { Id = 2 },

            new(3, "DL2060", "Fort Lauderdale", "Orlando", new DateTime(2024, 03, 13, 19, 40, 00), new DateTime(2023, 03, 20, 01, 13, 00), aircrafts[2],
            new List<RegisteredPassenger>
                {
                    new (6, "RP067", "24A", 12.9, null, passengers[2]) { Id = 6 },
                    new (7, "RP099", "10E", 25.4, null, passengers[3]) { Id = 7 },
                    new (8, "RP112", "27G", 17.6, null, passengers[1]) { Id = 8 }
                }

            ) { Id = 3 },

            new(4, "DL2132", "San Antonio", "Atlanta", new DateTime(2024, 07, 27, 21, 00, 00), new DateTime(2023, 07, 28, 00, 15, 00), aircrafts[3],
            new List<RegisteredPassenger>
                {
                    new (9, "RP138", "19H", 20.9, null, passengers[1]) { Id = 9 },
                    new (10, "RP164", "30K", 14.8, null, passengers[4]) { Id = 10 },
                    new (11, "RP187", "5A", 14.5, null, passengers[0]) { Id = 11 },
                    new (12, "RP203", "29J", 23.2 , null, passengers[2]) { Id = 12 }
                }

            ) { Id = 4 },

            new(5, "DL1302", "New York", "Chikago", new DateTime(2023, 12, 26, 20, 15, 00), new DateTime(2023, 12, 26, 23, 20, 00), aircrafts[4],
            new List<RegisteredPassenger>
                {
                    new (13, "RP221", "12F", 17.9, null, passengers[1]) { Id = 13 },
                    new (14, "RP245", "28B", 12.6, null, passengers[0]) { Id = 14 },
                    new (15, "RP269", "19E", 25.3, null, passengers[4]) { Id = 15 },
                    new (16, "RP298", "31D", 10.8, null, passengers[3]) { Id = 16 },
                    new (17, "RP317", "23C", 21.4, null, passengers[2]) { Id = 17 }
                }

            ) { Id = 5 }

        };

        registeredPassengers = new List<RegisteredPassenger>
        {
            new (1, "RP001", "12A", 18.5, flights[0], passengers[0]) { Id = 1 },
            new (2, "RP008", "28C", 22.3, flights[0], passengers[2]) { Id = 2 },
            new (3, "RP023", "15F", 15.7, flights[1], passengers[0]) { Id = 3 },
            new (4, "RP015", "31B", 10.2, flights[1], passengers[1]) { Id = 4 },
            new (5, "RP042", "18D", 28.1, flights[1], passengers[4]) { Id = 5 },
            new (6, "RP067", "24A", 12.9, flights[2], passengers[2]) { Id = 6 },
            new (7, "RP099", "10E", 25.4, flights[2], passengers[3]) { Id = 7 },
            new (8, "RP112", "27G", 17.6, flights[2], passengers[1]) { Id = 8 },
            new (9, "RP138", "19H", 20.9, flights[3], passengers[1]) { Id = 9 },
            new (10, "RP164", "30K", 14.8, flights[3], passengers[4]) { Id = 10 },
            new (11, "RP187", "5A", 14.5, flights[3], passengers[0]) { Id = 11 },
            new (12, "RP203", "29J", 23.2 , flights[3], passengers[2]) { Id = 12 },
            new (13, "RP221", "12F", 17.9, flights[4], passengers[1]) { Id = 13 },
            new (14, "RP245", "28B", 12.6, flights[4], passengers[0]) { Id = 14 },
            new (15, "RP269", "19E", 25.3, flights[4], passengers[4]) { Id = 15 },
            new (16, "RP298", "31D", 10.8, flights[4], passengers[3]) { Id = 16 },
            new (17, "RP317", "23C", 21.4, flights[4], passengers[2]) { Id = 17 }

        };

    }

}
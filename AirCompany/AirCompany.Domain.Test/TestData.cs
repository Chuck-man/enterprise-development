using System;
using System.Collections.Generic;
using AirCompany.Domain;

namespace AirCompany.Domain.Test;

public class TestDataProvider
{
    public List<Aircraft> aircrafts = 
        [
            new Aircraft(1, "Boeing 737", 10000.0, 850.0, 180) { Id = 1 },
            new Aircraft(2, "Airbus A320", 12000.0, 900.0, 180) { Id = 2 },
            new Aircraft(3, "Boeing 777", 15000.0, 950.0, 300) { Id = 3 },
            new Aircraft(4, "Airbus A380", 20000.0, 900.0, 500) { Id = 4 },
            new Aircraft(5, "Embraer E195", 8000.0, 800.0, 120) { Id = 5 }
        ];


}
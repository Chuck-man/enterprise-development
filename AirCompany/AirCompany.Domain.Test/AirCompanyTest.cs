﻿namespace AirCompany.Domain.Test;

public class AirCompanyTest(TestDataProvider testDataProvider) : IClassFixture<TestDataProvider>
{
    private readonly TestDataProvider _testDataProvider = testDataProvider;

    /// <summary>
    /// Вывести сведения о всех авиарейсах, вылетевших из указанного пункта отправления в указанный пункт прибытия.
    /// </summary>
    [Fact]
    public void TestSeeAllFlights()
    {
        var allFlights = _testDataProvider.Flights.ToList();
        Assert.Equal(5, allFlights.Count);
    }

    /// <summary>
    /// Вывести сведения обо всех пассажирах, летящих данным рейсом, вес багажа которых равен нулю, упорядочить по ФИО.
    /// </summary>
    [Fact]
    public void TestPassengersWithNoBaggageOnFlight()
    {
        var flightId = 1; // ID рейса для поиска
        var passengers = _testDataProvider.RegisteredPassengers
            .Where(p => p.Flight!.Id == flightId && p.BaggageWeight == 0)
            .OrderBy(p => p.Passenger.FullName)
            .ToList();

        Assert.NotEmpty(passengers);
        Assert.All(passengers, p => Assert.Equal(0, p.BaggageWeight));
    }

    /// <summary>
    /// Вывести сводную информацию обо всех полетах самолетов данного типа в указанный период времени.
    /// </summary>
    [Fact]
    public void TestOutputAircraftFlightsInTimePeriod()
    {
        var aircraftTypeId = 1;
        DateTime start = new(2023, 01, 20, 11, 00, 00);
        DateTime end = new(2024, 03, 14, 00, 00, 00);

        var flights = _testDataProvider.Flights
            .Where(f => f.PlaneType.Id == aircraftTypeId && f.DepartureDate >= start && f.ArrivalDate <= end)
            .ToList();

        Assert.NotEmpty(flights);
        Assert.All(flights, f => Assert.Equal(aircraftTypeId, f.PlaneType.Id));
        Assert.All(flights, f => Assert.True(f.DepartureDate >= start && f.ArrivalDate <= end));
    }

    /// <summary>
    /// Вывести топ 5 авиарейсов по количеству перевезённых пассажиров.
    /// </summary>
    [Fact]
    public void TestOutputTop5FlightsByPassengersNumber()
    {
        var topFlights = _testDataProvider.Flights
            .OrderByDescending(f => f.Passengers.Count)
            .Take(5)
            .ToList();

        Assert.Equal(5, topFlights.Count);
        Assert.Equal(_testDataProvider.Flights[4], topFlights[0]);
        Assert.Equal(_testDataProvider.Flights[3], topFlights[1]);
        Assert.Equal(_testDataProvider.Flights[0], topFlights[2]);
        Assert.Equal(_testDataProvider.Flights[1], topFlights[3]);
        Assert.Equal(_testDataProvider.Flights[2], topFlights[4]);
    }

    /// <summary>
    /// Вывести список рейсов с минимальным временем в пути.
    /// </summary>
    [Fact]
    public void TestOutputFlightsByMinTravelTime()
    {
        var minDuration = _testDataProvider.Flights.Min(f => f.TravelTime);
        var flightsByMinDuration = _testDataProvider.Flights
            .Where(f => f.TravelTime == minDuration)
            .ToList();

        Assert.NotEmpty(flightsByMinDuration);
        Assert.All(flightsByMinDuration, f => Assert.Equal(minDuration, f.TravelTime));
    }

    /// <summary>
    /// Вывести информацию о средней и максимальной загрузке авиарейсов из заданного пункта отправления
    /// </summary>
    [Fact]
    public void TestOutputMaxAndAverageOccupancyByDeparturePoint()
    {
        var departurePoint = "Detroit";

        var flightsFromPoint = _testDataProvider.Flights
            .Where(f => f.DeparturePoint == departurePoint)
            .ToList();

        var averageOccupancy = flightsFromPoint.Average(f => f.Passengers.Count);
        var maxOccupancy = flightsFromPoint.Max(f => f.Passengers.Count);

        Assert.Equal(3, averageOccupancy);
        Assert.Equal(4, maxOccupancy);
    }
}
using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class SmartParkingBoyTest
{
    private List<ParkingLot> parkingLots;
    private Vehicle car;
    
    [SetUp]
    public void Setup()
    {
        parkingLots = new List<ParkingLot>
        {
            {new(10, 2, "A")},
            {new(10, 2, "B")},
            {new(10, 2, "C")}
        };
        car = new Vehicle("111111");
    }

    // Task1: Given 3 parkinglots has same available count When park a car Then park in A
    [Test]
    public void should_park_in_A_parkinglot_when_all_parkinglots_have_same_avaliablecount()
    {
        parkingLots[0].AvailableCount = 10;
        parkingLots[1].AvailableCount = 10;
        parkingLots[2].AvailableCount = 10;

        var boy = new SmartParkingBoy(parkingLots);
        boy.Park(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(9));
        Assert.That(parkingLots[1].AvailableCount, Is.EqualTo(10));
        Assert.That(parkingLots[2].AvailableCount, Is.EqualTo(10));
    }
    
    // Task1: Given 3 parkinglots and B has most available count When park a car Then park in B
    [Test]
    public void should_park_in_B_parkinglot_when_B_has_most_avaliablecount()
    {
        parkingLots[0].AvailableCount = 9;
        parkingLots[1].AvailableCount = 10;
        parkingLots[2].AvailableCount = 9;

        var boy = new SmartParkingBoy(parkingLots);
        boy.Park(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(9));
        Assert.That(parkingLots[1].AvailableCount, Is.EqualTo(9));
        Assert.That(parkingLots[2].AvailableCount, Is.EqualTo(9));
    }

}
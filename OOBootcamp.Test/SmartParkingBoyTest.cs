using System;
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

    // Task1: Given 3 full parkinglots When park a car Then throw exception
    [Test]
    public void should_thorw_an_exception_when_all_parkinglots_are_full()
    {
        parkingLots[0].AvailableCount = 0;
        parkingLots[1].AvailableCount = 0;
        parkingLots[2].AvailableCount = 0;
        
        var boy = new SmartParkingBoy(parkingLots);
        var notAvaliabeException = Assert.Throws<Exception>((() => boy.Park(car)));
        
        Assert.That(notAvaliabeException.Message, Is.EqualTo("Parkinglot is not avaliable"));
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(0));
        Assert.That(parkingLots[1].AvailableCount, Is.EqualTo(0));
        Assert.That(parkingLots[2].AvailableCount, Is.EqualTo(0));
    }
    
    // Task1: Given "111111" is in Parkinglot When pull out a car Then success
    [Test]
    public void should_succes_when_pull_out_an_existing_car()
    {
        parkingLots[0].AvailableCount = 10;
        parkingLots[1].AvailableCount = 10;
        parkingLots[2].AvailableCount = 10;
        
        var boy = new SmartParkingBoy(parkingLots);
        boy.Park(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(9));

        boy.Pullout(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(10));
    }

}
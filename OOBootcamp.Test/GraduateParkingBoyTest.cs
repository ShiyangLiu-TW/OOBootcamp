using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class GraduateParkingBoyTest
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

    // Given 3 avaliable parkinglots, When a can parks, Then park in Parkinglot A
    [Test]
    public void should_park_in_A_parkinglot_when_all_parkinglots_avaliable()
    {
        var boy = new GraduateParkingBoy(parkingLots,null);
        
        boy.Park(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(9));
    }
    
    // Given 3  avaliable parkinglots and last car parked in A, When a car parks, Then park in B
    [Test]
    public void should_park_in_B_parkinglot_when_all_parkinglots_avaliable_and_last_parking_in_A_parkinglots()
    {
        parkingLots[0].AvailableCount = 9;

        var boy = new GraduateParkingBoy(parkingLots, parkingLots[0]);

        boy.Park(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(9));
        Assert.That(parkingLots[1].AvailableCount, Is.EqualTo(9));
    }

    // Given A(avaliable), B(avaliable), C(full) parkinglots and last car parked in 2, When a car parks, Then park in A
    [Test]
    public void should_park_in_A_parkinglot_when_C_parkinglot_is_full_and_last_parking_in_B_parkinglots()
    {
        parkingLots[1].AvailableCount = 9;
        parkingLots[2].AvailableCount = 0;

        var boy = new GraduateParkingBoy(parkingLots, parkingLots[1]);

        boy.Park(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(9));
    }

    // Given 3 full parkinglots, Then a car parks, Then throw exception
    [Test]
    public void should_throw_exception_when_all_parkinglots_are_full()
    {
        parkingLots[0].AvailableCount = 0;
        parkingLots[1].AvailableCount = 0;
        parkingLots[2].AvailableCount = 0;

        var boy = new GraduateParkingBoy(parkingLots, parkingLots[1]);
        
        Assert.Throws<Exception>(() => boy.Park(car));
    }
    
    // Given 3 parkinglots, When a car leaves from A, Then A has one more space
    [Test]
    public void should_has_one_more_availablecount_when_one_car_leaves_parkinglot_A()
    {
        parkingLots[0].AvailableCount = 0;
        parkingLots[1].AvailableCount = 0;
        parkingLots[2].AvailableCount = 0;

        var boy = new GraduateParkingBoy(parkingLots, parkingLots[1]);
        parkingLots[0]._parkedVehicles.Add(car,DateTime.UtcNow);

        boy.PullOut(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(1));
    }

    // Given 3 parkinglots, When a external car leaves, Then throw exception
    [Test]
    public void should_throw_ecxption_when_external_car_leaves_parkinglot_A()
    {
        parkingLots[0].AvailableCount = 0;
        parkingLots[1].AvailableCount = 0;
        parkingLots[2].AvailableCount = 0;

        var boy = new GraduateParkingBoy(parkingLots, parkingLots[1]);
        
        Assert.Throws<Exception>(() => boy.PullOut(car));
    }

}
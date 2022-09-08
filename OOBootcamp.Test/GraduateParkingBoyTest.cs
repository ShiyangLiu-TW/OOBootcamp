using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class GraduateParkingBoyTest
{
    // Given 3 avaliable parkinglots, When a can parks, Then park in Parkinglot A
    [Test]
    public void should_park_in_1_parkinglot_when_all_parkinglots_avaliable()
    {
        var parkingLots = new List<ParkingLot>
        {
            {new(10, 2, "A")},
            {new(10, 2, "B")},
            {new(10, 2, "C")}
        };

        var boy = new GraduateParkingBoy(parkingLots,null);
        var car = new Vehicle("111111");

        boy.Park(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(9));
    }
    
    // Given 3  avaliable parkinglots and last car parked in A, When a car parks, Then park in B
    [Test]
    public void should_park_in_2_parkinglot_when_all_parkinglots_avaliable_and_last_parking_in_1_parkinglots()
    {
        var parkingLots = new List<ParkingLot>
        {
            {new(10, 2, "A")},
            {new(10, 2, "B")},
            {new(10, 2, "C")}
        };

        var boy = new GraduateParkingBoy(parkingLots, parkingLots[0]);
        var car = new Vehicle("111111");

        boy.Park(car);
        
        Assert.That(parkingLots[0].AvailableCount, Is.EqualTo(9));
        Assert.That(parkingLots[1].AvailableCount, Is.EqualTo(9));
    }

    // Given A(avaliable), B(avaliable), C(full) parkinglots and last car parked in 2, When a car parks, Then park in A
    
    // Given 3 full parkinglots, Then a car parks, Then throw exception
    
    // Given 3 parkinglots, When a car leaves from A, Then A has one more space
    
    // Given 3 parkinglots, When a external car leaves, Then throw exception
}
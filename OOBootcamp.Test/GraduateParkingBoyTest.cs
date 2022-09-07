using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class GraduateParkingBoyTest
{
    [Test]
    public void should_park_in_A_parkinglot_when_all_parkinglots_avaliable()
    {
        var parkingLots = new Dictionary<string, ParkingLot>
        {
            {"A", new ParkingLot(10, 2, "A")},
            {"B", new ParkingLot(10, 2, "B")},
            {"C", new ParkingLot(10, 2, "C")}
        };

        var boy = new GraduateParkingBoy(parkingLots);
        var car = new Vehicle("111111");

        boy.Park(car);
        
        Assert.That(parkingLots["A"]._availableSpace, Is.EqualTo(9));
    }
    
}
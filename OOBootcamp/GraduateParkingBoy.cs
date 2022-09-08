
using System.Net.Sockets;

namespace OOBootcamp;

public class GraduateParkingBoy
{
    private readonly List<ParkingLot> _parkingLots;
    private ParkingLot _lastParkingLot;
    
    public GraduateParkingBoy(List<ParkingLot> parkingLots, ParkingLot? lastParkingLot)
    {
        _parkingLots = parkingLots;
        _lastParkingLot = lastParkingLot;
    }

    public void Park(Vehicle car)
    {
        var indexOfNextParkingLot = GetNextParkingLot(_lastParkingLot);
        _parkingLots[indexOfNextParkingLot].ParkVehicle(car);
    }

    private int GetNextParkingLot(ParkingLot lastParkingLot)
    {
        var count = _parkingLots.Count;
        var point = _parkingLots.IndexOf(_lastParkingLot);
        for (int i = 0; i < count; i++)
        {
            point++;
            if (_parkingLots[point % count].AvailableCount != 0)
            {
                return point % count;
            }
        }

        throw new Exception("No Parkinglot Available!");
    }

    public void PullOut(Vehicle car, ParkingLot parkingLot)
    {
        if (!parkingLot.HasVehicle(car))
        {
            throw new Exception($"Cannot find car: {car.LicensePlate}");
        }

        parkingLot.AvailableCount++;
    }
}
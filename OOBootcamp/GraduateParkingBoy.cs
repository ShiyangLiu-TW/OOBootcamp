
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
        var indexOfLastParkingLot = _parkingLots.IndexOf(_lastParkingLot);
        var indexOfNextParkingLot = indexOfLastParkingLot + 1;
        _parkingLots[indexOfNextParkingLot].ParkVehicle(car);
    }
}
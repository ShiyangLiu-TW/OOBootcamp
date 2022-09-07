
namespace OOBootcamp;

public class GraduateParkingBoy
{
    private readonly Dictionary<int, ParkingLot> _parkingLots;
    public GraduateParkingBoy(Dictionary<int, ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
    }

    public void Park(Vehicle car)
    {
        var lastParkedLot = _parkingLots.Where(p => p.Value.IsLastParked).FirstOrDefault().Key;
        if (lastParkedLot != 0)
        {
            _parkingLots[lastParkedLot].IsLastParked = false;
        }
        _parkingLots[(lastParkedLot + 1)%_parkingLots.Count].ParkVehicle(car);
    }
}
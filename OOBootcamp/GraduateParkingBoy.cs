
namespace OOBootcamp;

public class GraduateParkingBoy
{
    private readonly Dictionary<string, ParkingLot> _parkingLots;
    public GraduateParkingBoy(Dictionary<string, ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
    }

    public void Park(Vehicle car)
    {
        _parkingLots.First().Value.ParkVehicle(car);
    }
}
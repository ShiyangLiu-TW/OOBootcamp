namespace OOBootcamp;

public class SmartParkingBoy
{
    private List<ParkingLot> _parkingLots;
    public SmartParkingBoy(List<ParkingLot> parkingLots)
    {
        this._parkingLots = parkingLots;
    }

    public void Park(Vehicle car)
    {
        try
        {
            var nextParkingLot = _parkingLots.Where(p => p.AvailableCount != 0)
                .OrderByDescending(p => p.AvailableCount / p.MaxCapacity).First();
            nextParkingLot.ParkVehicle(car);
        }
        catch (Exception)
        {
            throw new Exception("Parkinglot is not avaliable");
        }
    }
}
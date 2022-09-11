namespace OOBootcamp;

public class VehicleNotFoundException : Exception
{
    private Vehicle _missingVehicle;
    public VehicleNotFoundException(Vehicle vehicle)
    {
        _missingVehicle = vehicle;
    }
}
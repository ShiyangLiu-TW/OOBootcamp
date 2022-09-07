namespace OOBootcamp;

public class ParkingLot
{
    public string Name { get; }
    public double HourlyRate { get; }
    public int AvailableCount { get; private set; }
    public int MaxCapacity { get; }
    public bool IsLastParked { get; set; }
    private readonly Dictionary<Vehicle, DateTime> _parkedVehicles;

    public ParkingLot(int maxCapacity, double hourlyRate, string name,bool isLastParked = false)
    {
        MaxCapacity = maxCapacity;
        Name = name;
        HourlyRate = hourlyRate;
        AvailableCount = maxCapacity;
        _parkedVehicles = new Dictionary<Vehicle, DateTime>();
        IsLastParked = isLastParked;
    }
    
    public bool ParkVehicle(Vehicle vehicle)
    {
        if (AvailableCount > 0)
        {
            _parkedVehicles.Add(vehicle, DateTime.UtcNow);
            AvailableCount--;
            IsLastParked = true;
            return true;
        }

        return false;
    }

    public bool HasVehicle(Vehicle vehicle)
    {
        return _parkedVehicles.ContainsKey(vehicle);
    }
    
    public double RetrieveVehicle(Vehicle vehicle)
    {
        if (_parkedVehicles.ContainsKey(vehicle))
        {
            return Math.Ceiling((DateTime.UtcNow - _parkedVehicles[vehicle]).TotalMilliseconds / 3600.0) * HourlyRate;
        }

        throw new VehicleNotFoundException(vehicle);
    }
}
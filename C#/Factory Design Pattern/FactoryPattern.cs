public interface IVehicle
{
    void Drive();
}

public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Car is driving...");
    }
}

public class Bike : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Bike is driving...");
    }
}

public class Truck : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Truck is driving...");
    }
}

public class VehicleFactory
{
    public static IVehicle GetVehicle(string VehicleType)
    {
        if(VehicleType=="car")
        {
            return new Car();
        }
        else if(VehicleType == "bike")
        {
            return new Bike();
        }
        else if(VehicleType == "truck")
        {
            return new Truck();
        }
        else
        {
            throw new ArgumentException("Invalid vehicle type.");
        }
    }
}

class Program
{
    static void Main()
    {
        IVehicle vehicle1= VehicleFactory.GetVehicle("car");
        vehicle1.Drive();

        IVehicle vehicle2 = VehicleFactory.GetVehicle("bike");
        vehicle2.Drive();
        
        IVehicle vehicle3 = VehicleFactory.GetVehicle("truck");
        vehicle3.Drive();
    }
}
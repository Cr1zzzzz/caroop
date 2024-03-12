using System;

class Car
{
    private string brand;
    private double fuelLevel;

    public Car(string brand, double initialFuelLevel)
    {
        this.brand = brand;
        this.fuelLevel = initialFuelLevel;
    }

    public void Refuel(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Кількість палива для заправки має бути додатньою.");
        }

        double totalFuel = fuelLevel + amount;
        if (totalFuel > 100)
        {
            throw new ArgumentException("Машина не може бути заправлена більше ніж на 100%.");
        }

        fuelLevel = totalFuel;
        Console.WriteLine($"Машина {brand} була заправлена на {amount} одиниць палива.");
    }

    public void Drive(double distance)
    {
        double fuelNeeded = distance * 0.1;

        if (fuelNeeded > fuelLevel)
        {
            Console.WriteLine($"Машина {brand} не може проїхати {distance} км. Потрібно заправити паливо.");
            return;
        }

        fuelLevel -= fuelNeeded;
        Console.WriteLine($"Машина {brand} проїхала {distance} км. Залишилось {fuelLevel:F2}% палива.");
    }

    public void PrintStatus()
    {
        Console.WriteLine($"Статус машини {brand}: Паливо: {fuelLevel:F2}%");
    }
}



class Program
{
    static void Main()
    {
        Car car = new Car("Toyota", 50);

        car.PrintStatus();

        car.Drive(100);
        car.PrintStatus();

        try
        {
            car.Refuel(60);
            car.PrintStatus();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

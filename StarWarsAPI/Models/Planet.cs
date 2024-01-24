using StarWarsAPI.DTOs;
using StarWarsAPI.Extensions;

namespace StarWarsAPI.Models;

public readonly record struct Planet
{
    public string Name { get; }
    public int Diameter { get; }
    public int? SurfaceWater { get; }
    public long? Population { get; }

    public Planet(string name,
        int diameter,
        int? surfaceWater,
        long? population)
    {
        if(name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;       
    }

    public static explicit operator Planet(Result v)
    {
        var name = v.name;
        var diameter = int.Parse(v.diameter);
        var surfaceWater = v.surface_water.IntOrNull();
        var population = v.population.LongOrNull();

        return new Planet(name, diameter, surfaceWater, population);
    }
}

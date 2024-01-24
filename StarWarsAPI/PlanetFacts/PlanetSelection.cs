using System;
using StarWarsAPI.Models;

namespace StarWarsAPI.PlanetFacts
{
/// <summary>
/// Provides options for selecting properties and values of a planet properties.
/// </summary>
public static class PlanetSelection
{
    /// <summary>
    /// Returns a dictionary of property name selectors for a planet.
    /// </summary>
    /// <returns>A dictionary containing property name and func for getting property values.</returns>
    public static Dictionary<string, Func<Planet, long?>> Options()
    {
        var propertyNameSelector = new Dictionary<string, Func<Planet, long?>>
        {
            ["population"] = selector => selector.Population,
            ["diameter"] = selector => selector.Diameter,
            ["surface water"] = selector => selector.SurfaceWater
        };

        return propertyNameSelector;
    }
}
}


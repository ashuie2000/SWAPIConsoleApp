using System;
using StarWarsAPI.Models;

namespace StarWarsAPI.PlanetStats
{
	public static class PlanetStat
	{
        public static string Get(string propertyName, IEnumerable<Planet> planets,
            Func<Planet, long?> predicate)
        {
            var planetWithMaxValue = planets.MaxBy(predicate);
            var planetWithMinValue = planets.MinBy(predicate);

            return @$"The Planet with the highest {propertyName} is {planetWithMaxValue.Name} with {predicate(planetWithMaxValue)}
The planet with the lowest {propertyName}, is {planetWithMinValue.Name} with {predicate(planetWithMinValue)}";
        }
    }
}


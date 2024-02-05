using System;
using StarWarsAPI.DTOs;
using StarWarsAPI.Models;

namespace StarWarsAPI.Utilities
{
    /// <summary>
    /// Provides methods to convert DTO objects to Planet entity objects.
    /// </summary>
    public static class DTOtoPlanetEntity
    {
        /// <summary>
        /// Converts a Root object to a collection of Planet entities.
        /// </summary>
        /// <param name="root">The Root object to convert.</param>
        /// <returns>A collection of Planet entities.</returns>
        public static IEnumerable<Planet> Convert(Root? root)
        {
            if (root is null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return root.results.Select(planet => (Planet)planet);
        }
    }

}
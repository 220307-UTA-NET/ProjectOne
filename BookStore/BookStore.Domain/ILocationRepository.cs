using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public interface ILocationRepository
    {
        // CRUD Location

        /// <summary>
        /// Returns the list of all Locations from the database.
        /// </summary>
        /// <returns> List<Location> toReturn </returns>
        public List<Location> GetAllLocations();

        /// <summary>
        /// Returns the specific Location matching the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Location loc </returns>
        public Location GetLocationByID(int id);

        /// <summary>
        /// Returns the specific Location matching the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns> Location loc </returns>
        public Location GetLocationByName(string name);

        /// <summary>
        /// Adds the given Location to the database.
        /// </summary>
        /// <param name="l"></param>
        public void AddLocation(Location l);

        /// <summary>
        /// Updates the given Location in the database.
        /// </summary>
        /// <param name="l"></param>
        public void UpdateLocation(Location l);

        /// <summary>
        /// Deletes the given Location in the database.
        /// </summary>
        /// <param name="l"></param>
        public void DeleteLocation(Location l);
    }
}

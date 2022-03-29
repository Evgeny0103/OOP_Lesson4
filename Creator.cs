using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lesson4.OOP_Lesson4
{
  public  class Creator 
    {
        private const double DefaultHeight = 5;
        private const int DefaultFloorCount = 2;
        private const int DefaultApartmentCount = 8;
        private const int DefaultEntranceCount = 1;

        private static readonly Hashtable BuildingCollection = new Hashtable();
        private Creator()
        { }
        public static Building CreateBuilding()
        {
            return CreateBuilding(DefaultHeight, DefaultFloorCount, DefaultApartmentCount, DefaultEntranceCount);
        }
        public static Building CreateBuilding(double height)
        {
            return CreateBuilding(height, DefaultFloorCount, DefaultApartmentCount, DefaultEntranceCount);
        }

        public static Building CreateBuilding(double height, int floors)
        {
            return CreateBuilding(height, floors, DefaultApartmentCount, DefaultEntranceCount);
        }
        public static Building CreateBuilding(double height, int floors, int apartments)
        {
            return CreateBuilding(height, floors, apartments, DefaultEntranceCount);
        }

        public static Building CreateBuilding(double height, int floors, int apartments, int entrances)
        {
            var building = new Building(height, floors, apartments, entrances);
            AddBuildingToCollection(building);
            return building;
        }

        private static void AddBuildingToCollection(Building building)
        {
            try
            {
                BuildingCollection.Add(building.GetId(), building);
            }
            catch
            {
                Console.WriteLine($"An element with Key: {building.GetId()} already exists.");
            }
        }
        public static void DeleteBuilding(long id)
        {
            if (!BuildingCollection.ContainsKey(id))
            {
                Console.WriteLine($"Building with id: {id} is not exits in collection");
                return;
            }
            Console.WriteLine($"Removing building with id: {id}");
            BuildingCollection.Remove(id);
        }
    }
}

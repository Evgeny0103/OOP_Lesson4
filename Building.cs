using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lesson4.OOP_Lesson4
{
  public  class Building
    {

        private static long _buildingId;
        private long _id;
        private double _height;
        private int _floorCount;
        private int _apartmentCount;
        private int _entranceCount;

        private Building()
        {
            SetId(GenerateNewId());
        }
        public Building(double height, int floorCount, int apartmentCount, int entranceCount) : this()
        {
            SetHeight(height);
            SetFloorCount(floorCount);
            SetApartmentCount(apartmentCount);
            SetEntranceCount(entranceCount);
        }

        public long GetId() => _id;
        public double GetHeight() => _height;
        public int GetFloorCount() => _floorCount;
        public int GetTotalApartmentCount() => _apartmentCount;
        public int GetEntranceCount() => _entranceCount;
        public double GetFloorHeight(int floor)
        {
            if (floor <= 0 || floor > _floorCount)
            {
                return -1;
            }

            return (_height * floor) / _floorCount;
        }

        public int GetApartmentCountInEntrance(int entrance)
        {
            if (entrance <= 0 || entrance > _entranceCount)
            {
                return -1;
            }
            var apartmentPerEntrance = (float)_apartmentCount / _entranceCount;
            return entrance != _entranceCount
                ? (int)System.MathF.Floor(apartmentPerEntrance)
                : _apartmentCount - (int)System.MathF.Floor((_entranceCount - 1) * apartmentPerEntrance);
        }

        public int GetApartmentCountAtFloor(int floor)
        {
            if (floor <= 0 || floor > _floorCount)
            {
                return -1;
            }

            var apartmentPerFloor = (float)_apartmentCount / _floorCount;
            return floor != _floorCount
                ? (int)System.MathF.Floor(apartmentPerFloor)
                : _apartmentCount - (int)System.MathF.Floor((_floorCount - 1) * apartmentPerFloor);
        }

        private void SetId(long id) => _id = id;

        private void SetHeight(double height)
        {
            _height = height <= 0
                ? throw new ArgumentException($"Invalid height data: {height}")
                : height;
        }

        private void SetFloorCount(int floorCount)
        {
            _floorCount = floorCount <= 0
                ? throw new ArgumentException($"Invalid floor data: {floorCount}")
                : floorCount;
        }
        private void SetApartmentCount(int apartmentCount)
        {
            _apartmentCount = apartmentCount <= 0
                ? throw new ArgumentException($"Invalid apartment data: {apartmentCount}")
                : apartmentCount;
        }
        private void SetEntranceCount(int entranceCount)
        {
            _entranceCount = entranceCount <= 0
                ? throw new ArgumentException($"Invalid entrance data: {entranceCount}")
                : entranceCount;
        }

        private long GenerateNewId()
        {
            return ++_buildingId;
        }

        public string Print()
        {
            var id = GetId();
            var height = GetHeight();
            var floor = GetFloorCount();
            var apartment = GetTotalApartmentCount();
            var entrance = GetEntranceCount();
            return $"Building: {id}, Height:{height}, Floor: {floor}, Apartment: {apartment}, Entrance: {entrance}";
        }
    }
}

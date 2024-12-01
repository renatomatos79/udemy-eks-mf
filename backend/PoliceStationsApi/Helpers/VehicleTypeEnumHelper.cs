using PoliceStationsApi.Enums;

namespace PoliceStationsApi.Helpers
{
    public class VehicleTypeEnumHelper
    {
        private readonly string _vehicleType;

        public static VehicleTypeEnumHelper Car = new VehicleTypeEnumHelper(VehicleTypeEnum.Car);
        public static VehicleTypeEnumHelper Truck = new VehicleTypeEnumHelper(VehicleTypeEnum.Truck);
        public static VehicleTypeEnumHelper Bike = new VehicleTypeEnumHelper(VehicleTypeEnum.Bike);

        private VehicleTypeEnumHelper(VehicleTypeEnum vt)
        {
            this._vehicleType = VehicleTypeToString(vt);
        }

        private string VehicleTypeToString(VehicleTypeEnum vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleTypeEnum.Car: return "Car";
                case VehicleTypeEnum.Truck: return "Truck";
                default: return "Bike";
            }
        }

        public override string ToString()
        {
            return _vehicleType;
        }

        public static VehicleTypeEnumHelper FromString(string vehicleType)
        {
            var fmtVehicleType = (vehicleType ?? string.Empty).Trim().ToLower();
            if (fmtVehicleType == Car.ToString().ToLower()) return Car;
            if (fmtVehicleType == Truck.ToString().ToLower()) return Truck;
            return Bike;
        }
    }
}

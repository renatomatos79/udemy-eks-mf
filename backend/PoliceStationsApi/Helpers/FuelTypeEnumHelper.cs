using ServiceRequests.PoliceStations.Api.Enums;

namespace ServiceRequests.PoliceStations.Api.Helpers;

public class FuelTypeEnumHelper
{
    private readonly string _fueldType;

    public static FuelTypeEnumHelper Gasoline = new FuelTypeEnumHelper(FuelTypeEnum.Gasoline);
    public static FuelTypeEnumHelper Diesel = new FuelTypeEnumHelper(FuelTypeEnum.Diesel);
    public static FuelTypeEnumHelper Ethanol = new FuelTypeEnumHelper(FuelTypeEnum.Ethanol);
    public static FuelTypeEnumHelper NaturalGas = new FuelTypeEnumHelper(FuelTypeEnum.NaturalGas);
    public static FuelTypeEnumHelper Electric = new FuelTypeEnumHelper(FuelTypeEnum.Electric);

    private FuelTypeEnumHelper(FuelTypeEnum role)
    {
        this._fueldType = FueldTypeToString(role);
    }

    private string FueldTypeToString(FuelTypeEnum role)
    {
        switch (role)
        {
            case FuelTypeEnum.Gasoline: return "Gasoline";
            case FuelTypeEnum.Diesel: return "Diesel";
            case FuelTypeEnum.Ethanol: return "Ethanol";
            case FuelTypeEnum.NaturalGas: return "NaturalGas";
            default: return "Electric";
        }
    }

    public override string ToString()
    {
        return _fueldType;
    }

    public static FuelTypeEnumHelper FromString(string fueldType)
    {
        var fmtFueldType = (fueldType ?? string.Empty).Trim().ToLower();
        if (fmtFueldType == Gasoline.ToString().ToLower()) return Gasoline;
        if (fmtFueldType == Diesel.ToString().ToLower()) return Diesel;
        if (fmtFueldType == Ethanol.ToString().ToLower()) return Ethanol;
        if (fmtFueldType == NaturalGas.ToString().ToLower()) return NaturalGas;
        return FuelTypeEnumHelper.Electric;
    }
}

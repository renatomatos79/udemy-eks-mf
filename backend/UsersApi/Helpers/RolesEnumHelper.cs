using ServiceRequests.Users.Api.Enums;

namespace ServiceRequests.Users.Api.Helpers;

public class RolesEnumHelper
{
    private readonly string _role;

    public static RolesEnumHelper Admin = new RolesEnumHelper(RolesEnum.Admin);
    public static RolesEnumHelper Operator = new RolesEnumHelper(RolesEnum.Operator);
    public static RolesEnumHelper Dashboard = new RolesEnumHelper(RolesEnum.Dashboard);

    private RolesEnumHelper(RolesEnum role)
    {
        this._role = RolesEnumToString(role);
    }

    private string RolesEnumToString(RolesEnum role)
    {
        switch (role)
        {
            case RolesEnum.Admin: return "Admin";
            case RolesEnum.Operator: return "Operator";
            default: return "Dashboard";
        }
    }

    public override string ToString()
    {
        return _role;
    }

    public static RolesEnumHelper FromString(string role)
    {
        var fmtRole = (role ?? string.Empty).Trim().ToLower();
        if (fmtRole == "admin") return RolesEnumHelper.Admin;
        if (fmtRole == "operator") return RolesEnumHelper.Operator;
        return RolesEnumHelper.Dashboard;
    }
}

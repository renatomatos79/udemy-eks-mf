namespace UsersApi.Helpers;

public static class EnvironmentHelper
{

    public static string GetValue(this WebApplicationBuilder builder, string variableName, string defaultValue = "")
    {
        Console.WriteLine($"GetValue VariableName: {variableName}");
        try
        {
            var value = Environment.GetEnvironmentVariable(variableName) ?? defaultValue;
            Console.WriteLine($"GetValue VariableName: {variableName} value: {value}");
            return value;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetValue VariableName: {variableName} Error: {ex}");
        }
        return defaultValue;
    }

    public static string GetMongoDbConnectionString(this WebApplicationBuilder builder)
    {
        return builder.GetValue("APP_MONGODB_CS", "mongodb://admin:m0ng0d4t4@localhost:27019/");
    }    
}
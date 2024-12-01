using Microsoft.AspNetCore.Builder;

namespace ServiceRequests.Common.Helpers;

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

    public static string GetSecretKey(this WebApplicationBuilder builder)
    {
        return GetValue(builder, "APP_JWT_SECRET_KEY", "33a19758-19c0-4be4-9582-f010eb7928f4");
    }

    public static string GetSecretIssuer(this WebApplicationBuilder builder)
    {
        return GetValue(builder, "APP_JWT_ISSUER", "https://bjss-aws.pt");
    }

    public static string GetSecretAudience(this WebApplicationBuilder builder)
    {
        return GetValue(builder, "APP_JWT_AUDIENCE", "https://bjss-aws.pt");
    }
}
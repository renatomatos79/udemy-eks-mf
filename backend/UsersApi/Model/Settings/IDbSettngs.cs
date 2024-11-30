namespace UsersApi.Model.Settings
{
    public interface IDbSettngs
    {
        string DBName { get; set; }
        string ConnectionString { get; set; }
    }
}

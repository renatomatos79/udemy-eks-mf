namespace UsersApi.Model.Settings
{
    public class DbSettngs : IDbSettngs
    {
        public required string DBName { get; set; }
        public required string ConnectionString { get; set; }
    }
}

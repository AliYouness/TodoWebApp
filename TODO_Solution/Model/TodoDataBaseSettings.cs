using MongoDB.Driver.Core.Configuration;
using System.Collections;
using System.Data.Common;

namespace TODO_Solution.Model
{
    public interface IDatabaseSettings
    {
        string tododCollectionName { get; set; }
        string connectionString { get; set; }
        string databaseName { get; set; }
    }

    public class TodoDataBaseSettings: IDatabaseSettings
    {
        public string connectionString { get; set; }
        public string databaseName { get; set; }
        public string tododCollectionName { get; set; }


        public TodoDataBaseSettings(IConfiguration configuration) {
            tododCollectionName = configuration["TODOStoreDatabase:tododCollectionName"];
            connectionString = configuration["TODOStoreDatabase:connectionString"];
            databaseName = configuration["TODOStoreDatabase:databaseName"];

        }
    }
}

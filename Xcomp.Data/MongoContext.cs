using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System.Diagnostics;
using Xcomp.Share.Common;

namespace Xcomp.Data
{
    public interface IMongoContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChangesAsync();
        IMongoCollection<T> GetCollection<T>(string name);
    }

    public class MongoContext : IMongoContext
    {

        private IMongoDatabase Database { get; set; }
        private IClientSessionHandle Session { get; set; }
        private MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;
        private readonly IConfiguration _configuration;

        public MongoContext(IConfiguration configuration)
        {
            _configuration = configuration;
            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();
            ConfigureMongo();

        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                int taskCount = _commands.Count;
                //using (Session = await MongoClient.StartSessionAsync())
                //{
                //    Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                //await Session.CommitTransactionAsync();
                //}
                _commands?.Clear();
                return taskCount;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            //var mongoClient = new MongoClient(
            //    SystemInfo.ConnectionString);

            //var mongoDatabase = mongoClient.GetDatabase(
            //    SystemInfo.NameDb);



            //var connectionString = SystemInfo.ConnectionString;// _configuration["MongoSettings:Connection"];
            //var mongoUrl = new MongoUrl(connectionString);



            //var dbname = mongoUrl.DatabaseName;
            //var mongoClientSettings = MongoClientSettings.FromUrl(mongoUrl);
            //mongoClientSettings.ClusterConfigurator = cb =>
            //{
            //    cb.Subscribe<CommandStartedEvent>(e =>
            //    {
            //        Debug.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
            //    });
            //};
            //MongoClient = new MongoClient(mongoClientSettings);
            //Database = MongoClient.GetDatabase(dbname);


            MongoClient = new MongoClient(SystemInfo.ConnectionString);
            Database = MongoClient.GetDatabase(SystemInfo.NameDb);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            _commands?.Clear();
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }
}
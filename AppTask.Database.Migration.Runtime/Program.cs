using AppTask.Database;

using (var dbContext = new AppTaskContext())
{
    dbContext.InitializeDatabaseAsync().Wait();
}
using Web_Estoque_E_Faturamento;
using Microsoft.EntityFrameworkCore;
public class TestDatabaseFixture
{
    private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=EFTestSample;Trusted_Connection=True";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    
                }

                _databaseInitialized = true;
            }
        }
    }

    public MvcProductContext CreateContext()
    {
        return new MvcProductContext(new DbContextOptionsBuilder<MvcProductContext>()
                .UseSqlServer(ConnectionString)
                .Options);

    }
}
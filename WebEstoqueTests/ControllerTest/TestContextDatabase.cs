using Web_Estoque_E_Faturamento;
using Microsoft.EntityFrameworkCore;
public class TestDatabaseFixture
{
    private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=EFTestSample;Trusted_Connection=True";
    private const string ConnectionStringMvcIndependentObjectsOfProductsContext = @"Server=(localdb)\mssqllocaldb;Database=TestMvcIndependentObjectsOfProductsContext;Trusted_Connection=True";
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

                using(var MvcIndependent = CreateMvcIndependentContext())
                {
                    MvcIndependent.Database.EnsureDeleted();
                    MvcIndependent.Database.EnsureCreated();
                }
            }
        }
    }

    public MvcProductContext CreateContext()
    {
        return new MvcProductContext(new DbContextOptionsBuilder<MvcProductContext>()
                .UseSqlServer(ConnectionString)
                .Options);

    }
    public MvcIndependentObjectsOfProductsContext CreateMvcIndependentContext(){
        return new MvcIndependentObjectsOfProductsContext(
            new DbContextOptionsBuilder<MvcIndependentObjectsOfProductsContext>()
            .UseSqlServer(ConnectionStringMvcIndependentObjectsOfProductsContext,options=> options.EnableRetryOnFailure())
            .Options
            );
    }


}
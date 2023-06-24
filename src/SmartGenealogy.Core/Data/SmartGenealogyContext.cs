namespace SmartGenealogy.Core.Data;

public class SmartGenealogyContext : DbContext
{
    public DbSet<Person> People { get; set; }

    public static string? DbPath { get; protected set; }
    public static bool Initialized { get; protected set; }

    public SmartGenealogyContext()
    {
        DbPath = Path.Combine("../", "UsedByMigratorOnly1.db3");
        Initialize();
    }

    public SmartGenealogyContext(string filenameWithPath)
    {
        DbPath = filenameWithPath;
        Initialize();
    }

    void Initialize()
    {
        if (!Initialized)
        {
            Initialized = true;
            SQLitePCL.Batteries_V2.Init();
            Database.Migrate();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite($"DataSource={DbPath}");

    public void Reload()
    {
        Database.CloseConnection();
        Database.OpenConnection();
    }
}
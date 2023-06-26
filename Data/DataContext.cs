using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FirstNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Character> Characters => Set<Character>();

        // public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        // {
        //     var entityType = typeof(TEntity);
        //     var entityProperties = entityType.GetProperties();

        //     var identityProperty = entityProperties.FirstOrDefault(p =>
        //         p.GetCustomAttributes(typeof(DatabaseGeneratedAttribute), false)
        //             .OfType<DatabaseGeneratedAttribute>()
        //             .Any(attr => attr.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity)
        //     );

        //     if (identityProperty != null)
        //     {
        //         Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {entityType.Name} ON");
        //     }

        //     var entry = base.Characters.Add(entity);
        //     SaveChanges();


        //     if (identityProperty != null)
        //     {
        //         Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {entityType.Name} OFF");
        //     }

        //     return entry;
        // }
    }
}
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PlaceApp.Data;

/* This is used if database provider does't define
 * IPlaceAppDbSchemaMigrator implementation.
 */
public class NullPlaceAppDbSchemaMigrator : IPlaceAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

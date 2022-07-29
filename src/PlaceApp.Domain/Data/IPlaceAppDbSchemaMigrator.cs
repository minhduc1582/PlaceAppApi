using System.Threading.Tasks;

namespace PlaceApp.Data;

public interface IPlaceAppDbSchemaMigrator
{
    Task MigrateAsync();
}

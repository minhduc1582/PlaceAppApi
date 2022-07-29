using PlaceApp.MongoDB;
using Xunit;

namespace PlaceApp;

[CollectionDefinition(PlaceAppTestConsts.CollectionDefinitionName)]
public class PlaceAppWebCollection : PlaceAppMongoDbCollectionFixtureBase
{

}

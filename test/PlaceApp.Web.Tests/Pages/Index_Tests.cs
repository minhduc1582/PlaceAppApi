using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace PlaceApp.Pages;

[Collection(PlaceAppTestConsts.CollectionDefinitionName)]
public class Index_Tests : PlaceAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

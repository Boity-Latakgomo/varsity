using System.Threading.Tasks;
using varsity.Models.TokenAuth;
using varsity.Web.Controllers;
using Shouldly;
using Xunit;

namespace varsity.Web.Tests.Controllers
{
    public class HomeController_Tests: varsityWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
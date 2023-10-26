using Alba;

namespace DemoApi.ContractTests.Todos;
public class GettingTodos
{

    [Fact]
    public async Task CanGetATodo()
    {
        var host = await AlbaHost.For<Program>();

        await host.Scenario(api =>
        {
            api.Get.Url("/todo-list/8968985b-6c85-426d-bff0-6a42b520620e");
            api.StatusCodeShouldBeOk();
        });

        await host.Scenario(api =>
        {
            api.Get.Url("/todo-list/" + Guid.NewGuid().ToString());
            api.StatusCodeShouldBe(404);

        });
    }
}
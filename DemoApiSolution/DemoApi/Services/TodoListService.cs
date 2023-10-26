using Marten;

namespace DemoApi.Services;

public class TodoListService
{
    private readonly IDocumentSession _documentSession;

    public TodoListService(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }
    //async returns something of type task
    public async Task<TodoItemCreated> CreateTodoItem(CreateTodoItem item)
    {
        var newItem = new TodoItemCreated(Guid.NewGuid(), item.Description, false);

        _documentSession.Store(newItem);
        // get all your work lined up
        await _documentSession.SaveChangesAsync();
        return newItem;
    }
    public async Task<TodoItemCreated?> GetTodoItemAsync(Guid id)
    {
        return await _documentSession.Query<TodoItemCreated>()
            .Where(item => item.Id == id)
            .SingleOrDefaultAsync();
    }

    internal async Task<IReadOnlyList<TodoItemCreated>> GetAllAsync()
    {
        return await _documentSession.Query<TodoItemCreated>().ToListAsync();
    }
}

public record CreateTodoItem(string Description);

public record TodoItemCreated(Guid Id, string Description, bool completed);
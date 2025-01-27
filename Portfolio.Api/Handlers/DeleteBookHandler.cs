using MediatR;
using Portfolio.RepositoryPattern.Shared;

namespace Portfolio.Api.Handlers;

public class DeleteBookRequest : IRequest
{
    public required string Id { get; set; }
}

public class DeleteBookHandler : IRequestHandler<DeleteBookRequest>
{
    private IRepository<Book> _repository;

    public DeleteBookHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        await _repository.Delete(request.Id);
    }
}

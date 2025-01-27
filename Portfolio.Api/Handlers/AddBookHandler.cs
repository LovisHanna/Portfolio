using MediatR;
using Portfolio.Api.DTOs;
using Portfolio.Api.Extensions;
using Portfolio.RepositoryPattern.Shared;

namespace Portfolio.Api.Handlers;

public class AddBookRequest : IRequest
{
    public required BookDto BookDto { get; init; }
}
public class AddBookHandler : IRequestHandler<AddBookRequest>
{
    private IRepository<Book> _repository;

    public AddBookHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public async Task Handle(AddBookRequest request, CancellationToken cancellationToken)
    {
        await _repository.Add(request.BookDto.FromDto());
    }
}

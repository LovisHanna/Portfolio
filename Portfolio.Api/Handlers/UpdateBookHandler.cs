using MediatR;
using Portfolio.Api.DTOs;
using Portfolio.Api.Extensions;
using Portfolio.RepositoryPattern.Shared;

namespace Portfolio.Api.Handlers;

public class UpdateBookRequest : IRequest
{
    public required BookDto BookDto { get; init; }
}

public class UpdateBookHandler : IRequestHandler<UpdateBookRequest>
{
    private IRepository<Book> _repository;

    public UpdateBookHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        await _repository.Update(request.BookDto.FromDto());
    }
}

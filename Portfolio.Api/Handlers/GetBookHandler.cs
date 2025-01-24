using MediatR;
using Portfolio.Api.DTOs;
using Portfolio.Api.Extensions;
using Portfolio.RepositoryPattern.Shared;

namespace Portfolio.Api.Handlers;

public class GetBookRequest : IRequest<BookDto>
{
    public required string Id { get; init; }
}


public class GetBookHandler : IRequestHandler<GetBookRequest, BookDto>
{
    private IRepository<Book> _repository;

    public GetBookHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public async Task<BookDto> Handle(GetBookRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.Get(request.Id);
        return result.ToDto();
    }
}


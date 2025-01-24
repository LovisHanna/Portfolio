using MediatR;
using Portfolio.Api.DTOs;
using Portfolio.Api.Extensions;
using Portfolio.RepositoryPattern.Shared;

namespace Portfolio.Api.Handlers;

public class GetBooksByAuthorRequest : IRequest<List<BookDto>>
{
    public string Author { get; init; }
}

public class GetBooksByAuthorHandler : IRequestHandler<GetBooksByAuthorRequest, List<BookDto>>
{
    private readonly IRepository<Book> _repository;

    public GetBooksByAuthorHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public Task<List<BookDto>> Handle(GetBooksByAuthorRequest request, CancellationToken cancellationToken)
    {
        var result = _repository.Query().Where(x => x.Author == request.Author);
        return Task.FromResult(result.Select(x => x.ToDto()).ToList());
    }
}

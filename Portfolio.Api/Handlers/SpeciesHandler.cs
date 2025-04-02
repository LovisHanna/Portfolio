using MediatR;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Handlers
{
    public class SpeciesRequest : IRequest<SpeciesDetail>
    {
        public required int Id { get; init; }
    }

    public class SpeciesHandler : IRequestHandler<SpeciesRequest, SpeciesDetail>
    {
        private IClient _artDbClient;

        public SpeciesHandler(IClient client)
        {
            _artDbClient = client;
        }

        public async Task<SpeciesDetail> Handle(SpeciesRequest request, CancellationToken cancellationToken)
        {
            var response = await _artDbClient.GetSpecies(request.Id);
            return response;

        }
    }
}

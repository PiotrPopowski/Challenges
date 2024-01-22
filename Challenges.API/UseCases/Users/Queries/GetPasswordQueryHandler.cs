using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Challenges.API.UseCases.Users.Queries
{
    public record GetUserPasswordQuery(string Username) : IRequest<string>;

    public class GetPasswordQueryHandler : IRequestHandler<GetUserPasswordQuery, string>
    {
        private readonly IDistributedCache cache;

        public GetPasswordQueryHandler(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public async Task<string> Handle(GetUserPasswordQuery request, CancellationToken cancellationToken)
        {
            return await cache.GetStringAsync(request.Username, cancellationToken) ?? throw new Exception("Not found");
        }
    }
}

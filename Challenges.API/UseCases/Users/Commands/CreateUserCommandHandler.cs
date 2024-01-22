using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Challenges.API.UseCases.Users.Commands
{
    public record CreateUser(string username, string password) : IRequest;

    public class CreateUserCommandHandler : IRequestHandler<CreateUser>
    {
        private readonly IDistributedCache _cache;

        public CreateUserCommandHandler(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task Handle(CreateUser request, CancellationToken cancellationToken)
        {
            await _cache.SetStringAsync(request.username, request.password);
        }
    }
}

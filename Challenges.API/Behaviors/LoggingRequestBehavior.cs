using MediatR;
using MediatR.Pipeline;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Challenges.API.Behaviors
{
    public class LoggingRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        private readonly ILogger logger;

        public LoggingRequestBehavior(ILogger<Program> logger)
        {
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var result = await next();
            logger.LogInformation("Executed {0} at {1}. Data: {2}", request.GetType().Name, DateTime.Now, JsonSerializer.Serialize(request));

            return result;
        }
    }
}

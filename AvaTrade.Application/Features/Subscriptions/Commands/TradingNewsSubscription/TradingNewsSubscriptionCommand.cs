using MediatR;

namespace AvaTrade.Application.Features.Subscriptions.Commands.TradingNewsSubscription
{
    public record TradingNewsSubscriptionCommand() : IRequest<TradingNewsSubscriptionResponse>;

    public class TradingNewsSubscriptionHandler : IRequestHandler<TradingNewsSubscriptionCommand, TradingNewsSubscriptionResponse>
    {
        //private readonly ITradingNewsSubscriptionService _subscriptionService;

        //public TradingNewsSubscriptionHandler(ITradingNewsSubscriptionService subscriptionService)
        //{
        //    _subscriptionService = subscriptionService;
        //}

        public async Task<TradingNewsSubscriptionResponse> Handle(TradingNewsSubscriptionCommand request, CancellationToken cancellationToken)
        {
            //taking userId from auth service
            //var userId = _authService.GetUserId();

            // Perform the subscription based on userId
            //var result = await _subscriptionService.SubscribeAsync(userId);


            //return new TradingNewsSubscriptionResponse
            //{
            //    Success = result,
            //    Message = result ? "Subscription successful." : "Subscription failed. Please try again."
            //};


            return new TradingNewsSubscriptionResponse
            {
                Success = true,
                Message = "Subscription successful."
            };
        }
    }

}

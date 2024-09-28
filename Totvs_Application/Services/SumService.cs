using MediatR;
using TotvsTest_Model;

namespace Totvs_Application.Services
{
    public class SumService: IRequestHandler<SumRequest, SumResponse>
    {
        public SumService() { }

        public async Task<SumResponse> Handle(SumRequest request, CancellationToken cancellationToken)
        {
            var model = new SumResponse()
            {
                sum_total = request.first_number + request.second_number
            };

            return model;
        }

    }
}

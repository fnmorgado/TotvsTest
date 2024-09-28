using MediatR;

namespace TotvsTest_Model
{
    public class SumRequest: IRequest<SumResponse>
    {
        public int first_number { get; set; }
        public int second_number { get; set; }
    }

    public class SumResponse
    {
        public int sum_total { get; set; }
    }
}

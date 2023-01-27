using AkademiECommerce.Shared.ControllerBases;
using AkademiECommerce.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiECommerce.Services.FakePaymentt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : CustomBaseController
    {

        [HttpPost]
        public IActionResult ReceivePayment()
        {
            return CreateActionResultInstance(ResponseDto<NoContent>.Success(200));
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;

namespace OnlineStore.API.Controllers.FrontUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService _invoiceService;
        private IOrderPaymentService _orderPaymentService;


        public InvoiceController(IInvoiceService invoiceService, IOrderPaymentService orderPaymentService)
        {
            _invoiceService = invoiceService;
            _orderPaymentService = orderPaymentService;
        }

        [HttpPost]
        public async Task<IActionResult> PayOrder(int orderId)
        {
            if (orderId < 1)
            {
                return BadRequest();
            }

            var invoiceModel = await _orderPaymentService.GenerateInvoiceForOrder(orderId);
            await _invoiceService.Add(invoiceModel);

            return Ok(invoiceModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }

            var invoiceModel = await _invoiceService.GetInvoiceById(id);

            if (invoiceModel.Id == 0)
            {
                return NotFound();
            }

            return Ok(invoiceModel);
        }
    }
}

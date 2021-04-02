using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartPaymentsController : ControllerBase
    {
        private readonly ICartPaymentService _cartPaymentService;

        public CartPaymentsController(ICartPaymentService cartPaymentService)
        {
            _cartPaymentService = cartPaymentService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _cartPaymentService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByCustomerId")]
        public IActionResult GetCartPaymentsByCustomerId(int customerId)
        {
            var result = _cartPaymentService.GetCartPaymentsByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(CartPayment cardPayment)
        {
            var result = _cartPaymentService.Add(cardPayment);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(CartPayment cardPayment)
        {
            var result = _cartPaymentService.Update(cardPayment);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(CartPayment cartPayment)
        {
            var result = _cartPaymentService.Delete(cartPayment);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

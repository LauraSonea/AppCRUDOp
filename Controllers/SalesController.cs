using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCRUDOp.Models;
using AppCRUDOp.Repositories;
using AppCRUDOp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AppCRUDOp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class SalesController : ControllerBase
    {

        private readonly ISaleRepository _saleRepository;

        public SalesController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet("GetAllSales")]
        public IActionResult GetAllSales()
        {
            try
            {
                var result = _saleRepository.GetAllSales();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get sales {ex}");
            }
            
            
        }

        [HttpPost("AddSale")]
        public async Task<IActionResult> AddSale(SaleViewModel saleViewModel)
        {
            try
            {
                var sale = new Sale();
                sale.CouponUsed = saleViewModel.CouponUsed;
                sale.PurchaseMethod = saleViewModel.PurchaseMethod;
                sale.SaleDate = saleViewModel.SaleDate;
                sale.StoreLocation = saleViewModel.StoreLocation;
                sale.Items = saleViewModel.Items;
                sale.Customer = saleViewModel.Customer;

                await _saleRepository.InsertOneAsync(sale);
                return Ok(new { error = string.Empty, status = "Add sale success.", saleId = sale.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = $"Add Sale error: {ex}" });
            }
        }


        [HttpGet("GetSaleById")]
        public ActionResult<Sale> GetSaleById(string id)
        {
            try
            {
                var sale = _saleRepository.FindSaleById(id);

                if (sale == null)
                {
                    return NotFound();
                }
                return Ok(sale);
            }
            catch (Exception ex)
            {

                return BadRequest(new { error = $"Get Sale by Id error: {ex}" });
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                var sale = _saleRepository.FindSaleById(id);

                if (sale == null)
                {
                    return NotFound();
                }

                _saleRepository.Delete(sale.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = $"Delete Sale error: {ex}" });
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(string id, Sale saleIn)
        {
            try
            {
                var sale = _saleRepository.FindSaleById(id);

                if (sale == null)
                {
                    return NotFound();
                }

                _saleRepository.Update(id, saleIn);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = $"Update Sale error: {ex}" });
            }
         
        }
    }
}

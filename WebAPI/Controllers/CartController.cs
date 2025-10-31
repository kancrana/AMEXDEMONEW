using eShop.Domain.Cart;
using eShop.Repository.EntityFramework.Cart;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace eShop.WebApi.Controllers
{
    [RoutePrefix("api/Cart")]
    public class CartController : ApiController
    {
        ICartRepository _cartRepository;
        private static ILog log = LogManager.GetLogger(typeof(CartController));

        /// <summary>
        /// TODO Dependency Inject Reposotory Here
        /// </summary>
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(CustomerCart))]
        public async Task<IHttpActionResult> GetCartById(string id)
        {
            var cart = await _cartRepository.GetCartAsync(id);
            return Ok(cart);
        }

        [HttpPost]
        [ResponseType(typeof(CustomerCart))]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateCartAsync(CustomerCart customerCart)
        {
            var cart = await _cartRepository.UpdateCartAsync(customerCart);
            
            return Ok(cart);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(Task<bool>))]
        public async Task<bool> DeteleCartAsync(string id)
        {
            return await _cartRepository.DeleteCartAsync(id);
        }
    }
}

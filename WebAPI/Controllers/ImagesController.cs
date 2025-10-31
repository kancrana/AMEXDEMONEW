
using eShop.Domain.ProductCatalog;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace eShop.WebApi.Controllers
{
    public class ImagesController : ApiController
    {
        private readonly IProductRepository _productRepo;
        private static ILog log = LogManager.GetLogger(typeof(ImagesController));

        public ImagesController(IProductRepository productRepository)
        {
            this._productRepo = productRepository;
        }
        [HttpGet]
        [Route("api/product/items/{productId:int}/image")]
        public async Task<HttpResponseMessage> GetImageAsync(int productId)
        {
            log.Info($"ImagesController -> GetImageAsync({productId}) Call Initiated");
            if (productId < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid ProductId");
            }
            var product = await _productRepo.FindByIdAsync(productId);
            if (product != null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + product.PictureFileName;
                var fileExtention = Path.GetExtension(product.PictureFileName);
                string mimeType = GetImageMimeType(fileExtention);
                var buffer = File.ReadAllBytes(path);
                MemoryStream ms = new MemoryStream(buffer);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(ms.ToArray());
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
                
                return response;
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not Found");
        }

        private string GetImageMimeType(string fileExtention)
        {
            string mimetype;
            switch (fileExtention)
            {
                case ".png":
                    mimetype = "image/png";
                    break;
                case ".gif":
                    mimetype = "image/gif";
                    break;
                case ".jpg":
                case ".jpeg":
                    mimetype = "image/jpeg";
                    break;
                case ".bmp":
                    mimetype = "image/bmp";
                    break;
                case ".tiff":
                    mimetype = "image/tiff";
                    break;
                case ".wmf":
                    mimetype = "image/wmf";
                    break;
                case ".jp2":
                    mimetype = "image/jp2";
                    break;
                case ".svg":
                    mimetype = "image/svg+xml";
                    break;
                default:
                    mimetype = "application/octet-stream";
                    break;
            }
            return mimetype;
        }
    }
}
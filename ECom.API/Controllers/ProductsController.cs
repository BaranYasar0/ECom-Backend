using ECom.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public void Get()
        {
            _productWriteRepository.AddRange(new()
            {
                new(){Id=Guid.NewGuid(),Stock=2,Name="pro 1",CreatedDate=DateTime.UtcNow,Price=123},
                new(){Id=Guid.NewGuid(),Stock=32,Name="pro 2",CreatedDate=DateTime.UtcNow,Price=1234},
                new(){Id=Guid.NewGuid(),Stock=21,Name="pro 3",CreatedDate=DateTime.UtcNow,Price=1233},
                new(){Id=Guid.NewGuid(),Stock=11,Name="Baran",CreatedDate=DateTime.UtcNow,Price=31}
            });
            _productWriteRepository.SaveAsync();
        }
    }
}

using AutoMapper;
using BLL.Interface;
using BLL.Repository;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Errors;
using Talabat.API.Helpers;
using Talabat.BLL.Specifications;
using Talabat.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Talabat.DAL.Entities.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Stripe;
using Product = DAL.Entities.Product;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepo<Product> genericRepo;
        private readonly commentsrepos icommentsrepos;
        private readonly IGenericRepo<ProductCategory> _productCategoriesRepo;
        private readonly IGenericRepo<ProductType> _productTypesRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly AlbumsRepo albumrepo;

        private readonly IMapper mapper;

        public ProductController(AlbumsRepo _albumrepo, UserManager<AppUser> userManager,commentsrepos _icommentsrepos, IWebHostEnvironment webHostEnvironment, IGenericRepo<Product> genericRepo, IGenericRepo<ProductCategory> productCategoryRepo, IGenericRepo<ProductType> productTypesRepo, IMapper mapper )
        {
            this.genericRepo = genericRepo;
            _productCategoriesRepo = productCategoryRepo;
            _productTypesRepo = productTypesRepo;
            this.mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            this.icommentsrepos = _icommentsrepos;
            _userManager=userManager;
            albumrepo = _albumrepo;

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> CreateProduct(ProductregDTO productDTO)
        {
            Product product = new Product();
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.PictureUrl = productDTO.PictureUrl;
            product.ProductTypeId = productDTO.ProductTypeId;
            product.ProductCategoryId = productDTO.ProductCategoryId;
            product.publisher = productDTO.publisher;
            //product.User.Email = productDTO.User.Email;

            await genericRepo.Add(product);

            return Ok(product);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProdsForAllProdsDTO>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndCategoriesSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await genericRepo.GetCountAsync(countSpec);

            var products = await genericRepo.GetAllWithSpecAsync(spec);
            //var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);
            //return Ok(new Pagination<ProductDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
            //var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProdsForAllProdsDTO>>(products);
            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProdsForAllProdsDTO>>(products);
            foreach (var item in data) {
                item.publisherdispname = _userManager.FindByEmailAsync(item.publisher).Result.DisplayName;
            }

            return Ok(new Pagination<ProdsForAllProdsDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }


        [HttpGet("/products/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<ProdsForAllProdsDTO>>> GetProductsbycat([FromQuery] ProductSpecParams productParams,int categoryId)
        {

            var spec = new ProductsWithTypesAndCategoriesSpecification(categoryId, 0);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await genericRepo.GetCountAsync(countSpec);

            var products = await genericRepo.GetAllWithSpecAsync(spec);
            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProdsForAllProdsDTO>>(products);
            foreach (var item in data)
            {
                item.publisherdispname = _userManager.FindByEmailAsync(item.publisher).Result.DisplayName;
            }
            return Ok(new Pagination<ProdsForAllProdsDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }


        [HttpGet("/products/images/{prodid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<ProdsForAllProdsDTO>>> getphotosbyprodid(int prodid)
        {
            List<string> images= await albumrepo.getalbums(prodid);
            
            return Ok(images);
        }







        [HttpGet("/VendorProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<ProdsForAllProdsDTO>>> GetProductsbyvendor([FromQuery] ProductSpecParams productParams, [FromQuery] string vendorname)
        {

            var spec = new ProductsWithTypesAndCategoriesSpecification(vendorname);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await genericRepo.GetCountAsync(countSpec);

            var products = await genericRepo.GetAllWithSpecAsync(spec);
            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProdsForAllProdsDTO>>(products);
            foreach (var item in data)
            {
                item.publisherdispname = _userManager.FindByEmailAsync(item.publisher).Result.DisplayName;
            }
            return Ok(new Pagination<ProdsForAllProdsDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }






        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndCategoriesSpecification(id);

            var product = await genericRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));

            //product.publisher = _userManager.FindByEmailAsync(product.publisher).Result.DisplayName;
            ProductDTO proda = mapper.Map<Product, ProductDTO>(product);
            proda.PubliserName= _userManager.FindByEmailAsync(product.publisher).Result.DisplayName;
            foreach (var comment in proda.comments) { 
            comment.dispname = _userManager.FindByEmailAsync(product.publisher).Result.DisplayName;
            }
            return Ok(proda);


        }


        



        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetCategories()
        {
            return Ok(await _productCategoriesRepo.GetAllAsync());
        }
     
        [HttpGet("types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetTypes()
        {
            return Ok(await _productTypesRepo.GetAllAsync());
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deleteproduct(int id)
        {
            var spec = new ProductsWithTypesAndCategoriesSpecification(id);

            Product product = await genericRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));

            else {
                //icommentsrepos.Delete(id);
                await genericRepo.Delete(product); }

            return NoContent();

        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, ProductregDTO productDTO)
        {
            

            Product product = new Product();
            product.Id = id;
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.PictureUrl = productDTO.PictureUrl;
            product.ProductTypeId = productDTO.ProductTypeId;
            product.ProductCategoryId = productDTO.ProductCategoryId;
            product.publisher = productDTO.publisher;
            await genericRepo.Update(product);

            return NoContent();
        }


        [HttpPost("uploadproductphoto")]
        public async Task<IActionResult> UploadPhoto(IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
                return BadRequest("No file was uploaded.");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/products", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
            var fullman = "images/products/" + fileName;
            return Ok(new { fullman });
        }


        [HttpPost("uploadproductalbum")]
        public async Task<IActionResult> UploadPhototoalbum(IFormFile photo,[FromForm]int id)
        {
            if (photo == null || photo.Length == 0)
                return BadRequest("No file was uploaded.");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/products", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
            var fullman = "images/products/" + fileName;
            productsandalbum prodpic = new productsandalbum();
            prodpic.image = fullman;
            prodpic.prodid = id;
            await albumrepo.Add(prodpic);

            return Ok(new { fullman });
        }









    }
}

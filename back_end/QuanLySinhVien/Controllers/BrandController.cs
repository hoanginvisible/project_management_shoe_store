using Microsoft.AspNetCore.Mvc;
using QuanLyCuaHangBanGiay.Domain.Entities;
using QuanLySinhVien.Model;
using Service;

namespace QuanLyCuaHangBanGiay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        /// <summary>
        /// Badrequest khi ma validate du lieu bi sai
        /// NotFound khi ma khong tim thay du lieu nao
        /// Co the validate bang ModelState.IsValid 
        /// </summary>
        IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            // return Ok(await _brandService.GetAllBrand());
            return Ok("get all");
        }

        /// <summary>
        /// co the truyen vao regex de validate dinh dang tham so truyen vao VD: {id:regex("")}
        /// dat min max cho id cung duoc VD: {id:int:min(10)} --> bắt buoc phai nhap id lon hon muoi
        /// co the dat nhieu Route VD: [Route("get")] và [Route("get-all")] khi goi hai router
        /// nay thi no deu tra ve chung mot controller
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBrandById()
        {
            // return Ok(await _brandService.GetAllBrand());
            return Ok("get by id");
        }
        
        [HttpPost]
        public IActionResult InsertBrand([FromBody] BrandModel brandModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(brandModel.Name))
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi serverf");
            }
            // await _brandService.Insert(brandModel);
            string name = brandModel.Name;
            return Ok(name);
        }

        // co the truyen thuoc tinh cho model tuy chinh, truyen truong nao cap nhat truong do
        [HttpPatch]
        public void UpdateBrand(Brand brand)
        {
            _brandService.Update(brand);
        }

        [HttpPut]
        public void ModifyBrand(Brand brand)
        {
            _brandService.Update(brand);
        }

        [HttpDelete]
        public void DeleteBrand(Brand brand)
        {
            _brandService.Delete(brand);
        }
    }
}
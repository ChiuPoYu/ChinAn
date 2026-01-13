using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ParamModels;
using WebApi.Models.ResponseModel;
using WebApi.Models.Views.App;
using WebApi.Services.Interfaces.App;

namespace WebApi.Controllers.App
{
    /// <summary>
    /// 材料管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Tags("材料功能")]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// 取得所有材料清單
        /// </summary>
        /// <returns>材料清單</returns>
        [HttpGet("GetAllMaterials")]
        [ProducesResponseType(typeof(ListResponse<MaterialView>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ListResponse<MaterialView>> GetAll()
        {
            var materials = await _materialService.GetAllAsync();
            return new ListResponse<MaterialView>(materials);
        }

        /// <summary>
        /// 根據 ID 取得單一材料
        /// </summary>
        /// <param name="id">材料編號</param>
        /// <returns>材料資料</returns>
        [HttpGet("GetMaterial/{id}")]
        [ProducesResponseType(typeof(DataResponse<MaterialView>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<DataResponse<MaterialView>> GetById(int id)
        {
            var material = await _materialService.GetByIdAsync(id);
            return new DataResponse<MaterialView>(material);
        }

        /// <summary>
        /// 新增材料
        /// </summary>
        /// <param name="param">新增材料參數</param>
        /// <returns>操作結果</returns>
        [HttpPost("CreateMaterial")]
        [ProducesResponseType(typeof(ResultResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ResultResponse> Create([FromBody] CreateMaterialParam param)
        {
            await _materialService.CreateAsync(param);
            return new ResultResponse();
        }

        /// <summary>
        /// 更新材料
        /// </summary>
        /// <param name="param">更新材料參數</param>
        /// <returns>操作結果</returns>
        [HttpPut("UpdateMaterial")]
        [ProducesResponseType(typeof(ResultResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ResultResponse> Update([FromBody] UpdateMaterialParam param)
        {
            await _materialService.UpdateAsync(param);
            return new ResultResponse();
        }

        /// <summary>
        /// 刪除材料
        /// </summary>
        /// <param name="id">材料編號</param>
        /// <returns>操作結果</returns>
        [HttpDelete("DeleteMaterial/{id}")]
        [ProducesResponseType(typeof(ResultResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ResultResponse> Delete(int id)
        {
            await _materialService.DeleteAsync(id);
            return new ResultResponse();
        }
    }
}

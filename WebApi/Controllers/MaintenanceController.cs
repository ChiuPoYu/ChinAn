using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ParamModels;
using WebApi.Models.ResponseModel;
using WebApi.Models.Views.App;
using WebApi.Services.Interfaces.App;

namespace WebApi.Controllers
{
    /// <summary>
    /// 車輛保養管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Tags("車輛保養")]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        /// <summary>
        /// 新增保養紀錄
        /// </summary>
        /// <param name="param">保養紀錄參數</param>
        /// <returns>操作結果</returns>
        [HttpPost("InsertMaintenanceRecord")]
        [ProducesResponseType(typeof(ResultResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ResultResponse> InsertMaintenanceRecord([FromBody] MaintenanceRecordParam param)
        {
            await _maintenanceService.InsertMaintenanceRecordAsync(param);
            return new ResultResponse();
        }

        /// <summary>
        /// 根據車牌號碼取得車輛保養紀錄
        /// </summary>
        /// <param name="plateNumber">車牌號碼</param>
        /// <returns>保養紀錄清單</returns>
        [HttpGet("GetMaintenanceRecords")]
        [ProducesResponseType(typeof(ListResponse<MaintenanceRecordView>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ListResponse<MaintenanceRecordView>> GetMaintenanceRecords([FromQuery] string plateNumber)
        {
            var result = await _maintenanceService.GetMaintenanceRecordsByPlateNumberAsync(plateNumber);
            return new ListResponse<MaintenanceRecordView>(result);
        }
    }
}




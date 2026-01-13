using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ParamModels;
using WebApi.Models.ResponseModel;
using WebApi.Models.Views.App;
using WebApi.Services.Interfaces.App;

namespace WebApi.Controllers.App
{
    /// <summary>
    /// 客戶管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Tags("客戶功能")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerSerivce _customerSerivce;

        public CustomerController(ICustomerSerivce customerSerivce)
        {
            _customerSerivce = customerSerivce;
        }

        /// <summary>
        /// 根據 ID 取得客戶資料
        /// </summary>
        /// <param name="id">客戶編號</param>
        /// <returns>客戶資料</returns>
        [HttpGet("GetCustomer/{id}")]
        [ProducesResponseType(typeof(DataResponse<CustomerView>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<DataResponse<CustomerView>> GetCustomer(int id)
        {
            var customer = await _customerSerivce.GetCustomerByIdAsync(id);
            return new DataResponse<CustomerView>(customer);
        }

        /// <summary>
        /// 取得所有客戶清單
        /// </summary>
        /// <returns>客戶清單</returns>
        [HttpGet("GetAllCustomers")]
        [ProducesResponseType(typeof(ListResponse<CustomerView>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ListResponse<CustomerView>> GetAllCustomers()
        {
            var customers = await _customerSerivce.GetAllCustomersAsync();
            return new ListResponse<CustomerView>(customers);
        }

        /// <summary>
        /// 建立新客戶
        /// </summary>
        /// <param name="param">建立客戶參數</param>
        /// <returns>操作結果</returns>
        [HttpPost("CreateCustomer")]
        [ProducesResponseType(typeof(ResultResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ResultResponse> CreateCustomer([FromBody] CreateCustomerParam param)
        {
            await _customerSerivce.CreateCustomerAsync(param);
            return new ResultResponse();
        }

        /// <summary>
        /// 更新客戶資料
        /// </summary>
        /// <param name="param">更新客戶參數</param>
        /// <returns>操作結果</returns>
        [HttpPut("UpdateCustomer")]
        [ProducesResponseType(typeof(ResultResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ResultResponse> UpdateCustomer([FromBody] UpdateCustomerParam param)
        {
            await _customerSerivce.UpdateCustomerAsync(param);
            return new ResultResponse();
        }

        /// <summary>
        /// 刪除客戶資料
        /// </summary>
        /// <param name="id">客戶編號</param>
        /// <returns>操作結果</returns>
        [HttpDelete("DeleteCustomer/{id}")]
        [ProducesResponseType(typeof(ResultResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ResultResponse> DeleteCustomer(int id)
        {
            await _customerSerivce.DeleteCustomerAsync(id);
            return new ResultResponse();
        }
    }
}

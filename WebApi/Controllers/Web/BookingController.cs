using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ParamModels;
using WebApi.Models.ResponseModel;
using WebApi.Models.Views.Web;
using WebApi.Services.Interfaces.Web;

namespace WebApi.Controllers.Web
{
    /// <summary>
    /// 預約管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Tags("預約功能")]
    public class BookingController : ControllerBase
    {
        public readonly IBookingSerive _bookingSerive;

        public BookingController(IBookingSerive bookingSerive)
        {
            _bookingSerive = bookingSerive;
        }

        /// <summary>
        /// 取得所有預約清單
        /// </summary>
        /// <returns>預約清單</returns>
        [HttpGet("GetBookingList")]
        [ProducesResponseType(typeof(ListResponse<BookingView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public async Task<ListResponse<BookingView>> GetBookingList()
        {
            var result = await _bookingSerive.GetBookingListAsync();
            return new ListResponse<BookingView>(result);
        }

        /// <summary>
        /// 根據 ID 取得預約資料
        /// </summary>
        /// <param name="id">預約編號</param>
        /// <returns>預約資料</returns>
        [HttpGet("GetBooking/{id}")]
        [ProducesResponseType(typeof(DataResponse<BookingView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public async Task<DataResponse<BookingView>> GetBooking(int id)
        {
            var result = await _bookingSerive.GetBookingByIdAsync(id);
            return new DataResponse<BookingView>(result);
        }

        /// <summary>
        /// 建立新預約
        /// </summary>
        /// <param name="param">建立預約參數</param>
        /// <returns>操作結果</returns>
        [HttpPost("CreateBooking")]
        [ProducesResponseType(typeof(ResultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ResultResponse> CreateBooking([FromBody] CreateBookingParam param)
        {
            await _bookingSerive.CreateBookingAsync(param);
            return new ResultResponse();
        }

        /// <summary>
        /// 更新預約資料
        /// </summary>
        /// <param name="param">更新預約參數</param>
        /// <returns>操作結果</returns>
        [HttpPut("UpdateBooking")]
        [ProducesResponseType(typeof(ResultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ResultResponse> UpdateBooking([FromBody] UpdateBookingParam param)
        {
            await _bookingSerive.UpdateBookingAsync(param);
            return new ResultResponse();
        }

        /// <summary>
        /// 取消預約
        /// </summary>
        /// <param name="bookingId">預約編號</param>
        /// <returns>操作結果</returns>
        [HttpDelete("CancelBooking/{bookingId}")]
        [ProducesResponseType(typeof(ResultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public async Task<ResultResponse> CancelBooking(int bookingId)
        {
            await _bookingSerive.CancelBookingAsync(bookingId);
            return new ResultResponse();
        }
    }
}

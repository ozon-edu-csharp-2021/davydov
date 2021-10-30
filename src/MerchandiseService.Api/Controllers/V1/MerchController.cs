using System;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Api.Models;
using MerchandiseService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Api.Controllers.V1
{
    /// <summary>
    ///     Мерч контроллер
    /// </summary>
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController : ControllerBase
    {
        /// <inheritdoc />
        public MerchController(IMerchService merchService)
        {
            _merchService = merchService;
        }

        private readonly IMerchService _merchService;
        
        /// <summary>
        ///     Запросить мерч
        /// </summary>
        /// <param name="merchItemId">Ид мерча</param>
        /// <param name="token">Токен отмены</param>
        /// <response code="200">Успешное проведение запроса</response>
        [HttpPut]
        [Route("{merchItemId:long}/issue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> IssueById(long merchItemId, CancellationToken token)
        {
            var merchItem = await _merchService.IssueMerch(merchItemId, token);
            return merchItem != null ? Ok() : NotFound();
        }
        
        /// <summary>
        ///     Получить информацию о выдаче мерча
        /// </summary>
        /// <param name="merchItemId">Ид мерча</param>
        /// <param name="token">Токен отмены</param>
        /// <response code="200">Успешное получение информации</response>
        [HttpGet]
        [Route("{merchItemId:long}/distribution")]
        [ProducesResponseType(typeof(MerchDistributionInfo), StatusCodes.Status200OK)]
        public async Task<ActionResult<MerchDistributionInfo>> GetDistributionInfoById(long merchItemId, CancellationToken token)
        {
            var distributionInfo = await _merchService.GetMerchDistributionInfo(merchItemId, token);
            return distributionInfo != null ? Ok(distributionInfo) : NotFound();
        }
    }
}
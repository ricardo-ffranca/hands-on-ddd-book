using Marketplace.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Marketplace.ClassifiedAd.Contracts;

namespace Marketplace.ClassifiedAd
{
    [Route("/ad")]
    public class ClassifiedAdsCommandsApi: ControllerBase
    {
        private readonly ClassifiedAdsApplicationService _applicationService;
        private static ILogger Log = Serilog.Log.ForContext<ClassifiedAdsCommandsApi>();

        public ClassifiedAdsCommandsApi(ClassifiedAdsApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public Task<IActionResult> Post(V1.Create request)
            => RequestHandler.HandleRequest(request, _applicationService.Handle, Log);

        [Route("name")]
        [HttpPut]
        public Task<IActionResult> Put(V1.SetTitle request)
            => RequestHandler.HandleRequest(request, 
                _applicationService.Handle, Log);

        [Route("text")]
        [HttpPut]
        public Task<IActionResult> Put(V1.UpdateText request)
            => RequestHandler.HandleRequest(request, 
                _applicationService.Handle, Log);

        [Route("price")]
        [HttpPut]
        public Task<IActionResult> Put(V1.UpdatePrice request)
            => RequestHandler.HandleRequest(request,
                _applicationService.Handle, Log);

        [Route("publish")]
        [HttpPut]
        public Task<IActionResult> Put(V1.RequestToPublish request)
            => RequestHandler.HandleRequest(request,
                _applicationService.Handle, Log);
    }
}

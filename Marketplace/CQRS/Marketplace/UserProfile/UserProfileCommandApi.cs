﻿using Marketplace.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.UserProfile
{
    [Route("/profile")]
    public class UserProfileCommandsApi : Controller
    {
        private readonly UserProfileApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<UserProfileCommandsApi>();

        public UserProfileCommandsApi(UserProfileApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public Task<IActionResult> Post(Contracts.V1.RegisterUser request)
            => RequestHandler.HandleRequest(request, _applicationService.Handle, Log);

        [Route("fullname")]
        [HttpPut]
        public Task<IActionResult> Put(Contracts.V1.UpdateUserFullName request)
            => RequestHandler.HandleRequest(request, _applicationService.Handle, Log);

        [Route("displayname")]
        [HttpPut]
        public Task<IActionResult> Put(Contracts.V1.UpdateUserDisplayName request)
            => RequestHandler.HandleRequest(request, _applicationService.Handle, Log);

        [Route("photo")]
        [HttpPut]
        public Task<IActionResult> Put(Contracts.V1.UpdateUserProfilePhoto request)
            => RequestHandler.HandleRequest(request, _applicationService.Handle, Log);
    }
}

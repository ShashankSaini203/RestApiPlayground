﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestApiPlayground.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController : ControllerBase
    {
        public readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}

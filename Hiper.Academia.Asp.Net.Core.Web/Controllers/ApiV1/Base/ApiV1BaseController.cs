using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Controllers.ApiV1.Base
{
    [ApiController]
    [ApiVersion("1")]
    public abstract class ApiV1BaseController : ControllerBase
    {
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Errors;
using Talabat.Controllers;
using Talabat.Errors;

namespace Talabat.API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public ActionResult Error(int code)
        {  
            return new ObjectResult(new ApiResponse(code));
        }
    }
}

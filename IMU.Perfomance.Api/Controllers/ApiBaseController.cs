using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMU.Perfomance.Api.Controllers
{
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    }
}

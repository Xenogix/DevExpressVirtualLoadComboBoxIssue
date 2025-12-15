using LoadComboboxFilterIssue.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoadComboboxFilterIssue.Controllers
{
    [ApiController]
    [Route("metrics")]
    public class MetricsController : ControllerBase
    {
        [HttpGet("memory")]
        public ActionResult<MemorySnapshot> GetMemory()
        {
            var proc = Process.GetCurrentProcess();
            var ws = proc.WorkingSet64;
            var allocated = GC.GetTotalMemory(false);

            var snapshot = new MemorySnapshot(
                WorkingSetBytes: ws,
                TotalAllocatedBytes: allocated
            );

            return Ok(snapshot);
        }
    }
}

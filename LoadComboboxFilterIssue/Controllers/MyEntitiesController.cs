using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LoadComboboxFilterIssue.Shared.Database;
using Microsoft.AspNetCore.Mvc;

namespace LoadComboboxFilterIssue.Controllers
{
    [ApiController]
    [Route("")]
    public class MyEntitiesController(MyDbContext dbContext) : ControllerBase
    {
        [HttpPost("combobox")]
        public virtual async Task<ActionResult<LoadResult>> LoadComboBox([FromBody] DataSourceLoadOptionsBase options)
        {
            return DataSourceLoader.Load(dbContext.MyEntities, options);
        }
    }
}

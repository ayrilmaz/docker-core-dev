using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        readonly ILogger<UserController> logger;
        MyDbContext dbContext;

        public UserController(ILogger<UserController> logger, MyDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet("List")]
        public ActionResult<IEnumerable> List()
        {
            try
            {
                return dbContext.Users.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "User-List:");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CreateLog")]
        public ActionResult CreateLog()
        {
            try
            {
                dbContext.Add(new User());
                dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "User-CreateLog:");
                return BadRequest(ex.Message);
            }
        }
    }
}

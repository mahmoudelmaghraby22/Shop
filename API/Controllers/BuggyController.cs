using API.Controllers;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Errors
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult NotFoundRequest()
        {
            var thing = _context.Products.Find(58);

            if (thing == null)
                return NotFound(new ApiResponse(404));
            
            return Ok();
        }
        
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(58);

            var thingToReturn = thing.ToString();
            
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest(id);
        }
    }
}
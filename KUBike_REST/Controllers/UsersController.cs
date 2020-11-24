using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KUBike_REST.DBUTil;
using lib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KUBike_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ManageUser mgr = new ManageUser();
        // GET: api/<CyclesController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return mgr.HentAlle();
        }

        // GET api/<CyclesController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return mgr.HentEn(id);
        }

        // POST api/<CyclesController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            mgr.OpretUser(value);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NubimetricsChallenge.Context;
using NubimetricsChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NubimetricsChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;

        public UsersController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Users.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}",Name="GetUser")]
        public ActionResult Get(int id)
        {
            try
            {
                User user = context.Users.FirstOrDefault(user => user.Id == id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return CreatedAtRoute("GetUser", new { Id = user.Id }, user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                if (user.Id == id)
                {
                    context.Users.Update(user);
                    context.SaveChanges();
                    return CreatedAtRoute("GetUser", new { Id = user.Id }, user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                User user = context.Users.FirstOrDefault(user => user.Id == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

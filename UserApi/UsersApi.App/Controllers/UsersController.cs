using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UsersApi.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Business.Models;

namespace UsersApi.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _iUserBusiness;
        public UsersController(IUserBusiness iUserBusiness)
        {
            _iUserBusiness = iUserBusiness;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var requestResult = await _iUserBusiness.GetUsers(cancellationToken);

            return Ok(requestResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute]int id, CancellationToken cancellationToken)
        {
            var requestResult = await _iUserBusiness.GetUser(id, cancellationToken);

            return Ok(requestResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]User user, CancellationToken cancellationToken)
        {
            var requestResult = await _iUserBusiness.CreateUser(user, cancellationToken);

            return Ok(requestResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]User user, CancellationToken cancellationToken)
        {

            var requestResult = await _iUserBusiness.UpdateUser(id, user, cancellationToken);

            return Ok(requestResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id, CancellationToken cancellationToken)
        {
           var requestResult = await  _iUserBusiness.DeleteUser(id, cancellationToken);

            return Ok(requestResult);
        }

    }
}
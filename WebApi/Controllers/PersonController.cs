using Application.Features.ConnectedPersons.Commands.Create;
using Application.Features.ConnectedPersons.Queries;
using Application.Features.Persons.Commands.Create;
using Application.Features.Persons.Commands.Delete;
using Application.Features.Persons.Commands.Update;
using Application.Features.Persons.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Person
        [HttpGet("PersonsList")]
        public async Task<ActionResult<List<PersonListVM>>> GetAllPersons()
        {
            var dto = await _mediator.Send(new GetPersonListQuery());
            return Ok(dto);
        }

        [HttpGet("GetPersonById")]
        public async Task<ActionResult<List<PersonListVM>>> GetPersonById(int id)
        {
            return Ok();
        }

        [HttpPost("AddPerson")]
        public async Task<ActionResult<int>> AddPerson(CreatePersonCommand createPersonCommand)
        {
            var response = await _mediator.Send(createPersonCommand);
            return Ok(response);
        }

        [HttpDelete("DeletePerson")]
        public async Task<ActionResult<Unit>> DeletePerson(int id)
        {
            var response = await _mediator.Send(new DeletePersonCommand { Id = id });
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Unit>> Update(UpdatePersonCommand updatePersonCommand)
        {
            var response = await _mediator.Send(updatePersonCommand);
            return Ok(response);
        }

        [HttpPost("UploadImage")]
        public async Task<ActionResult<Unit>> UploadImage(string imageBase64Url)
        {
            return Ok();
        }

        #endregion

        #region ConnectedPersons

        [HttpGet("ConnectedPersonsList")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<List<ConnectedPersonsListVM>>> GetAllConnectedPersonsByPersonId(int id)
        {
            var dto = await _mediator.Send(new GetConnectedPersonsListQuery(id));
            return Ok(dto);
        }

        [HttpPost("AddConnectedPerson")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Unit>> AddConnectedPerson(CreateConnectedPersonCommand createConnectedPersonCommand)
        {
            var dto = await _mediator.Send(createConnectedPersonCommand);
            return Ok(dto);
        }

        [HttpDelete("DeleteConnectedPerson")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<List<PersonListVM>>> DeleteConnectedPerson()
        {
            return Ok();
        }


        #endregion

        #region Report



        #endregion
    }
}

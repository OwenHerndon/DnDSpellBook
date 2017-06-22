using DnDSpellBook.DAL;
using DnDSpellBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DnDSpellBook.Controllers
{
    public class AddCharacterController : ApiController
    {


        readonly IAddCharacterRepository _addCharacterRepository;

        public AddCharacterController(IAddCharacterRepository addCharacterRepository)
        {
            _addCharacterRepository = addCharacterRepository;
        }

        [HttpPost, Route("api/character/new")]
        public HttpResponseMessage addNewCharacter(Character character)
        {
            if (string.IsNullOrWhiteSpace(character.Name))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Name");
            }

            _addCharacterRepository.AddNewCharacter(character);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}

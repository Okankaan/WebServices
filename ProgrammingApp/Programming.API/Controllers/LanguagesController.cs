using Programming.API.Attributes;
using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Programming.API.Controllers
{
    public class LanguagesController : ApiController
    {
        [HttpGet] //or use method name like "GetSearchByName".
        public IHttpActionResult SearchByName(string name) //http://localhost:50570/api/languages?name=Anders
        {
            return Ok("name: " + name);
        }

        public IHttpActionResult GetSearchBySurname(string surname) //http://localhost:50570/api/languages?surname=Gosling
        {
            return Ok("surname: " + surname);
        }

        LanguagesDAL languagesDAL = new LanguagesDAL();
        [ResponseType(typeof(IEnumerable<Languages>))]
        [HttpGet] //or use method name like "GetAllLanguages".
        public IHttpActionResult AllLanguages()
        {
            var languages = languagesDAL.GetAllLanguages();
            return Ok(languages);
        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Get(int id)
        {
            var language = languagesDAL.GetAllLanguageById(id);
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Post(Languages language)
        {
            if (ModelState.IsValid)
            {
                var createdLanguage = languagesDAL.CreateLanguage(language);
                return CreatedAtRoute("DefaultApi", new { id = createdLanguage.ID }, createdLanguage);//First and Second parameters using from App_Start/WebApiConfig.cs (Route name and template).
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Put(int id, Languages language)
        {

            if (!languagesDAL.IsThereAnyLanguage(id)) //1- FirstOfAll, If the record for the id value does not exist in DB
            {
                return NotFound();
            }
            else if (!ModelState.IsValid) //2- If the language model is not valid
            {
                return BadRequest(ModelState);
            }
            else //3- If the language model is valid (OK)
            {
                return Ok(languagesDAL.UpdateLanguage(id, language));
            }
        }

        public IHttpActionResult Delete(int id)
        {
            if (!languagesDAL.IsThereAnyLanguage(id)) //1- FirstOfAll, If the record for the id value does not exist in DB
            {
                return NotFound();
            }
            else
            {
                languagesDAL.DeleteLanguage(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}

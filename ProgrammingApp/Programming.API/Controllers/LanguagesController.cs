using Programming.API.Attributes;
using Programming.API.Security;
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
    [APIAuthorize(Roles = "A")]//at the level of Controller(All methods of this Controller can used by Admin Role) using For my custom Authorization control from APIAuthorizaAttribute.cs -> Just "User Role = A" users(Admin Role users) in DB can see this method response  
    public class LanguagesController : ApiController
    {
        LanguagesDAL languagesDAL = new LanguagesDAL();

        [HttpGet] //or use method name like "GetSearchByName".
        [Authorize]//For Authorization control.
        public IHttpActionResult SearchByName(string name) //http://localhost:50570/api/languages?name=Anders
        {
            return Ok("Name: " + User.Identity.Name);
        }

        public IHttpActionResult GetSearchBySurname(string surname) //http://localhost:50570/api/languages?surname=Gosling
        {
            return Ok("Surname: " + surname);
        }

        [ResponseType(typeof(IEnumerable<Languages>))]
        //[APIAuthorize(Roles = "A")]//For my custom Authorization control from APIAuthorizaAttribute.cs -> Just "User Role = A" users(Admin Role) in DB can see this method response  
        public IHttpActionResult Get()
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

using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Programming.API.Controllers
{
    public class LanguagesController : ApiController
    {
        LanguagesDAL languagesDAL = new LanguagesDAL();
        public HttpResponseMessage Get()
        {
            var languages= languagesDAL.GetAllLanguages();
            return Request.CreateResponse(HttpStatusCode.OK, languages);
        }

        public HttpResponseMessage Get(int id)
        {
            var language= languagesDAL.GetAllLanguageById(id);
            if (language==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No such a record found (Böyle bir kayıt bulunamadı).");
            }
            return Request.CreateResponse(HttpStatusCode.OK, language);

        }
        public HttpResponseMessage Post(Languages language)
        {
            if (ModelState.IsValid)
            {
                var createdLanguage = languagesDAL.CreateLanguage(language);
                return Request.CreateResponse(HttpStatusCode.Created, createdLanguage);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
        }
        public HttpResponseMessage Put(int id, Languages language)
        {
            
            if (!languagesDAL.IsThereAnyLanguage(id)) //1- FirstOfAll, If the record for the id value does not exist in DB
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found for id param (id parametresine ait kayıt bulunamadı).");
            }
            else if (!ModelState.IsValid) //2- If the language model is not valid
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else //3- If the language model is valid (OK)
            {
                return Request.CreateResponse(HttpStatusCode.OK, languagesDAL.UpdateLanguage(id, language));  
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            if (!languagesDAL.IsThereAnyLanguage(id)) //1- FirstOfAll, If the record for the id value does not exist in DB
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found for id param (id parametresine ait kayıt bulunamadı).");
            }
            else 
            {
                languagesDAL.DeleteLanguage(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
    }
}

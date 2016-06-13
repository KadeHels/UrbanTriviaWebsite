using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class WordsController : ApiController
    {
        private WordRepository _repo;

        public WordsController(WordRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Word> Get()
        {
            var words = _repo.GetWords();

            return words;
        }
        public HttpResponseMessage Post([FromBody]Word newWord)
        {
            if(_repo.AddWord(newWord) &&
                _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created,
                    newWord);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}

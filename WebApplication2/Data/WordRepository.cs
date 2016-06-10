using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Data
{
    public class WordRepository : IWordRepository
    {
        private WordContext _ctx;
        public WordRepository(WordContext ctx)
        {
            this._ctx = ctx;
        }
        public IQueryable<Word> GetWords()
        {
            return _ctx.Words;
        }

        public IQueryable<Word> GetWordsById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
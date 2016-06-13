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

        public bool AddWord(Word newWord)
        {
            try
            {
                _ctx.Words.Add(newWord);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IQueryable<Word> GetWords()
        {
            return _ctx.Words;
        }

        public IQueryable<Word> GetWordsById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception)
            {
                //Todo watch error
                return false;
            }
        }
    }
}
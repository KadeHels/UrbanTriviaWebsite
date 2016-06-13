using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Data
{
    public interface IWordRepository
    {
        IQueryable<Word> GetWords();
        IQueryable<Word> GetWordsById(int Id);

        bool Save();

        bool AddWord(Word newWord);
    }
}
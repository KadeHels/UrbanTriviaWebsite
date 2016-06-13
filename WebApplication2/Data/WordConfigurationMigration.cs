using System.Data.Entity.Migrations;
using System.Linq;

namespace WebApplication2.Data
{
    public class WordConfigurationMigration : DbMigrationsConfiguration<WordContext>
    {
        public WordConfigurationMigration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }
        //starts every time the program restarts 
        protected override void Seed(WordContext context)
        {
            //Should only be used in a debugging mode must use caution
            base.Seed(context);
            if (context.Words.Count() == 0)
            {
                var word = new Word() {
                    Name = "Test Word",
                    Definition = "A word that should be used for testing and not included in the actual game",
                    Url = "UrbanDictionary.com/TestWord"
                };
                context.Words.Add(word);

                try
                {
                    context.SaveChanges();
                }
                catch (System.Exception e)
                { 

                    throw e;
                }
            }
        }
    }
}
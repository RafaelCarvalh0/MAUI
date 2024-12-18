using AppJogoForca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJogoForca.Repositories
{
    public interface IWordRepository
    {
        Task<Word> GetWordSync();
    }

    public class WordRepository : IWordRepository
    {
        public WordRepository() { }

        public async Task<Word> GetWordSync()
        {
            var words = new List<Word>
            {
                new Word("Nome", "Maria"),
                new Word("Vegetal", "Cenoura"),
                new Word("Fruta", "Abacate"),
                new Word("Tempero", "Ajinomoto")
            };

            Random random = new Random();
            int item = random.Next(0, words.Count);

            return words[item];
        }
    }
}

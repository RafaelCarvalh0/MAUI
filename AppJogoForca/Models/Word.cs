using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJogoForca.Models
{
    public class Word
    {
        public Word(string Tips, string Text) 
        { 
            this.Tips = Tips;
            this.Text = Text;
        }

        public string Tips { get; set; }
        public string Text { get; set; }
    }
}

using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVVMCommunityToolkit.Libraries.Messages
{
    //Se quiser trocar o envio do (Generics), pode ser string, int, decimal, object... qualquer coisa!
    // Então o tipo de dados que queremos enviar é só setarmos no Generics Ex: ValueChangedMessage<int> , ValueChangedMessage<Person>
    public class TextMessage : ValueChangedMessage<string> 
    {
        // Recebe um text no construtor e repassa o text tbem para o construtor da classe herdada, pois ele tbem precisa de uma string
        public TextMessage(string text) : base(text) 
        {
        }
    }
}

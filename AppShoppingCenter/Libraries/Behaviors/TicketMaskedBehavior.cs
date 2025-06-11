using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppShoppingCenter.Libraries.Behaviors
{
    public class TicketMaskedBehavior : Behavior<Entry>
    {
        private Entry _entry;

        protected override void OnAttachedTo(Entry bindable)
        {
            _entry = bindable;
            _entry.TextChanged += OnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            _entry.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue)) return;

            // Remove espaços existentes para evitar duplicar
            var text = e.NewTextValue.Replace(" ", string.Empty);

            // Agrupa em blocos de 3 caracteres separados por espaço
            var newText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                newText += text[i];
                if ((i + 1) % 3 == 0 && i != text.Length - 1)
                    newText += " ";
            }

            if (_entry.Text != newText)
                _entry.Text = newText;
        }
    }
}

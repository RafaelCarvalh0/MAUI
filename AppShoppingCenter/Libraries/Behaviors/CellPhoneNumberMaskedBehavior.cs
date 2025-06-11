using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppShoppingCenter.Libraries.Behaviors
{
    public class CellPhoneNumberMaskedBehavior : Behavior<Entry>
    {
        public string Mask { get; set; }
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
            if (string.IsNullOrEmpty(Mask)) return;

            string value = Regex.Replace(e.NewTextValue ?? "", "[^0-9]", "");
            int index = 0;
            var formatted = "";

            foreach (char c in Mask)
            {
                if (c == '9')
                {
                    if (index < value.Length)
                        formatted += value[index++];
                    else
                        break;
                }
                else
                {
                    if (index < value.Length)
                        formatted += c;
                    else
                        break;
                }
            }

            if (_entry.Text != formatted)
                _entry.Text = formatted;
        }
    }
}

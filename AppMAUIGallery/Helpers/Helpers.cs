using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Helpers
{
    internal static class Helpers
    {
        public static T FindParent<T>(Element element) where T : Element
        {
            while (element != null)
            {
                if (element is T parent)
                    return parent;

                element = element.Parent;
            }
            return null;
        }
    }
}

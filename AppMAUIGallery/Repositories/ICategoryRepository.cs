using AppMAUIGallery.Models;
using AppMAUIGallery.Views;
using AppMAUIGallery.Views.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly IServiceProvider _serviceProvider;
        public CategoryRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<List<Category>> GetCategories()
        {
            //var stackLayoutPage = _serviceProvider.GetService<StackLayoutPage>();

            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Name = "Layout",
                    Components = new List<Component>
                    {
                        new Component
                        {
                            Title = "StackLayout",
                            Description = "Organização sequencial dos elementos.",
                            Page = typeof(StackLayoutPage)
                        },
                        new Component
                        {
                            Title = "Grid",
                            Description = "Organiza os elementos dentro de uma tabela.",
                            Page = typeof(GridLayoutPage)
                        },
                        new Component
                        {
                            Title = "AbsoluteLayout",
                            Description = "Liberdade total para posicionar e dimensionar os elementos na tela",
                            Page = typeof(AbsoluteLayoutPage)
                        },
                        new Component
                        {
                            Title = "FlexLayout",
                            Description = "Organiza os elementos de forma sequencial com muitas opções de personalização",
                            Page = typeof(FlexLayoutPage)
                        }
                    }
                }
            };

            return categories;
        }
    }
}

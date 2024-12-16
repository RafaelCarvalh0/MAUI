using AppMAUIGallery.Models;
using AppMAUIGallery.Views;
using AppMAUIGallery.Views.Components.Mains;
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
                },
                new Category
                {
                    Name = "Componentes(Views)",
                    Components = new List<Component>
                    {
                        new Component
                        {
                            Title = "BoxView",
                            Description = "Um componente que cria uma caixa para ser apresentada.",
                            Page = typeof(BoxViewPage)
                        },
                        new Component
                        {
                            Title = "Label",
                            Description = "Apresenta um texto na tela.",
                            Page = typeof(LabelPage)
                        },
                        new Component
                        {
                            Title = "Button",
                            Description = "Apresenta um botão na tela.",
                            Page = typeof(ButtonPage)
                        },
                         new Component
                        {
                            Title = "Image",
                            Description = "Apresenta uma imagem na tela.",
                            Page = typeof(ImagePage)
                        },
                         new Component
                        {
                            Title = "ImageButton",
                            Description = "Apresenta uma imagem com comportamento de botão.",
                            Page = typeof(ImageButtonPage)
                        }
                    }
                }
            };
            //categories.Add

            return categories;
        }
    }
}

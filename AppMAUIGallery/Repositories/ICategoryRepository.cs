﻿using AppMAUIGallery.Models;
using AppMAUIGallery.Views;
using AppMAUIGallery.Views.Cells;
using AppMAUIGallery.Views.Components.Forms;
using AppMAUIGallery.Views.Components.Mains;
using AppMAUIGallery.Views.Components.Visuals;
using AppMAUIGallery.Views.Layouts;
using AppMAUIGallery.Views.Lists;
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
        public async Task<List<Category>> GetCategories()
        {
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
                },
                new Category
                {
                    Name = "Visuais",
                    Components = new List<Component>
                    {
                        new Component
                        {
                            Title = "Frame",
                            Description = "Caixa que envolve outros elementos. (Deprecated)",
                            Page = typeof(FramePage)
                        },
                        new Component
                        {
                            Title = "Border",
                            Description = "Caixa que envolve outros elementos.",
                            Page = typeof(BorderPage)
                        },
                        new Component
                        {
                            Title = "Shadow",
                            Description = "Adiciona uma sombra ao elemento.",
                            Page = typeof(ShadowPage)
                        }
                    }
                },
                new Category
                {
                    Name = "Formulários",
                    Components = new List<Component>
                    {
                        new Component
                        {
                            Title = "Entry",
                            Description = "Cria uma caixa de entrada de texto.",
                            Page = typeof(EntryPage)
                        },
                        new Component
                        {
                            Title = "Editor",
                            Description = "Cria uma caixa de entrada de texto de múltiplas linhas.",
                            Page = typeof(EditorPage)
                        },
                        new Component
                        {
                            Title = "Checkbox",
                            Description = "Cria uma caixa de marcação.",
                            Page = typeof(CheckBoxPage)
                        },
                        new Component
                        {
                            Title = "RadioButton",
                            Description = "Cria uma caixa de marcação de escolha única.",
                            Page = typeof(RadioButtonPage)
                        },
                        new Component
                        {
                            Title = "Switch",
                            Description = "Caixa de marcação booleana.",
                            Page = typeof(SwitchPage)
                        },
                        new Component
                        {
                            Title = "Stepper",
                            Description = "Cria opções de incrementar ou decrementar um número.",
                            Page = typeof(StepperPage)
                        },
                        new Component
                        {
                            Title = "Slider",
                            Description = "Cria uma barra de rolagem de incrementar ou decrementar um número.",
                            Page = typeof(SliderPage)
                        },
                        new Component
                        {
                            Title = "TimePicker",
                            Description = "Seleção da Hora e minuto.",
                            Page = typeof(TimerPickerPage)
                        },
                        new Component
                        {
                            Title = "DatePicker",
                            Description = "Seleção da Data.",
                            Page = typeof(DatePickerPage)
                        },
                        new Component
                        {
                            Title = "SearchBar",
                            Description = "Campo de entrada de texto para pesquisa.",
                            Page = typeof(SearchBarPage)
                        },
                        new Component
                        {
                            Title = "Picker",
                            Description = "Selecionar um item da lista.",
                            Page = typeof(PickerPage)
                        }
                    }
                },
                new Category
                {
                    Name = "Células",
                    Components = new List<Component>
                    {
                        new Component
                        {
                            Title = "TextCell",
                            Description = "Apresenta até duas labels onde uma é destinada ao título e outra a descrição.",
                            Page = typeof(TextCellPage)
                        },
                        new Component
                        {
                            Title = "ImageCell",
                            Description = "Apresenta uma imagem com duas labels onde uma é destinada ao título e outra a descrição.",
                            Page = typeof(ImageCellPage)
                        },
                        new Component
                        {
                            Title = "SwitchCell",
                            Description = "Apresenta uma label em conjunto com um switch.",
                            Page = typeof(SwitchCellPage)
                        },
                         new Component
                        {
                            Title = "EntryCell",
                            Description = "Apresenta uma label em conjunto com um Entry.",
                            Page = typeof(EntryCellPage)
                        },
                          new Component
                        {
                            Title = "ViewCell",
                            Description = "Permite criar uma célula com layout personalizado.",
                            Page = typeof(ViewCellPage)
                        }
                    } 
                },
                new Category
                {
                    Name = "Listas e Coleções",
                    Components = new List<Component>
                    {
                        new Component
                        {
                            Title = "TableView",
                            Description = "Apresenta células em linhas separadas e permite agrupar por seção.",
                            Page = typeof(TableViewPage)
                        },
                        new Component
                        {
                            Title = "Picker",
                            Description = "Apresenta uma lista de seleção única.",
                            Page = typeof(PickerListPage)
                        },
                        new Component
                        {
                            Title = "ListView",
                            Description = "Apresenta uma lista de itens.",
                            Page = typeof(ListViewPage)
                        }
                    }
                }
            };
            //categories.Add

            return categories;
        }
    }
}

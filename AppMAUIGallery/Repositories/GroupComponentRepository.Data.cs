﻿using AppMAUIGallery.Models;
using AppMAUIGallery.Shells;
using AppMAUIGallery.Views.Animations;
using AppMAUIGallery.Views.Cells;
using AppMAUIGallery.Views.CommunityMaui;
using AppMAUIGallery.Views.Components.Forms;
using AppMAUIGallery.Views.Components.Mains;
using AppMAUIGallery.Views.Components.Visuals;
using AppMAUIGallery.Views.Layouts;
using AppMAUIGallery.Views.Lists;
using AppMAUIGallery.Views.Styles;
using AppMAUIGallery.Views.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Repositories
{
    public partial class GroupComponentRepository : IGroupComponentRepository
    {
        private void LoadComponents()
        {
            _components = new List<Component>();
            _groupComponents = new List<GroupComponent>();

            LoadLayouts();
            LoadControls();
            LoadVisuals();
            LoadForms();
            LoadCells();
            LoadCollections();
            LoadStyles();
            LoadAnimations();
            LoadUtils();
            LoadCommunityMaui();
            LoadShell();
        }

        private void LoadLayouts()
        {
            var components = new List<Component>
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
            };

            // É uma classe comun que herda de um List<Component>
            var group = new GroupComponent { Name = "Layout" };

            // Por causa dessa herança que consigo utilizar o método AddRange
            // Então ele irá adicionar uma lista no indice do primeiro group criado
            // Parece um pouco confuso, mas entendendo de herança se torna simples
            group.AddRange(components);

            // Adiciona um array de componentes de forma sequencial (Por ser lista, precisa usar o método AddRange)
            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadControls()
        {
            var components = new List<Component>
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
            };

            var group = new GroupComponent { Name = "Controles (Views)" };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadVisuals()
        {
            var components = new List<Component>
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
            };

            var group = new GroupComponent { Name = "Visuais" };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadForms()
        {
            var components = new List<Component>
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
            };

            var group = new GroupComponent { Name = "Formulários" };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadCells()
        {
            var components = new List<Component>
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
            };

            var group = new GroupComponent { Name = "Células" };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadCollections()
        {
            var components = new List<Component>
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
                },
                new Component
                {
                    Title = "CollectionView",
                    Description = "Apresenta uma lista de itens.",
                    Page = typeof(CollectionViewPage)
                },
                new Component
                {
                    Title = "CarouselView",
                    Description = "Apresenta uma lista de itens horizontais com navegação lateral.",
                    Page = typeof(CarouselViewPage)
                },
                new Component
                {
                    Title = "BindableLayout (Atributo)",
                    Description = "Permite que os layouts possam apresentar nossas listas e coleções.",
                    Page = typeof(BindableLayoutPage)
                },
                new Component
                {
                    Title = "DataTemplateSelector (Classe)",
                    Description = "Permite que os itens possam ser apresentados com layouts diferentes.",
                    Page = typeof(DataTemplateSelectorPage)
                }
            };

            var group = new GroupComponent { Name = "Listas e Coleções" };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadStyles()
        {
            var components = new List<Component>
            {
                new Component
                {
                    Title = "Implicit & Explicit Styles",
                    Description = "Explicar como funciona os estilos.",
                    Page = typeof(ImplicitExplicitStyles)
                },
                new Component
                {
                    Title = "Global Style",
                    Description = "Aplica estilo global para todo o projeto.",
                    Page = typeof(GlobalStyle)
                },
                new Component
                {
                    Title = "ApplyToDerivedTypes",
                    Description = "Aplicar um estilo aos elementos derivados da classe/componente atual.",
                    Page = typeof(ApplyDerivedTypes)
                },
                new Component
                {
                    Title = "Inheritance Style",
                    Description = "Como criar estilos derivados de outros.",
                    Page = typeof(InheritanceStyle)
                },
                new Component
                {
                    Title = "Style Class",
                    Description = "Cria classes de estilos para serem aplicados aos componentes.",
                    Page = typeof(StyleClassPage)
                },
                new Component
                {
                    Title = "StaticResource/DynamicResource",
                    Description = "Define se o estilo pode ser alterado em tempo real.",
                    Page = typeof(StaticDynamicResource)
                },
                new Component
                {
                    Title = "Tema",
                    Description = "Define um tema padrão para o nosso projeto.",
                    Page = typeof(Theme)
                },
                new Component
                {
                    Title = "AppThemeBinding",
                    Description = "Adapta o tema ao modo claro/escuro do sistema operacional.",
                    Page = typeof(AppThemeBindingPage)
                },
                new Component
                {
                    Title = "Visual State Manager (VSM)",
                    Description = "Personalizar a apresentação de acordo com o estado do componente.",
                    Page = typeof(VisualStateManagerPage)
                }
            };

            // É uma classe comun que herda de um List<Component>
            var group = new GroupComponent { Name = "Styles" };

            // Por causa dessa herança que consigo utilizar o método AddRange
            // Então ele irá adicionar uma lista no indice do primeiro group criado
            // Parece um pouco confuso, mas entendendo de herança se torna simples
            group.AddRange(components);

            // Adiciona um array de componentes de forma sequencial (Por ser lista, precisa usar o método AddRange)
            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadAnimations()
        {
            var components = new List<Component>
            {
                new Component
                {
                    Title = "Basic Animation",
                    Description = "Animação básica do .NET MAUI.",
                    Page = typeof(BasicAnimation)
                }
            };

            // É uma classe comun que herda de um List<Component>
            var group = new GroupComponent { Name = "Animations" };

            group.AddRange(components);

            // Adiciona um array de componentes de forma sequencial (Por ser lista, precisa usar o método AddRange)
            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadUtils()
        {
            var components = new List<Component>
            {
                new Component
                {
                    Title = "Behavior",
                    Description = "Lógica que pode ser associada a um componente da tela.",
                    Page = typeof(BehaviorPage)
                },
                new Component
                {
                    Title = "Trigger",
                    Description = "Gatilho que dispara uma alteração visual no componente.",
                    Page = typeof(TriggerPage)
                },
                new Component
                {
                    Title = "OnPlatform/OnIdiom",
                    Description = "Define valores diferentes entre o S.O e também pelo tipo de dispositivo.",
                    Page = typeof(PlatformIdiomPage)
                },
                new Component
                {
                    Title = "Fontes",
                    Description = "Como usar fontes diferentes no nosso aplicativo.",
                    Page = typeof(FontPage)
                },
                new Component
                {
                    Title = "Color/Brush",
                    Description = "Como colocar as cores nos seus componentes.",
                    Page = typeof(ColorPage)
                }
            };

            // É uma classe comun que herda de um List<Component>
            var group = new GroupComponent { Name = "Útils" };

            // Por causa dessa herança que consigo utilizar o método AddRange
            // Então ele irá adicionar uma lista no indice do primeiro group criado
            // Parece um pouco confuso, mas entendendo de herança se torna simples
            group.AddRange(components);

            // Adiciona um array de componentes de forma sequencial (Por ser lista, precisa usar o método AddRange)
            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadCommunityMaui()
        {
            var components = new List<Component>
            {
                new Component
                {
                    Title = "Snackbar e Toast",
                    Description = "Formas de emitir alertas para o usuário.",
                    Page = typeof(AlertsPage)
                }
            };

            var group = new GroupComponent { Name = ".NET MAUI Community Toolkit" };

            group.AddRange(components);

            // Adiciona um array de componentes de forma sequencial (Por ser lista, precisa usar o método AddRange)
            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadShell()
        {
            var components = new List<Component>
            {
                new Component
                {
                    Title = "Shell",
                    Description = "Uma nova forma de estruturar as páginas do nosso projeto.",
                    Page = typeof(AppShell),
                    IsReplaceMainPage = true
                }
            };

            // É uma classe comun que herda de um List<Component>
            var group = new GroupComponent { Name = "Shell" };

            group.AddRange(components);

            // Adiciona um array de componentes de forma sequencial (Por ser lista, precisa usar o método AddRange)
            _components.AddRange(components);
            _groupComponents.Add(group);
        }

    }
}

using AppMAUIGallery.Views.Lists.Models;
using Microsoft.Maui.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMoviesAsync();
    }

    public class MovieRepository : IMovieRepository
    {
        public async Task<List<Movie>> GetMoviesAsync()
        {
            try
            {
                List<Movie> movies = new List<Movie>
                    {
                        new Movie
                        {
                            Id = 1,
                            Title = "Mufasa: O Rei Leão",
                            Genre = "Aventura/Musical",
                            Description = "Mufasa, um filhote órfão, perdido e sozinho, conhece um simpático leão chamado Taka, herdeiro de uma linhagem real. O encontro ao acaso dá início a uma grande jornada de um grupo extraordinário de deslocados em busca de seu destino, além de revelar a ascensão de um dos maiores reis das Terras do Orgulho.",
                            Duration = new TimeSpan(1, 58, 0),
                            LaunchYear = 2024
                        },
                        new Movie
                        {
                            Id = 2,
                            Title = "Operação Natal",
                            Genre = "Ação/Comédia",
                            Description = "Um vilão sequestra o Papai Noel do Polo Norte e um agente E.L.F. (Extremamente Grande e Formidável) une forças com o rastreador mais habilidoso do mundo para encontrá-lo e salvar o Natal.",
                            Duration = new TimeSpan(2, 03, 0),
                            LaunchYear = 2024
                        },
                        new Movie
                        {
                            Id = 3,
                            Title = "Robô Selvagem",
                            Genre = "Infantil/Aventura",
                            Description = "O robô ROZZUM da unidade 7134 naufraga em uma ilha desabitada e deve se adaptar ao ambiente hostil, estabelecendo gradualmente relações com os animais da ilha e se tornando mãe adotiva de um ganso órfão.",
                            Duration = new TimeSpan(1, 42, 0),
                            LaunchYear = 2024
                        },
                        new Movie
                        {
                            Id = 4,
                            Title = "Fé de um Campeão",
                            Genre = "Esporte/Drama",
                            Description = "Kurt Warner supera anos de desafios e contratempos para tornar-se duas vezes o jogador mais valioso da NFL, campeão do Super Bowl e quarterback do Hall da Fama.",
                            Duration = new TimeSpan(1, 52, 0),
                            LaunchYear = 2024
                        },
                        new Movie
                        {
                            Id = 5,
                            Title = "Super/Man - A História de Christopher Reeve",
                            Genre = "Drama/Documentário",
                            Description = "O ator Christopher Reeve ascende ao estrelato ao conseguir o papel de Superman na década de 1970. Um acidente a cavalo o deixa paralisado em 1995 e ele passa o resto da vida procurando uma cura para lesões na medula espinhal.",
                            Duration = new TimeSpan(1, 44, 0),
                            LaunchYear = 2024
                        },
                        new Movie
                        {
                            Id = 6,
                            Title = "Magic Mike",
                            Genre = "Comédia/Drama",
                            Description = "Mike é um experiente stripper que tenta ensinar a um jovem a arte de seduzir as mulheres em um palco. Ao mesmo tempo que passa seus conhecimentos para Adam, Mike começa a se interessar pela irmã dele, Brooke. Com o tempo, porém, Adam vai se mostrando cada vez mais confiante e acaba deixando o dinheiro fácil lhe subir à cabeça. Não demora muito para começar a se meter com drogas e a ignorar as pessoas próximas. Mas Mike e Brooke não desistem e fazem de tudo para tentar resgatá-lo.",
                            Duration = new TimeSpan(1, 50, 0),
                            LaunchYear = 2024
                        },
                        new Movie
                        {
                            Id = 7,
                            Title = "Assassino a Preço Fixo",
                            Genre = "Ação/Thriller",
                            Description = "Arthur Bishop, um talentoso assassino de elite, recebe a missão de matar seu melhor amigo, Harry McKenna. Após cumpri-la, Arthur reencontra Steve, o filho de Harry. Desejando vingança, Steve recebe a ajuda de Arthur para se tornar um assassino.",
                            Duration = new TimeSpan(1, 33, 0),
                            LaunchYear = 2024
                        },
                        new Movie
                        {
                            Id = 8,
                            Title = "Loucas por Amor, Viciadas em Dinheiro",
                            Genre = "Comédia/Thriller",
                            Description = "Depois que seu marido perde o emprego, a dona de casa Bridget Cardigan é forçada a assumir um trabalho como auxiliar de limpeza na Casa da Moeda em Kansas City, Missouri. Bridget encontra uma brecha no sistema de segurança do banco e convence duas novas amigas, Nina e Jackie, a ajudá-la roubar uma fortuna em notas gastas que foram destinadas à destruição.",
                            Duration = new TimeSpan(2, 06, 0),
                            LaunchYear = 2008
                        },
                        new Movie
                        {
                            Id = 9,
                            Title = "Transformers: O Início",
                            Genre = "Ação/Ficção científica",
                            Description = "A história que nunca antes havia sido contada. A origem de Optimus Prime e Megatron, duas figuras lendárias que em sua juventude foram irmãos de armas, lutando juntos pelo futuro de seu planeta natal, Cybertron.",
                            Duration = new TimeSpan(1, 44, 0),
                            LaunchYear = 2024
                        },
                        new Movie
                        {
                            Id = 10,
                            Title = "Fúria em Alto Mar",
                            Genre = "Ação/Suspense",
                            Description = "O capitão de um submarino norte-americano se une aos fuzileiros navais para resgatar o presidente russo, que foi sequestrado por um general desonesto.",
                            Duration = new TimeSpan(2, 02, 0),
                            LaunchYear = 2018
                        }
                    };

                return movies;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<GroupMovie> GetGroupList()
        {
            var disneyGroup = new GroupMovie()
            {
                CompanyName = "Disney"
            };

            disneyGroup.Add(new Movie
            {
                Id = 1,
                Title = "Mufasa: O Rei Leão",
                Genre = "Aventura/Musical",
                Description = "Mufasa, um filhote órfão, perdido e sozinho, conhece um simpático leão chamado Taka, herdeiro de uma linhagem real. O encontro ao acaso dá início a uma grande jornada de um grupo extraordinário de deslocados em busca de seu destino, além de revelar a ascensão de um dos maiores reis das Terras do Orgulho.",
                Duration = new TimeSpan(1, 58, 0),
                LaunchYear = 2024
            });

            var paramountGroup = new GroupMovie()
            {
                CompanyName = "Paramount"
            };

            paramountGroup.Add(new Movie
            {
                Id = 2,
                Title = "Operação Natal",
                Genre = "Ação/Comédia",
                Description = "Um vilão sequestra o Papai Noel do Polo Norte e um agente E.L.F. (Extremamente Grande e Formidável) une forças com o rastreador mais habilidoso do mundo para encontrá-lo e salvar o Natal.",
                Duration = new TimeSpan(2, 03, 0),
                LaunchYear = 2024
            });

            paramountGroup.Add(new Movie
            {
                Id = 3,
                Title = "Robô Selvagem",
                Genre = "Infantil/Aventura",
                Description = "O robô ROZZUM da unidade 7134 naufraga em uma ilha desabitada e deve se adaptar ao ambiente hostil, estabelecendo gradualmente relações com os animais da ilha e se tornando mãe adotiva de um ganso órfão.",
                Duration = new TimeSpan(1, 42, 0),
                LaunchYear = 2024
            });

            paramountGroup.Add(new Movie
            {
                Id = 4,
                Title = "Fé de um Campeão",
                Genre = "Esporte/Drama",
                Description = "Kurt Warner supera anos de desafios e contratempos para tornar-se duas vezes o jogador mais valioso da NFL, campeão do Super Bowl e quarterback do Hall da Fama.",
                Duration = new TimeSpan(1, 52, 0),
                LaunchYear = 2024
            });

            var universalGroup = new GroupMovie()
            {
                CompanyName = "Universal"
            };

            universalGroup.Add(
                 new Movie
                 {
                     Id = 5,
                     Title = "Super/Man - A História de Christopher Reeve",
                     Genre = "Drama/Documentário",
                     Description = "O ator Christopher Reeve ascende ao estrelato ao conseguir o papel de Superman na década de 1970. Um acidente a cavalo o deixa paralisado em 1995 e ele passa o resto da vida procurando uma cura para lesões na medula espinhal.",
                     Duration = new TimeSpan(1, 44, 0),
                     LaunchYear = 2024
                 });

            universalGroup.Add(
                new Movie
                {
                    Id = 6,
                    Title = "Magic Mike",
                    Genre = "Comédia/Drama",
                    Description = "Mike é um experiente stripper que tenta ensinar a um jovem a arte de seduzir as mulheres em um palco. Ao mesmo tempo que passa seus conhecimentos para Adam, Mike começa a se interessar pela irmã dele, Brooke. Com o tempo, porém, Adam vai se mostrando cada vez mais confiante e acaba deixando o dinheiro fácil lhe subir à cabeça. Não demora muito para começar a se meter com drogas e a ignorar as pessoas próximas. Mas Mike e Brooke não desistem e fazem de tudo para tentar resgatá-lo.",
                    Duration = new TimeSpan(1, 50, 0),
                    LaunchYear = 2024
                });

            universalGroup.Add(
                new Movie
                {
                    Id = 7,
                    Title = "Assassino a Preço Fixo",
                    Genre = "Ação/Thriller",
                    Description = "Arthur Bishop, um talentoso assassino de elite, recebe a missão de matar seu melhor amigo, Harry McKenna. Após cumpri-la, Arthur reencontra Steve, o filho de Harry. Desejando vingança, Steve recebe a ajuda de Arthur para se tornar um assassino.",
                    Duration = new TimeSpan(1, 33, 0),
                    LaunchYear = 2024
                });

            var netflixGroup = new GroupMovie()
            {
                CompanyName = "NetFlix"
            };

            netflixGroup.Add(
                new Movie
                {
                    Id = 8,
                    Title = "Loucas por Amor, Viciadas em Dinheiro",
                    Genre = "Comédia/Thriller",
                    Description = "Depois que seu marido perde o emprego, a dona de casa Bridget Cardigan é forçada a assumir um trabalho como auxiliar de limpeza na Casa da Moeda em Kansas City, Missouri. Bridget encontra uma brecha no sistema de segurança do banco e convence duas novas amigas, Nina e Jackie, a ajudá-la roubar uma fortuna em notas gastas que foram destinadas à destruição.",
                    Duration = new TimeSpan(2, 06, 0),
                    LaunchYear = 2008
                });

            netflixGroup.Add(new Movie
            {
                Id = 9,
                Title = "Transformers: O Início",
                Genre = "Ação/Ficção científica",
                Description = "A história que nunca antes havia sido contada. A origem de Optimus Prime e Megatron, duas figuras lendárias que em sua juventude foram irmãos de armas, lutando juntos pelo futuro de seu planeta natal, Cybertron.",
                Duration = new TimeSpan(1, 44, 0),
                LaunchYear = 2024
            });

            netflixGroup.Add(
                        new Movie
                        {
                            Id = 10,
                            Title = "Fúria em Alto Mar",
                            Genre = "Ação/Suspense",
                            Description = "O capitão de um submarino norte-americano se une aos fuzileiros navais para resgatar o presidente russo, que foi sequestrado por um general desonesto.",
                            Duration = new TimeSpan(2, 02, 0),
                            LaunchYear = 2018
                        });

            List<GroupMovie> movies = new List<GroupMovie>
                    {
                        disneyGroup,
                        paramountGroup,
                        universalGroup,
                        netflixGroup
                    };

            return movies;
        }
    }
}

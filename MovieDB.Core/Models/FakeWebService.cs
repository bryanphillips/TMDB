using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB.Core.Api;

namespace MovieDB.Core.Models
{
    public class FakeWebService : IWebService
    {
        public FakeWebService()
        {
            Sleep = 500;
        }

        public int Sleep
        {
            get;
            set;
        }

        private List<Movie> _nowPlaying = new List<Movie>
        {
            new Movie
            {
                Id = 283995,
                IsAdult = false,
                Overview = "The Guardians must fight to keep their newfound family together as they unravel the mysteries of Peter Quill's true parentage.",
                Title ="Guardians of the Galaxy Vol. 2",
                PosterUrl ="/y4MBh0EjBlMuOzv9axM4qJlmhzz.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 126889,
                IsAdult = false,
                Overview = "Bound for a remote planet on the far side of the galaxy, the crew of the colony ship Covenant discovers what they think is an uncharted paradise, but is actually a dark, dangerous world — whose sole inhabitant is the “synthetic” David, survivor of the doomed Prometheus expedition.",
                Title ="Alien: Covenant",
                PosterUrl ="/ewVHnq4lUiovxBCu64qxq5bT2lu.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 337339,
                IsAdult = false,
                Overview = "When a mysterious woman seduces Dom into the world of crime and a betrayal of those closest to him, the crew face trials that will test them as never before.",
                Title ="The Fate of the Furious",
                PosterUrl ="/iNpz2DgTsTMPaDRZq2tnbqjL2vF.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 166426,
                IsAdult = false,
                Overview = "Captain Jack Sparrow is pursued by an old rival, Captain Salazar, who along with his crew of ghost pirates has escaped from the Devil's Triangle, and is determined to kill every pirate at sea. Jack seeks the Trident of Poseidon, a powerful artifact that grants its possessor total control over the seas, in order to defeat Salazar.",
                Title ="Pirates of the Caribbean: Dead Men Tell No Tales",
                PosterUrl ="/qwoGfcg6YUS55nUweKGujHE54Wy.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 419430,
                IsAdult = false,
                Overview = "Chris and his girlfriend Rose go upstate to visit her parents for the weekend. At first, Chris reads the family's overly accommodating behavior as nervous attempts to deal with their daughter's interracial relationship, but as the weekend progresses, a series of increasingly disturbing discoveries lead him to a truth that he never could have imagined.",
                Title ="Get Out",
                PosterUrl ="/1SwAVYpuLj8KsHxllTF8Dt9dSSX.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 381288,
                IsAdult = false,
                Overview = "Though Kevin has evidenced 23 personalities to his trusted psychiatrist, Dr. Fletcher, there remains one still submerged who is set to materialize and dominate all the others. Compelled to abduct three teenage girls led by the willful, observant Casey, Kevin reaches a war for survival among all of those contained within him — as well as everyone around him — as the walls between his compartments shatter apart.",
                Title ="Split",
                PosterUrl ="/rXMWOZiCt6eMX22jWuTOSdQ98bY.jpg",
                IsVideo = false,
            },
        };
        private List<Movie> _popular = new List<Movie>
        {
            new Movie
            {
                Id = 321612,
                IsAdult = false,
                Overview = "A live-action adaptation of Disney's version of the classic 'Beauty and the Beast' tale of a cursed prince and a beautiful young woman who helps him break the spell.",
                Title ="Beauty and the Beast",
                PosterUrl ="/tWqifoYuwLETmmasnGHO7xBjEtt.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 283995,
                IsAdult = false,
                Overview = "The Guardians must fight to keep their newfound family together as they unravel the mysteries of Peter Quill's true parentage.",
                Title ="Guardians of the Galaxy Vol. 2",
                PosterUrl ="/y4MBh0EjBlMuOzv9axM4qJlmhzz.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 126889,
                IsAdult = false,
                Overview = "Bound for a remote planet on the far side of the galaxy, the crew of the colony ship Covenant discovers what they think is an uncharted paradise, but is actually a dark, dangerous world — whose sole inhabitant is the “synthetic” David, survivor of the doomed Prometheus expedition.",
                Title ="Alien: Covenant",
                PosterUrl ="/ewVHnq4lUiovxBCu64qxq5bT2lu.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 337339,
                IsAdult = false,
                Overview = "When a mysterious woman seduces Dom into the world of crime and a betrayal of those closest to him, the crew face trials that will test them as never before.",
                Title ="The Fate of the Furious",
                PosterUrl ="/iNpz2DgTsTMPaDRZq2tnbqjL2vF.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 263115,
                IsAdult = false,
                Overview = "In the near future, a weary Logan cares for an ailing Professor X in a hide out on the Mexican border. But Logan's attempts to hide from the world and his legacy are up-ended when a young mutant arrives, being pursued by dark forces.",
                Title ="Logan",
                PosterUrl ="/45Y1G5FEgttPAwjTYic6czC9xCn.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 22,
                IsAdult = false,
                Overview = "Jack Sparrow, a freewheeling 17th-century pirate who roams the Caribbean Sea, butts heads with a rival pirate bent on pillaging the village of Port Royal. When the governor's daughter is kidnapped, Sparrow decides to help the girl's love save her. But their seafaring mission is hardly simple.",
                Title ="Pirates of the Caribbean: The Curse of the Black Pearl",
                PosterUrl ="/tkt9xR1kNX5R9rCebASKck44si2.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 335797,
                IsAdult = false,
                Overview = "A koala named Buster recruits his best friend to help him drum up business for his theater by hosting a singing competition.",
                Title ="Sing",
                PosterUrl ="/eSVtBB2PVFbQiFWC7CQi3EjIZnn.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 166426,
                IsAdult = false,
                Overview = "Captain Jack Sparrow is pursued by an old rival, Captain Salazar, who along with his crew of ghost pirates has escaped from the Devil's Triangle, and is determined to kill every pirate at sea. Jack seeks the Trident of Poseidon, a powerful artifact that grants its possessor total control over the seas, in order to defeat Salazar.",
                Title ="Pirates of the Caribbean: Dead Men Tell No Tales",
                PosterUrl ="/qwoGfcg6YUS55nUweKGujHE54Wy.jpg",
                IsVideo = false,
            },
        };
        private List<Movie> _topRated = new List<Movie>()
        {
            new Movie
            {
                Id = 19404,
                IsAdult = false,
                Overview = "Raj is a rich, carefree, happy-go-lucky second generation NRI. Simran is the daughter of Chaudhary Baldev Singh, who in spite of being an NRI is very strict about adherence to Indian values. Simran has left for India to be married to her childhood fiancé. Raj leaves for India with a mission at his hands, to claim his lady love under the noses of her whole family. Thus begins a saga.",
                Title ="Dilwale Dulhania Le Jayenge",
                PosterUrl ="/2gvbZMtV1Zsl7FedJa5ysbpBx2G.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 372058,
                IsAdult = false,
                Overview = "High schoolers Mitsuha and Taki are complete strangers living separate lives. But one night, they suddenly switch places. Mitsuha wakes up in Taki’s body, and he in hers. This bizarre occurrence continues to happen randomly, and the two must adjust their lives around each other.",
                Title ="Your Name.",
                PosterUrl ="/xq1Ugd62d23K2knRUx6xxuALTZB.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 278,
                IsAdult = false,
                Overview = "Framed in the 1940s for the double murder of his wife and her lover, upstanding banker Andy Dufresne begins a new life at the Shawshank prison, where he puts his accounting skills to work for an amoral warden. During his long stretch in prison, Dufresne comes to be admired by the other inmates -- including an older prisoner named Red -- for his integrity and unquenchable sense of hope.",
                Title ="The Shawshank Redemption",
                PosterUrl ="/9O7gLzmreU0nGkIB6K3BsJbzvNv.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 238,
                IsAdult = false,
                Overview = "Spanning the years 1945 to 1955, a chronicle of the fictional Italian-American Corleone crime family. When organized crime family patriarch, Vito Corleone barely survives an attempt on his life, his youngest son, Michael steps in to take care of the would-be killers, launching a campaign of bloody revenge.",
                Title ="The Godfather",
                PosterUrl ="/rPdtLWNsZmAtoZl9PK7S2wE3qiS.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 244786,
                IsAdult = false,
                Overview = "Under the direction of a ruthless instructor, a talented young drummer begins to pursue perfection at any cost, even his humanity.",
                Title ="Whiplash",
                PosterUrl ="/lIv1QinFqz4dlp5U4lQ6HaiskOZ.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 424,
                IsAdult = false,
                Overview = "The true story of how businessman Oskar Schindler saved over a thousand Jewish lives from the Nazis while they worked as slaves in his factory during World War II.",
                Title ="Schindler's List",
                PosterUrl ="/yPisjyLweCl1tbgwgtzBCNCBle.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 432517,
                IsAdult = false,
                Overview = "Long buried secrets finally come to light as someone has been playing a very long game indeed. Sherlock and John face their greatest ever challenge. Is the game finally over?",
                Title ="Sherlock: The Final Problem",
                PosterUrl ="/ySiqbi1sW7imVYbtECZS0xQ3Hmj.jpg",
                IsVideo = false,
            },
        };
        private List<Movie> _similar = new List<Movie> //similar to 278 - shawshank redemption
        {
            new Movie
            {
                Id = 101,
                IsAdult = false,
                Overview = "Leon, the top hit man in New York, has earned a rep as an effective \"cleaner\". But when his next-door neighbors are wiped out by a loose-cannon DEA agent, he becomes the unwilling custodian of 12-year-old Mathilda. Before long, Mathilda's thoughts turn to revenge, and she considers following in Leon's footsteps.",
                Title ="Leon: The Professional",
                PosterUrl ="/gE8S02QUOhVnAmYu4tcrBlMTujz.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 1883,
                IsAdult = false,
                Overview = "The biopic of the controversial and influential Black Nationalist leader.",
                Title ="Malcolm X",
                PosterUrl ="/jDQ2iBJuiimvYqk9orA2YaigBmW.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 1368,
                IsAdult = false,
                Overview = "When former Green Beret John Rambo is harassed by local law enforcement and arrested for vagrancy, the Vietnam vet snaps, runs for the hills and rat-a-tat-tats his way into the action-movie hall of fame. Hounded by a relentless sheriff, Rambo employs heavy-handed guerilla tactics to shake the cops off his tail.",
                Title ="First Blood",
                PosterUrl ="/bbYNNEGLXrV3lJpHDg7CKaPscCb.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 107846,
                IsAdult = false,
                Overview = "Ray Breslin is the world's foremost authority on structural security. After analyzing every high security prison and learning a vast array of survival skills so he can design escape-proof prisons, his skills are put to the test. He's framed and incarcerated in a master prison he designed himself. He needs to escape and find the person who put him behind bars.",
                Title ="Escape Plan",
                PosterUrl ="/1jHF5or25uCZr7O5c7CYm9eTrTw.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 1701,
                IsAdult = false,
                Overview = "When the government puts all its rotten criminal eggs in one airborne basket, it's asking for trouble. Before you can say, \"Pass the barf bag,\" the crooks control the plane, led by creepy Cyrus \"The Virus\" Grissom. Watching his every move is the just-released Cameron Poe, who'd rather reunite with his family.",
                Title ="Con Air",
                PosterUrl ="/yhaOQ7xXw0PLHLvg1w0M9zlPdg6.jpg",
                IsVideo = false,
            },
            new Movie
            {
                Id = 38234,
                IsAdult = false,
                Overview = "Russian inmate Boyka, now severely hobbled by the knee injury suffered at the end of Undisputed 2. No longer the feared prison fighter he was, he has declined so far that he is now good only for cleaning toilets. But when a new prison fight tournament begins - an international affair, matching the best fighters from prisons around the globe, enticing them with the promise of freedom for the winner - Boyka must reclaim his dignity and fight for his position in the tournament.",
                Title ="Undisputed III : Redemption",
                PosterUrl ="/vLSnWLCnqk5j3oLnMnBHJGL3bO0.jpg",
                IsVideo = false,
            },
        };
        private List<Video> _videos = new List<Video>
        {
            new Video
            {
                Id = "58e9c034c3a36872ee070c84",
                CountryISO ="US",
                Key ="7NhoeyoR_XA",
                LanguageISO = "en",
                Name = "Mehndi Laga Ke Rakhna - song by CinePlusPlus",
                Site = "YouTube",
                Size = 720,
                Type = "Clip",
            },
            new Video
            {
                Id = "58e9bfb6925141351f02fde0",
                CountryISO ="US",
                Key ="Y9JvS2TmSvA",
                LanguageISO = "en",
                Name = "Mere Khwabon Mein - song by CinePlusPlus",
                Site = "YouTube",
                Size = 720,
                Type = "Clip",
            },
            new Video
            {
                Id = "5581bd68c3a3685df70000c6",
                CountryISO ="US",
                Key ="c25GKl5VNeY",
                LanguageISO = "en",
                Name = "Trailer 1",
                Site = "YouTube",
                Size = 720,
                Type = "Trailer",
            },
            new Video
            {
                Id = "58e9c00792514152ac020a34",
                CountryISO ="US",
                Key ="OkjXMqK1G0o",
                LanguageISO = "en",
                Name = "Ho Gaya Hai Tujhko To Pyar Sajna - song by CinePlusPlus",
                Site = "YouTube",
                Size = 720,
                Type = "Clip",
            },
        };

        public async Task<Movie> GetMovie(int movieId)
        {
            //ignore movie passed and return one a default one. its a fake service for crying out loud.
            //263115 I choose you.

            await Task.Delay(Sleep);

            return new Movie
            {
                HomePageUrl = "http://www.foxmovies.com/movies/logan",
                BackdropUrl = "",
                Budget = 0,
                MovieCollection = new MovieCollection
                {
                    BackdropImageUrl ="/QtSxEuCwcZSfCTMZfER3nHDVsG.jpg",
                    PosterImageUrl = "/8Ht4a5A5Ypxh0PjbVoRTzm1kAu3.jpg",
                    Id = 453993,
                    Name ="The Wolverine Collection",
                },
                Genres = new List<Genre>
                {
                    new Genre
                    {
                        Id = 28,
                        Name ="Action",
                    },
                    new Genre
                    {
                        Id = 18,
                        Name ="Drama",
                    },
                    new Genre
                    {
                        Id = 878,
                        Name ="Science Fiction",
                    },
                },
                Id = 263115,
                IMDB_Id = "tt3315342",
                IsAdult = false,
                IsVideo = false,
                OriginalLanguage = "en",
                OriginalTitle = "Logan",
                Overview = "In the near future, a weary Logan cares for an ailing Professor X in a hide out on the Mexican border. But Logan's attempts to hide from the world and his legacy are up-ended when a young mutant arrives, being pursued by dark forces.",
                Popularity = 59.472953f,
                PosterUrl = "/45Y1G5FEgttPAwjTYic6czC9xCn.jpg",
                ProductionCompanies = new List<ProductionCompany>
                {
                    new ProductionCompany
                    {
                        Id = 306,
                        Name = "Twentieth Century Fox Film Corporation",
                    },
                    new ProductionCompany
                    {
                        Id = 431,
                        Name = "Donners' Company",
                    },
                    new ProductionCompany
                    {
                        Id = 7505,
                        Name = "Marvel Entertainment",
                    },
                    new ProductionCompany
                    {
                        Id = 22213,
                        Name = "TSG Entertainment",
                    },
                },
                ProductionCountries = new List<ProductionCountry>
                {
                    new  ProductionCountry
                    {
                        CountryCode = "US",
                        Name = "United States of America"
                    },
                },
                ReleaseDate = new DateTime(2017,02,28),
                Revenue = 608578340,
                Runtime = 137,
                SpokenLanguages = new List<SpokenLanguage>
                {
                    new SpokenLanguage
                    {
                        LanguageCode = "en",
                        Name = "English",
                    },
                    new SpokenLanguage
                    {
                        LanguageCode = "es",
                        Name = "Español",
                    },
                },
                Status = "Released",
                Tagline = "His Time Has Come",
                Title = "Logan",
                VoteAverage = 7.5f,
                VoteCount = 3223,
            };
        }

        public async Task<QueryMoviesResponse> GetNowPlayingMovies()
        {
            await Task.Delay(Sleep);

            return new QueryMoviesResponse
            {
                Page = 1,
                Movies = _nowPlaying,
                Dates = new NowPlayingDates
                {
                    MaxDate = new DateTime(2017, 05, 24),
                    MinDate = new DateTime(2017, 04, 12),
                },
                TotalPages = 37,
                TotalResults = 731,
            };
        }

        public async Task<QueryMoviesResponse> GetPopularMovies()
        {
            await Task.Delay(Sleep);

            return new QueryMoviesResponse
            {
                Page = 1,
                Movies = _popular,
                TotalPages = 19547,
                TotalResults = 978,
            };
        }

        public async Task<QueryMoviesResponse> GetSimilarMovies(int movieId)
        {
            //we are using shawshank redemption, so i don't really care what was passed in.
            await Task.Delay(Sleep);

            return new QueryMoviesResponse
            {
                Page = 1,
                Movies = _similar,
                TotalPages = 6,
                TotalResults = 118,
            };
        }

        public async Task<QueryMoviesResponse> GetTopRatedMovies()
        {
            await Task.Delay(Sleep);

            return new QueryMoviesResponse
            {
                Page = 1,
                Movies = _topRated,
                TotalPages = 6247,
                TotalResults = 313,
            };
        }

        public async Task<QueryVideosResponse> GetVideos(int movieId)
        {
            await Task.Delay(Sleep);

            return new QueryVideosResponse
            {
                Id = 1,
                Videos = _videos,
            };
        }        

        public async Task<User> Login(string userName, string password)
        {
            await Task.Delay(Sleep);

            return new User { UserName = userName, Password = password };
        }
    }
}

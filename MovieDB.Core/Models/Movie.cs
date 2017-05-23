using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    [DataContract]
    public class Movie
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name = "adult")]
        public bool IsAdult { get; set; }
        [DataMember(Name ="backdrop_path")]
        public string BackdropUrl { get; set; }
        [DataMember(Name = "belongs_to_collection")]
        public MovieCollection MovieCollection { get; set; }
        [DataMember(Name ="budget")]
        public int Budget { get; set; }
        [DataMember(Name = "genres")]
        public List<Genre> Genres{ get; set; }
        [DataMember(Name = "homepage")]
        public string HomePageUrl { get; set; }
        [DataMember(Name = "imdb_id")]
        public string IMDB_Id { get; set; }
        [DataMember(Name = "original_language")]
        public string OriginalLanguage { get; set; }
        [DataMember(Name = "original_title")]
        public string OriginalTitle { get; set; }
        [DataMember(Name = "overview")]
        public string Overview { get; set; }
        [DataMember(Name = "popularity")]
        public float Popularity { get; set; }
        [DataMember(Name = "poster_path")]
        public string PosterUrl { get; set; }
        [DataMember(Name = "production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; }
        [DataMember(Name = "production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; }
        [DataMember(Name = "release_date")]
        public DateTime ReleaseDate { get; set; }
        [DataMember(Name = "revenue")]
        public int Revenue { get; set; }
        [DataMember(Name = "runtime")]
        public int Runtime { get; set; }
        [DataMember(Name = "spoken_languages")]
        public List<SpokenLanguage> SpokenLanguages { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "tagline")]
        public string Tagline { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "video")]
        public bool IsVideo { get; set; }
        [DataMember(Name = "vote_average")]
        public float VoteAverage { get; set; }
        [DataMember(Name = "vote_count")]
        public int VoteCount { get; set; }
    }
}

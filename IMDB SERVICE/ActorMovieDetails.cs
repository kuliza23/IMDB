using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace IMDB_SERVICE
{
    [DataContract]
    public class ActorMovieDetails
    {


        [DataMember(Name = "ActorName")]
        public string strActorName { get; set; }

        [DataMember(Name = "MovieName")]
        public string strMovieName { get; set; }

        [DataMember(Name = "Rating")]
        public string strRating { get; set; }

        [DataMember(Name = "Runtime")]
        public string strRuntime { get; set; }

        [DataMember(Name = "Release")]
        public string strRelease { get; set; }


      
    }

     [DataContract]
    public class MovieDetails
    {


        [DataMember(Name = "ActorName")]
        public string strActorName { get; set; }

        [DataMember(Name = "MovieName")]
        public string strMovieName { get; set; }

        [DataMember(Name = "Rating")]
        public string strRating { get; set; }

        [DataMember(Name = "Runtime")]
        public string strRuntime { get; set; }

        [DataMember(Name = "Release")]
        public string strRelease { get; set; }


        [DataMember(Name = "Comments")]
        public string strComments { get; set; }
    }
}
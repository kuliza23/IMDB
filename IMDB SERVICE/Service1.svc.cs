using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;


using System.Configuration;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.Web.UI;
using System.Web.Script.Serialization;

using System.Runtime.InteropServices;
using System.Globalization;
using System.Collections.Concurrent;

namespace IMDB_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {

        public List<ActorMovieDetails> lsSearchActorOnImdb(string strActorName)
        {
            string strConnectionString_IMDB_Dashboard = ConfigurationManager.ConnectionStrings["IMDB_CONNECTION"].ConnectionString;
            SqlConnection SQLcon = null;
            List<ActorMovieDetails> ob_ListActorMovieDetails = new List<ActorMovieDetails>();
            try
            {


                SQLcon = new SqlConnection(strConnectionString_IMDB_Dashboard);
                SqlCommand cmd = new SqlCommand("IMDB_spSearchActressActorMovie", SQLcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@szName", strActorName));

                cmd.Connection = SQLcon;



                SQLcon.Open();

                SqlDataReader sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                   ActorMovieDetails ob_ActorMovieDetails = new ActorMovieDetails();
                   ob_ActorMovieDetails.strActorName = Convert.ToString(sqlReader["ACTOR_NAME"]);
                   ob_ActorMovieDetails.strMovieName = Convert.ToString(sqlReader["MOVIE_NAME"]);
                   ob_ActorMovieDetails.strRating = Convert.ToString(sqlReader["RATING"]);
                   ob_ActorMovieDetails.strRuntime = Convert.ToString(sqlReader["MOVIE_RUNTIME"]);
                   ob_ActorMovieDetails.strRelease = Convert.ToString(sqlReader["RELEASE_TIME"]);

                   ob_ListActorMovieDetails.Add(ob_ActorMovieDetails);

                    
                }

                return ob_ListActorMovieDetails;
            }

            catch (SqlException ex)
            {
                
                return null;
            }

            finally
            {

                if (SQLcon.State == ConnectionState.Open)
                {
                    SQLcon.Close();
                }

            }


        }

        public List<MovieDetails> lsMovieDetailsOnImdb(string strMovieName)
        {
            string strConnectionString_IMDB_Dashboard = ConfigurationManager.ConnectionStrings["IMDB_CONNECTION"].ConnectionString;
            SqlConnection SQLcon = null;
            List<MovieDetails> ob_ListMovieDetails = new List<MovieDetails>();
            try
            {


                SQLcon = new SqlConnection(strConnectionString_IMDB_Dashboard);
                SqlCommand cmd = new SqlCommand("IMDB_spDetailsActressActorMovie", SQLcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@szMovieName", strMovieName));

                cmd.Connection = SQLcon;



                SQLcon.Open();

                SqlDataReader sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    MovieDetails ob_MovieDetails = new MovieDetails();
                    ob_MovieDetails.strActorName = Convert.ToString(sqlReader["ACTOR_NAME"]);
                    ob_MovieDetails.strMovieName = Convert.ToString(sqlReader["MOVIE_NAME"]);
                    ob_MovieDetails.strRating = Convert.ToString(sqlReader["RATING"]);
                    ob_MovieDetails.strRuntime = Convert.ToString(sqlReader["MOVIE_RUNTIME"]);
                    ob_MovieDetails.strRelease = Convert.ToString(sqlReader["RELEASE_TIME"]);
                    ob_MovieDetails.strComments = Convert.ToString(sqlReader["COMMENT"]);
                    ob_ListMovieDetails.Add(ob_MovieDetails);


                }

                return ob_ListMovieDetails;
            }

            catch (SqlException ex)
            {

                return null;
            }

            finally
            {

                if (SQLcon.State == ConnectionState.Open)
                {
                    SQLcon.Close();
                }

            }


        }
    }
}

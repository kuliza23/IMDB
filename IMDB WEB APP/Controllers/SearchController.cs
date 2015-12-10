using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB_WEB_APP.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchMovie(string name)
        {
            try
            {
                IMDB_SERVICE_REFERNCE.Service1Client Obj_WcfClient = new IMDB_SERVICE_REFERNCE.Service1Client();
                List<IMDB_WEB_APP.IMDB_SERVICE_REFERNCE.ActorMovieDetails> Obj_SearchMovie = new List<IMDB_WEB_APP.IMDB_SERVICE_REFERNCE.ActorMovieDetails>();
                Obj_SearchMovie = Obj_WcfClient.lsSearchActorOnImdb(name).ToList();
                return View(Obj_SearchMovie);
            }
            catch (Exception ex)
            {
               
                return View("~/Views/Shared/ErrorPage.cshtml");

            }
            return View();

        }


        public ActionResult SearchDetails(string name)
        {
            try
            {
                IMDB_SERVICE_REFERNCE.Service1Client Obj_WcfClient = new IMDB_SERVICE_REFERNCE.Service1Client();
                List<IMDB_WEB_APP.IMDB_SERVICE_REFERNCE.MovieDetails> Obj_DeatilsMovie = new List<IMDB_WEB_APP.IMDB_SERVICE_REFERNCE.MovieDetails>();
                Obj_DeatilsMovie = Obj_WcfClient.lsMovieDetailsOnImdb(name).ToList();
                return View(Obj_DeatilsMovie);
            }
            catch (Exception ex)
            {

                return View("~/Views/Shared/ErrorPage.cshtml");

            }
            return View();
        }
    }
}

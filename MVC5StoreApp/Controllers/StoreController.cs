using System.Linq;
using System.Web.Mvc;
using MVC5StoreApp.Models;

namespace MVC5StoreApp.Controllers
{
    public class StoreController : Controller
    {
        MVC5StoreAppDBContext storeDb = new MVC5StoreAppDBContext();

        // GET: Store
        public ActionResult Index()
        {
            var generes = storeDb.Genres.ToList();
   
            return View(generes);
        }

        //GET: /Store/Browse?genre=Books
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Items from database
            var genreModel = storeDb.Genres.Include("Items").Single(g => g.Name == genre);
            
            return View(genreModel);
        }

        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var item = storeDb.Items.Find(id);

            return View(item);
        }

        //GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var generes = storeDb.Genres.ToList();
            return PartialView(generes);
        }        
    }
}
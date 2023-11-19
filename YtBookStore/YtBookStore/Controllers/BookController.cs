using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YtBookStore.Models.Domain;
using YtBookStore.Repositories.Abstract;

namespace YtBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService service;
        private readonly DatabaseContext context;
        public BookController(IBookService service, DatabaseContext context)
        {
            this.service = service;
            this.context = context;
        }
        public IActionResult Add()
        {
            ViewBag.Authors = new SelectList(context.Author, "Id", "AuthorName");
            ViewBag.Publishers = new SelectList(context.Publisher, "Id", "PublisherName");
            ViewBag.Genres = new SelectList(context.Genre, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Add(Book model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            ViewBag.Authors = new SelectList(context.Author, "Id", "AuthorName");
            ViewBag.Publishers = new SelectList(context.Publisher, "Id", "PublisherName");
            ViewBag.Genres = new SelectList(context.Genre, "Id", "Name");
            var record = service.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated Successfully";
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return View(data);
        }
    }
}

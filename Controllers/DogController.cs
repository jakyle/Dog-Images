using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogClient _dogClient;

        public DogController(IDogClient dogClient)
        {
            _dogClient = dogClient;
        }

        public async Task<IActionResult> Images()
        {
            var response = await _dogClient.GetBreedImages();

            var model = new ImagesViewModel();

            model.Dogs = response.Message;

            return View(model);
        }
    }
}

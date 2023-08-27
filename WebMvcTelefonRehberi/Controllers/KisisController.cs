using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebMvcTelefonRehberi.BLManager.Abstract;
using WebMvcTelefonRehberi.Domain;
using WebMvcTelefonRehberi.Models.Dtos;

namespace WebMvcTelefonRehberi.Controllers
{
    public class KisisController : Controller
    {
        private readonly IKisiManager manager;
        private readonly IMapper mapper;
        private readonly BaseeDbContext _context;

        public KisisController(IKisiManager manager, IMapper mapper, BaseeDbContext context)
        {
            this.manager = manager;
            this.mapper = mapper;
            _context = context;
        }
        public IActionResult Index()
        {
            var kisiler = manager.GetAll(null);
            return View(kisiler);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var kisi = new KisiCreateDto();

            return View(kisi);
        }

        [HttpPost]
        public IActionResult Create(KisiCreateDto input)
        {
            if (ModelState.IsValid)
            {

                var kisi = mapper.Map<KisiCreateDto, Kisi>(input);

                manager.CheckForGsm(input.Gsm);


                manager.Add(kisi);
                RedirectToAction("Index", "Kisis");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kisi = manager.Find(id);
            var updateDto = mapper.Map<Kisi, KisiCreateDto>(kisi);


            return View(updateDto);
        }



        [HttpPost]
        public IActionResult Edit(KisiCreateDto input)
        {


            if (ModelState.IsValid)
            {
                var kisi = mapper.Map<KisiCreateDto, Kisi>(input);
                manager.Update(kisi);
                return RedirectToAction("Index", "Kisis");
                //if (!manager.CheckForGsm(input.Gsm))
                //{
                //    manager.Update(kisi);
                //    return RedirectToAction("Index", "Kisis");
                //}
                //else
                //    ModelState.AddModelError("", "Telefon numarasi yanliş girilmiş");
            }


            //if (ModelState.IsValid)
            //{
            //    Kisi m = new Kisi();
            //    m.Gsm = input.Gsm;
            //    m.Id = input.Id;
            //    m.Adi = input.Adi;
            //    m.Soyadi = input.Soyadi;
            //    m.CreateDate = input.CreateDate;
            //    m.Email = input.Email;




            //    manager.Update(m);
            //    RedirectToAction("Index", "Kisis");
            //}




            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }

        // POST: Kisis/Delete/5

        [HttpPost]
        public IActionResult Delete(Kisi input)
        {



            manager.Delete(input);
            return RedirectToAction("Index", "Kisis");






        }
        // GET: Kisis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = await _context.Kisiler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

    }
}

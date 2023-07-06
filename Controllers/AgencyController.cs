using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class AgencyController : Controller
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AgencyController(IAgencyRepository agencyRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _agencyRepository = agencyRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> IndexAgency()
        {
            var agencies = await _agencyRepository.GetAll();
            return View(agencies);
        }

        public async Task<IActionResult> DetailAgency(int id)
        {
            Agency agency = await _agencyRepository.GetByIdAsync(id);
            return View(agency);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAgencyViewModel agencyVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(agencyVM.Image);

                var agency = new Agency
                {
                    Title = agencyVM.Title,
                    Description = agencyVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = agencyVM.Address.Street,
                        City = agencyVM.Address.City,
                        Ward = agencyVM.Address.Ward,
                        District = agencyVM.Address.District
                    }
                };

                _agencyRepository.Add(agency);
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Photo upload failed");

            return View(agencyVM);
        }
    }
}

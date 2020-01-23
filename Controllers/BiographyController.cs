using System;
using System.Collections.Generic;
using biography.API.Entities;
using biography.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace biography_api.Controllers
{
    [ApiController]
    [Route("api/biography")]
    public class BiographyController : ControllerBase
    {
        private readonly IBiographyRepository _biographyRepository;

        public BiographyController(IBiographyRepository biographyRepository)
        {
            _biographyRepository = biographyRepository ??
                throw new ArgumentNullException(nameof(biographyRepository));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Biography>> GetBiographies()
        {
            var biographyFromRepo = _biographyRepository.GetBiographies();
            return Ok(biographyFromRepo);
        }

        [HttpPut("{biographyId}")]
        public ActionResult UpdateUser(Guid biographyId, Biography biography)
        {
            var biographyToUpdateFromRepo = _biographyRepository.GetBiography(biographyId);

            biographyToUpdateFromRepo.Id = biography.Id;
            biographyToUpdateFromRepo.Content = biography.Content;
            biographyToUpdateFromRepo.UserId = biography.UserId;
            _biographyRepository.Save();

            return Ok(biography);
        }
    }
}

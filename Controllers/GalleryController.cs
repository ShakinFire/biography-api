using System;
using System.Collections.Generic;
using biography.API.Entities;
using biography.API.Services;
using biography_api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace biography_api.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/gallery-image")]
    public class GalleryController : ControllerBase
    {
        private readonly IBiographyRepository _biographyRepository;

        public GalleryController(IBiographyRepository biographyRepository)
        {
            _biographyRepository = biographyRepository ??
                throw new ArgumentNullException(nameof(biographyRepository));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<GalleryImage>> GetCommentsForBiography(Guid userId)
        {
            var galleryImagesFromRepo = _biographyRepository.GetGalleryImagesForUser(userId);
            return Ok(galleryImagesFromRepo);
        }

        [HttpPost()]
        public ActionResult<GalleryImage> CreateCommentForBiography(Guid userId, GalleryImage galleryImage)
        {
            _biographyRepository.AddGalleryImage(userId, galleryImage);
            _biographyRepository.Save();

            return Ok(galleryImage);
        }
    }
}

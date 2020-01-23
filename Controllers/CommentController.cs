using System;
using System.Collections.Generic;
using biography.API.Entities;
using biography.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace biography_api.Controllers
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IBiographyRepository _biographyRepository;

        public CommentController(IBiographyRepository biographyRepository)
        {
            _biographyRepository = biographyRepository ??
                throw new ArgumentNullException(nameof(biographyRepository));
        }

        [HttpGet("api/biography/{biographyId}/comments")]
        public ActionResult<IEnumerable<Comment>> GetCommentsForBiography(Guid biographyId)
        {
            var commentsFromRepo = _biographyRepository.GetCommentsForBiography(biographyId);
            return Ok(commentsFromRepo);
        }

        [HttpPost("api/biography/{biographyId}/user/{userId}")]
        public ActionResult<Comment> CreateCommentForBiography(Guid biographyId, Guid userId, Comment comment)
        {
            _biographyRepository.AddComment(biographyId, userId, comment);
            _biographyRepository.Save();

            return Ok(comment);
        }
    }
}

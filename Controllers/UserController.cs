using System;
using System.Collections.Generic;
using biography.API.Entities;
using biography.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace biography_api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBiographyRepository _biographyRepository;

        public UserController(IBiographyRepository biographyRepository)
        {
            _biographyRepository = biographyRepository ??
                throw new ArgumentNullException(nameof(biographyRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var usesrFromRepo = _biographyRepository.GetUsers();
            return Ok(usesrFromRepo);
        }

        [HttpPut("{userId}")]
        public ActionResult UpdateUser(Guid userId, User user)
        {
            var userToUpdateFromRepo = _biographyRepository.GetUser(userId);

            userToUpdateFromRepo.Age = user.Age;
            userToUpdateFromRepo.AvatarImage = user.AvatarImage;
            userToUpdateFromRepo.Username = user.Username;
            userToUpdateFromRepo.Email = user.Email;
            userToUpdateFromRepo.Name = user.Name;
            userToUpdateFromRepo.Id = user.Id;
            _biographyRepository.Save();

            return Ok(user);
        }
    }
}

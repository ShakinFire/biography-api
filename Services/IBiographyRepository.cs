using System;
using System.Collections.Generic;
using biography.API.Entities;
using biography_api.Entities;

namespace biography.API.Services
{
    public interface IBiographyRepository
    {
        void AddGalleryImage(Guid userId, GalleryImage image);
        IEnumerable<GalleryImage> GetGalleryImagesForUser(Guid userId);
        IEnumerable<Biography> GetBiographies();
        Biography GetBiography(Guid biographyId);
        void AddBiography(Guid userId, Biography biography);
        void UpdateBiography(Biography biography);
        IEnumerable<Comment> GetCommentsForUser(Guid userId);
        IEnumerable<Comment> GetCommentsForBiography(Guid biographyId);
        Comment GetComment(Guid commentId);
        void AddComment(Guid biographyId, Guid userId, Comment comment);
        IEnumerable<User> GetUsers();
        //IEnumerable<User> GetUsers(AuthorsResourceParameters authorsResourceParameters);
        User GetUser(Guid userId);
        IEnumerable<User> GetUsers(IEnumerable<Guid> userIds);
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        bool UserExists(Guid userId);
        bool Save();
    }
}

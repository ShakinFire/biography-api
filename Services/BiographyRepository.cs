using System;
using System.Collections.Generic;
using System.Linq;
using biography.API.Entities;
using biography_api.DbContexts;
using biography_api.Entities;

namespace biography.API.Services
{
    public class BiographyRepository : IBiographyRepository, IDisposable
    {
        private readonly BiographyContext _context;

        public void AddGalleryImage(Guid userId, GalleryImage image)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            image.UserId = userId;
            _context.GalleryImage.Add(image);
        }

        public IEnumerable<GalleryImage> GetGalleryImagesForUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.GalleryImage.Where(a => a.UserId == userId)
                .ToList();
        }

        public BiographyRepository(BiographyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddBiography(Guid userId, Biography biography)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (biography == null)
            {
                throw new ArgumentNullException(nameof(biography));
            }
            // always set the AuthorId to the passed-in authorId
            biography.UserId = userId;
            _context.Biography.Add(biography);
        }

        public Biography GetBiography(Guid biographyId)
        {
            if (biographyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(biographyId));
            }

            return _context.Biography
                .FirstOrDefault(a => a.Id == biographyId);
        }

        public IEnumerable<Biography> GetBiographies()
        {
            return _context.Biography.ToList<Biography>();
        }

        public IEnumerable<Biography> GetBiographies(IEnumerable<Guid> biographyIds)
        {
            if (biographyIds == null)
            {
                throw new ArgumentNullException(nameof(biographyIds));
            }

            return _context.Biography.Where(a => biographyIds.Contains(a.Id))
                .ToList();
        }

        public void UpdateBiography(Biography biography)
        {
            if (biography == null)
            {
                throw new ArgumentNullException(nameof(biography));
            }

            _context.Biography.Update(biography);
        }

        public void AddComment(Guid biographyId, Guid userId, Comment comment)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (biographyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(biographyId));
            }

            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            comment.BiographyId = biographyId;
            comment.UserId = userId;
            comment.CreatedAt = DateTime.UtcNow;
            comment.UpdatedAt = DateTime.UtcNow;

            _context.Comment.Add(comment);
        }

        public Comment GetComment(Guid commentId)
        {
            if (commentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(commentId));
            }

            return _context.Comment.FirstOrDefault(a => a.Id == commentId);
        }

        public IEnumerable<Comment> GetCommentsForBiography(Guid biographyId)
        {
            if (biographyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(biographyId));
            }

            return _context.Comment.Where(a => a.BiographyId == biographyId)
                .ToList();
        }

        public IEnumerable<Comment> GetCommentsForUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Comment.Where(a => a.UserId == userId)
                .ToList();
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            // the repository fills the id (instead of using identity columns)
            user.Id = Guid.NewGuid();

            _context.User.Add(user);
        }

        public bool UserExists(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.User.Any(a => a.Id == userId);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.User.Remove(user);
        }

        public User GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.User.FirstOrDefault(a => a.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList<User>();
        }

        //public IEnumerable<User> GetUsers(AuthorsResourceParameters authorsResourceParameters)
        //{
        //    if (authorsResourceParameters == null)
        //    {
        //        throw new ArgumentNullException(nameof(authorsResourceParameters));
        //    }

        //    if (string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory) && string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
        //    {
        //        return GetAuthors();
        //    }

        //    var collection = _context.Authors as IQueryable<Author>;

        //    if (!string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory))
        //    {
        //        var mainCategory = authorsResourceParameters.MainCategory.Trim();
        //        collection = collection.Where(a => a.MainCategory == mainCategory);
        //    }

        //    if (!string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
        //    {
        //        var searchQuery = authorsResourceParameters.SearchQuery.Trim();
        //        collection = collection.Where(a => a.MainCategory.Contains(searchQuery)
        //            || a.FirstName.Contains(searchQuery)
        //            || a.LastName.Contains(searchQuery));
        //    }

        //    return collection.ToList();
        //}

        public IEnumerable<User> GetUsers(IEnumerable<Guid> userIds)
        {
            if (userIds == null)
            {
                throw new ArgumentNullException(nameof(userIds));
            }

            return _context.User.Where(a => userIds.Contains(a.Id))
                .ToList();
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.User.Update(user);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}

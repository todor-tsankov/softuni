using System;
using System.Linq;
using System.Collections.Generic;

using Git.Data;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public RepositoryViewModel GetRepository(string repositoryId)
        {
            var repository = this.db.Repositories
                .Where(x => x.Id == repositoryId)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedOn = x.CreatedOn,
                    OwnerName = x.Owner.Username,
                    CommitsCount = x.Commits.Count
                })
                .FirstOrDefault();

            return repository;
        }

        public IEnumerable<RepositoryViewModel> GetAllRepositories(bool @public = true)
        {
            var repositories = this.db.Repositories
                .Where(x => x.IsPublic == @public)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedOn = x.CreatedOn,
                    OwnerName = x.Owner.Username,
                    CommitsCount = x.Commits.Count
                }).ToList();

            return repositories;
        }

        public void CreateRepository(string name, bool isPublic, string ownerId)
        {
            var repository = new Repository
            {
                Name = name,
                IsPublic = isPublic,
                CreatedOn = DateTime.UtcNow,
                OwnerId = ownerId
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }
    }
}

using Git.Data;
using Git.ViewModels;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateCommit(string repositoryId, string description, string userId)
        {
            var commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = repositoryId,
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public bool DeleteCommit(string commitId, string userId)
        {
            var commit = this.db.Commits.FirstOrDefault(x => x.Id == commitId && x.CreatorId == userId);

            if (commit == null)
            {
                return false;
            }

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<CommitViewModel> GetUserCommits(string userId)
        {
            var userCommits = this.db.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn,
                    RepositoryName = x.Repository.Name
                }).ToList();

            return userCommits;
        }
    }
}

using System.Collections.Generic;

using Git.ViewModels;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public interface ICommitsService
    {
        IEnumerable<CommitViewModel> GetUserCommits(string userId);

        bool DeleteCommit(string commitId, string userId);

        void CreateCommit(string repositoryId, string description, string UserId);
    }
}

using System.Collections.Generic;

using Git.ViewModels.Repositories;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        RepositoryViewModel GetRepository(string repositoryId);

        IEnumerable<RepositoryViewModel> GetAllRepositories(bool @public = true);

        void CreateRepository(string name, bool isPublic, string ownerId);
    }
}

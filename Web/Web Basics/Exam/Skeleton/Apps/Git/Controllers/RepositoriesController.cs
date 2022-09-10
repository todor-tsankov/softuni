using Git.Services;
using Git.ViewModels.Repositories;

using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var publicRepositories = this.repositoriesService.GetAllRepositories();

            return this.View(publicRepositories);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RepositoryInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name)
                || input.Name.Length < 3
                || input.Name.Length > 10)
            {
                return this.Error("Repository's name must be between 3 and 10 characters long.");
            }

            var isPublic = true;

            if (input.RepositoryType == "Public")
            {
                isPublic = true;
            }
            else if (input.RepositoryType == "Private")
            {
                isPublic = false;
            }
            else
            {
                return this.Error("Invalid repository type.");
            }

            var userId = this.GetUserId();
            this.repositoriesService.CreateRepository(input.Name, isPublic, userId);

            return this.Redirect("/Repositories/All");
        }
    }
}

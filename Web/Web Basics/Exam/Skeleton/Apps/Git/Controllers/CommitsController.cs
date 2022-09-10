using Git.Services;
using Git.ViewModels.Commits;

using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var userCommits = this.commitsService.GetUserCommits(userId);

            return this.View(userCommits);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repository = this.repositoriesService.GetRepository(id);

            return this.View(repository);
        }

        [HttpPost]
        public HttpResponse Create(CommitInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Description) 
                || input.Description.Length < 5)
            {
                return this.Error("Description can't be less than 5 characters long.");
            }

            var userId = this.GetUserId();
            this.commitsService.CreateCommit(input.Id, input.Description, userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var success = this.commitsService.DeleteCommit(id, userId);

            if (!success)
            {
                return this.Error("Commit can only be deleted by its creator.");
            }

            return this.Redirect("/Commits/All");
        }
    }
}

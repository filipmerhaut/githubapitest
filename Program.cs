using Octokit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace githubapitest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Github API Test");

            Console.WriteLine("Enter the name of the user for which you want to list their repositories:");
            var username = Console.ReadLine();

            var github = new GitHubClient(new ProductHeaderValue("githubapitest"));
            var user = await github.User.Get(username);
            var repos = await github.Repository.GetAllForUser(user.Login);

            foreach (var repo in repos.OrderByDescending(x => x.StargazersCount))
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Name: {0}", repo.Name);
                Console.WriteLine("URL: {0}", repo.HtmlUrl);
                Console.WriteLine("Stars: {0}", repo.StargazersCount);
            }
        }
    }
}

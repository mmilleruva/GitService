using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitService.Models;
using RestSharp;

namespace GitService
{
    class GitHubService
    {
        RestClient client;
        string baseUrl = "https://api.github.com";

        public GitHubService(IAuthenticator authenticator)
        {
            this.client = new RestSharp.RestClient();
            client.Authenticator = authenticator;
        }


        public IList<Commit> GetCommits(string user, string repo)
        {
            var request = GetNewRelativeRequest("/repos/{user}/{repo}/commits", Method.GET);
            request.AddUrlSegment("user", user);
            request.AddUrlSegment("repo", repo);
            var result = client.Execute<List<Commit>>(request);

            return result.Data;
        }

        public Commit GetCommit(string user, string repo,string sha )
        {
            var request = GetNewRelativeRequest("/repos/{user}/{repo}/commits/{sha}", Method.GET);
            request.AddUrlSegment("user", user);
            request.AddUrlSegment("repo", repo);
            request.AddUrlSegment("sha", sha);
            var result = client.Execute<Commit>(request);

            return result.Data;
        }

        public string GetRawFile(string url)
        {
            var request = new RestRequest(url, Method.GET);
            return client.Execute(request).Content;
        }


        private RestRequest GetNewRelativeRequest(string relativePath, Method method){
            return new RestRequest(baseUrl + relativePath, method);
        }
    }
}

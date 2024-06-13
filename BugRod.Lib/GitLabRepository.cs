using BugRod.Lib.Abstract;
using BugRod.Lib.Containers;
using BugRod.Lib.NetworkConnector;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
// M2PAWBLe423eU2GXY_tr
namespace BugRod.Lib
{
    public class GitLabRepository : Repository
    {
        private IConnectionClient _httpClient;
        public GitLabRepository(string name, string webAddress, RepositoryType repositoryType, string description, string token, IConnectionClient httpClient)
                : base(name, webAddress, repositoryType, description, token)
        {
            _httpClient = httpClient;
            var connector = new GitLabRepositoryConnector(_httpClient);
            this.Issues = connector.GetIssuesAsync(this).Result.ToList<Issue>();

        }

        public override IRepositoryConnector GetConnector()
        {
            if (RepositoryType == RepositoryType.GitLab)
            {
                return new GitLabRepositoryConnector(this._httpClient);
            }
            throw new NotSupportedException($"Repository type {RepositoryType} is not supported");
        }
    }

    public class GitLabRepositoryConnector : IRepositoryConnector
    {
        private IConnectionClient _httpClient;
        private readonly string _token;
        public GitLabRepositoryConnector(IConnectionClient httpClient)
        {
            _httpClient = httpClient;
            //_token = this._token ?? string.Empty;
        }

        public async Task<bool> AddIssueAsync(Repository repository, string name, string description)
        {
            try
            {
            var url = $"https://api.github.com/repos/{repository.Name}/issues";
            var content = new StringContent(JsonSerializer.Serialize(new { title = name, body = description }), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

                //nie musimy dodawać - lepiej odświerzyć - poznajemy id i status wg serwisu.
                //repository.Issues.Add(new Issue(0, name, description, "open"));

            return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        public Task<bool> CloseIssueAsync(Repository repository, Issue bug)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConnectToServiceAsync(Repository repository)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DisconnectServiceAsync(Repository repository)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExportIssueAsync(Repository sourceRepository, IEnumerable<Issue> bugs)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ImportIssueAsync(Repository destinationRepository, string fromFilePath)
        {

            try
            {
                var fileContent = File.ReadAllText(fromFilePath);

                var issues = JsonSerializer.Deserialize<List<Issue>>(fileContent);

                if(issues.Count > 0)
                {
                    foreach (var issue in issues)
                    {
                        destinationRepository.Issues.Add(issue);
                        await AddIssueAsync(destinationRepository, issue.Name, issue.Description);
                    }
                }
                return true;
            }catch(Exception ex)
            {

            }

            return false;
        }

        public Task<bool> ModifyIssueAsync(Repository repository, Issue bug)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Issue>> GetIssuesAsync(Repository repository)
        {
            if (repository.RepositoryType != RepositoryType.GitLab)
            {
                throw new InvalidOperationException("Repository type is not GitLab");
            }

            var issues = new List<Issue>();
            var url = $"{repository.WebAddress}/api/v4/projects/{repository.Name}/issues";

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", repository.Token);

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var gitLabIssues = JsonSerializer.Deserialize<List<GitLabIssue>>(jsonResponse);

            foreach (var gitLabIssue in gitLabIssues)
            {
                var issue = new Issue(gitLabIssue.id, gitLabIssue.title, gitLabIssue.description, gitLabIssue.state);
                issues.Add(issue);
            }

            return issues;
        }    
        
        private class GitLabIssue
        {
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string state { get; set; }
        }
    }
}

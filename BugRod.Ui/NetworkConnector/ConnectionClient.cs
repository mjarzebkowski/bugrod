using BugRod.Lib.Abstract;
using BugRod.Lib.Containers;
using BugRod.Ui.Components.Pages;
using System.Net.Http;

namespace BugRod.Ui.NetworkConnector
{
    public class ConnectionClient : IConnectionClient
    {
        public static List<IRepositoryConnector> AllRepositories = new List<IRepositoryConnector>();
        public static List<Issue> AllIssues = new List<Issue>();


        private readonly HttpClient _httpClient;
        public ConnectionClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("");
        }
        public HttpClient httpClient => _httpClient;
    }

    public interface IConnectionClient
    {
        HttpClient httpClient { get; }
    }
}

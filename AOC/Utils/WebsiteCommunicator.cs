using System.Net;

namespace AOC.Utils;

public class WebsiteCommunicator
{
    private const string BaseAddress = "https://adventofcode.com";

    private string? _sessionCookie;
    private readonly string _sessionCookieFilePath;
    
    // the { UseCookies = false } allows to set cookie headers manually:
    private static readonly HttpClientHandler Handler = new HttpClientHandler { UseCookies = false };
    private static readonly HttpClient HttpClient = new HttpClient(Handler);

    public WebsiteCommunicator()
    {
        _sessionCookieFilePath = "/home/pypka/RiderProjects/AdventOfCode/AOC/Utils/session-cookie.txt";
    }
    public WebsiteCommunicator(string sessionCookieFilePath)
    {
        _sessionCookieFilePath = sessionCookieFilePath;
    }
    
    private string SessionCookie
    {
        get
        {
            if (_sessionCookie is null)
            {
                _sessionCookie = File.ReadAllText(_sessionCookieFilePath);
            }

            return _sessionCookie;
        }
    }

    private Uri GetRemotePuzzleInputUri(int year, int day)
    {
        return new Uri($"{BaseAddress}/{year}/day/{day}/input");
    }

    public async Task StoreRemoteInput(int year, int day)
    {
        // add checks if file exists
        // somehow figure out the file naming. maybe just refactor existing ones.
        
        
        var request = new HttpRequestMessage(HttpMethod.Get,
                                             GetRemotePuzzleInputUri(year, day));
        request.Headers.Add("Cookie", $"session={SessionCookie}");
        
        var response = await HttpClient.SendAsync(request);
        
        
        Console.WriteLine("Response Status Code: " + response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Response Body: " + responseBody);
    }
}
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CozProject.WebAPI.Hubs
{
    public class ScoreHub : Hub
    {
        public async Task SendScoreAsync(int score)
        {
            await Clients.Caller.SendAsync("SendScore", score);
        }
    }
}

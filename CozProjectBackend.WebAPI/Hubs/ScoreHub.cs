using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Hubs
{
    public class ScoreHub : Hub
    {
        public async Task SendScoreAsync(int score)
        {
            await Clients.Caller.SendAsync("SendScore", score);
        }
    }
}

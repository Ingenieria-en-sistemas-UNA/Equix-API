using EquixAPI.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Hubs
{
    public class PhraseHub : Hub
    {
        public async Task SendPhrase(Phrase phrase)
        {
            await Clients.All.SendAsync("SendPhrase", new object[] {
                phrase
            });
        }
    }
}

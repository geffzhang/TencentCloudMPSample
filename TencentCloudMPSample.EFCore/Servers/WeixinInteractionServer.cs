using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TencentCloudMPSample.EFCore.Models;

namespace TencentCloudMPSample.EFCore.Servers
{
    public class WeixinInteractionServer
    {
        private TencentCloudDbContext _dbContext;

        public WeixinInteractionServer(TencentCloudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddInteraction(string request,string response)
        {
            await _dbContext.WeixinInteractions.AddAsync(new WeixinInteraction { Request = request, Response = response });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<WeixinInteraction>> GetWeixinInteractions()
        {
            var list = await _dbContext.WeixinInteractions.ToListAsync();
            return list;
        }

    }
}

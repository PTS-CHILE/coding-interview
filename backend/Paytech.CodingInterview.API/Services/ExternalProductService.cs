using Microsoft.EntityFrameworkCore;
using Paytech.CodingInterview.API.Data;
using Paytech.CodingInterview.API.Data.Entities;
using Paytech.CodingInterview.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Services
{
    public class ExternalProductService : IExternalProductService
    {
        private readonly CodingInterviewContext _context;

        public ExternalProductService(CodingInterviewContext context)
        {
            _context = context;
        }

        public async Task<List<ExternalProduct>> GetProductsAsync()
        {
            return await _context
                .Set<ExternalProduct>()
                .Take(100)
                .ToListAsync();
        }

        public async Task CreateUpdateProductsAsync()
        {
            return;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace aws_lambda_lambdanative
{
    public class Services : IServices
    {
        private readonly DistrictContext _context;

        public Services(DistrictContext context)
        {
            _context = context;
        }

        public async Task<List<DistrictModel>> ListDistrict()
        {
            return await _context.Districts.ToListAsync();
        }
    }

}

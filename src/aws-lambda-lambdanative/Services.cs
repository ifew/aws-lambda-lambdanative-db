using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace aws_lambda_lambdanative
{
    public class Services
    {
        private readonly DistrictContext _context;

        public Services(DistrictContext context)
        {
            _context = context;
        }

        public async Task<List<DistrictModel>> ListDistrict()
        {
            return _context.Districts.ToList();
        }
    }

}

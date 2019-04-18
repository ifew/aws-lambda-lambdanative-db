using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace aws_lambda_lambdanative
{
    public class Services
    {
        private readonly MemberContext _context;

        public Services(MemberContext context)
        {
            _context = context;
        }

        public ProfileModel Get_Member_Information_By_ID(string id)
        {
            return _context.Members.Where(m => m.Id == int.Parse(id)).FirstOrDefault();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.HttpMessages.Requests
{
    public class GetHomePostRequest : QueryStringParameters
    {
        public override string SortBy { get; set; } = "CreatedAt";
    }
}

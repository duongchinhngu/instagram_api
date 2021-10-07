using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Instagram.HttpMessages.Requests
{
    public abstract class QueryStringParameters
    {
        [FromQuery(Name = "page-number")]
        public int PageNumber { get; set; } = 1;

        private int _pageSize = PagingParameters.DEFAULT_PAGESIZE;
        [FromQuery(Name = "page-size")]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value <= PagingParameters.MAX_PAGESIZE ? value : PagingParameters.MAX_PAGESIZE; }
        }

        //for sorting
        [FromQuery(Name = "order-by")]
        [EnumDataType(typeof(OrderType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType OrderBy { get; set; } = OrderType.None;

        [FromQuery(Name = "sort-by")]
        public abstract String SortBy { get; set; }
    }

    public class PagingParameters
    {
        public static readonly int DEFAULT_PAGESIZE = 10;
        public static readonly int MAX_PAGESIZE = 10;
    }

    public enum OrderType
    {
        Descending,
        Ascending,
        None,
    }
}

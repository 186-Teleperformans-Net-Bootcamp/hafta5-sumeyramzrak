using System.Text.Json.Serialization;

namespace Teleperformance.Odev4.Data.Dto
{
        public class PagedList<T> where T : class
        {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }


        //public List<T> Items { get; set; }
        //public int TotalCount { get; set; }
        //public int PageCount => (int)Math.Ceiling((TotalCount == 0 ? TotalCount + 1 : TotalCount) / (double)PageSize);
        //public int PageSize { get; set; }
        //public int ItemCount => Items.Count;
    }


}

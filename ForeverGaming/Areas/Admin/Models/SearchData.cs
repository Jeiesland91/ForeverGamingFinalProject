using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ForeverGaming.Models
{
    public class SearchData
    {
        private const string SearchKey = "search";
        private const string TypeKey = "searchtype";

        private ITempDataDictionary tempData { get; set; }
        public SearchData(ITempDataDictionary temp) =>
            tempData = temp;

        public string SearchTerm
        {
            get => tempData.Peek(SearchKey)?.ToString();
            set => tempData[SearchKey] = value;
        }
        public string Type
        {
            get => tempData.Peek(TypeKey)?.ToString();
            set => tempData[TypeKey] = value;
        }

        public bool HasSearchTerm => !string.IsNullOrEmpty(SearchTerm);
        public bool IsGame => Type.EqualsNoCase("game");
        public bool IsType => Type.EqualsNoCase("type");
        public bool IsGenre => Type.EqualsNoCase("genre");
        public bool IsFormat => Type.EqualsNoCase("format");
        public bool IsRating => Type.EqualsNoCase("rating");
        public bool IsPublisher => Type.EqualsNoCase("publisher");

        public void Clear()
        {
            tempData.Remove(SearchKey);
            tempData.Remove(TypeKey);
        }
    }
}

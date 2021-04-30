﻿using System.Collections.Generic;
using System.Linq;

namespace ForeverGaming.Models
{
    public static class FilterPrefix
    {
        // static class of constants used to add and remove user-friendly
        // prefix from filter route segment values. Public class rather
        // than private constants bc also used by GamesGridBuilder class.
        public const string Genre = "genre-";
        public const string Type = "type-";
        public const string Format = "format-";
        public const string Rating = "rating-";
        public const string Publisher = "publisher-";
    }

    // inherits dictionary of strings, adds a Clone() method. Adds properties
    // to get and set general paging, sorting, and filtering values from dictionary. 
    // Adds methods to set sort field value and sort direction value based on sort field, re-set filter values.
    public class RouteDictionary : Dictionary<string, string>
    {
        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }

        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;

            // set sort direction based on comparison of new and current sort field. if 
            // sort field is same as current, toggle between ascending and descending. 
            // if it's different, should always be ascending.
            if (current.SortField.EqualsNoCase(fieldName) &&
                current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "desc";
            else
                this[nameof(GridDTO.SortDirection)] = "asc";
        }

        public string GenreFilter
        {
            get => Get(nameof(GameGridDTO.Genre))?.Replace(FilterPrefix.Genre, "");
            set => this[nameof(GameGridDTO.Genre)] = value;
        }

        public string TypeFilter
        {
            get => Get(nameof(GameGridDTO.Type))?.Replace(FilterPrefix.Type, "");
            set => this[nameof(GameGridDTO.Type)] = value;
        }

        public string FormatFilter
        {
            get => Get(nameof(GameGridDTO.Format))?.Replace(FilterPrefix.Format, "");
            set => this[nameof(GameGridDTO.Format)] = value;
        }

        public string RatingFilter
        {
            get => Get(nameof(GameGridDTO.Rating))?.Replace(FilterPrefix.Rating, "");
            set => this[nameof(GameGridDTO.Rating)] = value;
        }

        public string PublisherFilter
        {
            get => Get(nameof(GameGridDTO.Publisher))?.Replace(FilterPrefix.Publisher, "");
            set => this[nameof(GameGridDTO.Publisher)] = value;
        }


        public void ClearFilters() =>
            GenreFilter = TypeFilter = FormatFilter = RatingFilter = PublisherFilter = GameGridDTO.DefaultFilter;

        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        // return a new dictionary that contains the same values as this dictionary.
        // needed so that pages can change the route values when calculating paging, sorting,
        // and filtering links, without changing the values of the current route
        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}

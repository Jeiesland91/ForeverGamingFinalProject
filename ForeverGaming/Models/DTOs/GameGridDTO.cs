using Newtonsoft.Json;

namespace ForeverGaming.Models
{
    // Inherits the general purpose GridDTO class and adds game-specific 
    // properties for the filtering route segments defined in the Startup.cs file. 

    // Instances of this class are stored in session after being converted to a 
    // JSON string. Since the readonly DefaultFilter property doesn't need
    // to be stored, it's decorated with the [JsonIgnore] attribute so it will 
    // be skipped when the JSON string is created.
    public class GameGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Genre { get; set; } = DefaultFilter;
        public string Type { get; set; } = DefaultFilter;
        public string Format { get; set; } = DefaultFilter;
        public string Rating { get; set; } = DefaultFilter;
        public string Publisher { get; set; } = DefaultFilter;
    }
}

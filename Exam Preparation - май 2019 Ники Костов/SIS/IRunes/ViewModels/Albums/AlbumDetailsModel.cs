using System.Collections.Generic;
using IRunes.ViewModels.Tracks;

namespace IRunes.ViewModels.Albums
{
    public class AlbumDetailsModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<TrackInfoViewModel> Tracks { get; set; }

    }
}

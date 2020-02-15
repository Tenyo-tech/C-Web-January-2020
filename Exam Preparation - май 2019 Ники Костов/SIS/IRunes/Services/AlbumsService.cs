using System.Collections.Generic;
using System.Linq;
using IRunes.Models;
using IRunes.ViewModels.Albums;
using IRunes.ViewModels.Tracks;

namespace IRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0M,
            };
            this.db.Albums.Add(album);
            this.db.SaveChanges();
            
        }

        public IEnumerable<AlbumInfoViewModel> GetAll()
        {
            var allAlbums = this.db.Albums.Select(x => new AlbumInfoViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return allAlbums;
        }

        public AlbumDetailsModel GetDetails(string id)
        {
            var album = this.db.Albums.Where(x => x.Id == id)
                .Select(x=> new AlbumDetailsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cover = x.Cover,
                    Price = x.Price,
                    Tracks = x.Tracks.Select(x=> new TrackInfoViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                    })
                }).FirstOrDefault();

            return album;
        }
    }
}

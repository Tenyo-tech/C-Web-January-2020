using System.Collections.Generic;
using IRunes.ViewModels.Albums;

namespace IRunes.Services
{
    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IEnumerable<AlbumInfoViewModel> GetAll();

        AlbumDetailsModel GetDetails(string id);
    }
}

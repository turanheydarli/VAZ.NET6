using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Models;
using VAZ.Domain.Entities;

namespace VAZ.Application.Storage.Interfaces
{
    public interface IPictureService
    {
        Task<Picture> SavePicture (IFormFile picture, int productId);
        Task<ICollection<Picture>> SavePictureBulk (ICollection<IFormFile> pictures, int productId);
        Task<Picture> UpdatePicture(Picture picture, int pictureId);
        Task<bool> DeletePicture(Picture picture, bool deleteOnDatabase = true);
        Task<bool> DeletePictureBulk(ICollection<Picture> pictures, bool deleteOnDatabase = true);
    }
}

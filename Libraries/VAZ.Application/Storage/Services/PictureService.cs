using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Models;
using VAZ.Application.Storage.Extensions;
using VAZ.Application.Storage.Interfaces;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Extensions;

namespace VAZ.Application.Storage.Services
{
	public class PictureService : IPictureService
	{
		IRepository<Picture> _pictureRepository;

		public PictureService(IRepository<Picture> mediaRepository)
		{
			_pictureRepository = mediaRepository;
		}

		public async Task<bool> DeletePicture(Picture picture, bool deleteOnDatabase = true)
		{
			if (picture == null)
				throw new ArgumentNullException(nameof(picture));

			//delete from file system
			await DeletePictureOnFileSystem(picture, CommonPath.ImageUploadedPath);

			//delete from database
			if (deleteOnDatabase)
			{
				return await _pictureRepository.DeleteAsync(picture) != -1;
			}
				
			return true;
		}

		public async Task<bool> DeletePictureBulk(ICollection<Picture> pictures, bool deleteOnDatabase = true)
		{
			foreach (Picture picture in pictures)
			{
				//delete from file system
				await DeletePictureOnFileSystem(picture, CommonPath.ImageUploadedPath);
			}

			//delete from database
			if (deleteOnDatabase)
			{
				return _pictureRepository.DeleteBulk(pictures) != -1;
			}

			return true;
		}

		public async Task DeletePictureOnFileSystem(Picture picture, string dirpath)
		{
			if (picture == null)
				throw new ArgumentNullException(nameof(picture));

			string fullPath = Path.Combine(dirpath, picture.FileName);

			if (!string.IsNullOrEmpty(fullPath))
			{
				await Task.Run(() => File.Delete(fullPath));
			}
		}


		public async Task<Picture> SavePicture(IFormFile picture, int productId)
		{
			string fileName = string.Format("{0}_{1}.{2}", Guid.NewGuid().ToString(), DateTime.Now.Year, picture.GetFileExtension());
			string dirpath = CommonPath.ImageUploadedPath;
			string fullPath = Path.Combine(dirpath, fileName);

			using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
			{
				await picture.CopyToAsync(fileStream);
			}

			return await _pictureRepository.InsertAsync(new Picture
			{
				Caption = null,
				CreatedTime = DateTime.Now,
				FileName = fileName,
				FileSize = picture.Length,
				MimeType = picture.ContentType,
				ProductId = productId
			});
		}

		public async Task<ICollection<Picture>> SavePictureBulk(ICollection<IFormFile> pictures, int productId)
		{
			ICollection<Picture> addedPictures = new List<Picture>();

			foreach (IFormFile picture in pictures)
			{
				string fileName = string.Format("{0}_{1}.{2}", Guid.NewGuid().ToString(), DateTime.Now.Year, picture.GetFileExtension());
				string dirpath = CommonPath.ImageUploadedPath;
				string fullPath = Path.Combine(dirpath, fileName);

				using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
				{
					await picture.CopyToAsync(fileStream);
				}

				Picture newPicture = new Picture
				{
					Caption = null,
					CreatedTime = DateTime.Now,
					FileName = fileName,
					FileSize = picture.Length,
					MimeType = picture.ContentType,
					ProductId = productId
				};

				addedPictures.Add(_pictureRepository.InsertWithoutCommit(newPicture));
			}

			await _pictureRepository.CommitAsync();
			return addedPictures;
		}

		public Task<Picture> UpdatePicture(Picture picture, int pictureId)
		{
			throw new NotImplementedException();
		}

	}
}

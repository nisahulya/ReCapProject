using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }



        public IResult Add(Image image, CarImage carImage)
        {
            var imageNumber = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count();

            if (imageNumber > 5)
            {
                return new ErrorResult(Messages.ExceedCarImagesNumber);
            }

            IResult result = BusinessRules.Run(FileUpload(image, carImage));
            
            
            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }



        private IResult FileUpload(Image image, CarImage carImage)
        {
            var currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
            var path = "\\images";
            string randomName = null;
            string extension = null;

            if (image.Files != null && image.Files.Length > 0)
            {
                randomName = Guid.NewGuid().ToString();
                extension = Path.GetExtension(image.Files.FileName);

                if (extension != ".jpeg" && extension != ".jpg" && extension != ".png")
                {
                    return new ErrorResult(Messages.WrongFileType);
                }

                if (!Directory.Exists(currentDirectory + path))
                {
                    Directory.CreateDirectory(currentDirectory + path);
                }

                using (FileStream fileStream = File.Create(currentDirectory + path + randomName + extension))
                {
                    image.Files.CopyTo(fileStream);
                    fileStream.Flush();
                    carImage.ImagePath = (path + randomName + extension).Replace("\\", "/");
                    carImage.Date = DateTime.Now;
                }  
                return new SuccessResult();
            }

            return new ErrorResult(Messages.NotExistFile);
        }



        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c=>c.CarImageId == carImage.CarImageId);
            if (image == null)
            {
                return new ErrorResult(Messages.NotFoundCarImage);
            }

            var path = "wwwroot" + image.ImagePath;

            if (File.Exists(path.Replace("/", "\\")))
            {
                File.Delete(path.Replace("/", "\\"));
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedCarImage);
        }



        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }



        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, CarImageId = 0, ImagePath = "/images/car.jpg" });

            return new SuccessDataResult<List<CarImage>>(images);

        }



        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId), Messages.CarImagesGottenById);
        }



        public IResult Update(Image image, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (isImage==null)
            {
                return new ErrorResult(Messages.NotFoundCarImage);
            }

            var newImagePath = "wwwroot" + isImage.ImagePath;
            if (File.Exists(newImagePath.Replace("/", "\\")))
            {
                File.Delete(newImagePath.Replace("/", "\\"));
            }

            IResult result = BusinessRules.Run(FileUpload(image, carImage));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);

        }


    }
}

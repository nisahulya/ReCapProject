using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());



            //carManager.Add(new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 50, Description = "Renault Araba", ModelYear = 2010 });
            //carManager.Add(new Car { CarId = 2, BrandId = 1, ColorId = 3, DailyPrice = 150, Description = "Opel Araba", ModelYear = 2015 });
            //carManager.Add(new Car { CarId = 3, BrandId = 3, ColorId = 5, DailyPrice = 100, Description = "Wolksvagen Araba", ModelYear = 2018 });
            //carManager.Add(new Car { CarId = 4, BrandId = 2, ColorId = 2, DailyPrice = 200, Description = "BMW Araba", ModelYear = 2009 });



            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.BrandId + " brand idli " + car.Description);
            //}



            //carManager.Update(new Car {CarId=5, BrandId=2, ColorId=3, DailyPrice=50 , Description="Ford Araba", ModelYear= 2004 });
            //carManager.Add(new Car { CarId = 7, BrandId = 3, ColorId = 5, CarName = "a", DailyPrice = 150, Description = "asf", ModelYear = 2012 });

            //carManager.Add(new Car { CarId = 6, BrandId = 2, ColorId = 3, DailyPrice = 10, Description = "Opel Araba", ModelYear = 2016 });

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { BrandId = 1, BrandName = "Opel" });
            //brandManager.Add(new Brand { BrandId = 2, BrandName = "BMW" });
            //brandManager.Add(new Brand { BrandId = 3, BrandName = "Woklsvagen" });
            //brandManager.Add(new Brand { BrandId = 4, BrandName = "Renault" });
            //brandManager.Update(new Brand { BrandId = 4, BrandName = "Ford" });
            //brandManager.Delete(new Brand { BrandId = 4, BrandName = "Ford" });

            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}

            //Console.WriteLine( brandManager.GetById(2).BrandName ); 

            //carManager.Update(new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 50, Description = "Opel 1.3 Araba", ModelYear = 2010 });
            //carManager.Update(new Car { CarId = 5, BrandId = 2, ColorId = 3, DailyPrice = 50, Description = "1.6 Araba", ModelYear = 2004 });
            //carManager.Update(new Car { CarId = 6, BrandId = 2, ColorId = 3, DailyPrice = 10, Description = "Arkadan Çekiş", ModelYear = 2016 });

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { ColorId = 1, ColorName = "Kırmızı"});
            //colorManager.Add(new Color { ColorId = 2, ColorName = "Sarı" });
            //colorManager.Add(new Color { ColorId = 3, ColorName = "Pembe" });
            //colorManager.Add(new Color { ColorId = 4, ColorName = "Mavi" });

            //colorManager.Update(new Color { ColorId = 4, ColorName = "Yeşil" });

            //colorManager.Delete(new Color { ColorId = 1, ColorName = "Kırmızı" });

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}

            //Console.WriteLine(colorManager.GetById(2).ColorName); 

            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine(car.Description +" / " + car.BrandName + " / " + car.ColorName +
            //        " / " + car.DailyPrice);
            //}

            //brandManager.Add( new Brand { BrandId=4, BrandName="Volvo" });

            ////Console.WriteLine(colorManager.GetAll().Message); 

            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { UserId=1, FirstName="ahmet", LastName="Doğan", Email="dfczx@sdf", Password="esfsd" });

            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { CompanyName="AC ltd.şti" , CustomerId=1, UserId=1});

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentalId = 1, RentDate = new DateTime(2010,11,11)  , ReturnDate=null  });
            rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentalId = 2, RentDate = new DateTime(2010, 12, 11), ReturnDate = new DateTime(2010, 12, 12) });
            
        }
    }
}

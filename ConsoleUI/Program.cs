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

            carManager.Add(new Car { CarId = 6, BrandId = 2, ColorId = 3, DailyPrice = 10, Description = "Opel Araba", ModelYear = 2016 });
        }
    }
}

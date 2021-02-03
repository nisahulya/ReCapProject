using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            
           Car car1 = carManager.GetById(1);
            Console.WriteLine(car1.Description);


            carManager.Add(new Car
            { CarId=5, BrandId=5, ColorId=2, DailyPrice=200, Description="Renault Araba", ModelYear=2019
            });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Update(new Car { CarId = 1, BrandId = 2, ColorId = 2, DailyPrice = 150, Description = "Wolkswagen Araba", ModelYear = 2010 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Delete(new Car { CarId = 2, BrandId = 4, ColorId = 2, DailyPrice = 100, Description = "Renault Araba", ModelYear = 2009 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}

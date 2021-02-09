using Business.Concrete;
using DataAccess.Concrete.InMemory;
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
                Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            }
            
            Console.WriteLine("---------------------");

            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            }

            Console.WriteLine("---------------------");

            CarManager carManager1 = new CarManager(new InMemoryCarDal());
            carManager1.Add(new Entities.Concrete.Car { CarId = 6, BrandId = 3, ColorId = 1, ModelYear = 2021, DailyPrice = 1000, Description = "Lamborghini Aventador" });

            foreach (var car in carManager1.GetAll()) 
            {
                Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            }
        }
    }
}

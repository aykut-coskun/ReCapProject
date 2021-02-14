using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tüm araç listesi");

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            }
            


            Console.WriteLine("Marka Id'si 2 olan araç listesi");

            CarManager carManager2 = new CarManager(new EfCarDal());
            foreach (var car in carManager2.GetCarsByBrandId(2))
            {
                Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            }



            Console.WriteLine("Renk Id'si 1 olan araç listesi");

            CarManager carManager3 = new CarManager(new EfCarDal());
            foreach (var car in carManager2.GetCarsByColorId(1))
            {
                Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            }


            Console.WriteLine("Yeni araç ekleme ve araç listesi");

            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(new Entities.Concrete.Car { CarId = 7, BrandId = 5, ColorId = 2, ModelYear = 2020, DailyPrice = 1100, Description = "Lamborghini Gallardo " });

            foreach (var car in carManager1.GetAll()) 
            {
                Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            }
        }
    }
}

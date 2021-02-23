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
            // CRUD OPERASYONLARI----- CAR -----
            Console.WriteLine("TÜM ARAÇ LİSTESİ .....DTO.....");
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Model: {0} Marka: {1} Renk: {2} Günlük fiyat:  {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            

             Console.WriteLine("------YENİ ARAÇ EKLEME, ARAÇ GÜNCELLEME VE ARAÇ LİSTESİ------");

            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(new Car { CarId=9, BrandId=3, ColorId=2, ModelYear=2020, DailyPrice=925, Description = "VW Arteon" });
            carManager1.Update(new Car { CarId = 8, BrandId = 2, ColorId = 2, ModelYear = 2021, DailyPrice = 1000, Description = "Audi A7" });

            foreach (var car in carManager1.GetCarDetails().Data) 
            {
                Console.WriteLine("Model {0} Marka {1} Renk {2} Günlük fiyat  {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }

            Console.WriteLine("------ARAÇ SİLME VE ARAÇ LİSTESİ------");

            carManager1.Delete( new Car { CarId = 9 });
            CarManager carManager2 = new CarManager(new EfCarDal());
            foreach (var car in carManager2.GetCarDetails().Data)
            {
                Console.WriteLine("Model {0} Marka {1} Renk {2} Günlük fiyat  {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }


            //CRUD OPERASYONLARI----- BRAND -----
            Console.WriteLine("------YENİ MARKA EKLEME, MARKA GÜNCELLEME VE MARKA LİSTESİ------");

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand { BrandId = 6, BrandName = "Renault" });
            brandManager.Update(new Brand { BrandId = 3, BrandName = "Ferrari" });
            brandManager.Delete(new Brand { BrandId = 6 });

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("Marka Id {0} Marka {1}", brand.BrandId, brand.BrandName);
            }


            //CRUD OPERASYONLARI----- COLOR -----
            Console.WriteLine("------YENİ RENK EKLEME, RENK GÜNCELLEME VE RENK LİSTESİ-----");

            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color {ColorId=4, ColorName="Sarı" });
            colorManager.Update(new Color { ColorId=3, ColorName="Lacivert" });
            colorManager.Delete(new Color { ColorId = 5 });

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Renk Id {0} Renk {1}", color.ColorId, color.ColorName);
            }

            







            //Console.WriteLine("Marka Id'si 2 olan araç listesi");

            //CarManager carManager2 = new CarManager(new EfCarDal());
            //foreach (var car in carManager2.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            //}



            //Console.WriteLine("Renk Id'si 1 olan araç listesi");

            //CarManager carManager3 = new CarManager(new EfCarDal());
            //foreach (var car in carManager2.GetCarsByColorId(1))
            //{
            //    Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            //}



            //Console.WriteLine("Yeni araç ekleme ve araç listesi");

            //CarManager carManager1 = new CarManager(new EfCarDal());
            //carManager1.Add(new Entities.Concrete.Car { CarId = 7, BrandId = 5, ColorId = 2, ModelYear = 2020, DailyPrice = 1100, Description = "Lamborghini Gallardo " });

            //foreach (var car in carManager1.GetAll())
            //{
            //    Console.WriteLine("Modelyılı {0} Marka {1} Günlük Fiyatı {2} Tanımı {3}", car.ModelYear, car.BrandId, car.DailyPrice, car.Description);
            //}



        }
    }
}

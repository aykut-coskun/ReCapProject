﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2020, DailyPrice=250, Description="Toyota Yaris"},
                new Car{CarId=2, BrandId=1, ColorId=2, ModelYear=2017, DailyPrice=350, Description="Audi A5"},
                new Car{CarId=3, BrandId=2, ColorId=2, ModelYear=2018, DailyPrice=300, Description="BMW Z4"},
                new Car{CarId=4, BrandId=2, ColorId=3, ModelYear=2019, DailyPrice=450, Description="VW Golf"},
                new Car{CarId=5, BrandId=3, ColorId=3, ModelYear=2021, DailyPrice=600, Description="Mercedes AMG"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
       

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            // Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
    }

    public static class CarService
    {
        public static Task<IEnumerable<Car>> GetCarsAsync(string uri)
        {
            Thread.Sleep(500);

            var cars = new List<Car>
            {
                new Car
                {
                    Id = 1
                },
                new Car
                {
                    Id = 2
                }
            }.AsEnumerable();

            return Task.FromResult(cars);
        }

        public static IEnumerable<Car> GetCars(string uri)
        {
            Thread.Sleep(500);
            var cars = new List<Car>
            {
                new Car
                {
                    Id = 3
                },
                new Car
                {
                    Id = 4
                }
            };

            return cars;
        }
    }

    [Route("api/[controller]")]
    public class TPLController : Controller
    {
        private static readonly string[] PayloadSources = new[] {
            "http://localhost:2700/api/cars/cheap",
            "http://localhost:2700/api/cars/expensive"
        };

        [HttpGet("sync")]
        public IEnumerable<Car> AllCarsSync()
        {

            IEnumerable<Car> cars =
                PayloadSources.SelectMany(x => CarService.GetCars(x));

            return cars;
        }

        [HttpGet("parallel")]
        public IEnumerable<Car> AllCarsInParallelSync()
        {

            IEnumerable<Car> cars = PayloadSources.AsParallel()
                .SelectMany(uri => CarService.GetCars(uri)).AsEnumerable();

            return cars;
        }

        [HttpGet("async")]
        public async Task<IEnumerable<Car>> AllCarsAsync()
        {

            List<Car> carsResult = new List<Car>();
            foreach (var uri in PayloadSources)
            {

                IEnumerable<Car> cars = await CarService.GetCarsAsync(uri);
                carsResult.AddRange(cars);
            }

            return carsResult;
        }

        [HttpGet("asyncparallel")]
        public async Task<IEnumerable<Car>> AllCarsInParallelNonBlockingAsync()
        {

            IEnumerable<Task<IEnumerable<Car>>> allTasks = PayloadSources.Select(uri => CarService.GetCarsAsync(uri));
            IEnumerable<Car>[] allResults = await Task.WhenAll(allTasks);

            return allResults.SelectMany(cars => cars);
        }
    }
}

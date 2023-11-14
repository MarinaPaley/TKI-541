// <copyright file="WeatherForecastController.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Net.Mime;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Контроллер, реализующий взаимодействие с прогнозом погоды (<see cref="WeatherForecast"/>).
    /// </summary>
    [ApiController]
    [Route(WeatherForecastController.RouteUrl)]
    [Produces(MediaTypeNames.Application.Json)]
    public sealed class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// Целевой маршрут контроллера.
        /// </summary>
        public const string RouteUrl = "api/weather-forecast";

        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        private readonly ILogger<WeatherForecastController> logger;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WeatherForecastController"/>.
        /// </summary>
        /// <param name="logger"> Логгер. </param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Формирует тестовый прогноз погоды.
        /// </summary>
        /// <response code="200">
        /// Коллекция моделей прогноза погоды.
        /// </response>
        /// <returns>
        /// <c>200</c> и результат.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Index()
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToArray();

            return this.Ok(result);
        }
    }
}

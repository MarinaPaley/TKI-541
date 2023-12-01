// <copyright file="WeatherForecast.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace WebApi
{
    using System;

    /// <summary>
    /// Прогноз погоды.
    /// </summary>
    public sealed class WeatherForecast
    {
        /// <summary>
        /// Дата.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Темпратура в градусах Цельсия.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Темпратура в градусах Фаренгейта.
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Короткое описание.
        /// </summary>
        public string? Summary { get; set; }
    }
}

using IS_Projekt.Core.AccidentStatistics;
using IS_Projekt.Server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IS_Projekt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccidentsController : ControllerBase
    {
        private readonly string connectionString;

        public AccidentsController(IConfiguration configuration)
        {
            connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("Default");

            using var context = new StatisticsContext(connectionString);
            using var transaction = context.Database.BeginTransaction();
            context.Database.EnsureCreated();
            context.SaveChanges();
            transaction.Commit();
        }

        // GET: api/<AccidentsController>
        [HttpGet]
        [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public List<AccidentStatisticDto> Get()
        {
            List<AccidentStatisticDto> rows = new();

            using var context = new StatisticsContext(connectionString);
            var data = context.AccidentStatisticDtos;

            foreach (var item in data)
            {
                rows.Add(item);
            }

            return rows;
        }

        // POST api/<AccidentsController>
        [HttpPost]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public /*async*/ void Post([FromBody] AccidentStatisticDto[] value)
        {
            using var context = new StatisticsContext(connectionString);
            using var transaction = context.Database.BeginTransaction();
            context.Database.EnsureCreated(); //tworzy bazę jeśli nie istnieje

            for (int i = 0; i < value.Length; i++)
            {
                context.AccidentStatisticDtos.Add(value[i]);
            }

            //await Task.Delay(10000);

            context.SaveChanges();
            transaction.Commit();
        }

        // DELETE api/<AccidentsController>
        /// <summary>
        ///     Usuwa statystyki.
        /// </summary>
        [HttpDelete]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void Delete()
        {
            using var context = new StatisticsContext(connectionString);
            using var transaction = context.Database.BeginTransaction();
            context.AccidentStatisticDtos.RemoveRange(context.AccidentStatisticDtos);
            context.SaveChanges();
            transaction.Commit();
        }

        // DELETE api/<AccidentsController>
        /// <summary>
        ///     Resetuje bazę danych.
        /// </summary>
        [HttpDelete("reset")]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void Reset()
        {
            using var context = new StatisticsContext(connectionString);
            using var transaction = context.Database.BeginTransaction();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();
            transaction.Commit();
        }
    }
}

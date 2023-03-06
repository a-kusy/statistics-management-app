using IS_Projekt.Core.AccidentStatistics;
using IS_Projekt.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace IS_Projekt.Server.Services
{
    public class DtoToReadableService : IDtoToReadableService
    {
        private readonly string connectionString;

        public DtoToReadableService(IConfiguration configuration)
        {
            connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("Default");

            using var context = new StatisticsContext(connectionString);
            using var transaction = context.Database.BeginTransaction();
            context.Database.EnsureCreated();
            context.SaveChanges();
            transaction.Commit();
        }

        public AccidentStatistic ToReadable(AccidentStatisticDto dto)
        {
            using var dbContext = new StatisticsContext(connectionString);
            return new AccidentStatistic(
                   Wojewodztwo: IdToName(dto.IdTerytWojewodztwo, dbContext.WojewodztwoDtos),
                   TypPodmiotu: IdToName(dto.IdTypPodmiotu, dbContext.TypPodmiotuDtos),
                   RodzajWypadku: IdToName(dto.IdRodzajWypadku, dbContext.RodzajWypadkuDtos),
                   PrzyczynaWypadku: IdToName(dto.IdPrzyczynaWypadku, dbContext.PrzyczynaWypadkuDtos),
                   MiejsceWypadku: IdToName(dto.IdMiejsceWypadku, dbContext.MiejsceWypadkuDtos),
                   RodzajZajec: IdToName(dto.IdRodzajZajec, dbContext.RodzajZajecDtos),
                   LiczbaWypadkow: dto.LiczbaWypadkow
            );
        }

        private static string IdToName<T>(int id, DbSet<T> typPodmiotuDtos) where T : NameDto
        {
            return typPodmiotuDtos.First(x => x.Id == id).Name;
        }

        private static int NameToId<T>(string name, DbSet<T> typPodmiotuDtos) where T : NameDto
        {
            return typPodmiotuDtos.First(x => x.Name == name).Id;
        }

        public AccidentStatisticDto ToDto(AccidentStatistic readable)
        {
            using var dbContext = new StatisticsContext(connectionString);
            return new AccidentStatisticDto(
                   IdStatystyki: 0,
                   IdTerytWojewodztwo: NameToId(readable.Wojewodztwo, dbContext.WojewodztwoDtos),
                   IdTypPodmiotu: NameToId(readable.TypPodmiotu, dbContext.TypPodmiotuDtos),
                   IdRodzajWypadku: NameToId(readable.RodzajWypadku, dbContext.RodzajWypadkuDtos),
                   IdPrzyczynaWypadku: NameToId(readable.PrzyczynaWypadku, dbContext.PrzyczynaWypadkuDtos),
                   IdMiejsceWypadku: NameToId(readable.MiejsceWypadku, dbContext.MiejsceWypadkuDtos),
                   IdRodzajZajec: NameToId(readable.RodzajZajec, dbContext.RodzajZajecDtos),
                   LiczbaWypadkow: readable.LiczbaWypadkow
            );
        }

        public AccidentStatistic[] ToReadableMultiple(AccidentStatisticDto[] dto)
        {
            return dto.Select(x => ToReadable(x)).ToArray();
        }

        public AccidentStatisticDto[] ToDtoMultiple(AccidentStatistic[] dto)
        {
            return dto.Select(x => ToDto(x)).ToArray();
        }
    }
}

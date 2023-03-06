using IS_Projekt.Core.AccidentStatistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Serialization;

namespace IS_Projekt.Server.Data
{
    public class StatisticsContext : DbContext
    {
        private static readonly XmlSerializer xmlSerializer = new(typeof(AccidentStatisticsXml));
        private readonly string connectionString;

        public StatisticsContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<AccidentStatisticDto> AccidentStatisticDtos { get; set; } = null!;
        public DbSet<MiejsceWypadkuDto> MiejsceWypadkuDtos { get; set; } = null!;
        public DbSet<PrzyczynaWypadkuDto> PrzyczynaWypadkuDtos { get; set; } = null!;
        public DbSet<RodzajWypadkuDto> RodzajWypadkuDtos { get; set; } = null!;
        public DbSet<RodzajZajecDto> RodzajZajecDtos { get; set; } = null!;
        public DbSet<TypPodmiotuDto> TypPodmiotuDtos { get; set; } = null!;
        public DbSet<WojewodztwoDto> WojewodztwoDtos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var accidentStatisticsXml = GetAccidentStatisticsXml();
            var miejsceWypadkuDictionary = getIdNameDictionary(x => x.IdMiejsceWypadku, x => x.MiejsceWypadku);
            var przyczynaWypadkuDictionary = getIdNameDictionary(x => x.IdPrzyczynaWypadku, x => x.PrzyczynaWypadku);
            var rodzajWypadkuDictionary = getIdNameDictionary(x => x.IdRodzajWypadku, x => x.RodzajWypadku);
            var rodzajZajecDictionary = getIdNameDictionary(x => x.IdRodzajZajec, x => x.RodzajZajec);
            var typPodmiotuDictionary = getIdNameDictionary(x => x.IdTypPodmiotu, x => x.TypPodmiotu);
            var wojewodztwoDictionary = getIdNameDictionary(x => x.IdTerytWojewodztwo, x => x.Wojewodztwo);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccidentStatisticDto>(entity =>
            {
                entity.ToTable(typeof(AccidentStatisticDto).Name.Replace("dto", null, StringComparison.InvariantCultureIgnoreCase) + 's');
                entity.HasKey(e => e.IdStatystyki);
                entity.Property(e => e.IdMiejsceWypadku).IsRequired();
                entity.Property(e => e.IdPrzyczynaWypadku).IsRequired();
                entity.Property(e => e.IdRodzajWypadku).IsRequired();
                entity.Property(e => e.IdRodzajZajec).IsRequired();
                entity.Property(e => e.IdTypPodmiotu).IsRequired();
                entity.Property(e => e.IdTerytWojewodztwo).IsRequired();
            });
            modelBuilder.Entity<MiejsceWypadkuDto>(e => ConfigureNameEntity(e, miejsceWypadkuDictionary));
            modelBuilder.Entity<PrzyczynaWypadkuDto>(e => ConfigureNameEntity(e, przyczynaWypadkuDictionary));
            modelBuilder.Entity<RodzajWypadkuDto>(e => ConfigureNameEntity(e, rodzajWypadkuDictionary));
            modelBuilder.Entity<RodzajZajecDto>(e => ConfigureNameEntity(e, rodzajZajecDictionary));
            modelBuilder.Entity<TypPodmiotuDto>(e => ConfigureNameEntity(e, typPodmiotuDictionary));
            modelBuilder.Entity<WojewodztwoDto>(e => ConfigureNameEntity(e, wojewodztwoDictionary));

            Dictionary<int, string> getIdNameDictionary(Func<AccidentStatisticsRowXml, int> idSelector, Func<AccidentStatisticsRowXml, string> nameSelector) => accidentStatisticsXml.Rows
                    .Select(x => new NameDto(idSelector(x), nameSelector(x)))
                    .ToHashSet()
                    .ToDictionary(x => x.Id, x => x.Name);
        }

        private static AccidentStatisticsXml GetAccidentStatisticsXml()
        {
            var fileName = "Assets/wypadki.xml";
            if (!File.Exists(fileName))
                Console.WriteLine($"Plik {fileName} nie istnieje!");
            using var fs = new FileStream(fileName, FileMode.Open);
            using var reader = new StreamReader(fs);
            return (AccidentStatisticsXml)xmlSerializer.Deserialize(reader)!;
        }

        private static void ConfigureNameEntity<T>(EntityTypeBuilder<T> entity, Dictionary<int, string> d) where T : NameDto
        {
            entity.ToTable(typeof(T).Name.Replace("dto", null, StringComparison.InvariantCultureIgnoreCase));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.HasData(d.Select(dr => new NameDto(dr.Key, dr.Value)));
        }
    }
}

namespace IS_Projekt.Core.AccidentStatistics
{
    /// <summary>
    ///     Klasa, która przechowuje statystykę o wypadkach
    ///     w formie czytelnej dla człowieka.
    /// </summary>
    public record AccidentStatistic(
        string Wojewodztwo,
        string TypPodmiotu,
        string RodzajWypadku,
        string PrzyczynaWypadku,
        string MiejsceWypadku,
        string RodzajZajec,
        int LiczbaWypadkow
    )
    {
        public AccidentStatistic() : this(null!, null!, null!, null!, null!, null!, 0)
        {

        }
    }
}

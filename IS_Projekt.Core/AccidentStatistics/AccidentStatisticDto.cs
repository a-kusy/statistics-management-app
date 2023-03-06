namespace IS_Projekt.Core.AccidentStatistics
{
    /// <summary>
    ///     Klasa posiadające dane w formie bazodanowej,
    ///     czyli jako klucze do zewnętrznych tabel.
    /// </summary>
    public record AccidentStatisticDto(
        int IdStatystyki,
        int IdTerytWojewodztwo,
        int IdTypPodmiotu,
        int IdRodzajWypadku,
        int IdPrzyczynaWypadku,
        int IdMiejsceWypadku,
        int IdRodzajZajec,
        int LiczbaWypadkow
    )
    {
        public AccidentStatisticDto() : this(0, 0, 0, 0, 0, 0, 0, 0)
        {

        }
    }
}

using System.Xml.Serialization;

#nullable disable
namespace IS_Projekt.Core.AccidentStatistics
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Root));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Root)serializer.Deserialize(reader);
    // }

    /// <summary>
    ///     Klasa replikująca strukturę pliku wejściowego XML.
    ///     Posiada dane czytelne dla człowieka jak i ID dla kluczy obcych.
    /// </summary>
    [XmlRoot(ElementName = "row")]
    public class AccidentStatisticsRowXml
    {
        public int IdStatystyki { get; set; }

        [XmlElement(ElementName = "idTerytWojewodztwo")]
        public int IdTerytWojewodztwo { get; set; }

        [XmlElement(ElementName = "Wojewodztwo")]
        public string Wojewodztwo { get; set; }

        [XmlElement(ElementName = "idTypPodmiotu")]
        public int IdTypPodmiotu { get; set; }

        [XmlElement(ElementName = "TypPodmiotu")]
        public string TypPodmiotu { get; set; }

        [XmlElement(ElementName = "idRodzajWypadku")]
        public int IdRodzajWypadku { get; set; }

        [XmlElement(ElementName = "RodzajWypadku")]
        public string RodzajWypadku { get; set; }

        [XmlElement(ElementName = "idPrzyczynaWypadku")]
        public int IdPrzyczynaWypadku { get; set; }

        [XmlElement(ElementName = "PrzyczynaWypadku")]
        public string PrzyczynaWypadku { get; set; }

        [XmlElement(ElementName = "idMiejsceWypadku")]
        public int IdMiejsceWypadku { get; set; }

        [XmlElement(ElementName = "MiejsceWypadku")]
        public string MiejsceWypadku { get; set; }

        [XmlElement(ElementName = "idRodzajZajec")]
        public int IdRodzajZajec { get; set; }

        [XmlElement(ElementName = "RodzajZajec")]
        public string RodzajZajec { get; set; }

        [XmlElement(ElementName = "LiczbaWypadkow")]
        public int LiczbaWypadkow { get; set; }

    }

    [XmlRoot(ElementName = "root")]
    public class AccidentStatisticsXml
    {

        [XmlElement(ElementName = "row")]
        public List<AccidentStatisticsRowXml> Rows { get; set; }
    }
}
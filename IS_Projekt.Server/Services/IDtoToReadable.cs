using IS_Projekt.Core.AccidentStatistics;
using System.ServiceModel;

namespace IS_Projekt.Server.Services
{
    [ServiceContract]
    public interface IDtoToReadableService
    {
        [OperationContract]
        AccidentStatistic ToReadable(AccidentStatisticDto dto);
        [OperationContract]
        AccidentStatistic[] ToReadableMultiple(AccidentStatisticDto[] dto);
        [OperationContract]
        AccidentStatisticDto ToDto(AccidentStatistic dto);
        [OperationContract]
        AccidentStatisticDto[] ToDtoMultiple(AccidentStatistic[] dto);
    }
}

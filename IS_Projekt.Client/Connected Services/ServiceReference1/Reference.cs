﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AccidentStatisticDto", Namespace="http://tempuri.org/")]
    public partial class AccidentStatisticDto : object
    {
        
        private int IdStatystykiField;
        
        private int IdTerytWojewodztwoField;
        
        private int IdTypPodmiotuField;
        
        private int IdRodzajWypadkuField;
        
        private int IdPrzyczynaWypadkuField;
        
        private int IdMiejsceWypadkuField;
        
        private int IdRodzajZajecField;
        
        private int LiczbaWypadkowField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int IdStatystyki
        {
            get
            {
                return this.IdStatystykiField;
            }
            set
            {
                this.IdStatystykiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int IdTerytWojewodztwo
        {
            get
            {
                return this.IdTerytWojewodztwoField;
            }
            set
            {
                this.IdTerytWojewodztwoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int IdTypPodmiotu
        {
            get
            {
                return this.IdTypPodmiotuField;
            }
            set
            {
                this.IdTypPodmiotuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public int IdRodzajWypadku
        {
            get
            {
                return this.IdRodzajWypadkuField;
            }
            set
            {
                this.IdRodzajWypadkuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public int IdPrzyczynaWypadku
        {
            get
            {
                return this.IdPrzyczynaWypadkuField;
            }
            set
            {
                this.IdPrzyczynaWypadkuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public int IdMiejsceWypadku
        {
            get
            {
                return this.IdMiejsceWypadkuField;
            }
            set
            {
                this.IdMiejsceWypadkuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public int IdRodzajZajec
        {
            get
            {
                return this.IdRodzajZajecField;
            }
            set
            {
                this.IdRodzajZajecField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public int LiczbaWypadkow
        {
            get
            {
                return this.LiczbaWypadkowField;
            }
            set
            {
                this.LiczbaWypadkowField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AccidentStatistic", Namespace="http://tempuri.org/")]
    public partial class AccidentStatistic : object
    {
        
        private string WojewodztwoField;
        
        private string TypPodmiotuField;
        
        private string RodzajWypadkuField;
        
        private string PrzyczynaWypadkuField;
        
        private string MiejsceWypadkuField;
        
        private string RodzajZajecField;
        
        private int LiczbaWypadkowField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Wojewodztwo
        {
            get
            {
                return this.WojewodztwoField;
            }
            set
            {
                this.WojewodztwoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string TypPodmiotu
        {
            get
            {
                return this.TypPodmiotuField;
            }
            set
            {
                this.TypPodmiotuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string RodzajWypadku
        {
            get
            {
                return this.RodzajWypadkuField;
            }
            set
            {
                this.RodzajWypadkuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string PrzyczynaWypadku
        {
            get
            {
                return this.PrzyczynaWypadkuField;
            }
            set
            {
                this.PrzyczynaWypadkuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string MiejsceWypadku
        {
            get
            {
                return this.MiejsceWypadkuField;
            }
            set
            {
                this.MiejsceWypadkuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string RodzajZajec
        {
            get
            {
                return this.RodzajZajecField;
            }
            set
            {
                this.RodzajZajecField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public int LiczbaWypadkow
        {
            get
            {
                return this.LiczbaWypadkowField;
            }
            set
            {
                this.LiczbaWypadkowField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDtoToReadableService")]
    public interface IDtoToReadableService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDtoToReadableService/ToReadable", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.ToReadableResponse> ToReadableAsync(ServiceReference1.ToReadableRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDtoToReadableService/ToReadableMultiple", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.AccidentStatistic[]> ToReadableMultipleAsync(ServiceReference1.AccidentStatisticDto[] dto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDtoToReadableService/ToDto", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.ToDtoResponse> ToDtoAsync(ServiceReference1.ToDtoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDtoToReadableService/ToDtoMultiple", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.AccidentStatisticDto[]> ToDtoMultipleAsync(ServiceReference1.AccidentStatistic[] dto);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ToReadableRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ToReadable", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.ToReadableRequestBody Body;
        
        public ToReadableRequest()
        {
        }
        
        public ToReadableRequest(ServiceReference1.ToReadableRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ToReadableRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference1.AccidentStatisticDto dto;
        
        public ToReadableRequestBody()
        {
        }
        
        public ToReadableRequestBody(ServiceReference1.AccidentStatisticDto dto)
        {
            this.dto = dto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ToReadableResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ToReadableResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.ToReadableResponseBody Body;
        
        public ToReadableResponse()
        {
        }
        
        public ToReadableResponse(ServiceReference1.ToReadableResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ToReadableResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference1.AccidentStatistic ToReadableResult;
        
        public ToReadableResponseBody()
        {
        }
        
        public ToReadableResponseBody(ServiceReference1.AccidentStatistic ToReadableResult)
        {
            this.ToReadableResult = ToReadableResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ToDtoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ToDto", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.ToDtoRequestBody Body;
        
        public ToDtoRequest()
        {
        }
        
        public ToDtoRequest(ServiceReference1.ToDtoRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ToDtoRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference1.AccidentStatistic dto;
        
        public ToDtoRequestBody()
        {
        }
        
        public ToDtoRequestBody(ServiceReference1.AccidentStatistic dto)
        {
            this.dto = dto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ToDtoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ToDtoResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.ToDtoResponseBody Body;
        
        public ToDtoResponse()
        {
        }
        
        public ToDtoResponse(ServiceReference1.ToDtoResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ToDtoResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference1.AccidentStatisticDto ToDtoResult;
        
        public ToDtoResponseBody()
        {
        }
        
        public ToDtoResponseBody(ServiceReference1.AccidentStatisticDto ToDtoResult)
        {
            this.ToDtoResult = ToDtoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IDtoToReadableServiceChannel : ServiceReference1.IDtoToReadableService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class DtoToReadableServiceClient : System.ServiceModel.ClientBase<ServiceReference1.IDtoToReadableService>, ServiceReference1.IDtoToReadableService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DtoToReadableServiceClient() : 
                base(DtoToReadableServiceClient.GetDefaultBinding(), DtoToReadableServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IDtoToReadableService_soap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DtoToReadableServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(DtoToReadableServiceClient.GetBindingForEndpoint(endpointConfiguration), DtoToReadableServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DtoToReadableServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DtoToReadableServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DtoToReadableServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DtoToReadableServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DtoToReadableServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.ToReadableResponse> ServiceReference1.IDtoToReadableService.ToReadableAsync(ServiceReference1.ToReadableRequest request)
        {
            return base.Channel.ToReadableAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.ToReadableResponse> ToReadableAsync(ServiceReference1.AccidentStatisticDto dto)
        {
            ServiceReference1.ToReadableRequest inValue = new ServiceReference1.ToReadableRequest();
            inValue.Body = new ServiceReference1.ToReadableRequestBody();
            inValue.Body.dto = dto;
            return ((ServiceReference1.IDtoToReadableService)(this)).ToReadableAsync(inValue);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.AccidentStatistic[]> ToReadableMultipleAsync(ServiceReference1.AccidentStatisticDto[] dto)
        {
            return base.Channel.ToReadableMultipleAsync(dto);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.ToDtoResponse> ServiceReference1.IDtoToReadableService.ToDtoAsync(ServiceReference1.ToDtoRequest request)
        {
            return base.Channel.ToDtoAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.ToDtoResponse> ToDtoAsync(ServiceReference1.AccidentStatistic dto)
        {
            ServiceReference1.ToDtoRequest inValue = new ServiceReference1.ToDtoRequest();
            inValue.Body = new ServiceReference1.ToDtoRequestBody();
            inValue.Body.dto = dto;
            return ((ServiceReference1.IDtoToReadableService)(this)).ToDtoAsync(inValue);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.AccidentStatisticDto[]> ToDtoMultipleAsync(ServiceReference1.AccidentStatistic[] dto)
        {
            return base.Channel.ToDtoMultipleAsync(dto);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDtoToReadableService_soap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDtoToReadableService_soap))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:5229/Service.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return DtoToReadableServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IDtoToReadableService_soap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return DtoToReadableServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IDtoToReadableService_soap);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IDtoToReadableService_soap,
        }
    }
}

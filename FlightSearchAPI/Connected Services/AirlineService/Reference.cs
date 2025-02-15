﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirlineService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchRequest", Namespace="http://schemas.datacontract.org/2004/07/FlightProvider")]
    public partial class SearchRequest : object
    {
        
        private System.DateTime DepartureDateField;
        
        private string DestinationField;
        
        private string OriginField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DepartureDate
        {
            get
            {
                return this.DepartureDateField;
            }
            set
            {
                this.DepartureDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Destination
        {
            get
            {
                return this.DestinationField;
            }
            set
            {
                this.DestinationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Origin
        {
            get
            {
                return this.OriginField;
            }
            set
            {
                this.OriginField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchResult", Namespace="http://schemas.datacontract.org/2004/07/FlightProvider")]
    public partial class SearchResult : object
    {
        
        private AirlineService.FlightOption[] FlightOptionsField;
        
        private bool HasErrorField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AirlineService.FlightOption[] FlightOptions
        {
            get
            {
                return this.FlightOptionsField;
            }
            set
            {
                this.FlightOptionsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool HasError
        {
            get
            {
                return this.HasErrorField;
            }
            set
            {
                this.HasErrorField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FlightOption", Namespace="http://schemas.datacontract.org/2004/07/FlightProvider")]
    public partial class FlightOption : object
    {
        
        private System.DateTime ArrivalDateTimeField;
        
        private System.DateTime DepartureDateTimeField;
        
        private string FlightNumberField;
        
        private decimal PriceField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ArrivalDateTime
        {
            get
            {
                return this.ArrivalDateTimeField;
            }
            set
            {
                this.ArrivalDateTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DepartureDateTime
        {
            get
            {
                return this.DepartureDateTimeField;
            }
            set
            {
                this.DepartureDateTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FlightNumber
        {
            get
            {
                return this.FlightNumberField;
            }
            set
            {
                this.FlightNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                this.PriceField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AirlineService.IAirSearch")]
    public interface IAirSearch
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirSearch/AvailabilitySearch", ReplyAction="http://tempuri.org/IAirSearch/AvailabilitySearchResponse")]
        System.Threading.Tasks.Task<AirlineService.SearchResult> AvailabilitySearchAsync(AirlineService.SearchRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IAirSearchChannel : AirlineService.IAirSearch, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class AirSearchClient : System.ServiceModel.ClientBase<AirlineService.IAirSearch>, AirlineService.IAirSearch
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public AirSearchClient() : 
                base(AirSearchClient.GetDefaultBinding(), AirSearchClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IAirSearch.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AirSearchClient(EndpointConfiguration endpointConfiguration) : 
                base(AirSearchClient.GetBindingForEndpoint(endpointConfiguration), AirSearchClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AirSearchClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(AirSearchClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AirSearchClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(AirSearchClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AirSearchClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<AirlineService.SearchResult> AvailabilitySearchAsync(AirlineService.SearchRequest request)
        {
            return base.Channel.AvailabilitySearchAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IAirSearch))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IAirSearch))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:5001/Service.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return AirSearchClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IAirSearch);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return AirSearchClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IAirSearch);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IAirSearch,
        }
    }
}

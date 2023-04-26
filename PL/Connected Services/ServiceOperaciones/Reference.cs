﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceOperaciones {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceOperaciones.IOperaciones")]
    public interface IOperaciones {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperaciones/Saludar", ReplyAction="http://tempuri.org/IOperaciones/SaludarResponse")]
        string Saludar(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperaciones/Saludar", ReplyAction="http://tempuri.org/IOperaciones/SaludarResponse")]
        System.Threading.Tasks.Task<string> SaludarAsync(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperaciones/Suma", ReplyAction="http://tempuri.org/IOperaciones/SumaResponse")]
        int Suma(int numeroUno, int numeroDos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperaciones/Suma", ReplyAction="http://tempuri.org/IOperaciones/SumaResponse")]
        System.Threading.Tasks.Task<int> SumaAsync(int numeroUno, int numeroDos);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOperacionesChannel : PL.ServiceOperaciones.IOperaciones, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OperacionesClient : System.ServiceModel.ClientBase<PL.ServiceOperaciones.IOperaciones>, PL.ServiceOperaciones.IOperaciones {
        
        public OperacionesClient() {
        }
        
        public OperacionesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OperacionesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperacionesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperacionesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Saludar(string nombre) {
            return base.Channel.Saludar(nombre);
        }
        
        public System.Threading.Tasks.Task<string> SaludarAsync(string nombre) {
            return base.Channel.SaludarAsync(nombre);
        }
        
        public int Suma(int numeroUno, int numeroDos) {
            return base.Channel.Suma(numeroUno, numeroDos);
        }
        
        public System.Threading.Tasks.Task<int> SumaAsync(int numeroUno, int numeroDos) {
            return base.Channel.SumaAsync(numeroUno, numeroDos);
        }
    }
}

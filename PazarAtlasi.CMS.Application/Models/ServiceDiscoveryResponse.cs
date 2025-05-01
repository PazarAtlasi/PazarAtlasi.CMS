using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Application.Models
{
    /// <summary>
    /// Response from the service discovery endpoint
    /// </summary>
    public class ServiceDiscoveryResponse
    {
        public string ServiceName { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public DateTime ServerTime { get; set; }
        public string BaseUrl { get; set; }
        public List<ApiEndpoint> Endpoints { get; set; } = new List<ApiEndpoint>();
    }

    /// <summary>
    /// Represents an API endpoint from the discovery response
    /// </summary>
    public class ApiEndpoint
    {
        public string Path { get; set; }
        public string HttpMethod { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public bool RequiresAuthentication { get; set; }
        public List<string> RequiredRoles { get; set; } = new List<string>();
        public List<ApiOperation> Operations { get; set; } = new List<ApiOperation>();
    }

    /// <summary>
    /// Represents an operation within an API endpoint
    /// </summary>
    public class ApiOperation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string RequestContentType { get; set; }
        public string ResponseContentType { get; set; }
        public string RequestSchema { get; set; }
        public string ResponseSchema { get; set; }
        public List<ApiParameter> Parameters { get; set; } = new List<ApiParameter>();
    }

    /// <summary>
    /// Represents a parameter for an API operation
    /// </summary>
    public class ApiParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public string DefaultValue { get; set; }
    }
}
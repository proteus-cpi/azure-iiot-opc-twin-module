﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.OpcUa.Modules.Twin.Runtime {
    using Microsoft.Azure.IIoT.OpcUa.Protocol;
    using Microsoft.Azure.IIoT.Edge;
    using Microsoft.Azure.IIoT.Edge.Hub;
    using Microsoft.Azure.IIoT.Utils;
    using Microsoft.Extensions.Configuration;
    using System;

    /// <summary>
    /// Web service configuration - wraps a configuration root
    /// </summary>
    public class Config : ConfigBase, IOpcUaConfig, IEdgeConfig {

        /// <summary>
        /// Edge module configuration
        /// </summary>
        private const string EDGEHUB_CONNSTRING_KEY = "EdgeHubConnectionString";
        /// <summary>Hub connection string</summary>
        public string HubConnectionString =>
            GetString(EDGEHUB_CONNSTRING_KEY);
        /// <summary>Whether to bypass cert validation</summary>
        public bool BypassCertVerification =>
            GetBool(nameof(BypassCertVerification));
        /// <summary>Transports to use</summary>
        public TransportOption Transport => Enum.Parse<TransportOption>(
            GetString(nameof(Transport), nameof(TransportOption.Amqp)), true);
        /// <summary>No proxy</summary>
        public bool BypassProxy => false;
        /// <summary>No service connection string</summary>
        public string IoTHubConnString => null;
        /// <summary>No resource</summary>
        public string IoTHubResourceId => null;

        /// <summary>
        /// Configuration constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Config(IConfigurationRoot configuration) : 
            base(Uptime.ProcessId, configuration) {
        }
    }
}
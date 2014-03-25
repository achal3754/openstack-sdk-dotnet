﻿// /* ============================================================================
// Copyright 2014 Hewlett Packard
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ============================================================================ */

namespace Openstack.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Newtonsoft.Json.Linq;
    using Openstack.Common;
    using Openstack.Common.ServiceLocation;

    /// <inheritdoc/>
    internal class OpenstackServiceDefinitionPayloadConverter : IOpenstackServiceDefinitionPayloadConverter
    {
        /// <inheritdoc/>
        public OpenstackServiceDefinition Convert(string payload)
        {
            payload.AssertIsNotNull("payload", "A null service catalog payload cannot be converted.");

            try
            {
                var serviceDefinition = JObject.Parse(payload);
                var name = (string)serviceDefinition["name"];
                var type = (string)serviceDefinition["type"];

                var endpoints = new List<OpenstackServiceEndpoint>();
                endpoints.AddRange(serviceDefinition["endpoints"].Select(ConvertEndpoint));

                return new OpenstackServiceDefinition(name, type, endpoints);
            }
            catch (Exception ex)
            {
                throw new HttpParseException(string.Format("Service definition payload could not be parsed. Payload: '{0}'", payload), ex);
            }
        }

        /// <summary>
        /// Converts a Json token that represents a service endpoint into a POCO object.
        /// </summary>
        /// <param name="endpoint">The token.</param>
        /// <returns>A service endpoint.</returns>
        internal OpenstackServiceEndpoint ConvertEndpoint(JToken endpoint)
        {
            var converter = ServiceLocator.Instance.Locate<IOpenstackServiceEndpointPayloadConverter>();
            return converter.Convert(endpoint.ToString());
        }
    }
}
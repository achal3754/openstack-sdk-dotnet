﻿// /* ============================================================================
// Copyright 2014 Hewlett Packard
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ============================================================================ */

namespace OpenStack.Compute
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Client that can interact with an OpenStack compute service.
    /// </summary>
    public interface IComputeServiceClient : IOpenStackServiceClient
    {
        /// <summary>
        /// Gets a list of flavors available on the remote OpenStack instance.
        /// </summary>
        /// <returns>An enumerable list of compute flavors.</returns>
        Task<IEnumerable<ComputeFlavor>> GetFlavors();

        /// <summary>
        /// Gets the detailed metadata for a compute flavor.
        /// </summary>
        /// <param name="flavorId">The id of the flavor.</param>
        /// <returns>An object that represents the given flavor.</returns>
        Task<ComputeFlavor> GetFlavor(string flavorId);

        /// <summary>
        /// Gets a list of images available on the remote OpenStack instance.
        /// </summary>
        /// <returns>An enumerable list of compute images.</returns>
        Task<IEnumerable<ComputeImage>> GetImages();

        /// <summary>
        /// Gets the detailed metadata for a compute image.
        /// </summary>
        /// <param name="imageId">The id of the image.</param>
        /// <returns>An object that represents the given image.</returns>
        Task<ComputeImage> GetImage(string imageId);

        /// <summary>
        /// Deletes the compute image from the remote instance of OpenStack.
        /// </summary>
        /// <param name="imageId">The id of the image.</param>
        /// <returns>An async task.</returns>
        Task DeleteImage(string imageId);

        /// <summary>
        /// Gets the associated metadata for a given compute image.
        /// </summary>
        /// <param name="imageId">The id for the image.</param>
        /// <returns>A collection of key values pairs.</returns>
        Task<IDictionary<string, string>> GetImageMetadata(string imageId);

        /// <summary>
        /// Updates the metadata for a given compute image. 
        /// Note: If a key does not exist on the remote server, it will be created.
        /// </summary>
        /// <param name="imageId">The id for the image.</param>
        /// <param name="metadata">A collection of key value pairs.</param>
        /// <returns>An async task.</returns>
        Task UpdateImageMetadata(string imageId, IDictionary<string, string> metadata);

        /// <summary>
        /// Deletes the given key from the metadata for the given compute image.
        /// </summary>
        /// <param name="imageId">The id for the image</param>
        /// <param name="key">The metadata key to remove.</param>
        /// <returns>An async task.</returns>
        Task DeleteImageMetadata(string imageId, string key);

        /// <summary>
        /// Gets the associated metadata for a given compute server.
        /// </summary>
        /// <param name="serverId">The id for the server.</param>
        /// <returns>A collection of key values pairs.</returns>
        Task<IDictionary<string, string>> GetServerMetadata(string serverId);

        /// <summary>
        /// Updates the metadata for a given compute server. 
        /// Note: If a key does not exist on the remote server, it will be created.
        /// </summary>
        /// <param name="serverId">The id for the server.</param>
        /// <param name="metadata">A collection of key value pairs.</param>
        /// <returns>An async task.</returns>
        Task UpdateServerMetadata(string serverId, IDictionary<string, string> metadata);

        /// <summary>
        /// Deletes the given key from the metadata for the given compute server.
        /// </summary>
        /// <param name="serverId">The id for the server</param>
        /// <param name="key">The metadata key to remove.</param>
        /// <returns>An async task.</returns>
        Task DeleteServerMetadata(string serverId, string key);
    }
}
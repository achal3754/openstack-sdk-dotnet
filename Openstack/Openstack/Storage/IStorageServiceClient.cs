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

using System;

namespace Openstack.Storage
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Client that can interact with an Openstack storage service.
    /// </summary>
    public interface IStorageServiceClient : IOpenstackServiceClient
    {
        /// <summary>
        /// Gets the current public endpoint that this client is using.
        /// </summary>
        /// <returns>The public Uri.</returns>
        Uri GetPublicEndpoint();

        /// <summary>
        /// Creates a storage container on the remote Openstack instance.
        /// </summary>
        /// <param name="containerName">The name of the container.</param>
        /// <param name="metadata">Metadata for the container.</param>
        /// <returns>An async task.</returns>
        Task CreateStorageContainer(string containerName, IDictionary<string, string> metadata);

        /// <summary>
        /// Gets a storage container from the remote Openstack instance.
        /// </summary>
        /// <param name="containerName">The name of the container.</param>
        /// <returns>A storage container.</returns>
        Task<StorageContainer> GetStorageContainer(string containerName);

        /// <summary>
        /// Deletes a storage container from the remote Openstack instance.
        /// </summary>
        /// <param name="containerName">The name of the container.</param>
        /// <returns>An async task.</returns>
        Task DeleteStorageContainer(string containerName);

        /// <summary>
        /// Updates a storage container on the remote Openstack instance.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns>An async task.</returns>
        Task UpdateStorageContainer(StorageContainer container);

        /// <summary>
        /// Lists the storage object in a given container.
        /// </summary>
        /// <param name="containerName">The name of the container.</param>
        /// <returns>An enumerable list of storage objects.</returns>
        Task<IEnumerable<StorageObject>> ListStorageObjects(string containerName);

        /// <summary>
        /// Lists storage containers on the remote Openstack instance.
        /// </summary>
        /// <returns>An enumerable list of storage containers.</returns>
        Task<IEnumerable<StorageContainer>> ListStorageContainers();

        /// <summary>
        /// Gets the details of the current storage account from the remote Openstack instance.
        /// </summary>
        /// <returns>A storage account.</returns>
        Task<StorageAccount> GetStorageAccount();

        /// <summary>
        /// Creates a storage object on the remote Openstack instance.
        /// </summary>
        /// <param name="containerName">The name of the parent container.</param>
        /// <param name="objectName">The name of the object.</param>
        /// <param name="metadata">Metadata for the object.</param>
        /// <param name="content">The objects content.</param>
        /// <returns>A storage object. </returns>
        Task<StorageObject> CreateStorageObject(string containerName, string objectName, IDictionary<string, string> metadata, Stream content);

        /// <summary>
        /// Gets a storage object from the remote Openstack instance.
        /// </summary>
        /// <param name="containerName">The name of the parent container.</param>
        /// <param name="objectName">The name of the object.</param>
        /// <returns>The storage object.</returns>
        Task<StorageObject> GetStorageObject(string containerName, string objectName);

        /// <summary>
        /// Downloads the content of a storage object from the remote Openstack instance.
        /// </summary>
        /// <param name="containerName">The name of the parent container.</param>
        /// <param name="objectName">The name of the object.</param>
        /// <param name="outputStream">The output stream to copy the objects content to.</param>
        /// <returns>The storage object details.</returns>
        Task<StorageObject> DownloadStorageObject(string containerName, string objectName, Stream outputStream);

        /// <summary>
        /// Deletes a storage object from the remote Openstack instance.
        /// </summary>
        /// <param name="containerName">The name of the parent container.</param>
        /// <param name="objectName">The name of the object.</param>
        /// <returns>An async task.</returns>
        Task DeleteStorageObject(string containerName, string objectName);

        /// <summary>
        /// Updates a storage object on the remote Openstack instance.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        /// <returns>An async task.</returns>
        Task UpdateStorageObject(StorageObject obj);
    }
}
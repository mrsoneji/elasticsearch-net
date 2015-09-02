﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Delete a snapshot
		/// <para> </para>http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/modules-snapshots.html#_snapshot
		/// </summary>
		/// <param name="repository">The repository name under which the snapshot we want to delete lives</param>
		/// <param name="snapshotName">The name of the snapshot that we want to delete</param>
		/// <param name="selector">Optionally further describe the delete snapshot operation</param>
		IAcknowledgedResponse DeleteSnapshot(string repository, string snapshotName, Func<DeleteSnapshotDescriptor, IDeleteSnapshotRequest> selector = null);

		/// <inheritdoc/>
		IAcknowledgedResponse DeleteSnapshot(IDeleteSnapshotRequest deleteSnapshotRequest);

		/// <inheritdoc/>
		Task<IAcknowledgedResponse> DeleteSnapshotAsync(string repository, string snapshotName, Func<DeleteSnapshotDescriptor, IDeleteSnapshotRequest> selector = null);

		/// <inheritdoc/>
		Task<IAcknowledgedResponse> DeleteSnapshotAsync(IDeleteSnapshotRequest deleteSnapshotRequest);

	}
	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public IAcknowledgedResponse DeleteSnapshot(string repository, string snapshotName, Func<DeleteSnapshotDescriptor, IDeleteSnapshotRequest> selector = null) => 
			this.Dispatcher.Dispatch<IDeleteSnapshotRequest, DeleteSnapshotRequestParameters, AcknowledgedResponse>(
				selector.InvokeOrDefault(new DeleteSnapshotDescriptor().Snapshot(snapshotName).Repository(repository)),
				(p, d) => this.LowLevelDispatch.SnapshotDeleteDispatch<AcknowledgedResponse>(p)
			);

		/// <inheritdoc/>
		public IAcknowledgedResponse DeleteSnapshot(IDeleteSnapshotRequest deleteSnapshotRequest) => 
			this.Dispatcher.Dispatch<IDeleteSnapshotRequest, DeleteSnapshotRequestParameters, AcknowledgedResponse>(
				deleteSnapshotRequest,
				(p, d) => this.LowLevelDispatch.SnapshotDeleteDispatch<AcknowledgedResponse>(p)
			);

		/// <inheritdoc/>
		public Task<IAcknowledgedResponse> DeleteSnapshotAsync(string repository, string snapshotName, Func<DeleteSnapshotDescriptor, IDeleteSnapshotRequest> selector = null) => 
			this.Dispatcher.DispatchAsync<IDeleteSnapshotRequest, DeleteSnapshotRequestParameters, AcknowledgedResponse, IAcknowledgedResponse>(
				selector.InvokeOrDefault(new DeleteSnapshotDescriptor().Snapshot(snapshotName).Repository(repository)),
				(p, d) => this.LowLevelDispatch.SnapshotDeleteDispatchAsync<AcknowledgedResponse>(p)
			);

		/// <inheritdoc/>
		public Task<IAcknowledgedResponse> DeleteSnapshotAsync(IDeleteSnapshotRequest deleteSnapshotRequest) => 
			this.Dispatcher.DispatchAsync<IDeleteSnapshotRequest, DeleteSnapshotRequestParameters, AcknowledgedResponse, IAcknowledgedResponse>(
				deleteSnapshotRequest,
				(p, d) => this.LowLevelDispatch.SnapshotDeleteDispatchAsync<AcknowledgedResponse>(p)
			);
	}
}
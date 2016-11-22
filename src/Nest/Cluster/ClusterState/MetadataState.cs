using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	public class MetadataState
	{
		[JsonProperty("templates")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, TemplateMapping>))]
		public IDictionary<string, TemplateMapping> Templates { get; internal set; }

		[JsonProperty("cluster_uuid")]
		public string ClusterUUID { get; internal set; }

		[JsonProperty("indices")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, MetadataIndexState>))]
		public Dictionary<string, MetadataIndexState> Indices { get; internal set; }
	}
}

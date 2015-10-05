﻿using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.Cat.CatAllocation
{
	public class CatAllocationUrlTest : IUrlTest
	{
		[U] public async Task Urls()
		{
			await GET("/_cat/allocation")
				.Fluent(c => c.CatAllocation())
				.Request(c => c.CatAllocation(new CatAllocationRequest()))
				.FluentAsync(c => c.CatAllocationAsync())
				.RequestAsync(c => c.CatAllocationAsync(new CatAllocationRequest()))
				;

			await GET("/_cat/allocation/foo")
				.Fluent(c => c.CatAllocation(a => a.NodeId("foo")))
				.Request(c => c.CatAllocation(new CatAllocationRequest("foo")))
				.FluentAsync(c => c.CatAllocationAsync(a => a.NodeId("foo")))
				.RequestAsync(c => c.CatAllocationAsync(new CatAllocationRequest("foo")))
				;
		}
	}
}

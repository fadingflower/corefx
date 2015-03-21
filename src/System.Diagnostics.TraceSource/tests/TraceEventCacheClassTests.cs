﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Xunit;

namespace System.Diagnostics.TraceSourceTests
{
    public class TraceEventCacheClassTests
    {
        [Fact]
        public void DateTimeProperty()
        {
            var cache = new TraceEventCache();
            var begin = DateTime.UtcNow;
            var dt = cache.DateTime;
            var end = DateTime.UtcNow;
            Assert.True(dt >= begin);
            Assert.True(dt <= end);
            var cached = cache.DateTime;
            Assert.Equal(dt, cached);
        }

        [Fact]
        public void ProcessId()
        {
            var cache = new TraceEventCache();
            var id = cache.ProcessId;
            var expected = Interop.mincore.GetCurrentProcessId();
            Assert.Equal((int)expected, id);
        }

        [Fact]
        public void ThreadId()
        {
            var cache = new TraceEventCache();
            var id = cache.ThreadId;
            Assert.NotNull(id);
            Assert.NotEqual("", id);
        }

        [Fact]
        public void Timestamp()
        {
            var cache = new TraceEventCache();
            var dt1 = cache.Timestamp;
            var dt2 = cache.Timestamp;
            Assert.Equal(dt1, dt2);
        }
    }
}

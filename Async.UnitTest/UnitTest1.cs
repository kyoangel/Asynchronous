using System;
using System.Threading.Tasks;
using Async.Models;
using NUnit.Framework;

namespace Async.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        { }

        [Test]
        public async Task ThreadParallelRun()
        {
            var whatAspNetCoreDie = new WhatAspNetCoreDie();
            for (var i = 0; i < 1000; i++)
            {
                var bothAsync = await whatAspNetCoreDie.GetBothAsync("https://www.google.com", "https://www.google.com");

                Assert.AreEqual(bothAsync.Count, 2);
            }
        }
    }
}
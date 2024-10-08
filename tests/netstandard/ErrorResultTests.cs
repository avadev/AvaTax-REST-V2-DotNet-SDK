﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using Avalara.AvaTax.RestClient.Test.netstandard;

namespace Avalara.AvaTax.RestClient.Test.netstandard
{
    [TestFixture]
    public class ErrorResultTests : TestBase
    {
        [Test]
        public async Task NonJsonErrorResult()
        {
            AvaTaxError avataxError = null;
            try
            {
                // make a client that points to a server that will give a 404 for ping
                var client = new AvaTaxClient(GetType().Name,
                        GetType().GetTypeInfo().Assembly.ImageRuntimeVersion.ToString(),
                        Environment.MachineName, new Uri("https://www.google.com"));

                var result = await client.PingAsync().ConfigureAwait(false);
            }
            catch (AvaTaxError e)
            {
                avataxError = e;
            }

            Assert.NotNull(avataxError);
            Assert.True(avataxError.error.error.message.Contains("the response is in an unexpected format"));
            Assert.True(avataxError.error.error.details[0].description.ToLower().Contains("not found"));
        }

        [Test]
        public async Task JsonErrorResult()
        {
            AvaTaxError avataxError = null;
            try
            {
                var result = await _client.ChangePasswordAsync(new PasswordChangeModel
                {
                }).ConfigureAwait(false);
            }
            catch (AvaTaxError e)
            {
                avataxError = e;
            }

            Assert.NotNull(avataxError);
            var details = avataxError.error.error.details[0];
            var code = avataxError.error.error.code;
            Assert.True(details.description.Contains("oldPassword"));
            Assert.True(code == ErrorCodeId.ValueRequiredError);
        }
    }
}

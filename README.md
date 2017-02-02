# AvaTax-REST-V2-DotNet-SDK

This GitHub repository is the DotNet (or C#) SDK for Avalara's world-class tax service, AvaTax.  It uses the AvaTax REST v2 API, which is a fully REST implementation and provides a single client for all AvaTax functionality.  For more information about AvaTax REST v2, please visit [Avalara's Developer Network](http://developer.avalara.com/) or view the [online Swagger documentation](https://sandbox-rest.avatax.com/swagger/ui/index.html).

# Build Status

NuGet

[![NuGet](https://img.shields.io/nuget/v/Avalara.AvaTax.svg?style=plastic)](https://www.nuget.org/packages/Avalara.AvaTax/)

Travis-CI

![](https://api.travis-ci.org/avadev/AvaTax-REST-V2-DotNet-SDK.svg?branch=master&style=plastic)

# Installing the DotNet SDK

The AvaTax DotNet SDK is available on NuGet:
* Right click on a project and select `Manage NuGet Packages`
* Search for `Avalara.AvaTax`
* Click `Install` to add the latest version

A detailed walkthrough is available on the Avalara Developer Blog:
* http://developer.avalara.com/blog/2016/12/05/csharp-nuget-library/

# Using the DotNet SDK

The DotNet SDK uses a fluent interface to define a connection to AvaTax and to make API calls to calculate tax on transactions.  Here's an example of how to connect to AvaTax in C#:

```csharp
using Avalara.AvaTax.RestClient;

public class Program
{
    public void Main()
    {
        // Create a client and set up authentication
        var Client = new AvaTaxClient("MyTestApp", "1.0", Environment.MachineName, AvaTaxEnvironment.Sandbox)
            .WithSecurity("MyUsername", "MyPassword");

        // Verify that we can ping successfully
        var pingResult = Client.Ping();
        if (pingResult.authenticated) {
            Console.WriteLine("Success!");
        }

        // Create a simple transaction for $100 using the fluent transaction builder
        var transaction = new TransactionBuilder(Client, "DEFAULT", DocumentType.SalesInvoice, "ABC")
            .WithAddress(TransactionAddressType.SingleLocation, "123 Main Street", null, null, "Irvine", "CA", "92615", "US")
            .WithLine(100.0m, 1, "P0000000")
            .Create();
    }
}

```

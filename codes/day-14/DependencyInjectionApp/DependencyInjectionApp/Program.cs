using DependencyInjectionApp;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("DI in Console App...");

//creating a container (an instance of ServiceCollection)
IServiceCollection serviceContainer = new ServiceCollection();

//IInterface => service descriptor
//TImplementation => service implementation
IServiceProvider provider = serviceContainer
    .AddScoped<IDataAccessComponent, ProductDataAccessComponent>()
    .AddScoped<IBusinessComponent, ProductBusinessComponent>()
    .BuildServiceProvider();

//GetService returns the reference to the instance of the Service Implementation (class) via the Service Descriptor (interface)
//single provider can provide instances of mutiple services, that's why with GetService method mention the name of the Service Descriptor
//IDataAccessComponent? dataAccessComponent = provider.GetService<IDataAccessComponent>();

//if (dataAccessComponent != null)
//{
//    IBusinessComponent businessComponent = new ProductBusinessComponent(dataAccessComponent);

//    string data = businessComponent.FetchData();
//    Console.WriteLine(data);
//}


//the provider will resolve the dependency between ProductBusinessComponent and ProductDataAccessComponent and supply the instance of ProductDataAccessComponent to the constructor of ProductBusinessComponent, while creating instance of ProductBusinessComponent
IBusinessComponent? businessComponent = provider.GetService<IBusinessComponent>();
Console.WriteLine($"Data fetched: {businessComponent?.FetchData()}");

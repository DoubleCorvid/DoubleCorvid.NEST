using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoubleCorvid.NEST.Plugin;

public class ServiceAdapter (IServiceCollection serviceProvider) : IServiceAdapter {
    private readonly IServiceCollection _serviceProvider = serviceProvider;

    public void AddSingleton (Type serviceType) => _serviceProvider.AddSingleton (serviceType);

    public void AddSingleton (Type serviceType, Type implementationType) => _serviceProvider.AddSingleton (serviceType, implementationType);

    public void AddSingleton (Type serviceType, Func<IServiceProvider, object> implementationFactory) => _serviceProvider.AddSingleton (serviceType, implementationFactory);

    public void AddSingleton<TService> () where TService : class => _serviceProvider.AddSingleton<TService> ();

    public void AddSingleton<TService> (Func<IServiceProvider, TService> implementationFactory) where TService : class => _serviceProvider.AddSingleton<TService> (implementationFactory);

    public void AddSingleton<TService, TImplementation> () where TService : class where TImplementation : class, TService => _serviceProvider.AddSingleton<TService, TImplementation> ();

    public void AddSingleton<TService, TImplementation> (Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService  => _serviceProvider.AddSingleton<TService, TImplementation> (implementationFactory);

    public void AddScoped (Type serviceType) => _serviceProvider.AddScoped (serviceType);

    public void AddScoped (Type serviceType, Type implementationType) => _serviceProvider.AddScoped (serviceType, implementationType);

    public void AddScoped (Type serviceType, Func<IServiceProvider, object> implementationFactory) => _serviceProvider.AddScoped (serviceType, implementationFactory);

    public void AddScoped<TService> () where TService : class => _serviceProvider.AddScoped<TService> ();

    public void AddScoped<TService> (Func<IServiceProvider, TService> implementationFactory) where TService : class => _serviceProvider.AddScoped<TService> (implementationFactory);

    public void AddScoped<TService, TImplementation> () where TService : class where TImplementation : class, TService => _serviceProvider.AddScoped<TService, TImplementation> ();

    public void AddScoped<TService, TImplementation> (Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService  => _serviceProvider.AddScoped<TService, TImplementation> (implementationFactory);

    public void AddTransient (Type serviceType) => _serviceProvider.AddTransient (serviceType);

    public void AddTransient (Type serviceType, Type implementationType) => _serviceProvider.AddTransient (serviceType, implementationType);

    public void AddTransient (Type serviceType, Func<IServiceProvider, object> implementationFactory) => _serviceProvider.AddTransient (serviceType, implementationFactory);

    public void AddTransient<TService> () where TService : class => _serviceProvider.AddTransient<TService> ();

    public void AddTransient<TService> (Func<IServiceProvider, TService> implementationFactory) where TService : class => _serviceProvider.AddTransient<TService> (implementationFactory);

    public void AddTransient<TService, TImplementation> () where TService : class where TImplementation : class, TService => _serviceProvider.AddTransient<TService, TImplementation> ();

    public void AddTransient<TService, TImplementation> (Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService  => _serviceProvider.AddTransient<TService, TImplementation> (implementationFactory);

    public void AddHostedService<TService> () where TService : class, IHostedService => _serviceProvider.AddHostedService<TService> ();

    public void AddBackgroundService<TService> () where TService : BackgroundService => _serviceProvider.AddHostedService<TService> ();
}

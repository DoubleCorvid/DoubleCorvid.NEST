using Microsoft.Extensions.Hosting;

namespace DoubleCorvid.NEST.Plugin;

public interface IServiceAdapter {
    void AddSingleton (Type serviceType);

    void AddSingleton (Type serviceType, Type implementationType);

    void AddSingleton (Type serviceType, Func<IServiceProvider, object> implementationFactory);

    void AddSingleton<TService> () where TService : class;

    void AddSingleton<TService> (Func<IServiceProvider, TService> implementationFactory) where TService : class;

    void AddSingleton<TService, TImplementation> () where TService : class where TImplementation : class, TService;

    void AddSingleton<TService, TImplementation> (Func<IServiceProvider, TImplementation> serviceFactory) where TService : class where TImplementation : class, TService;

    void AddScoped (Type serviceType);

    void AddScoped (Type serviceType, Type implementationType);

    void AddScoped (Type serviceType, Func<IServiceProvider, object> implementationFactory);

    void AddScoped<TService> () where TService : class;

    void AddScoped<TService> (Func<IServiceProvider, TService> implementationFactory)  where TService : class;

    void AddScoped<TService, TImplementation> () where TService : class where TImplementation : class, TService;

    void AddScoped<TService, TImplementation> (Func<IServiceProvider, TImplementation> serviceFactory) where TService : class where TImplementation : class, TService;

    void AddTransient (Type serviceType);

    void AddTransient (Type serviceType, Func<IServiceProvider, object> implementationFactory);

    void AddTransient (Type serviceType, Type implementationType);

    void AddTransient<TService> () where TService : class;

    void AddTransient<TService> (Func<IServiceProvider, TService> implementationFactory) where TService : class;

    void AddTransient<TService, TImplementation> () where TService : class where TImplementation : class, TService;

    void AddTransient<TService, TImplementation> (Func<IServiceProvider, TImplementation> serviceFactory) where TService : class where TImplementation : class, TService;

    void AddHostedService <TService> () where TService : class, IHostedService ;

    void AddBackgroundService <TService> () where TService : BackgroundService ;
}

using Core.Utilities.Message;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Extensions
{
    public static class LanguageMessageExtensions
    {
        public static IServiceCollection AddResultMessage(this IServiceCollection services, Action<LanguageSettings> action)
        {
            using (LanguageSettings settings = new LanguageSettings())
            {
                action(settings);
                services.AddSingleton(typeof(ILanguageMessage), settings.LanguageMessage);
                return services;
            }
        }
    }
    public sealed class LanguageSettings : IDisposable
    {
        public ILanguageMessage LanguageMessage { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

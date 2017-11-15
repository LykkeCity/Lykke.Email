using System;
using JetBrains.Annotations;

namespace Lykke.Email
{
    /// <summary>
    /// Creates IEmailCommand&lt;<typeparamref name="TModel"/>&gt; for further setup and sending
    /// </summary>
    /// <typeparam name="TModel">Mesage model type</typeparam>
    public interface IEmailCommandFactory<TModel> : IDisposable
    {
        /// <summary>
        /// Create a new IEmailCommand&lt;<typeparamref name="TModel"/>&gt;
        /// </summary>
        /// <param name="model">Data model to use during email message formatting</param>
        /// <param name="partnerId">Sender partner ID (e.g. "Lykke" or "AlpineVault")</param>
        /// <returns>A new instance of IEmailCommand&lt;<typeparamref name="TModel"/>&gt;</returns>
        [NotNull] IEmailCommand<TModel> Create([NotNull] TModel model, [NotNull] string partnerId);
    }
}

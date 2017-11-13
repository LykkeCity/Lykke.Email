using System;
using JetBrains.Annotations;

namespace Lykke.Email
{
    /// <summary>
    /// Creates IEmailMessage&lt;<typeparamref name="TModel"/>&gt; for further setup and sending
    /// </summary>
    /// <typeparam name="TModel">Mesage model type</typeparam>
    public interface IEmailMessageFactory<TModel> : IDisposable
    {
        /// <summary>
        /// Create a new IEmailMessage&lt;<typeparamref name="TModel"/>&gt;
        /// </summary>
        /// <param name="model">Data model to use during email message formatting</param>
        /// <param name="partnerId">Sender partner ID (e.g. "Lykke" or "AlpineVault")</param>
        /// <returns>A new instance of IEmailMessage&lt;<typeparamref name="TModel"/>&gt;</returns>
        [NotNull] IEmailMessage<TModel> Create([NotNull] TModel model, [NotNull] string partnerId);
    }
}

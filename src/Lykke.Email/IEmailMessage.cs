using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Lykke.Email
{
    /// <summary>
    /// Email message
    /// </summary>
    /// <typeparam name="TModel">Email message model type</typeparam>
    /// <remarks>Email message acquires sending logic from factory. Make sure to dispose email message after sending to release sending logic</remarks>
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IEmailMessage<TModel> : IDisposable
    {
        /// <summary>
        /// Add text attachment
        /// </summary>
        /// <param name="name">Attachment name (e.g. "smile.txt")</param>
        /// <param name="text">Attachment content text</param>
        /// <param name="contentType">Attachment content type (e.g. "text/plain", "text/csv", "text/xml" or "application/json")</param>
        /// <returns>Same instance</returns>
        /// <remarks>UTF-8 encoding is always used. For text documents containing inner encoding declaration (like XML) use UTF-8 to avoid compatibility issues</remarks>
        [NotNull] IEmailMessage<TModel> AddTextAttachment([NotNull] string name, [NotNull] string text, [NotNull] string contentType = "text/plain");

        /// <summary>
        /// Add binary attachment
        /// </summary>
        /// <param name="name">Attachment name (e.g. "smile.jpg")</param>
        /// <param name="data">Binary array with attachment data</param>
        /// <param name="contentType">Attachment content type (e.g. "application/octet-stream", "image/jpeg")</param>
        /// <returns>Same instance</returns>
        [NotNull] IEmailMessage<TModel> AddBinaryAttachment([NotNull] string name, [NotNull] byte[] data, [NotNull] string contentType = "application/octet-stream");

        /// <summary>
        /// Add broadcast group as a recipient
        /// </summary>
        /// <param name="broadcastGroup">Broadcast group that should receive curent message</param>
        /// <returns>Same instance</returns>
        [NotNull] IEmailMessage<TModel> AddRecipient(BroadcastGroup broadcastGroup);

        /// <summary>
        /// Add client recipient by email and display name
        /// </summary>
        /// <param name="emailEddress">Client email address</param>
        /// <param name="displayName">Client display name</param>
        /// <param name="type">Client is added to "To" section by default but alternatively can be added to "Cc" or "Bcc"</param>
        /// <returns>Same instance</returns>
        [NotNull] IEmailMessage<TModel> AddRecipient([NotNull] string emailEddress, string displayName = null, RecipientPosition type = RecipientPosition.To);

        /// <summary>
        /// Send email message
        /// </summary>
        /// <returns>Same instance</returns>
        /// <exception cref="ObjectDisposedException">Message cannot be send after being disposed as the sending logic was released during dispose</exception>
        [NotNull] Task<IEmailMessage<TModel>> SendAsync();
    }
}

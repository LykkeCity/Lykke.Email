namespace Lykke.Email
{
    /// <summary>
    /// Position of current recipient in email message recipient list
    /// </summary>
    public enum RecipientPosition
    {
        /// <summary>
        /// Recipient is in "To"
        /// </summary>
        To,

        /// <summary>
        /// Recipient is in "Cc"
        /// </summary>
        Cc,

        /// <summary>
        /// Recipient is in "Bcc"
        /// </summary>
        Bcc
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Lykke.Email
{
    /// <summary>
    /// Mark current type as email message model
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class EmailMessageModelAttribute : Attribute
    {
        /// <summary>
        /// Template to use when formatting email message from current model
        /// </summary>
        [NotNull]
        public string TemplateName { get; }

        /// <summary>
        /// Mark current type as email message model
        /// </summary>
        /// <param name="templateName">Template to use when formatting email message from current model</param>
        public EmailMessageModelAttribute([NotNull] string templateName)
        {
            if (string.IsNullOrWhiteSpace(templateName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(templateName));

            TemplateName = templateName;
        }
    }
}

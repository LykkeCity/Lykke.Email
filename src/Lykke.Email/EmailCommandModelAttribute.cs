using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Lykke.Email
{
    /// <summary>
    /// Mark current type as email command model
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class EmailCommandModelAttribute : Attribute
    {
        /// <summary>
        /// Template to use when formatting email command from current model
        /// </summary>
        [NotNull]
        public string TemplateName { get; }

        /// <summary>
        /// Mark current type as email command model
        /// </summary>
        /// <param name="templateName">Template to use when formatting email command from current model</param>
        public EmailCommandModelAttribute([NotNull] string templateName)
        {
            if (string.IsNullOrWhiteSpace(templateName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(templateName));

            TemplateName = templateName;
        }
    }
}

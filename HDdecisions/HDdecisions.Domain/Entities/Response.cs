using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace HDdecisions.Domain.Entities
{
    /// <summary>
    /// Possible suggested credit cards for applicants
    /// </summary>
    public enum Response
    {
        [Description("No card recommended")]
        None = 0,
        [Description("No Cards Available")]
        NoCardsAvailable = 1,
        [Description("Barclaycard")]
        Barclaycard = 2,
        [Description("Vanquis Card")]
        Vanquis = 3
    }

    /// <summary>
    /// Response Extension class
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Maps Responses to location of images
        /// </summary>
        private static readonly IDictionary<Response, string> ResponseImageUrls = new Dictionary<Response, string> { 
        { Response.None, string.Empty }, 
        { Response.NoCardsAvailable, string.Empty }, 
        { Response.Barclaycard, @"~/Content/images/Barclaycard.jpg" },
        { Response.Vanquis, @"~/Content/images/Vanquis.png" }};

        /// <summary>
        /// Gets image URL for Response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static string GetUrl(this Response response)
        {
            string url;
            ResponseImageUrls.TryGetValue(response, out url);
            return url ?? string.Empty;
        }

        /// <summary>
        /// Gets a display name for response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static string GetDescription(this Response response)
        {
            FieldInfo field = response.GetType().GetField(response.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? response.ToString() : attribute.Description;
        }
    }
}

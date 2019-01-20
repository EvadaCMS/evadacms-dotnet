using System;

namespace Evada.Core.Http
{
    public class RateLimit
    {
        /// <summary>
        /// The maximum number of requests the consumer is allowed to make.
        /// </summary>
        public long Limit { get; internal set; }

        /// <summary>
        /// The number of requests remaining in the current rate limit window.
        /// </summary>
        public long Remaining { get; internal set; }

        /// <summary>
        /// The date and time offset at which the current rate limit window is reset.
        /// </summary>
        public DateTimeOffset Reset { get; internal set; }
    }
}

﻿using System;
using System.Net;

namespace Evada.Exceptions
{
    /// <summary>
    /// Represents errors that occur when making API calls.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        ///     The exception payload from the response
        /// </summary>
        public ApiError ApiError { get; private set; }

        /// <summary>
        ///     The HTTP status code associated with the repsonse
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        public ApiException(HttpStatusCode statusCode)
            : base(statusCode.ToString())
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="apiError">The API error.</param>
        public ApiException(HttpStatusCode statusCode, ApiError apiError)
            : base(apiError == null ? statusCode.ToString() : apiError.Detail)
        {
            StatusCode = statusCode;
            ApiError = apiError;
        }

        public ApiException() : base()
        {
        }

        public ApiException(string message) : base(message)
        {
        }
    }
}

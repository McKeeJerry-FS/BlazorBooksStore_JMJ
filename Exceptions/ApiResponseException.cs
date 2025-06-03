using System;
using BlazorBooksStore.Models;

namespace BlazorBooksStore.Exceptions;

public class ApiResponseException : Exception
{
  public ApiErrorResponse? ErrorDetails { get; set; }

  public ApiResponseException(ApiErrorResponse errorDetails) : base(errorDetails.Message)
  {
    ErrorDetails = errorDetails;
  }
}

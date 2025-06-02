using System;
using BlazorBooksStore.Services.Interfaces;

namespace BlazorBooksStore;

public class DemoLoggingHandler : DelegatingHandler
{
  private readonly ILogger<DemoLoggingHandler> _logger;
  public DemoLoggingHandler(ILogger<DemoLoggingHandler> logger)
  {
    _logger = logger;
  }

  protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Sending request to {Url}", request.RequestUri);
    
    var response = await base.SendAsync(request, cancellationToken);
    
    _logger.LogInformation("Received response with status code {StatusCode} from {Url}", response.StatusCode, request.RequestUri);
    
    return response;
  }
  
}

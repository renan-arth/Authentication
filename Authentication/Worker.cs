using Authentication.Request;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Authentication
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpListener _listener;
        private readonly HttpRequestHandler _requestHandler;

        public Worker(ILogger<Worker> logger, HttpRequestHandler requestHandler)
        {
            _logger = logger;
            _requestHandler = requestHandler;
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:5000/ValidateToken/");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _listener.Start();
            _logger.LogInformation("Listening on http://localhost:5000/ValidateToken/");

            while (!stoppingToken.IsCancellationRequested)
            {
                var context = await _listener.GetContextAsync();
                await _requestHandler.HandleAsync(context);
            }

            _listener.Stop();
        }
    }
}

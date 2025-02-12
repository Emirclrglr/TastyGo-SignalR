namespace SignalR.UI.ApiConfig
{
    public class ApiConfig : IApiConfig
    {
        private readonly IConfiguration _configuration;

        public ApiConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string BaseUrl => _configuration.GetSection("ApiConfig")["BaseUrl"];
    }
}

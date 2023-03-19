namespace EventAPI
{
    public class AuthServerSettings
    {
        private static readonly IConfigurationRoot config = new ConfigurationManager().AddJsonFile("appsettings.json").Build();

        public static string? GetAddress()
        {
            var address = config.GetValue<string>("Address");
            return address;
        }

        public static string? GetAuthority()
        {
            var authority = config.GetValue<string>("Authority");
            return authority;
        }

        public static string? GetAudience()
        {
            var audience = config.GetValue<string>("Audience");
            return audience;
        }
    }
}

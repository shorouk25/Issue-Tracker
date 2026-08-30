namespace IssueTracker.Infrastructure.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTimeInMinutes { get; set; }
        public string SecretKey { get; set; }
    }
}

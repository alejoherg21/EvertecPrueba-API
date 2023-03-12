namespace Service.Jwt
{
    public class JwtParams
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}

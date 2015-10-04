
namespace JWTDemo
{
    public class JWTHeader
    {
        public JWTHeader()
        {
            this.typ = "JWT";
        }

        public string typ { get; set; }

        public string alg { get { return "HS256"; } }
    }
}
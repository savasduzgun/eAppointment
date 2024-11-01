using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eAppointmentServer.Infrastructure.Services
{
    internal sealed class JwtProvider : IJwtProvider
    {
        public string CreateToken(AppUser user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty), //email null gelirse boş gönder. Identity de email zorunlu olmadığı için hata vermesin diye eklendi. ?? null kontrolü
                new Claim("UserName", user.UserName ?? string.Empty) //ClaimTypes kullanmadan da verilebilir.
            };

            DateTime expires = DateTime.Now.AddDays(1); // 1 günlük token

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(string.Join("-", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid())));
            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha512);

            JwtSecurityToken securityToken = new(
                issuer: "Savaş Düzgün", //uygulama kim taradından oluşturuldu
                audience: "eAppointment",//kim kullanacak, kişi adı site adı vb. birden fazla yazılabilir
                claims: claims, //oluşan jwt içerisine body olarak birden fazla değer eklenebilir, bu token ı kullanan kişi o body deki değerleri okuyarak gönderilen değerleri kullanabilir
                notBefore: DateTime.Now, //uygulamanın oluşturacağı tokenı ne zamandan sonra kullanacağını söyler. server arasıdnaki fark veya gönderilen uygulama ve bilgisayar arasında fark olabilir diye ileri veya geriye dönük verilebilir. Datetime.now ile Oluştuğu andan itibaren kullanılabilir
                expires: expires, //token ne zaman sonlanacak
                signingCredentials: signingCredentials); //Uygulamanın şifrelenecek anahtarını şifreleme türünü vs. ister

            JwtSecurityTokenHandler handler = new();

            string token = handler.WriteToken(securityToken); //token üretme
            return token;
        }
    }
}

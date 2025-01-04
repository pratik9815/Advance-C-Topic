using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
					
public class JwtProgram
{
  // one of the most common ways for authentication is using jwt token
  // here we have created a token for validating user and roles 
  // we have used 2 packages here one is microsoft.identitymodel.tokens and another is system.identitymodel.tokens.jwt
  // this program creates a jwt token from the given security key using claims
	//public static void Main()
	//{
	//	Console.WriteLine(GetToken());
	//}
	public static string GetToken()
	{
		var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your 256 bit security key"));
		var signIn = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);
		DateTime expires = DateTime.UtcNow.AddMinutes(60);
		var claims = new List<Claim>{
			new Claim(JwtRegisteredClaimNames.Sub, "your subject"),
			new Claim(ClaimTypes.Name, "Username"),
			new Claim("Username","Your username"),
		};
		// you can add additional things in the user claim such as roles of the user and what things can he access 
		var securityToken = new JwtSecurityToken(
			"yourissuer.com",
			"youraudience.com",
			claims,
			expires,
			signingCredentials: signIn
		);
		
		JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
		var token = handler.WriteToken(securityToken);
		return token;
	}
}

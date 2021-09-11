using System;
using System.Security.Cryptography;
using System.Text;

namespace Task_3_Game.Data
{
	public class Encryptor
	{
		private HMACSHA512 _hmac;
		private byte[] _secretKey = new byte[16];

		private byte[] GenerateRandomKey()
		{
			byte[] secretKey = new byte[16];
			using (var random = RandomNumberGenerator.Create())
			{
				random.GetBytes(secretKey);
			}
			return secretKey;
		}

		public void CreatreHmac(string message)
		{
			_secretKey = GenerateRandomKey();
			_hmac?.Dispose();
			_hmac = new HMACSHA512(_secretKey);
			_hmac.ComputeHash(Encoding.ASCII.GetBytes(message));
		}

		public string GetHmacKey()
		{
			return BitConverter.ToString(_hmac.Key).Replace("-", "");
		}

		public string GetHmacHash()
		{
			return BitConverter.ToString(_hmac.Hash).Replace("-", "");
		}
	}
}

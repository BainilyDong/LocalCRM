using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CRM.Core
{
    public class Utils
    {
		public static XmlDocument GetXmlConfigFile(string organizationName = null)
		{
			string text = "C:/CRMConfig/";
			string text2 = ConfigurationManager.AppSettings["CRMConfig"];
			string hostName = Dns.GetHostName();
			bool flag = !string.IsNullOrEmpty(text2);
			string filename;
			if (flag)
			{
				filename = text2;
			}
			else
			{
				bool flag2 = !string.IsNullOrEmpty(organizationName);
				if (flag2)
				{
					filename = string.Concat(new string[]
					{
						text,
						hostName,
						"/",
						organizationName,
						".xml"
					});
				}
				else
				{
					filename = text + "CRMConfig.xml";
				}
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(filename);
			return xmlDocument;
		}
		public static string GetConfigValue(XmlDocument xmlDoc, string itemName)
		{
			string result;
			try
			{
				XmlNode xmlNode = xmlDoc.SelectSingleNode("/CRMExtensionConfig/ConfigList");
				foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
				{
					bool flag = xmlNode2.Name == itemName;
					if (flag)
					{
						result = xmlNode2.InnerText.Trim();
						return result;
					}
				}
				result = "";
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public static string DecryptDes(string decryptString)
		{
			string result;
			try
			{
				byte[] encryptKeys = Utils.EncryptKeys;
				byte[] keys = Utils.Keys;
				byte[] array = Convert.FromBase64String(decryptString);
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(encryptKeys, keys), CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				result = Encoding.UTF8.GetString(memoryStream.ToArray());
			}
			catch
			{
				result = decryptString;
			}
			return result;
		}
		private static readonly byte[] Keys = new byte[]
		{
			76,
			90,
			84,
			88,
			68,
			73,
			72,
			72
		};
		private static readonly byte[] EncryptKeys = new byte[]
		{
			66,
			87,
			87,
			78,
			88,
			71,
			80,
			68
		};
	}
}

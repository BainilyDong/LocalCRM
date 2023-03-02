using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CRM.Core
{
    public class CrmOrganization
    {
		public static IServiceManagement<IOrganizationService> sm;
		public static IOrganizationService organizationServiceProxy;
		public static IOrganizationService GetService(string organizationName = null, Guid? callerId = null)
		{
			XmlDocument xmlConfigFile = Utils.GetXmlConfigFile(organizationName);
			string configValue = Utils.GetConfigValue(xmlConfigFile, "Domain");
			string configValue2 = Utils.GetConfigValue(xmlConfigFile, "UserName");
			//string password = Utils.DecryptDes(Utils.GetConfigValue(xmlConfigFile, "PassWord"));//密文
			string password = Utils.GetConfigValue(xmlConfigFile, "PassWord");
			string configValue3 = Utils.GetConfigValue(xmlConfigFile, "DiscoveryUri");
			string configValue4 = Utils.GetConfigValue(xmlConfigFile, "OrganizationUri");
			string configValue5 = Utils.GetConfigValue(xmlConfigFile, "IFD");
			string key = "sm";
			string key2 = "dis";
			bool flag = configValue5 == "true";
			IOrganizationService result;
			if (flag)
			{
				Uri serviceUri = new Uri(configValue4);
				Uri serviceUri2 = new Uri(configValue3);
				bool flag2 = MemeryCacheUtil.ContainsKey(key);
				if (flag2)
				{
					CrmOrganization.sm = MemeryCacheUtil.GetCache<IServiceManagement<IOrganizationService>>(key);
				}
				else
				{
					CrmOrganization.sm = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(serviceUri);
					MemeryCacheUtil.SetCache(key, CrmOrganization.sm, 300);
				}
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CrmOrganization.AcceptAllCertificatePolicy);
				ClientCredentials clientCredentials = new ClientCredentials();
				clientCredentials.UserName.UserName = configValue + "\\" + configValue2;
				clientCredentials.UserName.Password = password;
				bool flag3 = MemeryCacheUtil.ContainsKey(key2);
				IServiceConfiguration<IDiscoveryService> serviceConfiguration;
				if (flag3)
				{
					serviceConfiguration = MemeryCacheUtil.GetCache<IServiceConfiguration<IDiscoveryService>>(key2);
				}
				else
				{
					serviceConfiguration = ServiceConfigurationFactory.CreateConfiguration<IDiscoveryService>(serviceUri2);
					MemeryCacheUtil.SetCache(key2, serviceConfiguration, 300);
				}
				SecurityTokenResponse securityTokenResponse = serviceConfiguration.Authenticate(clientCredentials);
				OrganizationServiceProxy organizationServiceProxy = new OrganizationServiceProxy(CrmOrganization.sm, securityTokenResponse);
				organizationServiceProxy.EnableProxyTypes();
				bool hasValue = callerId.HasValue;
				if (hasValue)
				{
					organizationServiceProxy.CallerId = callerId.Value;
				}
				CrmOrganization.organizationServiceProxy = organizationServiceProxy;
				result = CrmOrganization.organizationServiceProxy;
			}
			else
			{
				bool flag4 = configValue5 == "false";
				if (flag4)
				{
					CrmOrganization.sm = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(new Uri(configValue4));
					ClientCredentials clientCredentials2 = new ClientCredentials();
					clientCredentials2.Windows.ClientCredential = new NetworkCredential(configValue2, password, configValue);
					OrganizationServiceProxy organizationServiceProxy2 = new OrganizationServiceProxy(CrmOrganization.sm, clientCredentials2);
					bool hasValue2 = callerId.HasValue;
					if (hasValue2)
					{
						organizationServiceProxy2.CallerId = callerId.Value;
					}
					CrmOrganization.organizationServiceProxy = organizationServiceProxy2;
				}
				result = CrmOrganization.organizationServiceProxy;
			}
			return result;
		}
		private static bool AcceptAllCertificatePolicy(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}
	}

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace BaseProject.BaseClass {
    public class ProgramSettings {
        public const string ConfigFileName = "BaseProjectConfig.xml";
        private readonly string _configDirectory;
        private const string MainNode = "Settings";

        #region Constructor
        public ProgramSettings() {
            _configDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
            InitializeProgramSettings();
        }
        #endregion

        #region Properties
        public string Username {
            get {
                return CLoadSettings(ConfigFileName, MainNode, "Username", "root");
            }
            set {
                CSaveSettings(ConfigFileName, MainNode, "Username", value);
            }
        }
        public string Password {
            get {
                return CLoadSettings(ConfigFileName,MainNode, "Password", "");
            }
            set {
                CSaveSettings(ConfigFileName, MainNode, "Password", value);
            }
        }
        public string Host {
            get {
                return CLoadSettings(ConfigFileName, MainNode, "Host", "localhost");
            }
            set {
                CSaveSettings(ConfigFileName, MainNode, "Host", value);
            }
        }
        public string Database {
            get {
                return CLoadSettings(ConfigFileName, MainNode, "Database", "BaseProject");
            }
            set {
                CSaveSettings(ConfigFileName, MainNode, "Database", value);
            }
        }
        public string Port {
            get {
                return CLoadSettings(ConfigFileName, MainNode, "Port", "3306");
            }
            set {
                CSaveSettings(ConfigFileName, MainNode, "Port", value);
            }
        }
        #endregion

        #region Initialization
        private void InitializeProgramSettings() {
            if (!Directory.Exists(_configDirectory)) {
                Directory.CreateDirectory(_configDirectory);
            }
            string configPath = GetConfigPath(ConfigFileName);
            if (!File.Exists(configPath)) {
                CreateXml("BaseProject", configPath);
                InitializeProgramSettingsValues();
            }
        }
        private void InitializeProgramSettingsValues() {
            CSaveSettings(ConfigFileName, MainNode, "Username", "root");
            CSaveSettings(ConfigFileName, MainNode, "Password", "");
            CSaveSettings(ConfigFileName, MainNode, "Host", "localhost");
            CSaveSettings(ConfigFileName, MainNode, "Database", "BaseProject");
            CSaveSettings(ConfigFileName, MainNode, "Port", "3306");
        }
        #endregion

        #region XML Handling
        private XmlElement GetXmlElement(XmlDocument xmlDoc, string name, string value) {
            XmlElement element = xmlDoc.CreateElement(name);
            element.InnerText = value;
            return element;
        }
        private void CreateXml(string rootName, string filePath) {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement(rootName);
            xmlDoc.AppendChild(root);
            xmlDoc.Save(filePath);
        }
        private string GetConfigPath(string configName) {
            return Path.Combine(_configDirectory, configName);
        }
        #endregion

        #region Save Settings
        public void CSaveSettings(string configName, string main, string name, string value) {
            string configPath = GetConfigPath(configName);
            if (!File.Exists(configPath)) {
                CreateXml("BaseProject", configPath);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configPath);
            XmlNode documentElement = xmlDoc.DocumentElement;
            foreach (XmlNode childNode in documentElement.ChildNodes) {
                if (childNode.Name != main) {
                    continue;
                }
                foreach (XmlNode settingNode in childNode.ChildNodes) {
                    if (settingNode.Name == name) {
                        settingNode.InnerText = value ?? "";
                        xmlDoc.Save(configPath);
                        return;
                    }
                }
                childNode.AppendChild(GetXmlElement(xmlDoc, name, value ?? ""));
                xmlDoc.Save(configPath);
                return;
            }
            XmlElement mainElement = GetXmlElement(xmlDoc, main, "");
            documentElement.AppendChild(mainElement);
            mainElement.AppendChild(GetXmlElement(xmlDoc, name, value ?? ""));
            xmlDoc.Save(configPath);
        }
        #endregion

        #region Load Settings
        public string CLoadSettings(string configName, string main, string name, string defaultValue) {
            string configPath = GetConfigPath(configName);
            if (File.Exists(configPath)) {
                try {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(configPath);
                    XmlNode documentElement = xmlDoc.DocumentElement;

                    foreach (XmlNode childNode in documentElement.ChildNodes) {
                        if (childNode.Name != main) {
                            continue;
                        }
                        foreach (XmlNode settingNode in childNode.ChildNodes) {
                            if (settingNode.Name == name) {
                                return settingNode.InnerText;
                            }
                        }
                    }
                }
                catch (XmlException) {
                    File.Delete(configPath);
                    InitializeProgramSettings();
                }
            }
            CSaveSettings(configName, main, name, defaultValue);
            return defaultValue;
        }
        #endregion
    }
}

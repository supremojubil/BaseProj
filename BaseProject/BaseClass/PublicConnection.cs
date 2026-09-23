using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.BaseClass {
    public class PublicConnection {

        private enum SettingsFields {
            Username,
            Password,
            Host,
            Database,
            Port
        }
        public static bool IsOnline;
        public static List<string> ErrorIP;
        public static string m_EntityModel;
        public static string m_ConnectionString;
        public static string m_ConnectionStringEntity;
        private const string _ConfigName = "Connect.xml";
        private const string _MainNode = "Settings";
        private ProgramSettings m_Settings = new ProgramSettings();

        #region Connection Properties
        public string Username {
            get {
                string sDefaultValue = EncryptValue("root");
                string value = m_Settings.CLoadSettings("Connect.xml", "Settings", SettingsFields.Password.ToString(), "");
                return DecryptValue(value);
            }
            set {
                string sValue = EncryptValue(value);
                m_Settings.CSaveSettings(_ConfigName, _MainNode, SettingsFields.Username.ToString(), sValue);
            }
        }
        public string Password {
            get {
                string sDefaultValue = EncryptValue("");
                string value = m_Settings.CLoadSettings(_ConfigName, _MainNode, SettingsFields.Password.ToString(), sDefaultValue);
                return DecryptValue(value);
            }
            set {
                string sValue = EncryptValue(value);
                m_Settings.CSaveSettings(_ConfigName, _MainNode, SettingsFields.Password.ToString(), sValue);
            }
        }
        public string Host {
            get {
                string sDefaultValue = EncryptValue("localhost");
                string value = m_Settings.CLoadSettings(_ConfigName, _MainNode, SettingsFields.Host.ToString(), sDefaultValue);
                return DecryptValue(value);
            }
            set {
                string sValue = EncryptValue(value);
                m_Settings.CSaveSettings(_ConfigName, _MainNode, SettingsFields.Host.ToString(), sValue);
            }
        }
        public string Database {
            get {
                string sDefaultValue = EncryptValue("myDB");
                string value = m_Settings.CLoadSettings(_ConfigName, _MainNode, SettingsFields.Database.ToString(), sDefaultValue);
                return DecryptValue(value);
            }
            set {
                string sValue = EncryptValue(value);
                m_Settings.CSaveSettings(_ConfigName, _MainNode, SettingsFields.Database.ToString(), sValue);
            }
        }
        public string Port {
            get {
                string sDefaultValue = EncryptValue("3306");
                string value = m_Settings.CLoadSettings(_ConfigName, _MainNode, SettingsFields.Port.ToString(), sDefaultValue);
                return DecryptValue(value);
            }
            set {
                string sValue = EncryptValue(value);
                m_Settings.CSaveSettings(_ConfigName, _MainNode, SettingsFields.Port.ToString(), sValue);
            }
        }
        #endregion

        #region Connection Information
        public string ConnectionString {
            get {
                if (!IsOnline) {
                    return "Local Connection";
                }
                return "Online Connection";
            }
        }
        #endregion

        #region Connection Strings
        public static void SetConnectionString(string DataSource, string Database, string PORT) {
            if (ValidateIPRestriction(DataSource)) {
                m_ConnectionString = new MySqlConnectionStringBuilder {
                    Database = Database,
                    Port = Convert.ToUInt32(PORT),
                    ConnectionTimeout = 5,
                    DefaultCommandTimeout = 20,
                    Server = DataSource,
                    UserID = "root",
                    Password = "",
                    ConvertZeroDateTime = true,
                    SslMode = MySqlSslMode.Disabled
                }.ConnectionString;
            }
        }
        public static void SetConnectionString(string username, string password, string DataSource, string Database, string PORT) {
            if (ValidateIPRestriction(DataSource)) {
                m_ConnectionString = new MySqlConnectionStringBuilder {
                    Database = Database,
                    Port = Convert.ToUInt32(PORT),
                    ConnectionTimeout = 180,
                    DefaultCommandTimeout = 120,
                    Server = DataSource,
                    UserID = username,
                    Password = password,
                    ConvertZeroDateTime = true,
                    SslMode = MySqlSslMode.Disabled
                }.ConnectionString;
            }
        }
        #endregion

        #region Entity Connection Strings
        public static string CreateConnectionStringEntity(string EntityModel, string DataSource, string Database, string PORT, string Id, string pass) {
            if (!ValidateIPRestriction(DataSource)) {
                return string.Empty;
            }
            string providerConnectionString = new MySqlConnectionStringBuilder {
                Database = Database,
                Port = Convert.ToUInt32(PORT),
                ConnectionTimeout = 180,
                DefaultCommandTimeout = 120,
                Server = DataSource,
                UserID = Id,
                Password = pass,
                ConvertZeroDateTime = true,
                SslMode = MySqlSslMode.Disabled
            }.ConnectionString;
            return string.Format("metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;" +
                "provider=MySql.Data.MySqlClient;" +
                "provider connection string=\"{1}\"",
                EntityModel,
                providerConnectionString);
        }
        public static void SetConnectionStringEntity(string DataSource, string Database, string PORT) {
            m_ConnectionStringEntity = CreateConnectionStringEntity(m_EntityModel, DataSource, Database, PORT, "root", "");
        }
        public static void SetConnectionStringEntity(string username, string password, string DataSource, string Database, string PORT) {
            m_ConnectionStringEntity = CreateConnectionStringEntity(m_EntityModel, DataSource, Database, PORT, username, password);
        }
        #endregion

        #region Default Connection
        public static void SetDefaultConnectionString() {
            PublicConnection connection = new PublicConnection();
            SetConnectionString(connection.Username, connection.Password, connection.Host, connection.Database, connection.Port);
        }
        public static void SetDefaultConnectionStringEntity() {
            PublicConnection connection = new PublicConnection();
            SetConnectionStringEntity(connection.Username, connection.Password, connection.Host, connection.Database, connection.Port);
        }
        public static string ConnectionStringEntity(string MappingModel) {
            return string.Format("metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;" +
                "provider=MySql.Data.MySqlClient;" +
                "provider connection string=\"{1}\"",
                MappingModel,
                m_ConnectionString);
        }
        #endregion

        #region Connection Validation
        private static bool ValidateIPRestriction(string DataSource) {
            if (ErrorIP == null) {
                ErrorIP = new List<string>();
            }
            foreach (string item in ErrorIP) {
                if (item == DataSource) {
                    throw new Exception("Connection to the database is restricted for this IP address.");
                }
            }
            return true;
        }
        public static bool Ping() {
            if (string.IsNullOrEmpty(m_ConnectionString)) {
                return false;
            }
            using (MySqlConnection mySlqConnection = new MySqlConnection(m_ConnectionString)) {
                try {
                    if (mySlqConnection.State != ConnectionState.Open) {
                        mySlqConnection.Open();
                    }
                    return mySlqConnection.Ping();
                }
                catch {
                    return false;
                }
                finally {
                    mySlqConnection.Close();
                }
            }
        }
        #endregion
        #region Encryption

        private string EncryptValue(string value) {
            if (string.IsNullOrEmpty(value)) {
                return value;
            }
            byte[] data = Encoding.UTF8.GetBytes(value);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encrypted);
        }

        private string DecryptValue(string value) {
            if (string.IsNullOrEmpty(value)) {
                return value;
            }

            try {
                byte[] encrypted = Convert.FromBase64String(value);
                byte[] decrypted = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(decrypted);
            }
            catch (CryptographicException) {
                return string.Empty;
            }
            catch (FormatException) {
                return string.Empty;
            }
        }

        #endregion
    }
}

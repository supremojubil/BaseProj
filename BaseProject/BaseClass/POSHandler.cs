using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.BaseClass {
    public class POSHandler {
        private enum SettingsFields {
            Header1,
            Header2,
            Footer1,
            Footer2,
            IsPOS,
            POSPrinter,
            AutoCut
        }
        public enum Alignment {
            Left,
            Center,
            Right,
        }
        private readonly ProgramSettings m_Settings = new ProgramSettings();
        private const string ConfigName = "Company.xml";
        private const string MainNode = "POSSettings";

        #region POS Settings
        public bool AutoCut {
            get {
                return bool.Parse(m_Settings.CLoadSettings(ConfigName, MainNode, SettingsFields.AutoCut.ToString(), true.ToString()));
            }
            set {
                m_Settings.CSaveSettings(ConfigName, MainNode, SettingsFields.AutoCut.ToString(), value.ToString());
            }
        }
        public string Header1 {
            get {
                return m_Settings.CLoadSettings(ConfigName, MainNode, SettingsFields.Header1.ToString(), "Header 1");
            }
            set {
                m_Settings.CSaveSettings(ConfigName, MainNode, SettingsFields.Header1.ToString(), value);
            }
        }
        public string Header2 {
            get {
                return m_Settings.CLoadSettings(ConfigName, MainNode, SettingsFields.Header2.ToString(), "Header 2");
            }
            set {
                m_Settings.CSaveSettings(ConfigName, MainNode, SettingsFields.Header2.ToString(), value);
            }
        }

        public string Footer1 {
            get {
                return m_Settings.CLoadSettings(ConfigName, MainNode, SettingsFields.Footer1.ToString(), "Footer 1");
            }
            set {
                m_Settings.CSaveSettings(ConfigName, MainNode, SettingsFields.Footer1.ToString(), value);
            }
        }

        public string Footer2 {
            get {
                return m_Settings.CLoadSettings(ConfigName, MainNode, SettingsFields.Footer2.ToString(), "Footer 2");
            }
            set {
                m_Settings.CSaveSettings(ConfigName, MainNode, SettingsFields.Footer2.ToString(), value);
            }
        }

        public bool IsPOS {
            get {
                return bool.Parse(m_Settings.CLoadSettings(ConfigName, MainNode, SettingsFields.IsPOS.ToString(), false.ToString()));
            }
            set {
                m_Settings.CSaveSettings(ConfigName, MainNode, SettingsFields.IsPOS.ToString(), value.ToString());
            }
        }

        public string POSPrinter {
            get {
                return m_Settings.CLoadSettings(ConfigName, MainNode, SettingsFields.POSPrinter.ToString(), "Select a printer");
            }
            set {
                m_Settings.CSaveSettings(ConfigName, MainNode, SettingsFields.POSPrinter.ToString(), value);
            }
        }
        #endregion
        #region Message Formatting

        public static string AppendMessage(string message) {
            return message + "\n\r";
        }

        public static string AppendLine() {
            return "\n\r";
        }

        #endregion

        #region VAT

        public static decimal GetVatAmount(decimal netAmount) {
            return netAmount / 9.3333333m;
        }

        public static decimal GetVatableSales(decimal netAmount) {
            return netAmount - GetVatAmount(netAmount);
        }

        #endregion

        #region Append Items

        public static string AppendItems(decimal quantity, string description) {
            return InsertSpaceAndItem(quantity.ToCurrency(), 10, 40, description) + AppendLine();
        }

        public static string AppendItems(string description, decimal quantity, decimal price, decimal amount) {
            string quantityText;
            if (quantity % 1m == 0m) {
                quantityText = Convert.ToInt32(quantity).ToString();
            }
            else {
                quantityText = quantity.ToString("n2");
            }

            string priceText = price.ToCurrency();
            string amountText = amount.ToCurrency();
            string itemMessage = "";

            if (description.Length <= 12) {
                itemMessage = description;
                itemMessage = InsertSpaceAndItem(itemMessage, description.Length, 18, quantityText);
                itemMessage = InsertSpaceAndItem(itemMessage, 18, 28, priceText);
                return InsertSpaceAndItem(itemMessage, 28, 40, amountText);
            }
            itemMessage = AppendMessage(description);
            itemMessage = InsertSpaceAndItem(itemMessage, 0, 18, quantityText);
            itemMessage = InsertSpaceAndItem(itemMessage, 18, 28, priceText);
            return InsertSpaceAndItem(itemMessage, 28, 40, amountText);
        }

        public static string AppendItemsSB(string description, decimal quantity, decimal price, decimal amount) {
            string quantityText;
            if (quantity % 1m == 0m) {
                quantityText = Convert.ToInt32(quantity).ToString();
            }
            else {
                quantityText = quantity.ToString("n3");
            }

            string priceText = price.ToCurrency();
            string amountText = amount.ToCurrency();
            StringBuilder message = new StringBuilder();

            if (description.Length <= 12) {
                string itemMessage = description;
                itemMessage = InsertSpaceAndItem(itemMessage, description.Length, 18, quantityText);
                itemMessage = InsertSpaceAndItem(itemMessage, 18, 28, priceText);
                itemMessage = InsertSpaceAndItem(itemMessage, 28, 40, amountText);
                message.Append(itemMessage);
            }
            else {
                message.AppendLine(description);
                string itemMessage = "";
                itemMessage = InsertSpaceAndItem(itemMessage, 0, 18, quantityText);
                itemMessage = InsertSpaceAndItem(itemMessage, 18, 28, priceText);
                itemMessage = InsertSpaceAndItem(itemMessage, 28, 40, amountText);
                message.Append(itemMessage);
            }
            return message.ToString();
        }

        public static string AppendItems(string description, decimal quantity, decimal price, decimal amount, int additionalCharacters) {
            string quantityText = quantity.ToCurrency();
            string priceText = price.ToCurrency();
            string amountText = amount.ToCurrency();
            string message = "";

            if (description.Length <= 20) {
                message = description;
                message = InsertSpaceAndItem(message, description.Length, 28, quantityText);
                message = InsertSpaceAndItem(message, 30, 38, priceText);
                message = InsertSpaceAndItem(message, 38, 48, amountText);
            }
            else {
                message = AppendMessage(description);
                message = InsertSpaceAndItem(message, 0, 20 + additionalCharacters, quantityText);
                message = InsertSpaceAndItem(message, 20 + additionalCharacters, 30 + additionalCharacters, priceText);
                message = InsertSpaceAndItem(message, 30 + additionalCharacters, 40 + additionalCharacters, amountText);
            }

            return message + AppendLine();
        }

        #endregion

        #region Printer

        public static void SendCutCommand(string printerName) {
            if (!new POSHandler().AutoCut) {
                return;
            }

            byte[] cutCommand = {
                29,
                86,
                66,
                4
            };

            // Send the ESC/POS cut command
            // to the selected printer here.
        }

        #endregion

        #region String Formatting

        public static string InsertSpaceAndItem(string itemMessage, int beginningIndex, int endIndex, string value) {
            int endingPosition = endIndex - value.Length;
            for (int index = beginningIndex; index < endingPosition; index++) {
                itemMessage += " ";
            }
            itemMessage += value;
            return itemMessage;
        }

        public static string InsertMessage(string message, Alignment alignment) {
            switch (alignment) {
                case Alignment.Left:
                    return message;

                case Alignment.Center:
                    int totalWidth = message.Length + (20 - message.Length / 2);
                    return message.PadLeft(totalWidth);

                case Alignment.Right:
                    return message.PadLeft(40);

                default:
                    return message;
            }
        }

        #endregion
    }
}

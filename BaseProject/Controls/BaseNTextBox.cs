using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Controls {
    public class BaseNTextBox : TextBox {
        #region Enums
        public enum Input {
            Decimal,
            Integer
        }

        #endregion

        #region Fields
        private Input _inputType;
        private IContainer components;
        #endregion

        #region Properties

        [Category("BaseProject")]
        [Description("Choose the desired input type.")]
        [DefaultValue(Input.Decimal)]
        public Input InputType {
            get {
                return _inputType;
            }
            set {
                _inputType = value;
                OnInputTypeChanged(EventArgs.Empty);
            }
        }
        [Category("BaseProject")]
        [Description("The background color when the control loses focus.")]
        public Color OnTxtLeave { get; set; }

        [Category("BaseProject")]
        [Description("The background color when the control is focused.")]
        public Color OnTxtEnter { get; set; }

        [Category("BaseProject")]
        [Description("True to allow comma formatting.")]
        [DefaultValue(false)]
        public bool AllowComma { get; set; }
        #endregion

        #region Events
        public event EventHandler InputTypeChanged;
        protected virtual void OnInputTypeChanged(EventArgs e) {
            InputTypeChanged?.Invoke(this, e);
        }
        #endregion

        #region Constructor
        public BaseNTextBox() {
            InputTypeChanged += BaseNTextBox_InputTypeChanged;
            OnTxtEnter = Color.LightSteelBlue;
            OnTxtLeave = SystemColors.Window;
            InitializeComponent();
            BackColor = SystemColors.Window;
            MaxLength = 255;
            TextAlign = HorizontalAlignment.Right;
            InputType = Input.Decimal;
            AllowComma = false;
        }
        #endregion

        #region Input Type Changed
        private void BaseNTextBox_InputTypeChanged(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(Text)) {
                return;
            }
            switch (InputType) {
                case Input.Integer:
                    FormatInteger();
                    break;
                case Input.Decimal:
                    FormatDecimal();
                    break;
            }
        }
        #endregion

        #region Enter / Leave
        private void BaseNTextBox_Enter(object sender, EventArgs e) {
            BackColor = OnTxtEnter;
        }
        private void BaseNTextBox_Leave(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(Text)) {
                BackColor = Color.Red;
            }
            else {
                BackColor = OnTxtLeave;
            }
        }
        #endregion

        #region KeyPress
        private void BaseNTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\'') {
                e.Handled = true;
                return;
            }
            switch (InputType) {
                case Input.Decimal:
                    if (Text.Contains(".")) {
                        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') {
                            e.Handled = true;
                        }
                    }
                    else {
                        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b') {
                            e.Handled = true;
                        }
                    }
                    break;

                case Input.Integer:
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') {
                        e.Handled = true;
                    }
                    break;
            }
        }

        #endregion

        #region Text Changed

        private void BaseNTextBox_TextChanged(
            object sender,
            EventArgs e) {
            if (!string.IsNullOrWhiteSpace(Text)) {
                return;
            }
            switch (InputType) {
                case Input.Decimal:
                    Text = "0.00";
                    break;

                case Input.Integer:
                    Text = "0";
                    break;
            }

            SelectAll();
        }
        #endregion

        #region Validating
        private void BaseNTextBox_Validating(object sender, CancelEventArgs e) {
            string value = Text.Replace(",", "");
            switch (InputType) {
                case Input.Decimal:
                    if (!decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out _)) {
                        Text = "0.00";
                    }
                    break;

                case Input.Integer:
                    if (!long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out _)) {
                        Text = "0";
                    }
                    break;
            }
        }
        #endregion

        #region Key Up
        private void BaseNTextBox_KeyUp(object sender, KeyEventArgs e) {
            if (!AllowComma) {
                return;
            }
            if (e.Control ||
                e.Shift ||
                e.Alt) {
                e.Handled = true;
                return;
            }
            if (!IsNumberKey(e.KeyValue)) {
                e.Handled = true;
                FormatCurrentValue();
                return;
            }
            if (string.IsNullOrWhiteSpace(Text)) {
                return;
            }
            FormatCurrentValue();
        }
        #endregion

        #region Formatting
        private void FormatCurrentValue() {
            int selectionStart = SelectionStart;
            int commaCountBefore = Text.Count(f => f == ',');
            if (InputType == Input.Decimal) {
                if (Text.EndsWith(".")) {
                    return;
                }
                string value = Text.Replace(",", "");
                if (!decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal number)) {
                    return;
                }
                int decimalPlaces = GetDecimalPlaces(number);
                Text = number.ToString($"N{decimalPlaces}", CultureInfo.InvariantCulture);
            }
            else {
                string value = Text.Replace(",", "");
                if (!long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out long number)) {
                    return;
                }
                Text = number.ToString("N0", CultureInfo.InvariantCulture);
            }
            int commaCountAfter = Text.Count(f => f == ',');
            if (commaCountBefore < commaCountAfter) {
                SelectionStart = Math.Min(selectionStart + 1, Text.Length);
            }
            else if (commaCountBefore > commaCountAfter) {
                SelectionStart = Math.Max(selectionStart - 1, 0);
            }
            else {
                SelectionStart = Math.Min(selectionStart, Text.Length);
            }
        }

        private void FormatInteger() {
            string value = Text.Replace(",", "");
            if (!long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out long number)) {
                Text = "0";
                return;
            }
            int selectionStart = SelectionStart;
            int commaCountBefore = Text.Count(f => f == ',');
            Text = number.ToString("N0", CultureInfo.InvariantCulture);
            int commaCountAfter = Text.Count(f => f == ',');
            AdjustSelection(selectionStart, commaCountBefore, commaCountAfter);
        }

        private void FormatDecimal() {
            string value = Text.Replace(",", "");
            if (!decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal number)) {
                Text = "0.00";
                return;
            }
            int decimalPlaces = GetDecimalPlaces(number);
            Text = number.ToString($"N{decimalPlaces}", CultureInfo.InvariantCulture);
        }

        private void AdjustSelection(int selectionStart, int commaCountBefore, int commaCountAfter) {
            if (commaCountBefore < commaCountAfter) {
                SelectionStart = Math.Min(selectionStart + 1, Text.Length);
            }
            else if (commaCountBefore > commaCountAfter) {
                SelectionStart = Math.Max(selectionStart - 1, 0);
            }
            else {
                SelectionStart = Math.Min(selectionStart, Text.Length);
            }
        }

        #endregion

        #region Helper Methods

        private bool IsNumberKey(int keyValue) {
            return (keyValue >= 48 && keyValue <= 57) || (keyValue >= 96 && keyValue <= 105);
        }

        public static int GetDecimalPlaces(decimal value) {
            return BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing) {
            if (disposing && components != null) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region InitializeComponent
        private void InitializeComponent() {
            base.SuspendLayout();
            base.TextChanged += new EventHandler(BaseNTextBox_TextChanged);
            base.Enter += new EventHandler(BaseNTextBox_Enter);
            base.KeyPress += new KeyPressEventHandler(BaseNTextBox_KeyPress);
            base.KeyUp += new KeyEventHandler(BaseNTextBox_KeyUp);
            base.Leave += new EventHandler(BaseNTextBox_Leave);
            base.Validating += new CancelEventHandler(BaseNTextBox_Validating);
            base.ResumeLayout(false);
        }
        #endregion
    }
}

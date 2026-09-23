using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Entity {
    public abstract class BaseEntity : IDataErrorInfo {
        protected bool IsNew { get; set; } = true;
        public bool IsValid => Validate().Success;

        [Browsable(false)]
        public string this[string columnName] {
            get {
                var propertyDescriptor = TypeDescriptor.GetProperties(this)[columnName];
                if (propertyDescriptor == null) {
                    return string.Empty;
                }
                var results = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(propertyDescriptor.GetValue(this), new ValidationContext(this, null, null) { MemberName = columnName}, results);
                if (!result) {
                    return results.First().ErrorMessage;
                }
                return string.Empty;
            }
        }
        [Browsable(false)]
        public string Error {
            get {
                var results = new List<ValidationResult>();
                var result = Validator.TryValidateObject(this, new ValidationContext(this, null, null), results, true);
                if (!result) {
                    return string.Join(Environment.NewLine, results.Select(e => e.ErrorMessage));
                }
                return null;
            }
        }
        public abstract OperationResult Validate();
    }
}

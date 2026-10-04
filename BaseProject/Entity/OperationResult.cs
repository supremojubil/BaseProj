using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Entity {
    public class OperationResult {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static OperationResult SuccessResult => new OperationResult {
            Success = true,
            Message = ""
        };
        public OperationResult() {
            Success = false;
            Message = "";
        }
        public static OperationResult UnsuccessfuleResult(string message) {
            return new OperationResult {
                Success = false,
                Message = message
            };
        }
    }
}

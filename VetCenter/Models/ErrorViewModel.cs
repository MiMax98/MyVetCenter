using System;

namespace VetCenter.Models
{
    /// <summary>
    /// Model widoku b��du
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

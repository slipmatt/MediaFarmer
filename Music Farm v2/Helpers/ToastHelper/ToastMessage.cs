using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaFarmer.Helpers.ToastHelper
{
    /// <summary>
    /// This class is to implement a message to be shown.  The class must be serializable to be able to be saved in the TempData
    /// </summary>
    [Serializable]
    public class ToastMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public ToastType ToastType { get; set; }
        public bool IsSticky { get; set; }
    }
}
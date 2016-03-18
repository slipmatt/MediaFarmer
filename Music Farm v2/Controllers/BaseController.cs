using Music_Farm_v2.Helpers;
using Music_Farm_v2.Helpers.ReturnsHelper;
using Music_Farm_v2.Helpers.ToastHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Farm_v2.Controllers
{
    public class BaseController : Controller
    {
        public Toastr _toastr;

        public BaseController()
        {
            _toastr = new Toastr();
        }

        public void Success(string title, string message)
        {
            _toastr.AddToastMessage(title, message, ToastType.Success);
            TempData["Toastr"] = _toastr;
        }

        public void Information(string title, string message)
        {
            _toastr.AddToastMessage(title, message, ToastType.Info);
            TempData["Toastr"] = _toastr;
        }

        public void Warning(string title, string message)
        {
            _toastr.AddToastMessage(title, message, ToastType.Warning);
            TempData["Toastr"] = _toastr;
        }

        public void Error(string title, string message)
        {
            _toastr.AddToastMessage(title, message, ToastType.Error);
            TempData["Toastr"] = _toastr;
        }

        protected internal virtual JsonNetResult JsonNetResult()
        {
            return new JsonNetResult();
        }

        protected internal virtual JsonNetResult JsonNetResult(object data)
        {
            return new JsonNetResult(data);
        }

    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Farm_v2.Helpers.ReturnsHelper
{
    public class JsonNetResult : JsonResult
    {
        public JsonNetResult()
        {
            SerializerSettings = new JsonSerializerSettings();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data">object to be serialised</param>
        public JsonNetResult(object data)
        {
            Data = data;
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public JsonSerializerSettings SerializerSettings { get; set; }

        public Formatting Formatting { get; set; }


        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType)
                                       ? ContentType
                                       : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Data != null)
            {
                var writer = new JsonTextWriter(response.Output) { Formatting = Formatting };

                var serializer = JsonSerializer.Create(SerializerSettings);

                serializer.Serialize(writer, Data);

                writer.Flush();
            }
        }
    }
}
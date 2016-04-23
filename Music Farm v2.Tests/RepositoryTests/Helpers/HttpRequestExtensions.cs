using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MediaFarmer.Tests.RepositoryTests.Helpers
{
    /// <summary>
    /// Extension methods for the HttpRequest class.
    /// </summary>
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Adds the name/value pair to the ServerVariables for the HttpRequest.
        /// </summary>
        /// <param name="request">The request to append the variables to.</param>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The value of the variable.</param>
        public static void AddServerVariable(this HttpRequest request, string name, string value)
        {
            if (request == null) return;

            AddServerVariables(request, new Dictionary<string, string>() {
      { name, value }
    });
        }

        /// <summary>
        /// Adds the name/value pairs to the ServerVariables for the HttpRequest.
        /// </summary>
        /// <param name="request">The request to append the variables to.</param>
        /// <param name="collection">The collection of name/value pairs to add.</param>
        public static void AddServerVariables(this HttpRequest request, NameValueCollection collection)
        {
            if (request == null) return;
            if (collection == null) return;

            AddServerVariables(request, collection.AllKeys
                                                  .ToDictionary(k => k, k => collection[k]));
        }

        /// <summary>
        /// Adds the name/value pairs to the ServerVariables for the HttpRequest.
        /// </summary>
        /// <param name="request">The request to append the variables to.</param>
        /// <param name="dictionary">The dictionary containing the pairs to add.</param>
        public static void AddServerVariables(this HttpRequest request, IDictionary<string, string> dictionary)
        {
            if (request == null) return;
            if (dictionary == null) return;

            var field = request.GetType()
                               .GetField("_serverVariables", BindingFlags.Instance | BindingFlags.NonPublic);
            if (field != null)
            {
                var type = field.FieldType;

                var serverVariables = field.GetValue(request);
                if (serverVariables == null)
                {
                    var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                          new[] { typeof(HttpWorkerRequest), typeof(HttpRequest) }, null);
                    serverVariables = constructor.Invoke(new[] { null, request });
                    field.SetValue(request, serverVariables);
                }
                var addStatic = type.GetMethod("AddStatic", BindingFlags.Instance | BindingFlags.NonPublic);

                ((NameValueCollection)serverVariables).MakeWriteable();
                foreach (var item in dictionary)
                {
                    addStatic.Invoke(serverVariables, new[] { item.Key, item.Value });
                }
              ((NameValueCollection)serverVariables).MakeReadOnly();
            }
        }
    }

    /// <summary>
    /// Extension methods for the NameValueCollection class.
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Retreives the IsReadOnly property from the NameValueCollection
        /// </summary>
        /// <param name="collection">The collection to retrieve the propertyInfo from.</param>
        /// <param name="bindingFlags">The optional BindingFlags to use. If not specified defautls to Instance|NonPublic.</param>
        /// <returns>The PropertyInfo for the IsReadOnly property.</returns>
        private static PropertyInfo GetIsReadOnlyProperty(this NameValueCollection collection, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic)
        {
            if (collection == null) return (null);
            return (collection.GetType().GetProperty("IsReadOnly", bindingFlags));
        }

        /// <summary>
        /// Sets the IsReadOnly property to the specified value.
        /// </summary>
        /// <param name="collection">The collection to modify.</param>
        /// <param name="isReadOnly">The value to set.</param>
        private static void SetIsReadOnly(this NameValueCollection collection, bool isReadOnly)
        {
            if (collection == null) return;

            var property = GetIsReadOnlyProperty(collection);
            if (property != null)
            {
                property.SetValue(collection, isReadOnly, null);
            }
        }

        /// <summary>
        /// Makes the specified collection writable via reflection.
        /// </summary>
        /// <param name="collection">The collection to make writable.</param>
        public static void MakeWriteable(this NameValueCollection collection)
        {
            SetIsReadOnly(collection, false);
        }

        /// <summary>
        /// Makes the specified collection readonly via reflection.
        /// </summary>
        /// <param name="collection">The collection to make readonly.</param>
        public static void MakeReadOnly(this NameValueCollection collection)
        {
            SetIsReadOnly(collection, true);
        }
    }

}

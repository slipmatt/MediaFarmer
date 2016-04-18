using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaFarmer.Context.Repositories
{
    public class ContextData
    {
        public static ContextData Instance { get { return NestedClass.instance; } }
        private class NestedClass
        {
            static NestedClass()
            {

            }

            internal static readonly ContextData instance = new ContextData();
        }
    }
}
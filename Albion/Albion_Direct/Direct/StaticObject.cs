////////////////////////////////////////////////////////////////////////////////////
// Merlin API for Albion Online v1.0.336.100246-prod
////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Reflection;

namespace Albion_Direct
{
    /* Internal type: a1u */
    public partial class StaticObject : WorldObject
    {
        private static List<MethodInfo> _methodReflectionPool = new List<MethodInfo>();
        private static List<PropertyInfo> _propertyReflectionPool = new List<PropertyInfo>();
        private static List<FieldInfo> _fieldReflectionPool = new List<FieldInfo>();
        
        private a1u _internal;
        
        #region Properties
        
        public a1u StaticObject_Internal => _internal;
        
        #endregion
        
        #region Fields
        
        
        #endregion
        
        #region Methods
        
        
        #endregion
        
        #region Constructor
        
        public StaticObject(a1u instance) : base(instance)
        {
            _internal = instance;
        }
        
        static StaticObject()
        {
            
        }
        
        #endregion
        
        #region Conversion
        
        public static implicit operator a1u(StaticObject instance)
        {
            return instance._internal;
        }
        
        public static implicit operator StaticObject(a1u instance)
        {
            return new StaticObject(instance);
        }
        
        public static implicit operator bool(StaticObject instance)
        {
            return instance._internal != null;
        }
        #endregion
    }
}

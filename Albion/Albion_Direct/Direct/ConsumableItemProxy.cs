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
    /* Internal type: atu */
    public partial class ConsumableItemProxy : SimpleItemProxy
    {
        private static List<MethodInfo> _methodReflectionPool = new List<MethodInfo>();
        private static List<PropertyInfo> _propertyReflectionPool = new List<PropertyInfo>();
        private static List<FieldInfo> _fieldReflectionPool = new List<FieldInfo>();
        
        private atu _internal;
        
        #region Properties
        
        public atu ConsumableItemProxy_Internal => _internal;
        
        #endregion
        
        #region Fields
        
        
        #endregion
        
        #region Methods
        
        
        #endregion
        
        #region Constructor
        
        public ConsumableItemProxy(atu instance) : base(instance)
        {
            _internal = instance;
        }
        
        static ConsumableItemProxy()
        {
            
        }
        
        #endregion
        
        #region Conversion
        
        public static implicit operator atu(ConsumableItemProxy instance)
        {
            return instance._internal;
        }
        
        public static implicit operator ConsumableItemProxy(atu instance)
        {
            return new ConsumableItemProxy(instance);
        }
        
        public static implicit operator bool(ConsumableItemProxy instance)
        {
            return instance._internal != null;
        }
        #endregion
    }
}

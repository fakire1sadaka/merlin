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
    /* Internal type: atn */
    public partial class EquipmentItemProxy : DurableItemProxy
    {
        private static List<MethodInfo> _methodReflectionPool = new List<MethodInfo>();
        private static List<PropertyInfo> _propertyReflectionPool = new List<PropertyInfo>();
        private static List<FieldInfo> _fieldReflectionPool = new List<FieldInfo>();
        
        private atn _internal;
        
        #region Properties
        
        public atn EquipmentItemProxy_Internal => _internal;
        
        #endregion
        
        #region Fields
        
        
        #endregion
        
        #region Methods
        
        
        #endregion
        
        #region Constructor
        
        public EquipmentItemProxy(atn instance) : base(instance)
        {
            _internal = instance;
        }
        
        static EquipmentItemProxy()
        {
            
        }
        
        #endregion
        
        #region Conversion
        
        public static implicit operator atn(EquipmentItemProxy instance)
        {
            return instance._internal;
        }
        
        public static implicit operator EquipmentItemProxy(atn instance)
        {
            return new EquipmentItemProxy(instance);
        }
        
        public static implicit operator bool(EquipmentItemProxy instance)
        {
            return instance._internal != null;
        }
        #endregion
    }
}

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
    /* Internal type: cb */
    public partial class AgentTypeDescriptor
    {
        private static List<MethodInfo> _methodReflectionPool = new List<MethodInfo>();
        private static List<PropertyInfo> _propertyReflectionPool = new List<PropertyInfo>();
        private static List<FieldInfo> _fieldReflectionPool = new List<FieldInfo>();
        
        private cb _internal;
        
        #region Properties
        
        public cb AgentTypeDescriptor_Internal => _internal;
        
        #endregion
        
        #region Fields
        
        
        #endregion
        
        #region Methods
        
        
        #endregion
        
        #region Constructor
        
        public AgentTypeDescriptor(cb instance)
        {
            _internal = instance;
        }
        
        static AgentTypeDescriptor()
        {
            
        }
        
        #endregion
        
        #region Conversion
        
        public static implicit operator cb(AgentTypeDescriptor instance)
        {
            return instance._internal;
        }
        
        public static implicit operator AgentTypeDescriptor(cb instance)
        {
            return new AgentTypeDescriptor(instance);
        }
        
        public static implicit operator bool(AgentTypeDescriptor instance)
        {
            return instance._internal != null;
        }
        #endregion
    }
}

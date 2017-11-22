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
    /* Internal type: bx */
    public partial class ItemDescriptor
    {
        private static List<MethodInfo> _methodReflectionPool = new List<MethodInfo>();
        private static List<PropertyInfo> _propertyReflectionPool = new List<PropertyInfo>();
        private static List<FieldInfo> _fieldReflectionPool = new List<FieldInfo>();
        
        private bx _internal;
        
        #region Properties
        
        public bx ItemDescriptor_Internal => _internal;
        public string Description => _internal.ag;
        public string DescriptionTag
        {
            get => (string)_propertyReflectionPool[0].GetValue(_internal, null);
            set => _propertyReflectionPool[0].SetValue(_internal, (string)value, null);
        }
        public string Name => _internal.e;
        public string NameTag
        {
            get => (string)_propertyReflectionPool[1].GetValue(_internal, null);
            set => _propertyReflectionPool[1].SetValue(_internal, (string)value, null);
        }
        public string ResourceType => _internal.u;
        public int Tier => _internal.f;
        
        #endregion
        
        #region Fields
        
        
        #endregion
        
        #region Methods
        
        
        #endregion
        
        #region Constructor
        
        public ItemDescriptor(bx instance)
        {
            _internal = instance;
        }
        
        static ItemDescriptor()
        {
            _propertyReflectionPool.Add(typeof(bx).GetProperty("an", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance));
            _propertyReflectionPool.Add(typeof(bx).GetProperty("am", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance));
        }
        
        #endregion
        
        #region Conversion
        
        public static implicit operator bx(ItemDescriptor instance)
        {
            return instance._internal;
        }
        
        public static implicit operator ItemDescriptor(bx instance)
        {
            return new ItemDescriptor(instance);
        }
        
        public static implicit operator bool(ItemDescriptor instance)
        {
            return instance._internal != null;
        }
        #endregion
    }
}

////////////////////////////////////////////////////////////////////////////////////
// Merlin API for Albion Online v1.0.327.94396-live
////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using UnityEngine;

using Albion.Common.Time;

namespace Merlin.API.Direct
{
    /* Internal type: ad6 */
    public class TileDescriptor
    {
        private static List<MethodInfo> _methodReflectionPool = new List<MethodInfo>();
        private static List<PropertyInfo> _propertyReflectionPool = new List<PropertyInfo>();
        
        private ad6 _internal;
        
        #region Properties
        
        public ad6 Internal => _internal;
        
        #endregion
        
        #region Fields
        
        
        #endregion
        
        #region Methods
        
        
        #endregion
        
        #region Constructor
        
        public TileDescriptor(ad6 instance)
        {
            _internal = instance;
        }
        
        static TileDescriptor()
        {
            
        }
        
        #endregion
        
        #region Conversion
        
        public static implicit operator ad6(TileDescriptor instance)
        {
            return instance._internal;
        }
        
        public static implicit operator TileDescriptor(ad6 instance)
        {
            return new TileDescriptor(instance);
        }
        
        #endregion
    }
}

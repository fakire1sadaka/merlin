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

namespace Merlin.API.Direct
{
    /* Internal type: i7.PvpRules */
    public enum PvpRules
    {
        PvpDisabled = 0,
        PvpAllowed = 1,
        PvpForced = 2,
        None = 3
    }
    
    public static class PvpRulesExtensions
    {
        public static i7.PvpRules ToInternal(this PvpRules instance)
        {
            return (i7.PvpRules)instance;
        }
        
        public static PvpRules ToWrapped(this i7.PvpRules instance)
        {
            return (PvpRules)instance;
        }
    }
}

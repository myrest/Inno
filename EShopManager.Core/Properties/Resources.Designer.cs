﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShopManager.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("EShopManager.Core.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}沒辦法這樣用。.
        /// </summary>
        internal static string CanNotUseThisByThisWay {
            get {
                return ResourceManager.GetString("CanNotUseThisByThisWay", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 命令參數不夠。.
        /// </summary>
        internal static string DoNotHaveEnoughtPara {
            get {
                return ResourceManager.GetString("DoNotHaveEnoughtPara", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 這個命令後面必需要加上對象。.
        /// </summary>
        internal static string MustHaveTarget {
            get {
                return ResourceManager.GetString("MustHaveTarget", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 這裏沒有這個東西。.
        /// </summary>
        internal static string ThereAreNoSuchThing {
            get {
                return ResourceManager.GetString("ThereAreNoSuchThing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 你不能那樣做。.
        /// </summary>
        internal static string YouCannotDoThat {
            get {
                return ResourceManager.GetString("YouCannotDoThat", resourceCulture);
            }
        }
    }
}

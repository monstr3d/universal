﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Collada.Base.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Collada.Base.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot;?&gt;
        ///&lt;effect id=&quot;effect-a2431cff_dds&quot;&gt;
        ///		&lt;profile_COMMON&gt;
        ///			&lt;newparam sid=&quot;DiffuseColor-surface&quot;&gt;
        ///				&lt;surface type=&quot;2D&quot;&gt;
        ///					&lt;init_from&gt;object_1&lt;/init_from&gt;
        ///				&lt;/surface&gt;
        ///			&lt;/newparam&gt;
        ///			&lt;newparam sid=&quot;DiffuseColor-sampler&quot;&gt;
        ///				&lt;sampler2D&gt;
        ///					&lt;source&gt;DiffuseColor-surface&lt;/source&gt;
        ///					&lt;wrap_s&gt;WRAP&lt;/wrap_s&gt;
        ///					&lt;wrap_t&gt;WRAP&lt;/wrap_t&gt;
        ///					&lt;wrap_p&gt;WRAP&lt;/wrap_p&gt;
        ///					&lt;minfilter&gt;NONE&lt;/minfilter&gt;
        ///					&lt;magfilter&gt;NONE&lt;/magfilter&gt;
        ///					&lt;mipfilter&gt;NONE&lt;/mipfilter&gt;
        ///				&lt;/sa [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string effect {
            get {
                return ResourceManager.GetString("effect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot;?&gt;
        ///
        ///&lt;image xmlns=&quot;http://www.collada.org/2008/03/COLLADASchema&quot; id=&quot;object_1&quot;&gt;
        ///
        ///	&lt;init_from&gt;&lt;/init_from&gt;
        ///
        ///&lt;/image&gt;.
        /// </summary>
        internal static string image {
            get {
                return ResourceManager.GetString("image", resourceCulture);
            }
        }
    }
}

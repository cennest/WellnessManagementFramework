﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseEntities.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ANSHULEE-PC\\SQLEXPRESS;Initial Catalog=WellnessManagementFrameworkDB;" +
            "Integrated Security=True")]
        public string WellnessManagementFrameworkDBConnectionString {
            get {
                return ((string)(this["WellnessManagementFrameworkDBConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=POULOMEE-PC;Initial Catalog=WellnessManagementFrameworkDB;Integrated " +
            "Security=True")]
        public string WellnessManagementFrameworkDBConnectionString1 {
            get {
                return ((string)(this["WellnessManagementFrameworkDBConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=NILESH-BHOR-PC\\SQLExpress;Initial Catalog=WellnessManagementFramework" +
            "DB;Integrated Security=True")]
        public string WellnessManagementFrameworkDBConnectionString2 {
            get {
                return ((string)(this["WellnessManagementFrameworkDBConnectionString2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.0.5;Initial Catalog=WellnessManagementFrameworkDB;User ID=cen" +
            "nest")]
        public string WellnessManagementFrameworkDBConnectionString3 {
            get {
                return ((string)(this["WellnessManagementFrameworkDBConnectionString3"]));
            }
        }
    }
}

﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property FoodProductCSVPath() As String
            Get
                Return CType(Me("FoodProductCSVPath"),String)
            End Get
            Set
                Me("FoodProductCSVPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property DisplayParameter() As Integer
            Get
                Return CType(Me("DisplayParameter"),Integer)
            End Get
            Set
                Me("DisplayParameter") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Display_boolHighlight() As Boolean
            Get
                Return CType(Me("Display_boolHighlight"),Boolean)
            End Get
            Set
                Me("Display_boolHighlight") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Display_boolConditionalFormatting() As Boolean
            Get
                Return CType(Me("Display_boolConditionalFormatting"),Boolean)
            End Get
            Set
                Me("Display_boolConditionalFormatting") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("OliveDrab")>  _
        Public Property Display_HighlightColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_HighlightColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_HighlightColor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Yellow")>  _
        Public Property Display_MinColor_Tray() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MinColor_Tray"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MinColor_Tray") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("White")>  _
        Public Property Display_MaxColor_Tray() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MaxColor_Tray"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MaxColor_Tray") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Yellow")>  _
        Public Property Display_MinColor_Conveyor() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MinColor_Conveyor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MinColor_Conveyor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("White")>  _
        Public Property Display_MaxColor_Conveyor() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MaxColor_Conveyor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MaxColor_Conveyor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Red")>  _
        Public Property Display_MinColor_Ret() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MinColor_Ret"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MinColor_Ret") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("192, 255, 255")>  _
        Public Property Display_MaxColor_Ret() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MaxColor_Ret"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MaxColor_Ret") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("192, 255, 255")>  _
        Public Property Display_MinColor_Center() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MinColor_Center"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MinColor_Center") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Red")>  _
        Public Property Display_MaxColor_Center() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MaxColor_Center"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MaxColor_Center") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("192, 255, 255")>  _
        Public Property Display_MinColor_Surf() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MinColor_Surf"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MinColor_Surf") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Red")>  _
        Public Property Display_MaxColor_Surf() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MaxColor_Surf"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MaxColor_Surf") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("192, 255, 255")>  _
        Public Property Display_MinColor_Pow() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MinColor_Pow"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MinColor_Pow") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Red")>  _
        Public Property Display_MaxColor_Pow() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_MaxColor_Pow"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_MaxColor_Pow") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("8")>  _
        Public Property Main_PlaybackSpeed() As Long
            Get
                Return CType(Me("Main_PlaybackSpeed"),Long)
            End Get
            Set
                Me("Main_PlaybackSpeed") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Blue")>  _
        Public Property Display_FrozenColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_FrozenColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_FrozenColor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Red")>  _
        Public Property Display_UnfrozenColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("Display_UnfrozenColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Display_UnfrozenColor") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.VRTM_Simulator.My.MySettings
            Get
                Return Global.VRTM_Simulator.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace

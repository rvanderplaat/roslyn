﻿' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System.Reflection
Imports Microsoft.CodeAnalysis.Scripting
Imports Microsoft.CodeAnalysis.Scripting.Hosting
Imports Microsoft.CodeAnalysis.VisualBasic
Imports Microsoft.CodeAnalysis.VisualBasic.Scripting
Imports Microsoft.CodeAnalysis.VisualBasic.Scripting.Hosting

Namespace Microsoft.CodeAnalysis.VisualBasic.Scripting.Hosting

    Friend Class VisualBasicReplServiceProvider
            Inherits ReplServiceProvider

            Public Sub New()
            End Sub

            Public Overrides ReadOnly Property CommandLineParser As CommandLineParser
                Get
                    Return VisualBasicCommandLineParser.Script
                End Get
            End Property

            Public Overrides ReadOnly Property DiagnosticFormatter As DiagnosticFormatter
                Get
                    Return VisualBasicDiagnosticFormatter.Instance
                End Get
            End Property

            Public Overrides ReadOnly Property Logo As String
                Get
                    Return String.Format(VBScriptingResources.LogoLine1, Me.GetType().GetTypeInfo().Assembly.GetCustomAttribute(Of AssemblyFileVersionAttribute).Version)
                End Get
            End Property

            Public Overrides ReadOnly Property ObjectFormatter As ObjectFormatter = VisualBasicObjectFormatter.Instance

            Public Overrides Function CreateScript(Of T)(code As String, options As ScriptOptions, globalsTypeOpt As Type, assemblyLoader As InteractiveAssemblyLoader) As Script(Of T)
                Return VisualBasicScript.Create(Of T)(code, options, globalsTypeOpt, assemblyLoader)
            End Function
        End Class
    End Namespace


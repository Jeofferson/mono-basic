'Author:
'   V. Sudharsan (vsudharsan@novell.com)
'
' (C) 2005 Novell, Inc.
Option Strict Off

Imports System.Threading
Imports System.Globalization

Module ImpConversionDecimaltoStringA
    Function Main() As Integer
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")

        Dim a As Decimal = 123.052
        Dim b As String = a
        If b <> "123.052" Then
            System.Console.WriteLine("Conversion of Decimal to String not working. Expected 123.052 but got " & b) : Return 1
        End If
    End Function
End Module

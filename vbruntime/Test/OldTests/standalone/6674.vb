  '
  ' Copyright (c) 2002-2003 Mainsoft Corporation.
  '
  ' Permission is hereby granted, free of charge, to any person obtaining a
  ' copy of this software and associated documentation files (the "Software"),
  ' to deal in the Software without restriction, including without limitation
  ' the rights to use, copy, modify, merge, publish, distribute, sublicense,
  ' and/or sell copies of the Software, and to permit persons to whom the
  ' Software is furnished to do so, subject to the following conditions:
  ' 
  ' The above copyright notice and this permission notice shall be included in
  ' all copies or substantial portions of the Software.
  ' 
  ' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
  ' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  ' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
  ' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
  ' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
  ' FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
  ' DEALINGS IN THE SOFTWARE.
  '
Imports Microsoft.VisualBasic
Imports System.IO
Imports System
Public Class TestClass
    Public Function Test() As String
        Dim fa As FileAttribute
        Dim caughtException As Boolean
        '// Pathname is invalid or contains wildcards.
        caughtException = False
        Try
            SetAttr(System.IO.Directory.GetCurrentDirectory() + "/data/*.txt", FileAttribute.Normal)
        Catch e As ArgumentException
            If Err.Number = 5 Then
                caughtException = True
            End If
        End Try
        If caughtException = False Then Return "sub test 1 failed"
        caughtException = False
        Try
            SetAttr(System.IO.Directory.GetCurrentDirectory() + "/dir_notfound/foo.txt", FileAttribute.Normal)
        Catch e As DirectoryNotFoundException
            If Err.Number = 76 Then
                caughtException = True
            End If
        End Try
        If caughtException = False Then Return "sub test 2 failed"
        '// Target file does not exist.
        caughtException = False
        Try
            SetAttr(System.IO.Directory.GetCurrentDirectory() + "/data/notfound.txt", FileAttribute.Normal)
        Catch e As FileNotFoundException
            If Err.Number = 53 Then
                caughtException = True
            End If
        End Try
        If caughtException = False Then Return "sub test 3 failed"
        Return "success"
    End Function
End Class

'Author:
'   V. Sudharsan (vsudharsan@novell.com)
'
' (C) 2005 Novell, Inc.

Module ExpConversionStringtoCharA
    Function Main() As Integer
        Dim a As Char
        Dim b As String = "This is a program"
        a = CChar(b)
        If a <> "T" Then
            System.Console.WriteLine("Conversion of String to Char not working. Expected T but got " & a) : Return 1
        End If
    End Function
End Module

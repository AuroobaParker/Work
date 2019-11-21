Module Module1
    Sub FirstWordOneLastWordAnother(ByVal str1 As String, ByVal str2 As String)
        Dim x, a As Integer
        Dim y, z As String
        x = InStr(str1, " ")
        z = Left(str1, x - 1)
        a = str2.LastIndexOf(" ")
        y = Mid(str2, a + 1, Len(str2) - a)
        Console.WriteLine(z + y)
    End Sub
    Sub FindingAndTruncatingChar(ByVal Originalstring As String, ByVal truncatingChar As String)
        Dim str2 As String = ""
        For count = 1 To Len(Originalstring)
            If UCase(Mid(Originalstring, count, 1)) <> UCase(truncatingChar) Then
                str2 = str2 + Mid(Originalstring, count, 1)
            End If
        Next
        Console.WriteLine(str2)
    End Sub
    Sub FindingAndReplacingChar(ByVal Originalstring As String, ByVal ReplacingChar As String, ByVal Replacewith As String)
        Dim str2 As String = ""
        Dim x As String
        For count = 1 To Len(Originalstring)
            If UCase(Mid(Originalstring, count, 1)) = UCase(ReplacingChar) Then
                str2 = str2 + Replacewith
            Else
                x = Mid(Originalstring, count, 1)
                str2 = str2 + x
            End If
        Next
        Console.WriteLine(str2)
    End Sub
    Sub CountingAlphabetsAndDigits(ByVal str As String)
        Dim x As String
        Dim counta As Integer = 0
        Dim countd As Integer = 0
        For count = 1 To Len(str)
            x = Mid(str, count, 1)
            If x >= "0" And x <= "9" Then
                countd = countd + 1
            ElseIf ucase(x) >= "A" And UCase(x) <= "Z" Then
                counta = counta + 1
            End If
        Next
        Console.WriteLine("Number of Alphabets" & counta)
        Console.WriteLine("Number of Digits" & countd)
    End Sub
    Sub InverseString(ByVal str As String)
        Dim x As Integer
        Dim str2 As String = ""
        x = Len(str)
        For count = x To 1 Step -1
            str2 = str2 + Mid(str, count, 1)
        Next
        Console.WriteLine(str2)
    End Sub
    Sub VowelCounter(ByVal str As String)
        Dim x As String = ""
        Dim count As Integer = 0
        For i = 1 To Len(str)
            x = Mid(str, i, 1)
            If x = "a" Or x = "e" Or x = "i" Or x = "o" Or x = "u" Then
                count = count + 1
            End If
        Next
        Console.WriteLine("The Number of Vowels are " & count)
    End Sub
    Sub Anagram(ByVal str1 As String, ByVal str2 As String)
        Dim i As Integer
        Dim x As String
        i = 0
        Dim Yes As Boolean = True
        Dim found As Boolean = False
        x = ""
        If Len(str1) = Len(str2) Then
            Do
                i = i + 1
                x = Mid(str1, i, 1)
                For count = 1 To Len(str2)
                    If x = Mid(str2, count, 1) Then
                        found = True
                    End If
                Next

            Loop Until found = False Or i = Len(str1)
            If found = False Then
                Yes = False
            End If
        Else
            Yes = False
        End If
        If Yes = True Then
            Console.WriteLine("Yes They Are Anagrams")
        Else Console.WriteLine("No They Are Not Anagrams")
        End If
    End Sub
    Sub Panagram(ByVal str1 As String)
        Dim i As Integer
        Dim found As Boolean
        Dim x As String = ""
        Dim z As Integer = 64
        Do
            z = z + 1
            i = 0
            found = False
            Do
                i = i + 1
                If Chr(z) = UCase(Mid(str1, i, 1)) Then
                    found = True
                End If
            Loop Until found = True Or Len(str1) = i
        Loop Until found = False Or z = 90
        If found = False Then
            Console.WriteLine("String is not a panagram")
        Else console.WriteLine("String is a panagram")
        End If
    End Sub
    Sub Validation(ByVal str1 As String)
        Dim found = True
        Dim x As String = ""
        Dim i As Integer = 0
        If Len(str1) <> 9 Then
            found = False
        ElseIf Mid(str1, 4, 1) <> "-" And Mid(str1, 8, 1) <> "-" Then
            found = False
        ElseIf UCase(Right(str1, 1)) <> "X" Then
            found = False
        Else
            Do
                i = i + 1
                x = Mid(str1, i, 1)
                If UCase(x) < "A" Or UCase(x) > "Z" Then
                    found = False
                End If
            Loop Until found = False Or i = 3
            i = 5
            While found = True And i <= 7
                x = Mid(str1, i, 1)
                If (x) < "0" Or (x) > "9" Then
                    found = False
                End If
                i = i + 1
            End While
        End If
        If found = False Then
            Console.WriteLine("Invalid Format")
        Else console.WriteLine("Valid Format")
        End If
    End Sub




End Module


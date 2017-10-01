Imports System
Imports System.Data
Imports System.Data.Sql
Imports Microsoft.SqlServer.Server
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Collections 'the IEnumerable interface is here

'---------------------------------------------------------------------------------------
Namespace SimpleTalk.Phil.Factor
    Public Class RegularExpressionFunctions
        '
        '          RegExOptions function
        'this is used simply to creat the bitmap that is passed to the various
        'CLR routines

        <SqlFunction(IsDeterministic:=True, IsPrecise:=True)>
        Public Shared Function RegExOptionEnumeration(ByVal IgnoreCase As SqlBoolean,
                       ByVal MultiLine As SqlBoolean,
                                     ByVal ExplicitCapture As SqlBoolean,
                                     ByVal Compiled As SqlBoolean,
                                     ByVal SingleLine As SqlBoolean,
                                     ByVal IgnorePatternWhitespace As SqlBoolean,
                                     ByVal RightToLeft As SqlBoolean,
                                     ByVal ECMAScript As SqlBoolean,
                                     ByVal CultureInvariant As SqlBoolean) _
                        As SqlInt32
            Dim Result As Integer
            Result = (IIf(IgnoreCase.Value, RegexOptions.IgnoreCase, RegexOptions.None) Or
             IIf(MultiLine.Value, RegexOptions.Multiline, RegexOptions.None) Or
             IIf(ExplicitCapture.Value, RegexOptions.ExplicitCapture,
                          RegexOptions.None) Or
             IIf(Compiled.Value, RegexOptions.Compiled, RegexOptions.None) Or
             IIf(SingleLine.Value, RegexOptions.Singleline, RegexOptions.None) Or
             IIf(IgnorePatternWhitespace.Value, RegexOptions.IgnorePatternWhitespace,
                          RegexOptions.None) Or
             IIf(RightToLeft.Value, RegexOptions.RightToLeft, RegexOptions.None) Or
             IIf(ECMAScript.Value, RegexOptions.ECMAScript, RegexOptions.None) Or
             IIf(CultureInvariant.Value, RegexOptions.CultureInvariant, RegexOptions.None))
            Return (Result)
        End Function
        '----------end of RegExEnumeration function
        '
        '          RegExMatch function
        'This method returns the first substring found in input that matches the
        'regular expression pattern.
        <SqlFunction(IsDeterministic:=True, IsPrecise:=True)>
        Public Shared Function RegExMatch(ByVal pattern As SqlString,
                                            ByVal input As SqlString,
                                            ByVal Options As SqlInt32
         ) As SqlString
            If (input.IsNull OrElse pattern.IsNull) Then
                Return String.Empty
            End If
            Dim RegexOption As New System.Text.RegularExpressions.RegexOptions
            RegexOption = Options
            Return Regex.Match(input.Value, pattern.Value, RegexOption).Value
        End Function
        '----------end of RegExMatch function
        'end RegexOptions

        'RegExIsMatch function
        <SqlFunction(IsDeterministic:=True, IsPrecise:=True)>
        Public Shared Function RegExIsMatch(
                                            ByVal pattern As SqlString,
                                            ByVal input As SqlString,
                                            ByVal Options As SqlInt32) As SqlBoolean
            If (input.IsNull OrElse pattern.IsNull) Then
                Return SqlBoolean.False
            End If
            Dim RegexOption As New System.Text.RegularExpressions.RegexOptions
            RegexOption = Options
            Return Regex.IsMatch(input.Value, pattern.Value, RegexOption)
        End Function         '
        '          RegExIndex function
        'This method returns the index of the first substring found in input that
        'matches the regular expression pattern.
        <SqlFunction(IsDeterministic:=True, IsPrecise:=True)>
        Public Shared Function RegExIndex(ByVal pattern As SqlString,
                                            ByVal input As SqlString,
                                            ByVal Options As SqlInt32
                       ) As SqlInt32
            If (input.IsNull OrElse pattern.IsNull) Then
                Return 0
            End If
            Dim RegexOption As New System.Text.RegularExpressions.RegexOptions
            RegexOption = Options
            Return Regex.Match(input.Value, pattern.Value, RegexOption).Index
        End Function
        '----------end of RegExMatch function
        '          RegExEscape function
        'This method 'escapes'  a minimal set of characters (\, *, +, ?, |, {, [, (,),
        '^,$,., #, and white space) by replacing them with their escape codes. This
        'instructs the regular expression engine to interpret these characters
        'literally rather than as metacharacters so you can pass any atring into
        'the pattern harmlessly.
        <SqlFunction(IsDeterministic:=True, IsPrecise:=True)>
        Public Shared Function RegExEscape(ByVal input As SqlString) As SqlString
            If (input.IsNull) Then
                Return String.Empty
            End If
            Return Regex.Escape(input.Value)
        End Function
        '----------end of RegEscape function
        '
        '          RegExSplit function
        'RegexSplit function Splits an input string into an array of substrings at the
        'positions defined by a regular expression match.
        'This method splits the string at a delimiter determined by a regular
        'expression. The string is split as many times as possible. If no delimiter
        'is found, the return value contains one element whose value is the original
        'input parameter string.
        <SqlFunction(DataAccess:=DataAccessKind.None, IsDeterministic:=True,
          IsPrecise:=True, Name:="RegExSplit",
          SystemDataAccess:=SystemDataAccessKind.None,
          FillRowMethodName:="NextSplitRow")>
        Public Shared Function RegExSplit(
                                   ByVal pattern As SqlString,
                                   ByVal input As SqlString,
                                   ByVal Options As SqlInt32) _
                                  As IEnumerable
            If (input.IsNull OrElse pattern.IsNull) Then
                Return Nothing
            End If
            Dim RegexOption As New System.Text.RegularExpressions.RegexOptions
            RegexOption = Options
            Return Regex.Split(input.Value, pattern.Value, RegexOption)
        End Function
        Private Shared Sub NextSplitRow(ByVal input As Object,
                <Out()> ByRef match As SqlString)
            match = New SqlString(CStr(input))
        End Sub
        '----------end of RegexSplit function
        '
        '          RegExReplace function
        'SQL Server version with parameters like TSQL: REPLACE
        'Within a specified input string, replaces all strings that match a specified
        'regular expression with a specified replacement string. Specified options
        'modify the matching operation.
        'this works like the SQL 'Replace' function on steroids.
        <SqlFunction(DataAccess:=DataAccessKind.None, IsDeterministic:=True,
            IsPrecise:=True, Name:="RegExReplace",
            SystemDataAccess:=SystemDataAccessKind.None)>
        Public Shared Function RegExReplace(ByVal input As SqlString,
                                            ByVal pattern As SqlString,
                                            ByVal replacement As SqlString) _
              As SqlString
            If (input.IsNull OrElse pattern.IsNull) Then
                Return SqlString.Null
            End If
            Return New SqlString(Regex.Replace(input.Value, pattern.Value,
                replacement.Value, RegexOptions.IgnoreCase Or RegexOptions.Multiline))
        End Function
        '----------end of RegexReplace function
        '
        '          RegExReplacex function
        'Logical version of the Regex Replace with parameters like the others
        'Within a specified input string, replaces all strings that match a specified
        'regular expression with a specified replacement string. Specified options
        'modify the matching operation.
        <SqlFunction(DataAccess:=DataAccessKind.None, IsDeterministic:=True,
            IsPrecise:=True, Name:="RegExReplacex",
            SystemDataAccess:=SystemDataAccessKind.None)>
        Public Shared Function RegExReplacex(ByVal pattern As SqlString,
                                            ByVal input As SqlString,
                                            ByVal replacement As SqlString,
                                            ByVal Options As SqlInt32) _
              As SqlString
            If (input.IsNull OrElse pattern.IsNull) Then
                Return SqlString.Null
            End If
            Dim RegexOption As New System.Text.RegularExpressions.RegexOptions
            RegexOption = Options
            Return New SqlString(Regex.Replace(input.Value, pattern.Value,
                  replacement.Value, RegexOption))
        End Function
        '----------end of RegexReplace function
        '
        '         RegExMatches function
        'Searches the specified input string for all occurrences of the regular
        'expression supplied in a pattern parameter with matching options supplied
        'in an options parameter.

        <SqlFunction(DataAccess:=DataAccessKind.None, IsDeterministic:=True,
                     IsPrecise:=True, Name:="RegExMatches",
                     SystemDataAccess:=SystemDataAccessKind.None,
            FillRowMethodName:="NextMatchedRow")>
        Public Shared Function RegExMatches(ByVal pattern As SqlString,
                                             ByVal input As SqlString,
                                             ByVal Options As SqlInt32) _
                              As IEnumerable
            If (input.IsNull OrElse pattern.IsNull) Then
                Return Nothing
            End If
            Dim RegexOption As New System.Text.RegularExpressions.RegexOptions
            RegexOption = Options
            Return Regex.Matches(input.Value, pattern.Value, RegexOption)
        End Function

        Private Shared Sub NextMatchedRow(ByVal input As Object,
                  <Out()> ByRef match As SqlString,
                  <Out()> ByRef matchIndex As SqlInt32,
                  <Out()> ByRef matchLength As SqlInt32)
            Dim match2 As Match = DirectCast(input, Match)
            match = New SqlString(match2.Value)
            matchIndex = New SqlInt32(match2.Index)
            matchLength = New SqlInt32(match2.Length)
        End Sub

    End Class
End Namespace
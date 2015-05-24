Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Seminar")>
Partial Public Class Seminar
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property Id As Integer

    <Column("Seminar")>
    <StringLength(50)>
    Public Property Seminar1 As String

    <Column(TypeName:="date")>
    Public Property Datum As Date?
End Class

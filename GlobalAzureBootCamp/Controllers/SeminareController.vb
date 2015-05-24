Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports GlobalAzureBootCamp

Namespace Controllers
    Public Class SeminareController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/Seminare
        Function GetSeminar() As IQueryable(Of Seminar)
            Return db.Seminar
        End Function

        ' GET: api/Seminare/5
        <ResponseType(GetType(Seminar))>
        Function GetSeminar(ByVal id As Integer) As IHttpActionResult
            Dim seminar As Seminar = db.Seminar.Find(id)
            If IsNothing(seminar) Then
                Return NotFound()
            End If

            Return Ok(seminar)
        End Function

        ' PUT: api/Seminare/5
        <ResponseType(GetType(Void))>
        Function PutSeminar(ByVal id As Integer, ByVal seminar As Seminar) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = seminar.Id Then
                Return BadRequest()
            End If

            db.Entry(seminar).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (SeminarExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Seminare
        <ResponseType(GetType(Seminar))>
        Function PostSeminar(ByVal seminar As Seminar) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            seminar.Id = If(db.Seminar.Any(), db.Seminar.Max(Function(x) x.Id) + 1, 1)
            db.Seminar.Add(seminar)
            MyHub1.updateListe(seminar)
            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (SeminarExists(seminar.Id)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = seminar.Id}, seminar)
        End Function

        ' DELETE: api/Seminare/5
        <ResponseType(GetType(Seminar))>
        Function DeleteSeminar(ByVal id As Integer) As IHttpActionResult
            Dim seminar As Seminar = db.Seminar.Find(id)
            If IsNothing(seminar) Then
                Return NotFound()
            End If

            db.Seminar.Remove(seminar)
            db.SaveChanges()

            Return Ok(seminar)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function SeminarExists(ByVal id As Integer) As Boolean
            Return db.Seminar.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace
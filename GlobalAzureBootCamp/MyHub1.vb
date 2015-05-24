Imports Microsoft.AspNet.SignalR

Public Class MyHub1
    Inherits Hub

    Public Sub Hello()
        Clients.All.Hello()
    End Sub

    Public Shared Sub updateListe(s)
        Dim ctx = GlobalHost.ConnectionManager.GetHubContext(Of MyHub1)()
        ctx.Clients.All.addHannes(s)
    End Sub
End Class

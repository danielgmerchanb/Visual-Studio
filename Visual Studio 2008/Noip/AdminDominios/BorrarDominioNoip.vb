Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.CompilerServices
Imports System.DirectoryServices
Imports System.IO
Imports System.Diagnostics
Imports System.Threading
Imports System.Net
Imports System.Configuration
Imports System.Collections.Specialized

Public Class BorrarDominioNoip

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Listadominios"></param>
    ''' <remarks></remarks>
    Public Sub borrado_Noip(ByVal Listadominios As System.Collections.Specialized.StringCollection)

        For Each dominio As String In Listadominios

            Dim sw As New StringWriter
            Dim writer As New Jayrock.Json.JsonTextWriter(sw)
            Dim resultadoNoIP As String
            Dim resultadoNoIPError As String
            Dim resultado As String = String.Empty
            'Console.WriteLine(dominio & ": ok")

            writer.WriteStartObject()
            writer.WriteMember("cmd")
            writer.WriteValue("noipDeleteDomain")
            writer.WriteMember("email")
            writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
            writer.WriteMember("customer_id")
            writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
            writer.WriteMember("domain")
            writer.WriteValue(dominio)
            writer.WriteEndObject()
            writer.Flush()

            resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
            resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")

            If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") = -1 Then
                resultado = "Error al borrar el dominio en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Borrelo por la interfaz web!!!"
                Console.Write("Error al borrar el dominio en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Borrelo por la interfaz web!!!")
                'log("Error al borrar el dominio en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Borrelo por la interfaz web!!!")
                log(dominio & ": error - Dominio no existe!!!")

                Console.WriteLine(dominio & ": error - Dominio no existe!!!")
            Else
                Console.WriteLine(dominio & ": ok")
                log(dominio & ": ok")
            End If
        Next

        Console.Read()

    End Sub

    Public Shared Function EnviarInfoDominioNoIP(ByVal jsonText As String) As String

        Dim encoding As New ASCIIEncoding
        Dim postData As String = String.Empty
        Dim data() As Byte
        Dim myRequest As HttpWebRequest
        Dim newStream As Stream

        postData = jsonText
        data = encoding.GetBytes(postData)

        'Prepare web request...
        myRequest = WebRequest.Create(AdminDominios.My.MySettings.Default.url_NoIP)
        myRequest.Method = "POST"
        myRequest.ContentType = "text/plain"
        myRequest.ContentLength = data.Length

        Console.WriteLine(vbCrLf & "Inicia GetRequestStream: ")
        newStream = myRequest.GetRequestStream()
        'Send the data.
        Try
            Console.WriteLine(vbCrLf & "inicia newStream.Write: ")
            newStream.Write(data, 0, data.Length)
            Console.WriteLine(vbCrLf & "finaliza newStream.Write: ")
        Catch ex As Exception
            Console.WriteLine(vbCrLf & "Exception en newStream.Write: " & ex.Message)
        Finally
            newStream.Close()
        End Try

        'Receive Response
        Dim ResponseData As String = String.Empty
        Dim Response As HttpWebResponse
        Dim SR As StreamReader

        Try
            Console.WriteLine(vbCrLf & "Inicia myRequest.GetResponse: ")
            Response = myRequest.GetResponse()
            SR = New StreamReader(Response.GetResponseStream())
            ResponseData = SR.ReadToEnd()
            Console.WriteLine(vbCrLf & "Finaliza myRequest.GetResponse: ")
        Catch Wex As System.Net.WebException
            Console.WriteLine(vbCrLf & "Exception en myRequest.GetResponse: " & Wex.Message)
            SR = New StreamReader(Wex.Response.GetResponseStream())
            ResponseData = SR.ReadToEnd()
            Throw New Exception(ResponseData)
        Finally
            SR.Close()
        End Try
        Console.WriteLine(vbCrLf & "ResponseData: " & ResponseData)
        Return ResponseData
    End Function

    Private Function log(ByVal msg As String) As String

        If Directory.Exists(AdminDominios.My.MySettings.Default.StatsLogFilePath) = False Then
            Directory.CreateDirectory(AdminDominios.My.MySettings.Default.StatsLogFilePath)
        End If
        Dim logPath As String = AdminDominios.My.MySettings.Default.StatsLogFilePath
        Dim filepath As String = AdminDominios.My.MySettings.Default.LogFileName
        Try
            'logPath = logPath & portalName & ".log"
            logPath = logPath & filepath
            Dim strm As Stream = File.Open(logPath, FileMode.Append)
            Dim writer As StreamWriter = New StreamWriter(strm)
            msg = vbCrLf + DateTime.Now.ToString() + " - Mensaje: " + msg + "\n"
            writer.Write(msg)
            writer.Close()
        Catch ex As Exception
        End Try
        Return "ok"

    End Function

End Class

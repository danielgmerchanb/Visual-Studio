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

Public Class CrearDominioNoip

    Public Sub Creacion_Noip(ByVal Listadominios As System.Collections.Specialized.StringCollection, ByVal infoMX As String)

        For Each dominio As String In Listadominios

            Dim Res As String = String.Empty
            Res = NOIP(dominio, infoMX, AdminDominios.My.MySettings.Default.IPSitioWeb, True)

            If String.IsNullOrEmpty(Res) Then
                Console.WriteLine("Creacion de dominio: " & dominio & ": ok")
                log(dominio & ": ok")
            Else
                Console.WriteLine("Creacion de dominio: " & dominio & " -- " & Res)
                log(dominio & ": No se pudo crear")
            End If
        Next

        Console.Read()

    End Sub

    Public Function NOIP(ByVal nombreDominioFinal As String, ByVal infoMX As String, _
                             ByVal IPSitioWeb As String, ByVal boolMX As Boolean) As String

        Dim sw As New StringWriter
        Dim writer As New Jayrock.Json.JsonTextWriter(sw)
        Dim resultadoNoIP As String
        Dim resultadoNoIPError As String
        Dim resultado As String = String.Empty

        writer.WriteStartObject()
        writer.WriteMember("cmd")
        writer.WriteValue("noipAddDomain")
        writer.WriteMember("email")
        writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
        writer.WriteMember("customer_id")
        writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
        writer.WriteMember("domain")
        writer.WriteValue(nombreDominioFinal)
        writer.WriteMember("package")
        writer.WriteValue("plus")
        writer.WriteMember("default_ip")
        writer.WriteValue(IPSitioWeb)
        writer.WriteEndObject()
        writer.Flush()

        resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
        resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
        If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
            'Configurar el registro MX y adicionarlo al grupo de DominiosPropios
            sw = New StringWriter
            writer = New Jayrock.Json.JsonTextWriter(sw)
            'noipModifyHost
            writer.WriteStartObject()
            writer.WriteMember("cmd")
            writer.WriteValue("noipModifyHost")
            writer.WriteMember("email")
            writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
            writer.WriteMember("customer_id")
            writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
            writer.WriteMember("host")
            writer.WriteValue("-")
            writer.WriteMember("domain")
            writer.WriteValue(nombreDominioFinal)
            writer.WriteMember("ip")
            writer.WriteValue(IPSitioWeb)
            If boolMX = True Then
                writer.WriteMember("mx")
                writer.WriteStartArray()
                'Agregado AGV
                If infoMX = AdminDominios.My.MySettings.Default.infoMXEveryOne1 Then
                    writer.WriteValue(AdminDominios.My.MySettings.Default.infoMXEveryOne1)
                    writer.WriteValue(AdminDominios.My.MySettings.Default.infoMXEveryOne2)
                Else
                    writer.WriteValue(infoMX)
                End If
                writer.WriteEndArray()
            End If
            If IPSitioWeb = AdminDominios.My.MySettings.Default.IPSitioWeb_Infoplus Then
                writer.WriteMember("group_name")
                writer.WriteValue(AdminDominios.My.MySettings.Default.grupoInfoPlus_NoIP)
                writer.WriteEndObject()
                ' no se encuentra la referencia
            ElseIf IPSitioWeb = AdminDominios.My.MySettings.Default.IPReadServer Then
                writer.WriteMember("group_name")
                ' no se encuentra la referencia
                writer.WriteValue(AdminDominios.My.MySettings.Default.grupoAdminSites_NoIP)
                writer.WriteEndObject()
            Else
                writer.WriteMember("group_name")
                writer.WriteValue(AdminDominios.My.MySettings.Default.grupoDominios_NoIP)
                writer.WriteEndObject()
            End If
            writer.Flush()
            resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
            resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
            If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
                'Configurar el Alias de WWW
                sw = New StringWriter
                writer = New Jayrock.Json.JsonTextWriter(sw)
                'noipAddCname
                writer.WriteStartObject()
                writer.WriteMember("cmd")
                writer.WriteValue("noipAddCname")
                writer.WriteMember("email")
                writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                writer.WriteMember("customer_id")
                writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                writer.WriteMember("domain")
                writer.WriteValue(nombreDominioFinal)
                writer.WriteMember("host")
                writer.WriteValue("www")
                writer.WriteMember("target")
                writer.WriteValue(nombreDominioFinal)
                writer.WriteEndObject()
                writer.Flush()
                resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
                resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
                If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
                    If boolMX = True Then
                        'Configurar el Alias de correo
                        sw = New StringWriter
                        writer = New Jayrock.Json.JsonTextWriter(sw)
                        If infoMX = AdminDominios.My.MySettings.Default.infoMXEveryOne1 Then
                            'Agregado AGV
                            'noipAddCname
                            writer.WriteStartObject()
                            writer.WriteMember("cmd")
                            writer.WriteValue("noipAddCname")
                            writer.WriteMember("email")
                            writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                            writer.WriteMember("customer_id")
                            writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                            writer.WriteMember("domain")
                            writer.WriteValue(nombreDominioFinal)
                            writer.WriteMember("host")
                            writer.WriteValue("correo")
                            writer.WriteMember("target")
                            writer.WriteValue(AdminDominios.My.MySettings.Default.SitioInfoMXEveryOne)
                            writer.WriteEndObject()
                            writer.Flush()
                        Else
                            'noipAddCname
                            writer.WriteStartObject()
                            writer.WriteMember("cmd")
                            writer.WriteValue("noipAddCname")
                            writer.WriteMember("email")
                            writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                            writer.WriteMember("customer_id")
                            writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                            writer.WriteMember("domain")
                            writer.WriteValue(nombreDominioFinal)
                            writer.WriteMember("host")
                            writer.WriteValue("correo")
                            writer.WriteMember("target")
                            writer.WriteValue(infoMX)
                            writer.WriteEndObject()
                            writer.Flush()
                        End If
                        resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
                        resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
                        'Configurar el Cname webmail para EveryOne
                        If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
                            If infoMX = AdminDominios.My.MySettings.Default.infoMXEveryOne1 Then
                                'Configurar el Alias de pop para EveryOne
                                sw = New StringWriter
                                writer = New Jayrock.Json.JsonTextWriter(sw)
                                'Configurar el Alias de webmail para Colombia
                                'noipAddCname
                                writer.WriteStartObject()
                                writer.WriteMember("cmd")
                                writer.WriteValue("noipAddCname")
                                writer.WriteMember("email")
                                writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                                writer.WriteMember("customer_id")
                                writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                                writer.WriteMember("domain")
                                writer.WriteValue(nombreDominioFinal)
                                writer.WriteMember("host")
                                writer.WriteValue("webmail")
                                writer.WriteMember("target")
                                writer.WriteValue(AdminDominios.My.MySettings.Default.SitioInfoMXEveryOne)
                                writer.WriteEndObject()
                                writer.Flush()
                            End If
                        End If
                        resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
                        resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
                        'fin configuracion de el Cname webmail para EveryOne
                        If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
                            'Configurar los Cnames de pop, smtp, imap para EveryOne
                            If infoMX = AdminDominios.My.MySettings.Default.infoMXEveryOne1 Then
                                'Configurar el Alias de pop para EveryOne
                                sw = New StringWriter
                                writer = New Jayrock.Json.JsonTextWriter(sw)
                                'noipAddCname
                                writer.WriteStartObject()
                                writer.WriteMember("cmd")
                                writer.WriteValue("noipAddCname")
                                writer.WriteMember("email")
                                writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                                writer.WriteMember("customer_id")
                                writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                                writer.WriteMember("domain")
                                writer.WriteValue(nombreDominioFinal)
                                writer.WriteMember("host")
                                writer.WriteValue("pop")
                                writer.WriteMember("target")
                                writer.WriteValue(AdminDominios.My.MySettings.Default.infoPopEveryOne)
                                writer.WriteEndObject()
                                writer.Flush()
                                resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
                                resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
                                If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
                                    'Configurar el Alias de smtp para Everyone
                                    sw = New StringWriter
                                    writer = New Jayrock.Json.JsonTextWriter(sw)
                                    'noipAddCname
                                    writer.WriteStartObject()
                                    writer.WriteMember("cmd")
                                    writer.WriteValue("noipAddCname")
                                    writer.WriteMember("email")
                                    writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                                    writer.WriteMember("customer_id")
                                    writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                                    writer.WriteMember("domain")
                                    writer.WriteValue(nombreDominioFinal)
                                    writer.WriteMember("host")
                                    writer.WriteValue("smtp")
                                    writer.WriteMember("target")
                                    writer.WriteValue(AdminDominios.My.MySettings.Default.infoSmtpEveryOne)
                                    writer.WriteEndObject()
                                    writer.Flush()
                                    resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
                                    resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
                                    If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
                                        'Configurar el Alias de imap para Everyone
                                        sw = New StringWriter
                                        writer = New Jayrock.Json.JsonTextWriter(sw)
                                        'noipAddCname
                                        writer.WriteStartObject()
                                        writer.WriteMember("cmd")
                                        writer.WriteValue("noipAddCname")
                                        writer.WriteMember("email")
                                        writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                                        writer.WriteMember("customer_id")
                                        writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                                        writer.WriteMember("domain")
                                        writer.WriteValue(nombreDominioFinal)
                                        writer.WriteMember("host")
                                        writer.WriteValue("imap")
                                        writer.WriteMember("target")
                                        writer.WriteValue(AdminDominios.My.MySettings.Default.infoImapEveryOne)
                                        writer.WriteEndObject()
                                        writer.Flush()
                                        resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
                                        resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
                                        If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") = -1 Then
                                            resultado = "Error al Configurar el Alias de imap para Everyone en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
                                        End If
                                    Else
                                        resultado = "Error al Configurar el Alias de smtp para Everyone en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
                                    End If
                                Else
                                    resultado = "Error al Configurar el Alias de pop para Everyone en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
                                End If
                            End If
                        Else
                            resultado = "Error al configurar el Alias de correo en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
                        End If
                        If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
                            If infoMX = AdminDominios.My.MySettings.Default.infoMXBrasil Then
                                'Configurar el Alias de webmail para Brasil
                                sw = New StringWriter
                                writer = New Jayrock.Json.JsonTextWriter(sw)
                                'noipAddCname
                                writer.WriteStartObject()
                                writer.WriteMember("cmd")
                                writer.WriteValue("noipAddCname")
                                writer.WriteMember("email")
                                writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                                writer.WriteMember("customer_id")
                                writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                                writer.WriteMember("domain")
                                writer.WriteValue(nombreDominioFinal)
                                writer.WriteMember("host")
                                writer.WriteValue("webmail")
                                writer.WriteMember("target")
                                writer.WriteValue(AdminDominios.My.MySettings.Default.infoWebmailBrasil)
                                writer.WriteEndObject()
                                writer.Flush()
                                resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
                                resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
                                If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
                                    'Configurar el Alias de pop para Brasil
                                    sw = New StringWriter
                                    writer = New Jayrock.Json.JsonTextWriter(sw)
                                    'noipAddCname
                                    writer.WriteStartObject()
                                    writer.WriteMember("cmd")
                                    writer.WriteValue("noipAddCname")
                                    writer.WriteMember("email")
                                    writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                                    writer.WriteMember("customer_id")
                                    writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                                    writer.WriteMember("domain")
                                    writer.WriteValue(nombreDominioFinal)
                                    writer.WriteMember("host")
                                    writer.WriteValue("pop")
                                    writer.WriteMember("target")
                                    writer.WriteValue(AdminDominios.My.MySettings.Default.infoPopBrasil)
                                    writer.WriteEndObject()
                                    writer.Flush()
                                    resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
                                    resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
                                    If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") <> -1 Then
                                        'Configurar el Alias de smtp para Brasil
                                        sw = New StringWriter
                                        writer = New Jayrock.Json.JsonTextWriter(sw)
                                        'noipAddCname
                                        writer.WriteStartObject()
                                        writer.WriteMember("cmd")
                                        writer.WriteValue("noipAddCname")
                                        writer.WriteMember("email")
                                        writer.WriteValue(AdminDominios.My.MySettings.Default.email_NoIP)
                                        writer.WriteMember("customer_id")
                                        writer.WriteValue(AdminDominios.My.MySettings.Default.customerid_NoIP)
                                        writer.WriteMember("domain")
                                        writer.WriteValue(nombreDominioFinal)
                                        writer.WriteMember("host")
                                        writer.WriteValue("smtp")
                                        writer.WriteMember("target")
                                        writer.WriteValue(AdminDominios.My.MySettings.Default.infoSmtpBrasil)
                                        writer.WriteEndObject()
                                        writer.Flush()
                                        resultadoNoIP = EnviarInfoDominioNoIP(sw.GetStringBuilder().ToString())
                                        resultadoNoIPError = Replace(resultadoNoIP, sw.GetStringBuilder().ToString(), "")
                                        If resultadoNoIPError.IndexOf("{""result"":""1"",""error"":null}") = -1 Then
                                            resultado = "Error al configurar el Alias de smtp para Brasil en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
                                        End If
                                    Else
                                        resultado = "Error al configurar el Alias de pop para Brasil en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
                                    End If
                                Else
                                    resultado = "Error al configurar el Alias de webmail para Brasil en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
                                End If
                            End If
                        Else
                            resultado = "Error al configurar el Alias de correo en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
                        End If
                    End If
                Else
                    resultado = "Error al configurar el Alias de www en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
                End If
            Else
                resultado = "Error al configurar el MX o el Grupo en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
            End If
        Else
            resultado = "Error al configurar el dominio en NoIP: " & Replace(resultadoNoIPError, "<br>{""result"":""0"",""error"":", "") & ". Configurelo por la interfaz web!!!"
        End If
        Return resultado
    End Function


    Public Shared Function EnviarInfoDominioNoIP(ByVal jsonText As String) As String

        Dim encoding As New ASCIIEncoding
        Dim postData As String = String.Empty
        Dim data() As Byte
        Dim httpWebRequest As HttpWebRequest
        Dim stream As Stream

        postData = jsonText
        data = encoding.GetBytes(postData)

        'Prepare web request...
        httpWebRequest = WebRequest.Create(AdminDominios.My.MySettings.Default.url_NoIP)
        httpWebRequest.Method = "POST"
        httpWebRequest.ContentType = "text/plain"
        httpWebRequest.ContentLength = data.Length

        Console.WriteLine(vbCrLf & "Inicia GetRequestStream: ")
        stream = httpWebRequest.GetRequestStream()
        'Send the data.
        Try
            Console.WriteLine(vbCrLf & "inicia newStream.Write: ")
            stream.Write(data, 0, data.Length)
            Console.WriteLine(vbCrLf & "finaliza newStream.Write: ")
        Catch ex As Exception
            Console.WriteLine(vbCrLf & "Exception en newStream.Write: " & ex.Message)
        Finally
            stream.Close()
        End Try

        'Receive Response
        Dim ResponseData As String = String.Empty
        Dim Response As HttpWebResponse
        Dim SR As StreamReader

        Try
            Console.WriteLine(vbCrLf & "Inicia myRequest.GetResponse: ")
            Response = httpWebRequest.GetResponse()
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

    Public Sub SendUrlRequest(ByVal url As String)
        'Create an HTTP request
        Dim httpRequest As WebRequest = WebRequest.Create(url)
        Dim httpResponse As WebResponse = httpRequest.GetResponse()
        Dim stream As Stream = httpResponse.GetResponseStream()
        Dim reader As New StreamReader(stream)

        ' Make the request and print the result
        reader.ReadToEnd()
        reader.Close()
    End Sub

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

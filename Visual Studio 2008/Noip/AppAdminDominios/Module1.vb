Module Module1

    Sub Main()

        Dim accion As String
        accion = AppAdminDominios.My.MySettings.Default.Accion.ToString().ToUpper

        If accion.Equals("B") Then
            Dim borrar As New AdminDominios.BorrarDominioNoip
            borrar.borrado_Noip(AppAdminDominios.My.MySettings.Default.DominioAborrarOconfigurar)
        ElseIf accion.Equals("C") Then
            Dim crear As New AdminDominios.CrearDominioNoip
            crear.Creacion_Noip(AppAdminDominios.My.MySettings.Default.DominioAborrarOconfigurar, AppAdminDominios.My.MySettings.Default.infoMX)
        ElseIf accion.Equals("M") Then
            Dim modificar As New AdminDominios.ModificarIpDominio
            modificar.ModificarIp_Noip(AppAdminDominios.My.MySettings.Default.DominioAborrarOconfigurar, AppAdminDominios.My.MySettings.Default.infoMX)
        End If

    End Sub

End Module

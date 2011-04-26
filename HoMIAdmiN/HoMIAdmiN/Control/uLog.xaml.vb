﻿Partial Public Class uLog
    Public Event CloseMe(ByVal MyObject As Object)

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles BtnRefresh.Click
        TxtLog.Text = Nothing
        RefreshLog()
    End Sub

    Private Sub RefreshLog()
        If Window1.IsConnect = True Then TxtLog.Text = Window1.myService.ReturnLog()
    End Sub


    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        RefreshLog()

        If Window1.IsConnect = True Then
            TxtFile.Text = Window1.myService.GetMaxFileSizeLog
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles BtnClose.Click
        If IsNumeric(TxtFile.Text) = False Or CDbl(TxtFile.Text) < 1 Then
            MessageBox.Show("Veuillez saisir un numérique et positif pour la taille max du fichier de log!", "Admin", MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If
        If Window1.IsConnect = True And IsNumeric(TxtFile.Text) Then
            Window1.myService.SetMaxFileSizeLog(CDbl(TxtFile.Text))
        End If
        RaiseEvent CloseMe(Me)
    End Sub
End Class

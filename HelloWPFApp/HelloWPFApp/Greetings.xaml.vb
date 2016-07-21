Class MainWindow
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        If radioButton1.IsChecked = True Then
            MessageBox.Show("Hello.")
        Else radioButton2.IsChecked = True
            MessageBox.Show("Goodbye.")
        End If
    End Sub
End Class

﻿Imports System.Data.OleDb
Public Class delete_milking

    Private Sub delete_milking_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim adapt As OleDbDataAdapter
        Dim adaptt As OleDbDataAdapter
        Dim dt As DataTable
        Dim dt1 As DataTable
        Try
            adapt = New OleDbDataAdapter("select * from MILKING", con)
            adaptt = New OleDbDataAdapter("select milking_id from milking", con)
            dt = New DataTable
            dt1 = New DataTable
            adapt.Fill(dt)
            adaptt.Fill(dt1)
            DataGridView1.DataSource = dt
            ComboBox1.DataSource = dt1
            ComboBox1.DisplayMember = "milking_id"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    If Me.WindowState <> FormWindowState.Minimized Then
    '        Me.DataGridView1.Size = New Size(Me.ClientRectangle.Width - 100, Me.ClientRectangle.Height - 100)
    '    End If
    'End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim id As String = Trim(ComboBox1.Text)
        If ComboBox1.Text = "" Then
            MsgBox("kindly enter milk id")
            ComboBox1.Focus()
            Exit Sub
        End If

        Dim com As OleDbCommand
        com = New OleDbCommand
        Try
            com.Connection = con
            com.CommandText = "delete from milking where milking_id = '" & id & "' "
            com.ExecuteNonQuery()
            MsgBox("DATA DELETED SUCCESSFULLY")

            'repeated====
            Dim adapt As OleDbDataAdapter
            Dim adaptt As OleDbDataAdapter
            Dim dt As DataTable
            Dim dt1 As DataTable
            Try
                adapt = New OleDbDataAdapter("select * from milking", con)
                adaptt = New OleDbDataAdapter("select milking_id from milking", con)
                dt = New DataTable
                dt1 = New DataTable
                adapt.Fill(dt)
                adaptt.Fill(dt1)
                DataGridView1.DataSource = dt
                ComboBox1.DataSource = dt1
                ComboBox1.DisplayMember = "milking_id"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'over----------
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class
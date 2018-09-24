Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.Odbc
Public Class frmInfo
    Dim con As New OdbcConnection("DSN=hxcs")
    Dim cmd As OdbcCommand
    Dim oreader As OdbcDataReader
    Dim query As String
    Dim id As String
    Dim count As Integer
    Dim arrSNames(5) As TextBox
    Dim arrGrade(5) As ComboBox
    Dim arrThirdClass(5) As ComboBox
    Dim arrchNames(5) As TextBox
    Dim arrG(5) As ComboBox
    Dim arrBday(5) As TextBox
    Dim search As String
    Dim arrS(5) As Button
    Dim arrD(5) As Button
    Dim arrStudentFee(5) As TextBox
    Dim arrThirdClassFee(5) As TextBox
    Dim registered As Boolean
    Dim Student1Fee As Single
    Dim Student2Fee As Single
    Dim ThirdClass As Single
    Dim Registration As Single
    Dim ParentDuty As Single
    Dim Discount As Single
    Dim teachers(50) As Integer
    Dim num As Integer
    Dim teacherdiscount As Single
    Dim high As Single
    Dim tuition As Single
    Dim dueamount As Single
    Dim paidamount As Single
    Dim balance As Single
    Dim checknum As String
    Dim comment As String
    Dim numfamilies As Integer
    Dim familyid As Integer
    Dim delete As Integer
    Dim removeteacher As Integer
    Dim index As Integer
    Dim user As String
    Dim action As String
    Dim studentid(5) As Integer
    Dim deadlinestr As String
    Dim deadlinedate As DateTime
    Dim rday As Integer
    Dim ryear As Integer
    Dim rmonth As Integer
    Dim slash1 As Integer
    Dim slash2 As Integer
    Dim x As Integer


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        x = 1
        user = frmlogin.txtUser.Text
        If user = "admin" Then
            btnshowlog.Visible = True
            btnStartNew.Visible = True
        End If
        Setcontrolarray()
        Dim con As New OdbcConnection("DSN=hxcs")
        con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"
        Try
            'DISPLAYING ALL FAMILY ID
            con.Open()
            query = "select * from hxcs.family_info ORDER BY Family_ID"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            numfamilies = 0
            While oreader.Read
                id = oreader.GetInt32(0)
                lstID.Items.Insert(0, id)
                If id > numfamilies Then
                    numfamilies = id
                End If
            End While
            con.Close()
            'FINDING ALL TEACHERS
            con.Open()
            query = "select * from hxcs.teacher"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            num = 1
            While oreader.Read
                id = oreader.GetString(4)
                teachers(num) = Val(id)
                num = num + 1
            End While
            con.Close()
            'FINDING ALL CLASSES
            con.Open()
            query = "select * from hxcs.grade"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            While oreader.Read
                id = oreader.GetString(0)
                For i = 1 To 5
                    arrGrade(i).Items.Add(id)
                Next
            End While
            con.Close()
            'FINDING ALL THIRD CLASSES
            con.Open()
            query = "select * from hxcs.third_class"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            While oreader.Read
                id = oreader.GetString(0)
                For i = 1 To 5
                    arrThirdClass(i).Items.Add(id)
                Next
            End While
            con.Close()
            'GETTING THE FEE VALUES
            con.Open()
            query = "select * from hxcs.fee_table"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            oreader.Read()
            Student1Fee = oreader.GetString(1)
            oreader.Read()
            Student2Fee = oreader.GetString(1)
            oreader.Read()
            oreader.Read()
            ThirdClass = oreader.GetString(1)
            oreader.Read()
            Registration = oreader.GetString(1)
            oreader.Read()
            ParentDuty = oreader.GetString(1)
            oreader.Read()
            Discount = oreader.GetString(1)
            deadlinestr = oreader.GetString(2)

            For i = 1 To Len(deadlinestr)
                If Mid(deadlinestr, i, 1) = "/" And x = 1 Then
                    x = 2
                    slash1 = i
                ElseIf Mid(deadlinestr, i, 1) = "/" And x = 2 Then
                    slash2 = i
                    x = 1
                End If
            Next
            rmonth = Val(Mid(deadlinestr, 1, slash1 - 1))
            rday = Val(Mid(deadlinestr, slash1 + 1, slash2 - 1))
            ryear = Val(Mid(deadlinestr, slash2 + 1, Len(deadlinestr) - slash2))
            deadlinedate = New DateTime(ryear, rmonth, rday)

            con.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            con.Dispose()
        End Try
        lstID.SelectedIndex = 0
        For i = 1 To 5
            arrS(i).Enabled = False
            arrG(i).Items.Add("")
            arrG(i).Items.Add("M")
            arrG(i).Items.Add("F")
        Next
        btnUpdate.Enabled = False
        btnUpdate.ForeColor = Color.Gray

        btnupdatepayment.Enabled = False
        btnupdatepayment.ForeColor = Color.Gray
    End Sub

    Sub Setcontrolarray()
        arrSNames(1) = txtSName1
        arrSNames(2) = txtSName2
        arrSNames(3) = txtSName3
        arrSNames(4) = txtSName4
        arrSNames(5) = txtSName5

        arrGrade(1) = coboxGrade1
        arrGrade(2) = coboxGrade2
        arrGrade(3) = coboxGrade3
        arrGrade(4) = coboxGrade4
        arrGrade(5) = coboxGrade5

        arrThirdClass(1) = coboxThirdClass1
        arrThirdClass(2) = coboxThirdClass2
        arrThirdClass(3) = coboxThirdClass3
        arrThirdClass(4) = coboxThirdClass4
        arrThirdClass(5) = coboxThirdClass5

        arrchNames(1) = txtchName1
        arrchNames(2) = txtchName2
        arrchNames(3) = txtchName3
        arrchNames(4) = txtchName4
        arrchNames(5) = txtchName5

        arrG(1) = coboxG1
        arrG(2) = coboxG2
        arrG(3) = coboxG3
        arrG(4) = coboxG4
        arrG(5) = coboxG5

        arrBday(1) = txtBday1
        arrBday(2) = txtBday2
        arrBday(3) = txtBday3
        arrBday(4) = txtBday4
        arrBday(5) = txtBday5

        arrS(1) = btnS1
        arrS(2) = btnS2
        arrS(3) = btnS3
        arrS(4) = btnS4
        arrS(5) = btnS5

        arrD(1) = btnD1
        arrD(2) = btnD2
        arrD(3) = btnD3
        arrD(4) = btnD4
        arrD(5) = btnD5

        arrStudentFee(1) = txtSF1
        arrStudentFee(2) = txtSF2
        arrStudentFee(3) = txtSF3
        arrStudentFee(4) = txtSF4
        arrStudentFee(5) = txtSF5

        arrThirdClassFee(1) = txtThirdClassFee1
        arrThirdClassFee(2) = txtThirdClassFee2
        arrThirdClassFee(3) = txtThirdClassFee3
        arrThirdClassFee(4) = txtThirdClassFee4
        arrThirdClassFee(5) = txtThirdClassFee5
    End Sub

    Private Sub lstID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstID.SelectedIndexChanged

        Dim register As String

        Dim x As Integer
        x = 1
        teacherdiscount = 0
        balance = 0
        txtBalance.Text = balance
        paidamount = 0
        txtPaid.Text = paidamount
        registered = True
        familyid = lstID.SelectedItem
        For i = 1 To 5
            studentid(i) = 0
        Next
        For i = 1 To 5
            arrSNames(i).Clear()
            arrGrade(i).SelectedItem = "None"
            arrThirdClass(i).SelectedItem = "None"
            arrchNames(i).Clear()
            arrG(i).SelectedItem = ""
            arrBday(i).Clear()
            arrStudentFee(i).Clear()
            arrThirdClassFee(i).Clear()
            arrSNames(i).Visible = False
            arrGrade(i).Visible = False
            arrThirdClass(i).Visible = False
            arrchNames(i).Visible = False
            arrG(i).Visible = False
            arrBday(i).Visible = False
            arrS(i).Visible = False
            arrD(i).Visible = False
            arrStudentFee(i).Visible = False
            arrThirdClassFee(i).Visible = False
        Next
        Dim con As New OdbcConnection("DSN=hxcs")
        con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

        Try
            'FIND FAMILY INFORMATION
            con.open()
            query = "select * from hxcs.family_info where family_id='" & familyid & "'"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            While oreader.read
                txtFamilyID.Text = oreader.GetInt32(0)
                txtFather.Text = oreader.GetString(1)
                txtMother.Text = oreader.GetString(2)
                txtAddress.Text = oreader.GetString(3)
                txtEmail.Text = oreader.GetString(8)
                txtEmail2.Text = oreader.GetString(9)
                txtPhone.Text = oreader.GetString(7)
                txtMobile.Text = oreader.GetString(10)
                txtEContact.Text = oreader.GetString(11)
                txtEPhone.Text = oreader.GetString(12)
            End While
            con.close()
            'FIND NUMBER OF STUDENTS WITHIN A SINGLE FAMILY
            con.open()
            query = "select count(*) from hxcs.student where family_id='" & familyid & "'"
            cmd = New OdbcCommand(query, con)
            count = cmd.ExecuteScalar()
            cmd = Nothing
            For i = 1 To count
                arrSNames(i).Visible = True
                arrGrade(i).Visible = True
                arrThirdClass(i).Visible = True
                arrchNames(i).Visible = True
                arrG(i).Visible = True
                arrBday(i).Visible = True
                arrS(i).Visible = True
                arrD(i).Visible = True
                arrStudentFee(i).Visible = True
                arrThirdClassFee(i).Visible = True
            Next
            con.close()
            'FINDING STUDENT INFORMATION
            con.open()
            query = "select * from hxcs.student where family_id='" & familyid & "'"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            For i = 1 To count
                oreader.read()
                arrSNames(i).Text = oreader.GetString(0)
                arrGrade(i).SelectedItem = oreader.GetString(5)
                arrThirdClass(i).SelectedItem = oreader.GetString(8)
                arrchNames(i).Text = oreader.GetString(1)
                arrBday(i).Text = oreader.GetString(2)
                arrG(i).SelectedItem = oreader.GetString(3)
                studentid(i) = oreader.GetInt16(11)
            Next
            con.close()
            'FINDING REGISTER DATE AND PAID AMOUNT
            con.open()
            query = "select * from hxcs.fee where family_id='" & familyid & "'"
            cmd = New OdbcCommand(query, con)
            Dim sqlResult As Object = cmd.ExecuteScalar() 'DETERMINE WHETHER THERE IS INFORMATION IN THE FEE TABLE OR NOT
            If sqlResult Is Nothing Then
                txtDue.Text = ""
                txtPaid.Text = ""
                txtchecknum.Text = ""
                txtcomment.Text = ""
                balance = 0
                txtBalance.Text = ""
                con.close()
            Else
                con.Close()
                con.Open()
                query = "select * from hxcs.fee where family_id='" & familyid & "'"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                oreader.Read()
                register = oreader.GetString(10)
                paidamount = oreader.GetDecimal(8)
                checknum = oreader.GetString(9)
                comment = oreader.GetString(12)
                txtPaid.Text = paidamount
                txtchecknum.Text = checknum
                txtcomment.Text = comment

                con.Close()
            End If
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            con.dispose()
        End Try
        If register = "" Then
            txtRegisterDate.Text = "N/A"
            registered = False
            btnupdatepayment.Enabled = False
            btnupdatepayment.ForeColor = Color.Gray
            register = (DateTime.Now.ToString("MM/dd/yyyy"))
        Else
            txtRegisterDate.Text = register
            btnregister.Enabled = False
            btnregister.ForeColor = Color.Gray
        End If
        If registered = True Then
            btnupdatepayment.Enabled = True
            btnupdatepayment.ForeColor = Color.Red
        End If

        For i = 1 To Len(register)
            If Mid(register, i, 1) = "/" And x = 1 Then
                x = 2
                slash1 = i
            ElseIf Mid(register, i, 1) = "/" And x = 2 Then
                slash2 = i
                x = 1
            End If
        Next
        rmonth = Val(Mid(register, 1, slash1 - 1))
        rday = Val(Mid(register, slash1 + 1, slash2 - 1))
        ryear = Val(Mid(register, slash2 + 1, Len(register) - slash2))
        'FINDING WHETHER DISCOUNT SHOULD BE APPLIED OR NOT, DEPENDING ON REGISTER DATE
        Dim registrationdate As DateTime = New DateTime(ryear, rmonth, rday)
        Dim result As Int16 = DateTime.Compare(registrationdate, deadlinedate)
        If (result <= 0) Then
            txtDiscount.Text = Discount
        Else
            txtDiscount.Text = "0"
        End If
        'FINDING CHINESE CLASS FEE
        If arrGrade(1).SelectedItem = "" Or arrGrade(1).SelectedItem = "None" Then
            arrStudentFee(1).Text = "0"
        Else
            arrStudentFee(1).Text = Student1Fee
        End If
        If count > 1 Then
            For i = 2 To count
                If arrGrade(i).SelectedItem = "" Or arrGrade(i).SelectedItem = "None" Then
                    arrStudentFee(i).Text = "0"
                Else
                    arrStudentFee(i).Text = Student2Fee
                End If
            Next
        End If
        'FINDING THIRD CLASS FEE
        For i = 1 To count
            If arrThirdClass(i).SelectedItem = "" Or arrThirdClass(i).SelectedItem = "None" Then
                arrThirdClassFee(i).Text = "0"
            Else
                arrThirdClassFee(i).Text = ThirdClass
            End If
        Next
        'MISC STUDENTFEE CHECK
        For i = 1 To count
            If arrStudentFee(i).Text <> "0" Then
                arrStudentFee(i).Text = Student1Fee
                Exit For
            End If
        Next
        txtRegistrationFee.Text = registration
        txtParentDuty.Text = ParentDuty
        For i = 1 To num - 1
            If familyid = teachers(i) Then
                cboxteacher.Checked = True
                high = 0
                For j = 1 To count
                    If Val(arrStudentFee(j).Text) > high Then
                        high = Val(arrStudentFee(j).Text)
                    End If
                Next
                teacherdiscount = high / 2
                high = 0
                For j = 1 To count
                    If Val(arrThirdClassFee(j).Text) > high Then
                        high = Val(arrThirdClassFee(j).Text)
                    End If
                Next
                teacherdiscount = teacherdiscount + high / 2
                txtteacherdiscount.Text = teacherdiscount
                Label27.Visible = True

                txtteacherdiscount.Visible = True
                Exit For
            Else
                teacherdiscount = 0
                cboxteacher.Checked = False
                Label27.Visible = False

                txtteacherdiscount.Visible = False
            End If
        Next
        'FINDING DUE AMOUNT AND BALANCE
        dueamount = 0
        For i = 1 To count
            dueamount = dueamount + Val(arrStudentFee(i).Text) + Val(arrThirdClassFee(i).Text)
        Next
        tuition = dueamount
        dueamount = dueamount + Val(txtParentDuty.Text) + Val(txtRegistrationFee.Text) - teacherdiscount - Val(txtDiscount.Text)
        txtDue.Text = dueamount
        balance = dueamount - paidamount
        txtBalance.Text = balance
        If txtRegisterDate.Text = "N/A" Then
            btnregister.Enabled = True
            btnregister.ForeColor = Color.Red
        Else
            btnregister.Enabled = False
            btnregister.ForeColor = Color.Gray
        End If
        For i = 1 To 5
            arrS(i).Enabled = False
            arrS(i).ForeColor = Color.Red
        Next
        btnUpdate.Enabled = False
        btnUpdate.ForeColor = Color.Gray
        btnupdatepayment.Enabled = False
        btnupdatepayment.ForeColor = Color.Gray
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim query1 As String
        lstID.Items.Clear()
        Dim con As New OdbcConnection("DSN=hxcs")
        con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

        search = "%" & txtSearch.Text & "%"
        MessageBox.Show(search)
        Try
            con.open()
            query1 = "SELECT DISTINCT Family_Info.Family_ID FROM Family_Info INNER JOIN Student ON Family_Info.Family_ID = Student.Family_ID WHERE (((Family_Info.Mother) Like '" & search & "')) OR (((Family_Info.Father) Like '" & search & "')) OR (((Name) Like '" & search & "')) ORDER BY Family_ID"
            cmd = New OdbcCommand(query1, con)
            oreader = cmd.ExecuteReader()
            While oreader.read
                id = oreader.GetString(0)
                lstID.Items.Insert(0, id)
            End While

            con.close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim emailpass1 As Boolean
        Dim emailpass2 As Boolean
        emailpass1 = False
        emailpass2 = False

        If txtEmail.Text <> "" Then
            For i = 1 To Len(txtEmail.Text)
                If Mid(txtEmail.Text, i, 1) = "@" Then
                    emailpass1 = True
                    Exit For
                End If
            Next
        Else
            emailpass1 = True
        End If
        If txtEmail2.Text <> "" Then
            For i = 1 To Len(txtEmail2.Text)
                If Mid(txtEmail2.Text, i, 1) = "@" Then
                    emailpass2 = True
                    Exit For
                End If
            Next
        Else
            emailpass2 = True
        End If
        If emailpass2 = True And emailpass1 = True Then
            Dim con As New OdbcConnection("DSN=hxcs")
            con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

            Try
                con.open()
                query = "update hxcs.family_info set father='" & txtFather.Text & "',mother='" & txtMother.Text & "',address='" & txtAddress.Text & "',Phone='" & txtPhone.Text & "',Email='" & txtEmail.Text & "',Email2='" & txtEmail2.Text & "',Mobile='" & txtMobile.Text & "',Emergency_contact='" & txtEContact.Text & "',Emerg_Phone='" & txtEPhone.Text & "' where family_id='" & familyid & "' "
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                MsgBox("Information Updated")
                con.close()
                action = Replace(query, "'", " ")
                con.open()
                query = "insert into hxcs.log (ad, at, user, action) values ('" & DateTime.Now.ToString("yyyy/MM/dd") & "', '" & DateTime.Now.ToString("HH:mm") & " ','" & user & "','" & action & "')"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                txtLog.Text = query
                con.close()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                con.dispose()
            End Try
            btnUpdate.Enabled = False
            btnUpdate.ForeColor = Color.Gray
        Else
            If emailpass2 = False Then
                MsgBox("Please enter valid email.")
            End If
            If emailpass1 = False Then
                MsgBox("Please enter valid email.")
            End If
        End If
    End Sub

    Sub classchange()
        'FINDING CHINESE CLASS FEE
        If arrGrade(1).SelectedItem = "" Or arrGrade(1).SelectedItem = "None" Then
            arrStudentFee(1).Text = "0"
        Else
            arrStudentFee(1).Text = Student1Fee
        End If
        If count > 1 Then
            For i = 2 To count
                If arrGrade(i).SelectedItem = "" Or arrGrade(i).SelectedItem = "None" Then
                    arrStudentFee(i).Text = "0"
                Else
                    arrStudentFee(i).Text = Student2Fee
                End If
            Next
        End If
        'FINDING THIRD CLASS FEE
        For i = 1 To count
            If arrThirdClass(i).SelectedItem = "" Or arrThirdClass(i).SelectedItem = "None" Then
                arrThirdClassFee(i).Text = "0"
            Else
                arrThirdClassFee(i).Text = ThirdClass
            End If
        Next
        'MISC STUDENTFEE CHECK
        For i = 1 To count
            If arrStudentFee(i).Text <> "0" Then
                arrStudentFee(i).Text = Student1Fee
                Exit For
            End If
        Next
        'CHECKING FOR TEACHER DISCOUNT
        If cboxteacher.Checked = True Then
            high = 0
            For j = 1 To count
                If Val(arrStudentFee(j).Text) > high Then
                    high = Val(arrStudentFee(j).Text)
                End If
            Next
            teacherdiscount = high / 2
            high = 0
            For j = 1 To count
                If Val(arrThirdClassFee(j).Text) > high Then
                    high = Val(arrThirdClassFee(j).Text)
                End If
            Next
            teacherdiscount = teacherdiscount + high / 2
            txtteacherdiscount.Text = teacherdiscount
            Label27.Visible = True

            txtteacherdiscount.Visible = True
        End If
        dueamount = 0
        For i = 1 To count
            dueamount = dueamount + Val(arrStudentFee(i).Text) + Val(arrThirdClassFee(i).Text)
        Next
        tuition = dueamount
        dueamount = dueamount + Val(txtParentDuty.Text) + Val(txtRegistrationFee.Text) - teacherdiscount - Val(txtDiscount.Text)
        txtDue.Text = dueamount
        balance = dueamount - paidamount
        txtBalance.Text = balance

    End Sub

    Sub UpdateStudent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnS1.Click, btnS2.Click, btnS3.Click, btnS4.Click, btnS5.Click
        Dim birthdaypass As Boolean
        birthdaypass = True
        Dim s As Button = sender
        index = Mid(s.Name, 5, 1)
        If arrBday(index).Text <> "" Then 'Checking validity of birthday
            For i = 1 To Len(arrBday(index).Text)
                If Mid(arrBday(index).Text, i, 1) = "/" And x = 1 Then
                    slash1 = i
                    x = 2
                ElseIf Mid(arrBday(index).Text, i, 1) = "/" And x = 2 Then
                    slash2 = i
                    x = 1
                End If
            Next
            If Val(Mid(arrBday(index).Text, 1, slash1 - 1)) <= 0 Or Val(Mid(arrBday(index).Text, 1, slash1 - 1)) > 12 Then
                birthdaypass = False
            ElseIf Val(Mid(arrBday(index).Text, slash1 + 1, slash2 - slash1 - 1)) <= 0 Or Val(Mid(arrBday(index).Text, slash1 + 1, slash2 - slash1 - 1)) > 31 Then
                birthdaypass = False
            End If
        Else
            birthdaypass = True
        End If
        If birthdaypass = True Then 'Updating student info
            Dim con As New OdbcConnection("DSN=hxcs")
            con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"
            Try
                con.Open()
                query = "update hxcs.student set name='" & arrSNames(index).Text & "',chname='" & arrchNames(index).Text & "',Birthday='" & arrBday(index).Text & "',Gender='" & arrG(index).SelectedItem & "',Grade='" & arrGrade(index).SelectedItem & "',Third_class='" & arrThirdClass(index).SelectedItem & "' where family_id='" & familyid & "' and studentid='" & studentid(index) & "'"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                MsgBox("Information Updated")
                txtLog.Text = query
                con.Close()
                action = Replace(query, "'", " ")
                con.Open()
                query = "insert into hxcs.log (ad, at, user, action) values ('" & DateTime.Now.ToString("yyyy/MM/dd") & "', '" & DateTime.Now.ToString("HH:mm") & " ','" & user & "', '" & action & " ')"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                con.Close()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                con.Dispose()
            End Try
            arrS(index).Enabled = False
            If registered = True Then 'updating tuition and due amount in case changed
                con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"
                Try
                    con.Open()
                    query = "update hxcs.fee set due_amt='" & txtDue.Text & "', tuition='" & tuition & "' where family_id= '" & familyid & "'"
                    cmd = New OdbcCommand(query, con)
                    oreader = cmd.ExecuteReader()
                    con.Close()
                    action = Replace(query, "'", " ")
                    con.Open()
                    query = "insert into hxcs.log (ad, at, user, action) values ('" & DateTime.Now.ToString("yyyy/MM/dd") & "', '" & DateTime.Now.ToString("HH:mm") & " ','" & user & "','" & action & "')"
                    cmd = New OdbcCommand(query, con)
                    oreader = cmd.ExecuteReader()
                    txtLog.Text = query
                    con.Close()
                Catch ex As MySqlException
                    MsgBox(ex.Message)
                Finally
                    con.Dispose()
                End Try
            End If
        Else
            MsgBox("Please enter a valid birthdate in the format MM/dd/YYYY")
        End If
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstID.Items.Clear()
        Dim con As New OdbcConnection("DSN=hxcs")
        con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

        Try
            'DISPLAYING ALL FAMILY ID
            con.open()
            query = "select Family_id from hxcs.family_info ORDER BY Family_ID"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            While oreader.read
                id = oreader.GetString(0)
                lstID.Items.Insert(0, id)
            End While
            con.close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            con.dispose()
        End Try
        txtSearch.Clear()
    End Sub

    Private Sub btnregister_Click(sender As Object, e As EventArgs) Handles btnregister.Click
        If txtchecknum.Text <> "" And txtPaid.Text <> "" Then
            Dim con As New OdbcConnection("DSN=hxcs")
            con.ConnectionString =
                  "Dsn=hxcs;" +
                  "Uid=root;" +
                  "Pwd=school;"
            Try
                con.Open()
                query = "insert into hxcs.FEE (family_id, register_date, Tuition, Duty_Hold, Discount, Registration, due_amt, check_number, paid_amt, comment) values ('" & familyid & "', '" & DateTime.Now.ToString("MM/dd/yyyy") & " ', '" & tuition & " ', '" & txtParentDuty.Text & " ', '" & txtDiscount.Text & " ', '" & txtRegistrationFee.Text & " ', '" & txtDue.Text & " ', '" & txtchecknum.Text & " ', '" & txtPaid.Text & " ', '" & txtcomment.Text & " ')"
                'MessageBox.Show(query)
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                txtRegisterDate.Text = (DateTime.Now.ToString("MM/dd/yyyy"))
                con.Close()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                con.Dispose()
            End Try
            registered = True
            btnregister.Enabled = False
            btnregister.ForeColor = Color.Gray
        Else
            MsgBox("Please input payment information")
        End If
    End Sub

    Private Sub btnnewfamily_Click(sender As Object, e As EventArgs) Handles btnnewfamily.Click
        Dim con As New OdbcConnection("DSN=hxcs")
        con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

        numfamilies = numfamilies + 1
        familyid = numfamilies
        txtFamilyID.Text = numfamilies
        lstID.Items.Insert(0, numfamilies)
        txtFather.Clear()
        txtMother.Clear()
        txtEmail.Clear()
        txtEmail2.Clear()
        txtAddress.Clear()
        txtPhone.Clear()
        txtMobile.Clear()
        txtEContact.Clear()
        txtEPhone.Clear()
        For i = 1 To 5
            arrSNames(i).Clear()
            arrGrade(i).SelectedItem = "None"
            arrThirdClass(i).SelectedItem = "None"
            arrchNames(i).Clear()
            arrG(i).SelectedItem = ""
            arrBday(i).Clear()
            arrStudentFee(i).Clear()
            arrThirdClassFee(i).Clear()
            arrSNames(i).Visible = False
            arrGrade(i).Visible = False
            arrThirdClass(i).Visible = False
            arrchNames(i).Visible = False
            arrG(i).Visible = False
            arrBday(i).Visible = False
            arrS(i).Visible = False
            arrD(i).Visible = False
            arrStudentFee(i).Visible = False
            arrThirdClassFee(i).Visible = False
        Next
        con = New OdbcConnection("DSN=hxcs")
        con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

        Try
            con.open()
            query = "insert into hxcs.family_info (family_id, father, mother, address, phone, mobile, email, email2, emergency_contact, emerg_phone ) values ('" & familyid & "', '" & txtFather.Text & " ','" & txtMother.Text & "','" & txtAddress.Text & "','" & txtPhone.Text & "','" & txtMobile.Text & "','" & txtEmail.Text & "','" & txtEmail2.Text & "','" & txtEContact.Text & "','" & txtEPhone.Text & "')"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            con.close()
            action = Replace(query, "'", " ")
            con.open()
            query = "insert into hxcs.log (ad, at, user, action) values ('" & DateTime.Now.ToString("yyyy/MM/dd") & "', '" & DateTime.Now.ToString("HH:mm") & " ','" & user & "','" & action & "')"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            txtLog.Text = query
            con.close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            con.dispose()
        End Try
        cboxteacher.Checked = False
        txtRegisterDate.Text = "N/A"
        btnregister.Enabled = True
        btnregister.ForeColor = Color.Red
        txtParentDuty.Clear()
        txtDiscount.Clear()
        txtteacherdiscount.Clear()
        txtRegistrationFee.Clear()
        count = 0
        lstID.SelectedItem = numfamilies
    End Sub

    Sub Gradechange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles coboxGrade1.SelectedIndexChanged, coboxGrade2.SelectedIndexChanged, coboxGrade3.SelectedIndexChanged, coboxGrade4.SelectedIndexChanged, coboxGrade5.SelectedIndexChanged
        Dim s As ComboBox = sender
        index = Mid(s.Name, 11, 1)
        arrS(index).Enabled = True
        classchange()
    End Sub

    Sub ThirdClassChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles coboxThirdClass1.SelectedIndexChanged, coboxThirdClass2.SelectedIndexChanged, coboxThirdClass3.SelectedIndexChanged, coboxThirdClass4.SelectedIndexChanged, coboxThirdClass5.SelectedIndexChanged
        Dim s As ComboBox = sender
        index = Mid(s.Name, 16, 1)
        arrS(index).Enabled = True
        classchange()
    End Sub

    Private Sub btndeletefamily_Click(sender As Object, e As EventArgs) Handles btndeletefamily.Click
        delete = MsgBox("Are you sure you would like to delete this family? All corresponding students will be deleted as well.", vbYesNoCancel, "Delete Family")
        If delete = vbYes Then
            Dim con As New OdbcConnection("DSN=hxcs")
            con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

            Try
                con.open()
                query = "delete from hxcs.student where family_id='" & familyid & "'"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                con.close()
                con.open()
                query = "delete from hxcs.fee where family_id='" & familyid & "'"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                con.close()
                con.open()
                query = "delete from hxcs.family_info where family_id='" & familyid & "'"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                MsgBox("Family deleted")
                con.close()
                action = Replace(query, "'", " ")
                con.open()
                query = "insert into hxcs.log (ad, at, user, action) values ('" & DateTime.Now.ToString("yyyy/MM/dd") & "', '" & DateTime.Now.ToString("HH:mm") & " ','" & user & "','" & action & "')"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                txtLog.Text = query
                con.close()
                lstID.Items.Clear()
                'DISPLAYING ALL FAMILY ID
                con.open()
                query = "select Family_id from hxcs.family_info"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                numfamilies = 0
                While oreader.read
                    id = oreader.GetString(0)
                    lstID.Items.Insert(0, id)
                    If id > numfamilies Then
                        numfamilies = id
                    End If
                End While
                con.close()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                con.dispose()
            End Try
        End If
        lstID.SelectedIndex = 0
    End Sub

    Private Sub btnaddstudent_Click(sender As Object, e As EventArgs) Handles btnaddstudent.Click
        count = count + 1
        If count > 5 Then
            count = 5
            MsgBox("You have 6 kids?!?!?!")
        Else
            For i = 1 To 5
                arrSNames(i).Clear()
                arrGrade(i).SelectedItem = "None"
                arrThirdClass(i).SelectedItem = "None"
                arrchNames(i).Clear()
                arrG(i).SelectedItem = ""
                arrBday(i).Clear()
                arrStudentFee(i).Clear()
                arrThirdClassFee(i).Clear()
                arrSNames(i).Visible = False
                arrGrade(i).Visible = False
                arrThirdClass(i).Visible = False
                arrchNames(i).Visible = False
                arrG(i).Visible = False
                arrBday(i).Visible = False
                arrS(i).Visible = False
                arrD(i).Visible = False
                arrStudentFee(i).Visible = False
                arrThirdClassFee(i).Visible = False
                studentid(i) = 0
            Next
            For i = 1 To count
                arrSNames(i).Visible = True
                arrGrade(i).Visible = True
                arrThirdClass(i).Visible = True
                arrchNames(i).Visible = True
                arrG(i).Visible = True
                arrBday(i).Visible = True
                arrS(i).Visible = True
                arrD(i).Visible = True
                arrStudentFee(i).Visible = True
                arrThirdClassFee(i).Visible = True
            Next
            Dim con As New OdbcConnection("DSN=hxcs")
            con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

            Try
                con.open()
                query = "insert into hxcs.student (family_id, name, chname, grade, third_class, gender, birthday) values ('" & familyid & "', '" & arrSNames(count).Text & " ','" & arrchNames(count).Text & "','" & arrGrade(count).SelectedItem & "','" & arrThirdClass(count).Text & "','" & arrG(count).Text & "','" & arrBday(count).Text & "')"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                con.close()
                'FINDING STUDENT INFORMATION
                con.open()
                query = "select * from hxcs.student where family_id='" & familyid & "'"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                For i = 1 To count
                    oreader.read()
                    arrSNames(i).Text = oreader.GetString(0)
                    arrGrade(i).SelectedItem = oreader.GetString(5)
                    arrThirdClass(i).SelectedItem = oreader.GetString(8)
                    arrchNames(i).Text = oreader.GetString(1)
                    arrBday(i).Text = oreader.GetString(2)
                    arrG(i).SelectedItem = oreader.GetString(3)
                    studentid(i) = oreader.GetInt16(11)
                Next
                con.close()
                action = Replace(query, "'", " ")
                con.open()
                query = "insert into hxcs.log (ad, at, user, action) values ('" & DateTime.Now.ToString("yyyy/MM/dd") & "', '" & DateTime.Now.ToString("HH:mm") & " ','" & user & "','" & action & "')"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                txtLog.Text = query
                con.close()

            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                con.dispose()
            End Try
            For i = 1 To 5
                arrS(i).Enabled = False
            Next
        End If
    End Sub

    Sub DeleteStudent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnD1.Click, btnD2.Click, btnD3.Click, btnD4.Click, btnD5.Click
        count = count - 1
        Dim s As Button = sender
        index = Mid(s.Name, 5, 1)
        delete = MsgBox("Are you sure you would like to delete this student?", vbYesNoCancel, "Delete Family")
        If delete = vbYes Then
            Dim con As New OdbcConnection("DSN=hxcs")
            con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

            Try
                con.open()
                query = "delete from hxcs.student where family_id='" & familyid & "' and studentid='" & studentid(index) & "'"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                txtLog.Text = query
                MsgBox("Student deleted")
                con.close()
                action = replace(query, "'", " ")
                con.open()
                query = "insert into hxcs.log (ad, at, user, action) values ('" & DateTime.Now.ToString("yyyy/MM/dd") & "', '" & DateTime.Now.ToString("HH:mm") & " ','" & user & "','" & action & "')"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                con.close()
                'RESET INFO BOXES
                For i = 1 To 5
                    arrSNames(i).Clear()
                    arrGrade(i).SelectedItem = "None"
                    arrThirdClass(i).SelectedItem = "None"
                    arrchNames(i).Clear()
                    arrG(i).SelectedItem = ""
                    arrBday(i).Clear()
                    arrStudentFee(i).Clear()
                    arrThirdClassFee(i).Clear()
                    arrSNames(i).Visible = False
                    arrGrade(i).Visible = False
                    arrThirdClass(i).Visible = False
                    arrchNames(i).Visible = False
                    arrG(i).Visible = False
                    arrBday(i).Visible = False
                    arrS(i).Visible = False
                    arrD(i).Visible = False
                    arrStudentFee(i).Visible = False
                    arrThirdClassFee(i).Visible = False
                    studentid(i) = 0
                Next
                For i = 1 To count
                    arrSNames(i).Visible = True
                    arrGrade(i).Visible = True
                    arrThirdClass(i).Visible = True
                    arrchNames(i).Visible = True
                    arrG(i).Visible = True
                    arrBday(i).Visible = True
                    arrS(i).Visible = True
                    arrD(i).Visible = True
                    arrStudentFee(i).Visible = True
                    arrThirdClassFee(i).Visible = True
                Next

                'FINDING STUDENT INFORMATION
                con.open()
                query = "select * from hxcs.student where family_id='" & familyid & "'"
                cmd = New OdbcCommand(query, con)
                oreader = cmd.ExecuteReader()
                For i = 1 To count
                    oreader.read()
                    arrSNames(i).Text = oreader.GetString(0)
                    arrGrade(i).SelectedItem = oreader.GetString(5)
                    arrThirdClass(i).SelectedItem = oreader.GetString(8)
                    arrchNames(i).Text = oreader.GetString(1)
                    arrBday(i).Text = oreader.GetString(2)
                    arrG(i).SelectedItem = oreader.GetString(3)
                    studentid(i) = oreader.GetInt16(11)
                Next
                con.close()
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                con.dispose()
            End Try
        End If
        For i = 1 To 5
            arrS(i).Enabled = False
        Next
        classchange()
        balance = Val(txtDue.Text) - Val(txtPaid.Text)
        txtBalance.Text = balance
    End Sub

    Sub NameChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSName1.TextChanged, txtSName2.TextChanged, txtSName3.TextChanged, txtSName4.TextChanged, txtSName5.TextChanged
        Dim s As TextBox = sender
        index = Mid(s.Name, 9, 1)
        arrS(index).Enabled = True
    End Sub

    Sub chNameChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtchName1.TextChanged, txtchName2.TextChanged, txtchName3.TextChanged, txtchName4.TextChanged, txtchName5.TextChanged
        Dim s As TextBox = sender
        index = Mid(s.Name, 10, 1)
        arrS(index).Enabled = True
    End Sub

    Sub GenderChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles coboxG1.SelectedIndexChanged, coboxG2.SelectedIndexChanged, coboxG3.SelectedIndexChanged, coboxG4.SelectedIndexChanged, coboxG5.SelectedIndexChanged
        Dim s As ComboBox = sender
        index = Mid(s.Name, 7, 1)
        arrS(index).Enabled = True
    End Sub

    Sub BdayChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBday1.TextChanged, txtBday2.TextChanged, txtBday3.TextChanged, txtBday4.TextChanged, txtBday5.TextChanged
        Dim s As TextBox = sender
        index = Mid(s.Name, 8, 1)
        arrS(index).Enabled = True
    End Sub
    Sub FamilyInfoChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFamilyID.TextChanged, txtFather.TextChanged, txtMother.TextChanged, txtMobile.TextChanged, txtAddress.TextChanged, txtPhone.TextChanged, txtMobile.TextChanged, txtEContact.TextChanged, txtEPhone.TextChanged, txtEmail.TextChanged, txtEmail2.TextChanged

        btnUpdate.Enabled = True
        btnUpdate.ForeColor = Color.Red
    End Sub

    Private Sub btnupdatepayment_Click(sender As Object, e As EventArgs) Handles btnupdatepayment.Click
        Dim con As New OdbcConnection("DSN=hxcs")
        con.ConnectionString =
        "Dsn=hxcs;" +
        "Uid=root;" +
        "Pwd=school;"
        Try
            con.Open()
            query = "update hxcs.fee set paid_amt='" & txtPaid.Text & "', check_number='" & txtchecknum.Text & "', comment='" & txtcomment.Text & "' where family_id= '" & familyid & "'"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            MsgBox("Information Updated")
            con.Close()
            action = Replace(query, "'", " ")
            con.Open()
            query = "insert into hxcs.log (ad, at, user, action) values ('" & DateTime.Now.ToString("yyyy/MM/dd") & "', '" & DateTime.Now.ToString("HH:mm") & " ','" & user & "','" & action & "')"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader()
            txtLog.Text = query
            con.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            con.Dispose()
        End Try
        balance = Val(txtDue.Text) - Val(txtPaid.Text)
        txtBalance.Text = balance
        btnupdatepayment.Enabled = False
        btnupdatepayment.ForeColor = Color.Gray
    End Sub


    '    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '        'ADD BUTTON
    '        Try
    '            'Make Connection ' Ammar
    '            Dim cnn As DataAccess = New DataAccess(CONNECTION_STRING)
    '            ' Variable ' Ammar
    '            Dim i, j As Integer
    '            'Excel WorkBook object ' Ammar
    '            Dim xlApp As Microsoft.Office.Interop.Excel.Application
    '            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
    '            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
    '            Dim misValue As Object = System.Reflection.Missing.Value
    '            xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
    '            xlWorkBook = xlApp.Workbooks.Add(misValue)
    '            ' Sheet Name or Number ' Ammar
    '            xlWorkSheet = xlWorkBook.Sheets("sheet1")
    '            ' Sql QUery ' Ammar
    '            '  xlWorkBook.Sheets.Select("A1:A2")

    '            Dim sql As String = "SELECT * FROM EMP"
    '            ' SqlAdapter
    '            Dim dscmd As New SqlDataAdapter(sql, cnn.ConnectionString)
    '            ' DataSet
    '            Dim ds As New DataSet
    '            dscmd.Fill(ds)
    '            'COLUMN NAME ADD IN EXCEL SHEET OR HEADING 
    '            xlWorkSheet.Cells(1, 1).Value = "First Name"
    '            xlWorkSheet.Cells(1, 2).Value = "Last Name"
    '            xlWorkSheet.Cells(1, 3).Value = "Full Name"
    '            xlWorkSheet.Cells(1, 4).Value = "Salary"
    '            ' SQL Table Transfer to Excel
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                'Column
    '                For j = 0 To ds.Tables(0).Columns.Count - 1
    '                    ' this i change to header line cells >>>
    '                    xlWorkSheet.Cells(i + 3, j + 1) = _
    '                    ds.Tables(0).Rows(i).Item(j)
    '                Next
    '            Next
    '            'HardCode in Excel sheet
    '            ' this i change to footer line cells  >>>
    '            xlWorkSheet.Cells(i + 3, 7) = "Total"
    '            xlWorkSheet.Cells.Item(i + 3, 8) = "=SUM(H2:H18)"
    '            ' Save as path of excel sheet
    '            xlWorkSheet.SaveAs("D:\vbexcel.xlsx")
    '            xlWorkBook.Close()
    '            xlApp.Quit()
    '            releaseObject(xlApp)
    '            releaseObject(xlWorkBook)
    '            releaseObject(xlWorkSheet)
    '            'Msg Box of Excel Sheet Path
    '            MsgBox("You can find the file D:\vbexcel.xlsx")
    '        Catch ex As Exception

    '        End Try

    '    End Sub
    '    ' Function of Realease Object in Excel Sheet
    '    Private Sub releaseObject(ByVal obj As Object)
    '        Try
    '            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
    '            obj = Nothing
    '        Catch ex As Exception
    '            obj = Nothing
    '        Finally
    '            GC.Collect()
    '        End Try
    '    End Sub

    Private Sub btnshowlog_Click(sender As Object, e As EventArgs) Handles btnshowlog.Click
        FormLog.Show()
    End Sub

    Private Sub btnStartNew_Click(sender As Object, e As EventArgs) Handles btnStartNew.Click
        If MessageBox.Show("Would you like to start a new semester?", "New Semester", MessageBoxButtons.YesNoCancel) = Windows.Forms.DialogResult.Yes Then
            If MessageBox.Show("Are you sure? This will completely truncate the fee table.", "New Semester", MessageBoxButtons.YesNoCancel) = Windows.Forms.DialogResult.Yes Then
                Dim con As New OdbcConnection("DSN=hxcs")
                con.ConnectionString =
                      "Dsn=hxcs;" +
                      "Uid=root;" +
                      "Pwd=school;"
                Try
                    con.Open()
                    query = "TRUNCATE TABLE fee"
                    cmd = New OdbcCommand(query, con)
                    oreader = cmd.ExecuteReader()
                    MsgBox("Semester started")
                    con.Close()
                    action = Replace(query, "'", " ")
                    con.Open()
                    query = "insert into hxcs.log (ad, at, user, action) values ('" & DateTime.Now.ToString("yyyy/MM/dd") & "', '" & DateTime.Now.ToString("HH:mm") & " ','" & user & "','" & action & "')"
                    cmd = New OdbcCommand(query, con)
                    oreader = cmd.ExecuteReader()
                    txtLog.Text = query
                    con.Close()
                Catch ex As MySqlException
                    MsgBox(ex.Message)
                Finally
                    con.Dispose()
                End Try
            End If
        End If
    End Sub

    Private Sub txtidsearch_TextChanged(sender As Object, e As EventArgs) Handles txtidsearch.TextChanged
        lstID.SelectedItem = txtidsearch.Text

    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        End
    End Sub

    Private Sub txtchecknum_TextChanged(sender As Object, e As EventArgs) Handles txtchecknum.TextChanged
        If btnregister.Enabled = False Then
            btnupdatepayment.Enabled = True
            btnupdatepayment.ForeColor = Color.Red
        End If
    End Sub

    Private Sub txtPaid_TextChanged(sender As Object, e As EventArgs) Handles txtPaid.TextChanged
        If btnregister.Enabled = False Then
            btnupdatepayment.Enabled = True
            btnupdatepayment.ForeColor = Color.Red
        End If
        paidamount = Val(txtPaid.Text)
        balance = dueamount - paidamount
        txtBalance.Text = balance
    End Sub

    Private Sub txtcomment_TextChanged(sender As Object, e As EventArgs) Handles txtcomment.TextChanged
        If btnregister.Enabled = False Then
            btnupdatepayment.Enabled = True
            btnupdatepayment.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class




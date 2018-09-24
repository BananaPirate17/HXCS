VERSION 5.00
Object = "{67397AA1-7FB1-11D0-B148-00A0C922E820}#6.0#0"; "MSADODC.OCX"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   8850
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   13230
   LinkTopic       =   "Form1"
   ScaleHeight     =   8850
   ScaleWidth      =   13230
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame1 
      Caption         =   "Frame1"
      Height          =   4515
      Left            =   1620
      TabIndex        =   1
      Top             =   420
      Width           =   9975
      Begin VB.TextBox mother 
         DataField       =   "mother"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   3
         Left            =   5400
         MultiLine       =   -1  'True
         TabIndex        =   22
         Top             =   2400
         Width           =   2775
      End
      Begin VB.TextBox mother 
         DataField       =   "Mobile"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   2
         Left            =   5400
         MultiLine       =   -1  'True
         TabIndex        =   21
         Top             =   1760
         Width           =   2775
      End
      Begin VB.TextBox mother 
         DataField       =   "Email2"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   1
         Left            =   5400
         MultiLine       =   -1  'True
         TabIndex        =   20
         Top             =   1440
         Width           =   2775
      End
      Begin VB.TextBox Name 
         DataField       =   "address"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   2
         Left            =   1140
         MultiLine       =   -1  'True
         TabIndex        =   19
         Top             =   2400
         Width           =   2775
      End
      Begin VB.TextBox Phone 
         DataField       =   "Phone"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   1
         Left            =   1140
         MultiLine       =   -1  'True
         TabIndex        =   18
         Top             =   1760
         Width           =   2775
      End
      Begin VB.TextBox Email 
         DataField       =   "Email"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   1
         Left            =   1140
         MultiLine       =   -1  'True
         TabIndex        =   17
         Top             =   1440
         Width           =   2775
      End
      Begin VB.TextBox Address 
         DataField       =   "address"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   0
         Left            =   1140
         MultiLine       =   -1  'True
         TabIndex        =   5
         Top             =   1120
         Width           =   7035
      End
      Begin VB.TextBox FamilyID 
         DataField       =   "family_id"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   1
         Left            =   1560
         MultiLine       =   -1  'True
         TabIndex        =   4
         Top             =   480
         Width           =   2295
      End
      Begin VB.TextBox Father 
         DataField       =   "father"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   0
         Left            =   1140
         MultiLine       =   -1  'True
         TabIndex        =   3
         Top             =   780
         Width           =   2775
      End
      Begin VB.TextBox mother 
         DataField       =   "mother"
         DataSource      =   "familylistadodc"
         Height          =   300
         Index           =   0
         Left            =   5400
         MultiLine       =   -1  'True
         TabIndex        =   2
         Top             =   780
         Width           =   2775
      End
      Begin VB.Label Label11 
         Caption         =   "Phone"
         Height          =   300
         Left            =   4440
         TabIndex        =   16
         Top             =   2400
         Width           =   1095
      End
      Begin VB.Label Label10 
         Caption         =   "Name"
         Height          =   300
         Left            =   300
         TabIndex        =   15
         Top             =   2400
         Width           =   1095
      End
      Begin VB.Label Label9 
         Caption         =   "Father"
         Height          =   300
         Left            =   300
         TabIndex        =   14
         Top             =   780
         Width           =   1095
      End
      Begin VB.Label Label8 
         Caption         =   "Address"
         Height          =   300
         Left            =   300
         TabIndex        =   13
         Top             =   1120
         Width           =   1095
      End
      Begin VB.Label Label7 
         Caption         =   "Email"
         Height          =   300
         Left            =   300
         TabIndex        =   12
         Top             =   1440
         Width           =   1095
      End
      Begin VB.Label Label6 
         Caption         =   "Phone"
         Height          =   300
         Left            =   300
         TabIndex        =   11
         Top             =   1760
         Width           =   1095
      End
      Begin VB.Label Label5 
         Caption         =   "Emergency Contact"
         Height          =   300
         Left            =   300
         TabIndex        =   10
         Top             =   2085
         Width           =   1455
      End
      Begin VB.Label Label4 
         Caption         =   "Mobile"
         Height          =   300
         Left            =   4440
         TabIndex        =   9
         Top             =   1760
         Width           =   1095
      End
      Begin VB.Label Label3 
         Caption         =   "Mother"
         Height          =   300
         Left            =   4440
         TabIndex        =   8
         Top             =   780
         Width           =   1095
      End
      Begin VB.Label Label2 
         Caption         =   "Email 2"
         Height          =   300
         Left            =   4440
         TabIndex        =   7
         Top             =   1440
         Width           =   1095
      End
      Begin VB.Label Label1 
         Caption         =   "HXCS Family ID"
         Height          =   300
         Left            =   300
         TabIndex        =   6
         Top             =   480
         Width           =   1215
      End
   End
   Begin MSAdodcLib.Adodc familylistadodc 
      Height          =   675
      Left            =   2580
      Top             =   5460
      Width           =   1215
      _ExtentX        =   2143
      _ExtentY        =   1191
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   3
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   "DSN=hxcs"
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   "hxcs"
      OtherAttributes =   ""
      UserName        =   "root"
      Password        =   "magiktja"
      RecordSource    =   "select * from family_info"
      Caption         =   ""
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin VB.ListBox lstfamily 
      DataField       =   "family_id"
      DataSource      =   "familylistadodc"
      Height          =   3765
      ItemData        =   "Form1.frx":0000
      Left            =   420
      List            =   "Form1.frx":0007
      TabIndex        =   0
      Top             =   360
      Width           =   675
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim i As Integer
Dim l As Integer
Dim arrinfo(350) As String
Option Explicit

Private Sub RunQuery()

    Dim DBCon As ADODB.Connection
    Dim Cmd As ADODB.Command
    Dim Rs As ADODB.Recordset
    Dim strName As String

    'Create a connection to the database
    Set DBCon = New ADODB.Connection
    DBCon.CursorLocation = adUseClient
    'This is a connectionstring to a local MySQL server
    DBCon.Open "hxcs", "root", "magiktja"

    'Create a new command that will execute the query
    Set Cmd = New ADODB.Command
    Cmd.ActiveConnection = DBCon
    Cmd.CommandType = adCmdText
    'This is your actual MySQL query
    Cmd.CommandText = "SELECT * from family_info"

    'Executes the query-command and puts the result into Rs (recordset)
    Set Rs = Cmd.Execute

    'Loop through the results of your recordset until there are no more records
    Do While Not Rs.EOF
        'Put the value of field 'Name' into string variable 'Name'
        strName = Rs("family_id")
        lstfamily.AddItem strName
       ' arrinfo(Rs("family_id")) = Rs
        'Move to the next record in your resultset
        Rs.MoveNext
    Loop

    'Close your database connection
    DBCon.Close

    'Delete all references
    Set Rs = Nothing
    Set Cmd = Nothing
    Set DBCon = Nothing
End Sub

Private Sub cmdNameOrder_Click()
'familylistadodc.RecordSource = "select * from family_info where family_id=" + lstfamily.Text
'familylistadodc.Refresh


End Sub

Private Sub Form_Load()
'familylistadodc.RecordSource = "select * from family_info where family_id =" + lstfamily.Text
'familylistadodc.Refresh

RunQuery


End Sub

Private Sub lstfamily_Click()
  Dim DBCon As ADODB.Connection
    Dim Cmd As ADODB.Command
    Dim Rs As ADODB.Recordset
    Dim strName As String

    'Create a connection to the database
    Set DBCon = New ADODB.Connection
    DBCon.CursorLocation = adUseClient
    'This is a connectionstring to a local MySQL server
    DBCon.Open "hxcs", "root", "magiktja"

    'Create a new command that will execute the query
    Set Cmd = New ADODB.Command
    Cmd.ActiveConnection = DBCon
    Cmd.CommandType = adCmdText
    'This is your actual MySQL query
    Cmd.CommandText = "SELECT * from family_info where family_id =2"
    Print Cmd.CommandText
    
     '   Cmd.CommandText = "SELECT * from family_info where family_id =" + lstfamily.Text
    

    'Executes the query-command and puts the result into Rs (recordset)
    Set Rs = Cmd.Execute

    'Loop through the results of your recordset until there are no more records
    'Do While Not Rs.EOF
        'Put the value of field 'Name' into string variable 'Name'
     '   strName = Rs("family_id")
      '  lstfamily.AddItem strName
       ' arrinfo(Rs("family_id")) = Rs
        'Move to the next record in your resultset
       ' Rs.MoveNext
   ' Loop

    'Close your database connection
    DBCon.Close

    'Delete all references
    Set Rs = Nothing
    Set Cmd = Nothing
    Set DBCon = Nothing
End Sub


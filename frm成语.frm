VERSION 5.00
Begin VB.Form frmQuestions 
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   9585
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   18780
   LinkTopic       =   "Form1"
   ScaleHeight     =   9585
   ScaleWidth      =   18780
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
   Begin VB.Timer Timer 
      Interval        =   1000
      Left            =   9060
      Top             =   420
   End
   Begin VB.CommandButton cmdPull 
      Caption         =   "开始"
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   5520
      TabIndex        =   2
      Top             =   1320
      Width           =   1755
   End
   Begin VB.TextBox txtNumber 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   17.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   795
      Left            =   5700
      TabIndex        =   1
      Top             =   420
      Width           =   1455
   End
   Begin VB.Label lblResult 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   30
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3015
      Left            =   2580
      TabIndex        =   3
      Top             =   3120
      Width           =   15615
   End
   Begin VB.Label lblP1 
      Caption         =   "你的幸运数字："
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   17.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1575
      Left            =   2220
      TabIndex        =   0
      Top             =   420
      Width           =   2895
   End
End
Attribute VB_Name = "frmQuestions"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim arrnumbers(92) As String
Dim i As Integer
Dim r As Integer
Dim path As String
Dim strline As String
Option Explicit

Private Sub cmdPull_Click()
Pick
txtNumber.Text = ""
End Sub

Private Sub Form_Load()
frmStart.Show
frmQuestions.Hide
i = 0
path = "numbers.txt"
Open path For Input As #1
Do While Not EOF(1)
    i = i + 1
    Line Input #1, strline
    arrnumbers(i) = strline
Loop
Close #1
End Sub
Private Sub Pick()
Randomize
r = Int((Rnd * 92) + 1)
If arrnumbers(r) = "meile" Then
    Pick
Else
    lblResult.Caption = arrnumbers(r)
    arrnumbers(r) = "meile"
End If

End Sub

Private Sub Timer_Timer()
If txtNumber.Text <> "" Then
    cmdPull.Enabled = True
Else
    cmdPull.Enabled = False
End If
End Sub

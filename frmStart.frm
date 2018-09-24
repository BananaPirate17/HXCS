VERSION 5.00
Begin VB.Form frmStart 
   BackColor       =   &H000000FF&
   BorderStyle     =   0  'None
   Caption         =   "中文"
   ClientHeight    =   9015
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   14820
   FillColor       =   &H000000FF&
   FillStyle       =   0  'Solid
   ForeColor       =   &H000000FF&
   LinkTopic       =   "Form1"
   ScaleHeight     =   9015
   ScaleWidth      =   14820
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
   Begin VB.CommandButton cmdStart 
      BackColor       =   &H0080FFFF&
      Caption         =   "开始"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   30
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1515
      Left            =   9060
      MaskColor       =   &H000000FF&
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   4920
      Width           =   2595
   End
   Begin VB.Label Label 
      Alignment       =   2  'Center
      BackColor       =   &H0080FFFF&
      Caption         =   "华夏中文学校趣味中文比赛"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   60
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3855
      Left            =   6720
      TabIndex        =   0
      Top             =   120
      Width           =   7275
   End
End
Attribute VB_Name = "frmStart"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdStart_Click()
frmStart.Hide
frmQuestions.Show
End Sub

Private Sub Form_Load()
frmStart.Show
frmQuestions.Hide
End Sub

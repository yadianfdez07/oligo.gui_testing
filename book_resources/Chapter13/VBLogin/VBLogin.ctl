VERSION 5.00
Begin VB.UserControl UserControl1 
   ClientHeight    =   2115
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   3720
   ScaleHeight     =   2115
   ScaleWidth      =   3720
   Begin VB.CommandButton cmdCancel 
      Caption         =   "Cancel"
      Height          =   375
      Left            =   1920
      TabIndex        =   5
      Top             =   1320
      Width           =   1215
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "OK"
      Height          =   375
      Left            =   480
      TabIndex        =   4
      Top             =   1320
      Width           =   1215
   End
   Begin VB.TextBox txtPwd 
      Height          =   375
      Left            =   1680
      TabIndex        =   3
      Text            =   "Text2"
      Top             =   720
      Width           =   1695
   End
   Begin VB.TextBox txtUserID 
      Height          =   375
      Left            =   1680
      TabIndex        =   2
      Text            =   "Text1"
      Top             =   240
      Width           =   1695
   End
   Begin VB.Label lblPwd 
      Caption         =   "Password"
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   720
      Width           =   1215
   End
   Begin VB.Label lblUserID 
      Caption         =   "User ID"
      Height          =   375
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   1215
   End
End
Attribute VB_Name = "UserControl1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Txt_Msg = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbl_msg = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_fw = New System.Windows.Forms.Label()
        Me.lbl_datecode = New System.Windows.Forms.Label()
        Me.lbl_articlenos = New System.Windows.Forms.Label()
        Me.lbl_lastcounter = New System.Windows.Forms.Label()
        Me.lbl_psn = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lbl_currcounter = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Barcode_Comm = New System.IO.Ports.SerialPort(Me.components)
        Me.RFID_Comm = New System.IO.Ports.SerialPort(Me.components)
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.lbl_WOnos = New System.Windows.Forms.Label()
        Me.lbl_currentref = New System.Windows.Forms.Label()
        Me.lbl_wocounter = New System.Windows.Forms.Label()
        Me.lbl_tagnos = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Ethernet = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ethernet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(60, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Work Order Nos :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(12, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Work Order References :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(62, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Work Order Qty :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(76, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "RFID Tag Nos :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label5.Location = New System.Drawing.Point(59, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "New PSN : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label6.Location = New System.Drawing.Point(38, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Last Counter : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label7.Location = New System.Drawing.Point(46, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Article Nos :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label8.Location = New System.Drawing.Point(54, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Date Code :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label9.Location = New System.Drawing.Point(20, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Product Version :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label10.Location = New System.Drawing.Point(262, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Item to scan :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label11.Location = New System.Drawing.Point(267, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 75)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(155, 20)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "System Information :"
        '
        'Txt_Msg
        '
        Me.Txt_Msg.Location = New System.Drawing.Point(15, 163)
        Me.Txt_Msg.Multiline = True
        Me.Txt_Msg.Name = "Txt_Msg"
        Me.Txt_Msg.Size = New System.Drawing.Size(279, 142)
        Me.Txt_Msg.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 317)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Electro Magnet"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(14, 333)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(137, 20)
        Me.TextBox2.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(156, 317)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "PCBA"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(157, 333)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(137, 20)
        Me.TextBox3.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 368)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(170, 20)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Operator's Instruction :"
        '
        'lbl_msg
        '
        Me.lbl_msg.AutoSize = True
        Me.lbl_msg.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_msg.ForeColor = System.Drawing.Color.Red
        Me.lbl_msg.Location = New System.Drawing.Point(8, 397)
        Me.lbl_msg.Name = "lbl_msg"
        Me.lbl_msg.Size = New System.Drawing.Size(240, 24)
        Me.lbl_msg.TabIndex = 1
        Me.lbl_msg.Text = "Please scan Part Barcode..."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Ethernet)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkGreen
        Me.GroupBox1.Location = New System.Drawing.Point(12, 447)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 94)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ethernet Connection"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label20.Location = New System.Drawing.Point(3, 69)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(182, 15)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "PLC IP Address : 126.254.108.2"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label19.Location = New System.Drawing.Point(3, 54)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 15)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Connect"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label18.Location = New System.Drawing.Point(3, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 15)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Connect"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label17.Location = New System.Drawing.Point(27, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 15)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Connect"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(254, 456)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 59)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "READ PLC"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(254, 527)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 13)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "%MW101 -"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(319, 521)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(27, 20)
        Me.TextBox4.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Txt_Msg)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lbl_msg)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lbl_fw)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lbl_datecode)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lbl_articlenos)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lbl_lastcounter)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lbl_psn)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(428, 557)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'lbl_fw
        '
        Me.lbl_fw.AutoSize = True
        Me.lbl_fw.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fw.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_fw.Location = New System.Drawing.Point(129, 101)
        Me.lbl_fw.Name = "lbl_fw"
        Me.lbl_fw.Size = New System.Drawing.Size(40, 15)
        Me.lbl_fw.TabIndex = 0
        Me.lbl_fw.Text = "lbl_fw"
        '
        'lbl_datecode
        '
        Me.lbl_datecode.AutoSize = True
        Me.lbl_datecode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_datecode.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_datecode.Location = New System.Drawing.Point(129, 80)
        Me.lbl_datecode.Name = "lbl_datecode"
        Me.lbl_datecode.Size = New System.Drawing.Size(74, 15)
        Me.lbl_datecode.TabIndex = 0
        Me.lbl_datecode.Text = "lbl_datecode"
        '
        'lbl_articlenos
        '
        Me.lbl_articlenos.AutoSize = True
        Me.lbl_articlenos.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_articlenos.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_articlenos.Location = New System.Drawing.Point(129, 59)
        Me.lbl_articlenos.Name = "lbl_articlenos"
        Me.lbl_articlenos.Size = New System.Drawing.Size(83, 15)
        Me.lbl_articlenos.TabIndex = 0
        Me.lbl_articlenos.Text = "lbl_articlenos"
        '
        'lbl_lastcounter
        '
        Me.lbl_lastcounter.AutoSize = True
        Me.lbl_lastcounter.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lastcounter.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_lastcounter.Location = New System.Drawing.Point(129, 37)
        Me.lbl_lastcounter.Name = "lbl_lastcounter"
        Me.lbl_lastcounter.Size = New System.Drawing.Size(90, 15)
        Me.lbl_lastcounter.TabIndex = 0
        Me.lbl_lastcounter.Text = "lbl_lastcounter"
        '
        'lbl_psn
        '
        Me.lbl_psn.AutoSize = True
        Me.lbl_psn.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_psn.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_psn.Location = New System.Drawing.Point(129, 16)
        Me.lbl_psn.Name = "lbl_psn"
        Me.lbl_psn.Size = New System.Drawing.Size(47, 15)
        Me.lbl_psn.TabIndex = 0
        Me.lbl_psn.Text = "lbl_psn"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label22.Location = New System.Drawing.Point(441, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(101, 19)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Qty Output :"
        '
        'lbl_currcounter
        '
        Me.lbl_currcounter.AutoSize = True
        Me.lbl_currcounter.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_currcounter.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_currcounter.Location = New System.Drawing.Point(469, 25)
        Me.lbl_currcounter.Name = "lbl_currcounter"
        Me.lbl_currcounter.Size = New System.Drawing.Size(51, 56)
        Me.lbl_currcounter.TabIndex = 0
        Me.lbl_currcounter.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label24.Location = New System.Drawing.Point(562, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(119, 72)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "SC"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(716, 502)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(72, 70)
        Me.Button7.TabIndex = 11
        Me.Button7.Text = "MW101=10"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(716, 426)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(72, 70)
        Me.Button8.TabIndex = 11
        Me.Button8.Text = "Reset Screw Counter"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(716, 351)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(72, 70)
        Me.Button9.TabIndex = 11
        Me.Button9.Text = "Reset Sequence"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(589, 573)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(92, 59)
        Me.Button10.TabIndex = 6
        Me.Button10.Text = "Zbr Print?"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Barcode_Comm
        '
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(434, 575)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(137, 20)
        Me.TextBox5.TabIndex = 3
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(434, 601)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(108, 20)
        Me.TextBox6.TabIndex = 3
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(434, 627)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(108, 20)
        Me.TextBox7.TabIndex = 3
        '
        'lbl_WOnos
        '
        Me.lbl_WOnos.AutoSize = True
        Me.lbl_WOnos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_WOnos.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_WOnos.Location = New System.Drawing.Point(178, 9)
        Me.lbl_WOnos.Name = "lbl_WOnos"
        Me.lbl_WOnos.Size = New System.Drawing.Size(76, 16)
        Me.lbl_WOnos.TabIndex = 0
        Me.lbl_WOnos.Text = "lbl_WOnos"
        '
        'lbl_currentref
        '
        Me.lbl_currentref.AutoSize = True
        Me.lbl_currentref.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_currentref.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_currentref.Location = New System.Drawing.Point(178, 25)
        Me.lbl_currentref.Name = "lbl_currentref"
        Me.lbl_currentref.Size = New System.Drawing.Size(93, 16)
        Me.lbl_currentref.TabIndex = 0
        Me.lbl_currentref.Text = "lbl_currentref"
        '
        'lbl_wocounter
        '
        Me.lbl_wocounter.AutoSize = True
        Me.lbl_wocounter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wocounter.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_wocounter.Location = New System.Drawing.Point(178, 41)
        Me.lbl_wocounter.Name = "lbl_wocounter"
        Me.lbl_wocounter.Size = New System.Drawing.Size(98, 16)
        Me.lbl_wocounter.TabIndex = 0
        Me.lbl_wocounter.Text = "lbl_wocounter"
        '
        'lbl_tagnos
        '
        Me.lbl_tagnos.AutoSize = True
        Me.lbl_tagnos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tagnos.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_tagnos.Location = New System.Drawing.Point(178, 57)
        Me.lbl_tagnos.Name = "lbl_tagnos"
        Me.lbl_tagnos.Size = New System.Drawing.Size(73, 16)
        Me.lbl_tagnos.TabIndex = 0
        Me.lbl_tagnos.Text = "lbl_tagnos"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(434, 99)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(263, 468)
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'Button6
        '
        Me.Button6.Image = Global.XCS_11.My.Resources.Resources.EYE
        Me.Button6.Location = New System.Drawing.Point(716, 578)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 70)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Eye Open"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = Global.XCS_11.My.Resources.Resources.MISC05
        Me.Button5.Location = New System.Drawing.Point(716, 254)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 70)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "Refresh"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = Global.XCS_11.My.Resources.Resources.spec
        Me.Button4.Location = New System.Drawing.Point(716, 166)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 70)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Material"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = Global.XCS_11.My.Resources.Resources.debug
        Me.Button3.Location = New System.Drawing.Point(716, 90)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 70)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Rack"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.XCS_11.My.Resources.Resources.EXITWIN
        Me.Button2.Location = New System.Drawing.Point(716, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 70)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Quit"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(300, 163)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 142)
        Me.PictureBox2.TabIndex = 9
        Me.PictureBox2.TabStop = False
        '
        'Ethernet
        '
        Me.Ethernet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ethernet.Location = New System.Drawing.Point(6, 21)
        Me.Ethernet.Name = "Ethernet"
        Me.Ethernet.Size = New System.Drawing.Size(15, 15)
        Me.Ethernet.TabIndex = 4
        Me.Ethernet.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 655)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lbl_currcounter)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.lbl_tagnos)
        Me.Controls.Add(Me.lbl_wocounter)
        Me.Controls.Add(Me.lbl_currentref)
        Me.Controls.Add(Me.lbl_WOnos)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ethernet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Txt_Msg As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents lbl_msg As Label
    Friend WithEvents Ethernet As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label22 As Label
    Friend WithEvents lbl_currcounter As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Barcode_Comm As IO.Ports.SerialPort
    Friend WithEvents RFID_Comm As IO.Ports.SerialPort
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents lbl_WOnos As Label
    Friend WithEvents lbl_currentref As Label
    Friend WithEvents lbl_wocounter As Label
    Friend WithEvents lbl_tagnos As Label
    Friend WithEvents lbl_fw As Label
    Friend WithEvents lbl_datecode As Label
    Friend WithEvents lbl_articlenos As Label
    Friend WithEvents lbl_lastcounter As Label
    Friend WithEvents lbl_psn As Label
End Class


#define MyAppName "BusinessObjectsEtl"
#define MyAppLongName "Business Objects Etl"
#define MyAppVersion GetFileVersion(".\bin\Release\bo-etl-lib.dll")
#define MyAppPublisher "Florent BREHERET"
#define MyAppURL "http://code.google.com/p/bo-utils/"

[Setup]
PrivilegesRequired=poweruser
AppId={code:GetAppID}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
UninstallDisplayName="Config{code:GetParam|DBname}"
UsePreviousLanguage=no
VersionInfoVersion={#MyAppVersion}
VersionInfoTextVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={sd}\MYBOJOBS
DefaultGroupName={#MyAppLongName}
DisableProgramGroupPage=yes
;LicenseFile=.\License.txt
;InfoBeforeFile=.\ClassLibrary1\bin\Release\Info.txt
OutputDir=".\bin\Setup"
OutputBaseFilename=SetUpJob
Compression=lzma
SolidCompression=yes
DisableWelcomePage=yes
UsePreviousAppDir=no
AppendDefaultDirName=yes
SetupIconFile=setup.ico

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"

[Files]
Source: ".\launch.bat"; DestDir: "{app}"; DestName: "{code:GetParam|DBname}-launch.bat"; Flags: ignoreversion
Source: ".\config.xml"; DestDir: "{app}"; DestName: "{code:GetParam|DBname}-config.xml"; Flags: ignoreversion
Source: ".\trace.log"; DestDir: "{app}"; DestName: "{code:GetParam|DBname}-trace.log"; Flags: ignoreversion

[Icons]
;Name: "{group}\Jobs\{code:GetParam|DBname}"; Filename: "{app}"; Flags:foldershortcut;
Name: "{group}\Jobs\{code:GetParam|DBname}\{code:GetParam|DBname}-launch.bat"; Filename: "{app}\{code:GetParam|DBname}-launch.bat";
Name: "{group}\Jobs\{code:GetParam|DBname}\{code:GetParam|DBname}-config.xml"; Filename: "{app}\{code:GetParam|DBname}-config.xml";
Name: "{group}\Jobs\{code:GetParam|DBname}\{code:GetParam|DBname}-trace.log"; Filename: "{app}\{code:GetParam|DBname}-trace.log";
Name: "{group}\Jobs\{code:GetParam|DBname}\{code:GetParam|DBname}.FDB"; Filename: "{app}\{code:GetParam|DBname}.FDB";
Name: "{group}\Jobs\{code:GetParam|DBname}\Uninstall Job {code:GetParam|DBname}"; Filename: "{uninstallexe}";

[UninstallDelete]
Type: filesandordirs; Name: "{app}";

[Registry]
;create odbc database
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\ODBC Data Sources"; ValueType: string; ValueName:{code:GetParam|DBname}; ValueData: "Firebird/InterBase(r) driver"; Check:IsCreateODBC; Flags:uninsdeletevalue;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; Check:IsCreateODBC; Flags:uninsdeletekey;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "Driver"; ValueData: "{win}\system32\OdbcFb.dll"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "Description"; ValueData: "Firebird - {code:GetParam|DBname}";
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "Dbname"; ValueData: {code:GetDatabasePath}; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "Client"; ValueData: ""; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "User"; ValueData: {code:GetParam|DBuser}; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "Role"; ValueData: ""; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "CharacterSet"; ValueData: "NONE"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "JdbcDriver"; ValueData: "IscDbc"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "ReadOnly"; ValueData: "N"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "NoWait"; ValueData: "N"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "LockTimeoutWaitTransactions"; ValueData: ""; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "Dialect"; ValueData: "3"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "QuotedIdentifier"; ValueData: "Y"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "SensitiveIdentifier"; ValueData: "N"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "AutoQuotedIdentifier"; ValueData: "N"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "UseSchemaIdentifier"; ValueData: "0"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "SafeThread"; ValueData: "Y"; Check:IsCreateODBC;
Root: HKLM; Subkey: "Software\ODBC\ODBC.INI\{code:GetParam|DBname}"; ValueType: string; ValueName: "Password"; ValueData: {code:GetParam|DBpassword}; Check:IsCreateODBC;

Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\BusinessObjectsEtl_{code:GetParam|DBname}_is1"; ValueType: string; ValueName: "DBname"; ValueData: {code:GetParam|DBname};

[Code]

var
  lCurPageID: Integer;
  DefaultPath: String;
  AppID: String;
  vbCrLf: String;
  vbTab: String;

  DatabasePage: TWizardPage;
  lbl_DBname: TNewStaticText; txt_DBname: TNewEdit;
  lbl_DBuser: TNewStaticText; txt_DBuser: TNewEdit;
  lbl_DBpassword: TNewStaticText; txt_DBpassword: TPasswordEdit; inf_DBpassword: TNewStaticText;
  cb_DBmultipleload: TNewCheckBox;
  cb_DBcreateODBC: TNewCheckBox;

  WebservicePage: TWizardPage;
  lbl_WSsessionUrl: TNewStaticText; txt_WSsessionUrl: TNewEdit;
  lbl_WSsystem: TNewStaticText; txt_WSsystem: TNewEdit;
  lbl_WSuser: TNewStaticText; txt_WSuser: TNewEdit;
  lbl_WSpassword: TNewStaticText; txt_WSpassword: TPasswordEdit;
  lbl_WSauth: TNewStaticText; cb_WSauth: TComboBox;
  bt_WStest: TNewButton;

function XORcrypt(Value: String): String;
  var
      c,pl,kl: integer; Key: String;
  begin
      Key:='ydzngh'
      Result:=Value;
      pl:=Length(Value);
      kl:=Length(Key);
      for c := 1 to pl do begin
          Result[c]:=Chr(Ord(Value[c]) XOR Ord(Key[ ((c-1) mod kl)+1 ]));
      end;
  end;

const Codes64 = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/';

function Encode64(S: AnsiString): AnsiString;
  var
    i, a, x, b, ln: Integer;
  begin
    Result := '';
    a := 0; b := 0;
    for i := 1 to Length(s) do begin
      x := Ord(s[i]);
      b := b * 256 + x;
      a := a + 8;
      while (a >= 6) do begin
        a := a - 6;
        x := b div (1 shl a);
        b := b mod (1 shl a);
        Result := Result + copy(Codes64,x + 1,1);
      end;
    end;
    if a > 0 then begin
      x := b shl (6 - a);
      Result := Result + copy(Codes64,x + 1,1);
    end;
    if (Length(Result) mod 4) = 2 then begin 
      Result := Result + '==';
    end else if (Length(Result) mod 4) = 3 then begin
      Result := Result + '=';
    end;
  end;

function Decode64(S: AnsiString): AnsiString;
  var
    i, a, x, b: Integer;
  begin
    Result := '';
    a := 0; b := 0;
    for i := 1 to Length(s) do begin
      x := Pos(s[i], codes64) - 1;
      if x >= 0 then begin
        b := b * 64 + x;
        a := a + 6;
        if a >= 8 then begin
          a := a - 8;
          x := b shr a;
          b := b mod (1 shl a);
          x := x mod 256;
          Result := Result + chr(x);
        end;
      end
    else
      Exit; // finish at unknown
    end;
  end;


function InitializeSetup(): Boolean;
  begin
     vbCrLf:= chr(10);
     vbTab:= chr(9);
     Result:=true;  
  end;

function GetAppID(Param: String): String;
  begin
      if lCurPageID <> 0 then begin
        AppID := 'BusinessObjectsEtl_' + txt_DBname.Text;
      end else begin
        AppID := 'BusinessObjectsEtl_0';
      end;
      //if  then AppID:='BusinessObjectsEtl_' + GetDateTimeString('yymmddhhnnss',#0,#0);
      Result:= AppID;
  end;

procedure bt_WStestOnClick(Sender: TObject);
  var oCom: Variant;
  begin
      try
        TNewButton(Sender).Cursor := crHourGlass;
        oCom := CreateOleObject('BusinessObjectsEtl.Etl');
        oCom.Login(txt_WSsessionUrl.Text, txt_WSsystem.Text, txt_WSuser.Text, txt_WSpassword.Text, cb_WSauth.Text );
        oCom.Logout();
        MsgBox('Succed to login to the web service!', mbInformation, mb_Ok);
      except
        RaiseException( 'Failed to connect to the web service! '#13'Error : ' + GetExceptionMessage );
      end;
      TNewButton(Sender).Cursor := crDefault;
  end;

function GetParam(Param: String): String;
begin
  if Param = 'DBname' then begin
    Result := txt_DBname.Text;
  end else if Param = 'DBuser' then begin
    Result := txt_DBuser.Text;
  end else if Param = 'DBpassword' then begin
    Result := txt_DBpassword.Text;
  end;
end;

function GetDatabasePath(Param: String): String;
begin
    Result := ExpandConstant('{app}\') + Uppercase(txt_DBname.Text) + '.FDB';
end;


function IsCreateODBC() : Boolean;
  begin
    Result:= cb_DBcreateODBC.Checked;
  end;

function IIf(test: Boolean; valueIfTrue:  String; valueIfFalse:  String):  String;
  begin
    if test then Result:=valueIfTrue else Result:=valueIfFalse;
  end;
                                                      
procedure CreateBatchConfigFiles;
  var path: string; txtBatch: string; txtProperties: string; app: String;
  begin
    app:=ExpandConstant('{app}\');
    if not RegQueryStringValue(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\BusinessObjectsEtl_is1', 'InstallLocation', path) then begin
        RegQueryStringValue(HKEY_LOCAL_MACHINE, 'SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\BusinessObjectsEtl_is1', 'InstallLocation', path)
    end;
    txtBatch:= '"' + path + 'bo-etl.exe" "' + app + txt_DBname.Text + '-config.xml" "' + app + txt_DBname.Text + '-trace.log"' + vbCrLf + 'pause';
    txtProperties:= '<?xml version="1.0" encoding="utf-8"?>' + vbCrLf
       + '<Config>' + vbCrLf
       + '	<Databases>' + vbCrLf
       + '		<Database>' + vbCrLf
       + '			<Type>Firebird</Type>' + vbCrLf
       + '			<Path>' + GetDatabasePath(#0) + '</Path>' + vbCrLf
       + '			<Username>' + txt_DBuser.Text + '</Username>' + vbCrLf
//       + '			<Password>' + Encode64(XORcrypt(txt_DBpassword.Text)) + '</Password>' + vbCrLf
       + '			<Password>' + txt_DBpassword.Text + '</Password>' + vbCrLf
       + '			<Multiload>' + IIf(cb_DBmultipleload.Checked=true, 'true', 'false')  + '</Multiload>' + vbCrLf
       + '		</Database>' + vbCrLf
       + '	</Databases>' + vbCrLf
       + '	<WebService>' + vbCrLf
       + '		<WebServiceURL>' + txt_WSsessionUrl.Text + '</WebServiceURL>' + vbCrLf
       + '		<Domain>' + txt_WSsystem.Text + '</Domain>' + vbCrLf
       + '		<AuthType>' + cb_WSauth.Text + '</AuthType>' + vbCrLf
       + '		<Login>' + txt_WSuser.Text + '</Login>' + vbCrLf
//       + '		<Password>' + Encode64(XORcrypt(txt_WSpassword.Text)) + '</Password>' + vbCrLf
       + '		<Password>' + txt_WSpassword.Text + '</Password>' + vbCrLf
       + '	</WebService>' + vbCrLf
       + '</Config>';
    SaveStringToFile( app + txt_DBname.Text + '-launch.bat', txtBatch, False);
    SaveStringToFile( app + txt_DBname.Text + '-config.xml', txtProperties, False);
  end;

procedure CreateDatabase;
  var oCom: Variant;
  begin
      try
        DeleteFile(GetDatabasePath(#0));
        oCom := CreateOleObject('BusinessObjectsEtl.Firebird');
        oCom.Initialise(GetDatabasePath(#0), txt_DBuser.Text,txt_DBpassword.Text, cb_DBmultipleload.Checked);
      except
        RaiseException( 'Failed to create CreateOleObject ! '#13'Error : ' + GetExceptionMessage );
      end;
  end;

procedure RegisterDatabase;
  var conf: string; XMLDoc: Variant; XMLdb: Variant; XmlNodeServer: Variant; XmlNode: Variant; txtProperties: string;
  begin
      //Register the database in FlameRobin
      conf := ExpandConstant('{userappdata}\..\Local Settings\Application Data\') + 'flamerobin\fr_databases.conf'
      XMLDoc := CreateOleObject('MSXML2.DOMDocument');
      XMLDoc.Load( conf );
      XmlNodeServer := XMLDoc.SelectSingleNode('//server');
      XmlNode := XmlNodeServer.SelectSingleNode('//database/name[text()=''' + txt_DBname.Text + ''']');
      If VarIsEmpty(XmlNode) = false then begin
        XmlNodeServer.RemoveChild(XmlNode.ParentNode);
      end;
      XMLdb := CreateOleObject('MSXML2.DOMDocument');
      XMLdb.LoadXML (''
          + '    <database>'
          + '      <name>' + txt_DBname.Text + '</name>'
          + '      <path>'+ GetDatabasePath(#0) +'</path>'
          + '      <charset>NONE</charset>'
          + '      <username>' + txt_DBuser.Text + '</username>'
          + '      <password>' + txt_DBpassword.Text + '</password>'
          + '      <authentication>pwd</authentication>'
          + '    </database>'
        );
      XmlNodeServer.appendChild(XMLdb.FirstChild);
      XMLDoc.Save( conf );
  end;

procedure UnregisterDatabase;
  var conf: string;  XMLDoc: Variant; XMLdb: Variant; XmlNodeServer: Variant; XmlNode: Variant; DbName: String;
  begin
      DbName :=  GetPreviousData('DBname', 'not_found');
      conf := ExpandConstant('{userappdata}\..\Local Settings\Application Data\') + 'flamerobin\fr_databases.conf'
      XMLDoc := CreateOleObject('MSXML2.DOMDocument');
      XMLDoc.Load( conf );
      XmlNodeServer := XMLDoc.SelectSingleNode('//server');
      XmlNode := XmlNodeServer.SelectSingleNode('//database/name[text()=''' + DbName + ''']');
      If VarIsEmpty(XmlNode) = false then begin
        XmlNodeServer.RemoveChild(XmlNode.ParentNode);
      end;
      XMLDoc.Save( conf );
  end;

procedure RegisterPreviousData(PreviousDataKey: Integer);
  begin
    SetPreviousData(PreviousDataKey, 'DBname', txt_DBname.Text)
  end;


procedure AddDatabaseNameToPath;
  begin
    WizardForm.DirEdit.Text := DefaultPath + '\' + txt_DBname.Text;
  end;

procedure CurStepChanged(CurStep: TSetupStep);
  var
    ErrorCode: Integer;
  begin
    if CurStep = ssPostInstall  then begin
      CreateBatchConfigFiles
      CreateDatabase
      RegisterDatabase
    end else if CurStep = ssDone then begin
       ShellExec('', ExpandConstant('{app}'), '', '', SW_SHOW, ewNoWait, ErrorCode);
    end Else If CurStep = ssPostInstall then begin
    end;
  end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
  begin
    if CurUninstallStep = usUninstall  then begin
       UnregisterDatabase;
    end;
  end;

procedure CurPageChanged(CurPageID: Integer);
  begin
    lCurPageID:=CurPageID
  end;

function NextButtonClick(CurPageID: Integer): Boolean;
  var
    LibPage: TInputDirWizardPage;
  begin
    if CurPageID = DatabasePage.ID then begin
      AddDatabaseNameToPath
    end;
    Result:=True;
  end;

function UpdateReadyMemo(Space, NewLine, MemoUserInfoInfo, MemoDirInfo, MemoTypeInfo, MemoComponentsInfo, MemoGroupInfo, MemoTasksInfo: String): String;
  var
    s: string;
  begin
    s := s + 'Destination location:' + vbCrLf
    s := s + '   ' + WizardForm.DirEdit.Text + vbCrLf
    s := s + vbCrLf
    s := s + 'Register database:' + vbCrLf
    s := s + '   ' + txt_DBname.Text + vbCrLf
    s := s + vbCrLf
    s := s + 'Create ODBC:' + vbCrLf
    s := s + '   ' + IIf(cb_DBcreateODBC.Checked=true, 'true', 'false') + vbCrLf
    s := s + vbCrLf	
    s := s + 'Resiter web service:' + vbCrLf
    s := s + '   ' + txt_WSsessionUrl.Text + vbCrLf
    Result := s
  end;

procedure InitializeWizard;
  var y:integer;
  begin
    DefaultPath:=WizardForm.DirEdit.Text

    DatabasePage := CreateCustomPage(wpWelcome, 'Firebird database setup', 'Please specify informations to create the database');
    y:=-3
    lbl_DBname := TNewStaticText.Create(DatabasePage);
    lbl_DBname.Top := ScaleY(y);
    lbl_DBname.Caption := 'DataBase name:';
    lbl_DBname.Parent := DatabasePage.Surface;
    txt_DBname := TNewEdit.Create(DatabasePage);
    txt_DBname.Top := ScaleY(Y+15);
    txt_DBname.Width := ScaleX(190);
    txt_DBname.Text := 'BODATA';
    txt_DBname.Parent := DatabasePage.Surface;
    y:=y+38
    lbl_DBuser := TNewStaticText.Create(DatabasePage);
    lbl_DBuser.Top := ScaleY(Y);
    lbl_DBuser.Caption := 'User name:';
    lbl_DBuser.Parent := DatabasePage.Surface;
    txt_DBuser := TNewEdit.Create(DatabasePage);
    txt_DBuser.Top := ScaleY(Y+15);
    txt_DBuser.Width := ScaleX(190);
    txt_DBuser.ReadOnly := true;
    txt_DBuser.Color := $E0DFE3;
    txt_DBuser.Text := 'SYSDBA';
    txt_DBuser.Parent := DatabasePage.Surface;
    y:=y+38
    lbl_DBpassword := TNewStaticText.Create(DatabasePage);
    lbl_DBpassword.Top := ScaleY(Y);
    lbl_DBpassword.Caption := 'Password:';
    lbl_DBpassword.Parent := DatabasePage.Surface;
    txt_DBpassword := TPasswordEdit.Create(DatabasePage);
    txt_DBpassword.Top := ScaleY(Y+15);
    txt_DBpassword.Width := ScaleX(190);
    txt_DBpassword.Text := 'masterkey';
    txt_DBpassword.Parent := DatabasePage.Surface;
    inf_DBpassword := TNewStaticText.Create(DatabasePage);
    inf_DBpassword.Top := ScaleY(Y+18);
    inf_DBpassword.Left := ScaleY(194);
    inf_DBpassword.Caption := '(Default is masterkey)';
    inf_DBpassword.Parent := DatabasePage.Surface;
    y:=y+50                          
    cb_DBmultipleload := TNewCheckBox.Create(DatabasePage);
    cb_DBmultipleload.Top := ScaleY(y);
    cb_DBmultipleload.Width := ScaleX(300);
    cb_DBmultipleload.Caption := 'Keep previous records at each load';
    cb_DBmultipleload.Parent := DatabasePage.Surface;
    y:=y+25
    cb_DBcreateODBC := TNewCheckBox.Create(DatabasePage);
    cb_DBcreateODBC.Top := ScaleY(y);
    cb_DBcreateODBC.Width := ScaleX(300);
    cb_DBcreateODBC.Caption := 'Create ODBC connection'; 
    cb_DBcreateODBC.Checked := True;
    cb_DBcreateODBC.Parent := DatabasePage.Surface;

    WebservicePage := CreateCustomPage(DatabasePage.ID, 'Business Objects web service setup', 'Please specify informations to connect Business Objects web service');
    y:=-3
    lbl_WSsessionUrl := TNewStaticText.Create(WebservicePage);
    lbl_WSsessionUrl.Top := ScaleY(Y);
    lbl_WSsessionUrl.Caption := 'Web service URL:';
    lbl_WSsessionUrl.Parent := WebservicePage.Surface;
    txt_WSsessionUrl := TNewEdit.Create(WebservicePage);
    txt_WSsessionUrl.Top := ScaleY(Y+14);
    txt_WSsessionUrl.Width := ScaleX(390);
    txt_WSsessionUrl.Text := 'http://hostname:port/dswsbobje/services';
    txt_WSsessionUrl.Parent := WebservicePage.Surface;
    y:=y+38
    lbl_WSsystem := TNewStaticText.Create(WebservicePage);
    lbl_WSsystem.Top := ScaleY(Y);
    lbl_WSsystem.Caption := 'System:';
    lbl_WSsystem.Parent := WebservicePage.Surface;
    txt_WSsystem := TNewEdit.Create(WebservicePage);
    txt_WSsystem.Top := ScaleY(Y+14);
    txt_WSsystem.Width := ScaleX(190);
    txt_WSsystem.Parent := WebservicePage.Surface;
    y:=y+38
    lbl_WSAuth := TNewStaticText.Create(WebservicePage);
    lbl_WSAuth.Top := ScaleY(y);
  //  lbl_WSAuth.Left := ScaleX(200);
    lbl_WSAuth.Caption := 'Auth:';
    lbl_WSAuth.Parent := WebservicePage.Surface;
    cb_WSauth := TComboBox.Create(WebservicePage);
    cb_WSauth.Top := ScaleY(Y+14);
   // cb_WSauth.Left := ScaleX(200); 
    cb_WSauth.Width := ScaleX(190);
    cb_WSauth.Parent := WebservicePage.Surface;
    cb_WSauth.Items.Add('secEnterprise');
    cb_WSauth.Items.Add('secLDAP');
    cb_WSauth.Items.Add('secWindowsNT');
    cb_WSauth.Items.Add('secWinAD');
    cb_WSauth.ItemIndex := 0;
    y:=y+38
    lbl_WSuser := TNewStaticText.Create(WebservicePage);
    lbl_WSuser.Top := ScaleY(y);
    lbl_WSuser.Caption := 'User name:';
    lbl_WSuser.Parent := WebservicePage.Surface;
    txt_WSuser := TNewEdit.Create(WebservicePage);
    txt_WSuser.Top := ScaleY(Y+14);
    txt_WSuser.Width := ScaleX(190);
    txt_WSuser.Parent := WebservicePage.Surface;
    y:=y+38
    lbl_WSpassword := TNewStaticText.Create(WebservicePage);
    lbl_WSpassword.Top := ScaleY(y);
    //lbl_WSpassword.Left := ScaleX(200);
    lbl_WSpassword.Caption := 'Password:';
    lbl_WSpassword.Parent := WebservicePage.Surface;
    txt_WSpassword := TPasswordEdit.Create(WebservicePage);
    txt_WSpassword.Top := ScaleY(Y+14);
    //txt_WSpassword.Left := ScaleX(200);
    txt_WSpassword.Width := ScaleX(190);
    txt_WSpassword.Parent := WebservicePage.Surface;
    y:=y+50
    bt_WStest := TNewButton.Create(WebservicePage);  
    bt_WStest.Top := ScaleY(y); 
    bt_WStest.Left := ScaleX(10); 
    bt_WStest.Caption := 'Test login to the web service';
    bt_WStest.Width := ScaleX(170);
   // bt_WStest.Height := ScaleX(40);
    bt_WStest.OnClick := @bt_WStestOnClick;
    bt_WStest.Parent := WebservicePage.Surface;

  end;


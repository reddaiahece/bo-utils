#define MyAppName "BusinessObjectsEtl"
#define MyDllName "BusinessObjectsEtl"
#define MyAppLongName "Business Objects Etl"
#define MyAppVersion GetFileVersion(".\bo-etl-lib\bin\Release\BusinessObjectsEtl.dll")
#define MyAppPublisher "Florent BREHERET"
#define MyAppURL "http://code.google.com/p/bo-utils/"

#define FirebirdInstall "Firebird-2.5.2.26540_0_Win32.exe"
#define FirebirdODBC "Firebird_ODBC_2.0.1.152_Win32.exe"
#define Flamerobin "flamerobin-0.9.2-1-setup.exe"

[Setup]
AppId={#MyAppName}
PrivilegesRequired=poweruser
AppName={#MyAppLongName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
VersionInfoTextVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppLongName}
DisableProgramGroupPage=yes
LicenseFile=.\License.txt
;InfoBeforeFile=.\ClassLibrary1\bin\Release\Info.txt
OutputDir="."
OutputBaseFilename=BusinessObjectsEtlSetup-{#MyAppVersion}
Compression=lzma
SolidCompression=yes

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"

[Dirs]

[Files]
Source: ".\bo-etl-runner\bin\Release\BusinessObjects.DSWS*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bo-etl-runner\bin\Release\FirebirdSql.Data.FirebirdClient.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bo-etl-runner\bin\Release\pluginwrapper.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bo-etl-runner\bin\Release\BusinessObjectsEtl.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bo-etl-runner\bin\Release\bo-etl.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bo-etl-runner\bin\Release\bo-etl.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bo-etl-runner\bin\Setup\SetUpJob.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\references\Innosetup\isxdl.dll"; DestDir: {tmp}; Flags: deleteafterinstall
Source: ".\references\Firebird\{#FirebirdInstall}"; DestDir: {tmp}; Flags: deleteafterinstall; Check: not IsFirebirdInstalled 
Source: ".\references\Firebird\{#FirebirdODBC}"; DestDir: {tmp}; Flags: deleteafterinstall; Check: not IsFirebirdODBCInstalled 
Source: ".\references\Firebird\{#Flamerobin}"; DestDir: {tmp}; Flags: deleteafterinstall; Check: not IsFlamerobinInstalled 
Source: ".\references\Firebird\fr_databases.conf"; DestDir: "{userappdata}\..\Local Settings\Application Data\flamerobin"; Flags: onlyifdoesntexist uninsneveruninstall
Source: ".\references\Firebird\fr_settings.conf"; DestDir: "{userappdata}\..\Local Settings\Application Data\flamerobin"; Flags: onlyifdoesntexist uninsneveruninstall
Source: ".\License.txt"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
;Name: "{group}\Readme"; Filename: "{app}\Readme.txt"; WorkingDir: "{app}";
;Name: "{group}\API documentation"; Filename: "{app}\SeleniumWrapperApi.chm"; WorkingDir: "{app}";      
;Name: "{group}\Help"; Filename: "{app}\help.chm"; WorkingDir: "{app}";
Name: "{group}\Set up a Job"; Filename: "{app}\SetUpJob.exe"; WorkingDir: "{app}";
Name: "{group}\FlameRobin Sql Editor"; Filename: {pf32}\FlameRobin\flamerobin.exe; WorkingDir: "{app}";
;Name: "{group}\Project Home Page"; Filename: "http://code.google.com/p/bo-utils/"; WorkingDir: "{app}";
;Name: "{group}\ODBC Data Source"; Filename: "odbcad32.exe";
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

[Registry]
;clean com objects in the registry
Root: HKCR; Subkey: "BusinessObjectsEtl.Assembly"; Flags: deletekey
Root: HKCR; Subkey: "{{AD47E6ED-92F3-4A6C-8E06-7E75D1A297E1}"; Flags: deletekey
Root: HKCR; Subkey: "BusinessObjectsEtl.Etl"; Flags: deletekey
Root: HKCR; Subkey: "{{83847508-4471-441F-89C1-8ECA1339ED90}"; Flags: deletekey
Root: HKCR; Subkey: "BusinessObjectsEtl.Firebird"; Flags: deletekey
Root: HKCR; Subkey: "{{2B485454-4EC1-4F6A-B7B1-0F206A3677A7}"; Flags: deletekey
;create file extention association with flamerobin
Root: HKCR; Subkey: ".FDB"; ValueType: string; ValueData: "FDB_file"; Flags: uninsdeletekey
Root: HKCR; Subkey: "FDB_file\shell\open\command"; ValueType: string; ValueData: """{pf}\FlameRobin\flamerobin.exe"" ""%1"""; Flags: uninsdeletekey

[Run]
Filename: "{dotnet2064}\RegAsm.exe"; Parameters: {#MyDllName}.dll /codebase /tlb:{#MyDllName}.tlb; WorkingDir: {app}; StatusMsg: "Registering {#MyDllName} dll"; Flags: runhidden; Check: IsWin64;
Filename: "{dotnet2032}\RegAsm.exe"; Parameters: {#MyDllName}.dll /codebase /tlb:{#MyDllName}.tlb; WorkingDir: {app}; StatusMsg: "Registering {#MyDllName} dll"; Flags: runhidden;
                                                                                                                                                                                                      
[UninstallDelete]
Type: files; Name: "{app}\{#MyDllName}.tlb"

[UninstallRun]
Filename: "{dotnet2064}\RegAsm.exe"; Parameters: {#MyDllName}.dll /unregister /tlb:{#MyDllName}.tlb; WorkingDir: {app}; StatusMsg: "Unregistering {#MyDllName} dll"; Flags: runhidden; Check: IsWin64;
Filename: "{dotnet2032}\RegAsm.exe"; Parameters: {#MyDllName}.dll /unregister /tlb:{#MyDllName}.tlb; WorkingDir: {app}; StatusMsg: "Unregistering {#MyDllName} dll"; Flags: runhidden;

[Code]
function GetFlameRobinDir(Param: String): String;
  begin
    if not RegQueryStringValue(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\FlameRobin_is1', 'InstallLocation', Result) then begin
      RegQueryStringValue(HKEY_LOCAL_MACHINE, 'SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\FlameRobin_is1', 'InstallLocation', Result);
    end;
  end;


//---------------------------------------------------------------------------------------
// Download and install an exe
//---------------------------------------------------------------------------------------
procedure isxdl_AddFile(URL, Filename: PChar);
external 'isxdl_AddFile@files:isxdl.dll stdcall';
function isxdl_DownloadFiles(hWnd: Integer): Integer;
external 'isxdl_DownloadFiles@files:isxdl.dll stdcall';
function isxdl_SetOption(Option, Value: PChar): Integer;
external 'isxdl_SetOption@files:isxdl.dll stdcall';

function InstallSoftware( url: string; file: string; arguments: string; info: string; description: string ): Boolean;
  var dotnetRedistPath: string; hWnd: Integer; ResultCode: Integer; 
  begin
    dotnetRedistPath := ExpandConstant('{tmp}\' + file);
    if not FileExists(dotnetRedistPath) then begin
      isxdl_AddFile(url, dotnetRedistPath);
      hWnd := StrToInt(ExpandConstant('{wizardhwnd}'));
      isxdl_SetOption('label', info);
      isxdl_SetOption('description', description);
      if isxdl_DownloadFiles(hWnd) <> 0 then begin
        if Exec(ExpandConstant(dotnetRedistPath), arguments, '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then begin
           result := (ResultCode = 0);
        end;
      end;
    end;
  end;

//---------------------------------------------------------------------------------------
// Firebird Installation
//---------------------------------------------------------------------------------------
function IsFirebirdInstalled() : Boolean;
  begin
    result := RegKeyExists(HKLM,'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\FBDBServer_2_5_is1') Or RegKeyExists(HKLM,'SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\FBDBServer_2_5_is1');
  end;

function InstallFirebird() : boolean;
  var  ResultCode: Integer;
  begin
    if not IsFirebirdInstalled() then begin
      if ShellExec('', ExpandConstant('{tmp}\{#FirebirdInstall}'), '/LANG=english /SILENT', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then result:= (ResultCode <> 0);
    end;
  end;
  
//---------------------------------------------------------------------------------------
// FirebirdODBC Installation
//---------------------------------------------------------------------------------------
function IsFirebirdODBCInstalled() : Boolean;
  begin
    result := RegKeyExists(HKLM,'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Firebird ODBC Driver_is1') Or RegKeyExists(HKLM,'SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Firebird ODBC Driver_is1');
  end;

function InstallFirebirdODBC() : boolean;
  var  ResultCode: Integer;
  begin
    if not IsFirebirdODBCInstalled() then begin
      if ShellExec('', ExpandConstant('{tmp}\{#FirebirdODBC}'), '/SILENT /NOICONS', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then result:= (ResultCode <> 0);
    end;
  end;
    
//---------------------------------------------------------------------------------------
// Flamerobin Installation
//---------------------------------------------------------------------------------------
function IsFlamerobinInstalled() : Boolean;
  begin
    result := RegKeyExists(HKLM,'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\FlameRobin_is1') Or RegKeyExists(HKLM,'SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\FlameRobin_is1');
  end;

function InstallFlamerobin() : boolean;
  var  ResultCode: Integer;
  begin
    if not IsFlamerobinInstalled() then begin
      if ShellExec('', ExpandConstant('{tmp}\{#Flamerobin}'), '/SILENT', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then result:= (ResultCode <> 0);
      //CreateShellLink( ExpandConstant('{group}\FlameRobin Sql Editor.lnk'), 'Opens the licence database in SQLite', GetFlameRobinDir(#0) + 'flamerobin.exe', '', GetFlameRobinDir(#0), '', 0, SW_SHOWNORMAL );
    end;
  end;

//---------------------------------------------------------------------------------------
// NET Framework Installation
//---------------------------------------------------------------------------------------
const dotnetRedistURLx64 = 'http://download.microsoft.com/download/c/6/e/c6e88215-0178-4c6c-b5f3-158ff77b1f38/NetFx20SP2_x64.exe';
const dotnetRedistURLx86 = 'http://download.microsoft.com/download/c/6/e/c6e88215-0178-4c6c-b5f3-158ff77b1f38/NetFx20SP2_x86.exe';

function InstallNetFramework(checkOnly : boolean) : Boolean;
  var ResultCode: Integer; 
  begin
    result := not (RegKeyExists(HKLM,'SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727') Or RegKeyExists(HKLM,'SOFTWARE\Wow6432Node\Microsoft\NET Framework Setup\NDP\v2.0.50727'));
    if result and (not checkOnly) then begin 
      if (not IsAdminLoggedOn()) then begin
        MsgBox('Microsoft .NET Framework 2.0 needs to be installed by an Administrator', mbInformation, MB_OK);
      end else begin
         if IsWin64() then begin
            result:= InstallSoftware( dotnetRedistURLx64, 'NetFx20SP2_x64.exe', '', 'Downloading Microsoft .NET Framework 2.0', 'Please wait while Setup is downloading extra files to your computer.') = false;
         end else begin
            result:= InstallSoftware( dotnetRedistURLx86, 'NetFx20SP2_x86.exe', '', 'Downloading Microsoft .NET Framework 2.0', 'Please wait while Setup is downloading extra files to your computer.') = false;
         end;
      end
      if InstallNetFramework(true) then begin
        MsgBox(ExpandConstant('Failed to install Microsoft .NET Framework 2.0 Service Pack 2 !  '#13'Please download and install it to continue the installaton'), mbError, MB_OK);
        ShellExec('open', 'http://www.microsoft.com/en-us/download/details.aspx?id=1639','', '', SW_SHOW, ewNoWait, ResultCode);
        result:= true;
      end
    end;
  end;

//---------------------------------------------------------------------------------------
// Check the installed application
//---------------------------------------------------------------------------------------
procedure TestInstallation();
var sLibVersion: Variant;
begin
    try
      sLibVersion := CreateOleObject(ExpandConstant('{#MyAppName}.Assembly'));
      sLibVersion.GetVersion();
    except
      RaiseException( 'Instalation tests failed ! '#13'Error : ' + GetExceptionMessage );
    end;
end;
                
//---------------------------------------------------------------------------------------
// Uninstall previous version
//---------------------------------------------------------------------------------------
function UnInstallPrevious(checkOnly: boolean): boolean;
  var sUnInstallString: String; iResultCode: Integer;
  begin
    result:= RegQueryStringValue(HKLM, ExpandConstant('SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppName}_is1'), 'UnInstallString', sUnInstallString);
    if not result then result:= RegQueryStringValue(HKLM, ExpandConstant('SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppName}_is1'), 'UnInstallString', sUnInstallString);
    if result and not checkOnly then Begin
        Exec( RemoveQuotes(sUnInstallString), '/SILENT', '', SW_SHOW, ewWaitUntilTerminated, iResultCode) ;
        //if iResultCode <> 0 then Abort();
        Sleep(1000);
    end;
  end;

//---------------------------------------------------------------------------------------
// Update list of todo
//---------------------------------------------------------------------------------------
function UpdateReadyMemo(Space, NewLine, MemoUserInfoInfo, MemoDirInfo, MemoTypeInfo, MemoComponentsInfo, MemoGroupInfo, MemoTasksInfo: String): String;
var
  s: string;
begin
  s := s + 'Uninstall previous version: ' + NewLine;
  if UnInstallPrevious(true) then s := s + Space + 'Found a previous installation to uninstall' + NewLine;
  s:= s + NewLine;
  s:= s + 'Dependencies to download and install:' + NewLine;
  if InstallNetFramework(true) then s := s + Space + 'Microsoft .Net Framework 2' + NewLine;
  if not IsFirebirdInstalled() then s := s + Space + 'Firebird database server' + NewLine;
  if not IsFirebirdODBCInstalled() then s := s + Space + 'ODBC driver for Firebird' + NewLine;
  if not IsFlamerobinInstalled() then s := s + Space + 'Flamerobin Sql editor' + NewLine;
  s := s + NewLine;
  s := s + MemoDirInfo + NewLine + NewLine;
  s:= s + 'Program to install:' + NewLine;
  s := s + Space + ExpandConstant('{#MyAppName} {#MyAppVersion}') + NewLine;
  s := s + NewLine;
  Result := s
end;

//---------------------------------------------------------------------------------------
// Uninstall previous version and install additional applications
//---------------------------------------------------------------------------------------
procedure CurStepChanged(CurStep: TSetupStep);
  begin
    if CurStep = ssInstall  then begin
      UnInstallPrevious(false);
      if InstallNetFramework(false) then Abort();
    end else if CurStep = ssPostInstall  then begin
      if InstallFirebird() then Abort();
      if InstallFirebirdODBC() then Abort();
      if InstallFlamerobin() then Abort();
    end else if CurStep = ssDone then begin

    end Else If CurStep = ssPostInstall then begin
      TestInstallation();
    end;
  end;






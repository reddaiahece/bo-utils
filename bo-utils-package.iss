#define MyAppName "BusinessObjectsUtils"
#define MyAppLongName "Business Objects Utils"
#define MyDllName "bo-utils-addin"
#define MyAppVersion GetFileVersion(".\bo-utils-addin\bin\Release12\bo-utils-addin.dll")
#define MyAppPublisher "Florent BREHERET"
#define MyAppURL "https://code.google.com/p/bo-utils/"

[Setup]
AppId={#MyAppName}
PrivilegesRequired=poweruser
AppName={#MyAppLongName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppLongName} {#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
VersionInfoTextVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
UsePreviousAppDir=no
DisableDirPage=yes
DefaultDirName={code:AppDir|}
DefaultGroupName={#MyAppLongName}
DisableProgramGroupPage=yes
LicenseFile=.\License.txt
OutputDir=.
OutputBaseFilename={#MyAppName}Setup-{#MyAppVersion}
Compression=lzma
SolidCompression=yes

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"

[Dirs]


[Files]
Source: ".\bo-utils-addin\bin\Release11\*.dll"; DestDir: {app}; Flags: ignoreversion; Check: IsExcel2003;
Source: ".\bo-utils-addin\bin\Release12\*.dll"; DestDir: {app}; Flags: ignoreversion; Check: IsExcel2007orSup;
Source: ".\bo-utils-addin\BO-Utils-Template.xlt"; DestDir: "{app}"; DestName: "BO-Utils.xlt"; Flags: ignoreversion skipifsourcedoesntexist overwritereadonly; Attribs:readonly; Check: IsExcel2003
Source: ".\bo-utils-addin\BO-Utils-Template.xltx"; DestDir: "{app}"; DestName: "BO-Utils.xltx"; Flags: ignoreversion skipifsourcedoesntexist overwritereadonly; Check: IsExcel2007orSup
Source: ".\License.txt"; DestDir: "{app}"; Flags: ignoreversion

Source: ".\bo-utils-runner\bin\Release\bo-utils.exe"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{userprograms}\{#MyAppLongName}\Project Home Page"; Filename: {#MyAppURL}; 
Name: "{userprograms}\{#MyAppLongName}\{cm:UninstallProgram,{#MyAppLongName}}"; Filename: "{uninstallexe}"
Name: "{userprograms}\{#MyAppLongName}\Excel Template"; Filename: "{app}\BO-Utils.xlt"; WorkingDir: "{app}"; Check: IsExcel2003
Name: "{userprograms}\{#MyAppLongName}\Excel Template"; Filename: "{app}\BO-Utils.xltx"; WorkingDir: "{app}"; Check: IsExcel2007orSup

[Registry]
Root: HKCR; Subkey: "BOUtilsAddin.Connect"; Flags: deletekey uninsdeletevalue
Root: HKCR; Subkey: "CLSID\{{CB9AD7C2-DBA2-4CEB-BD80-50B23D4284F7}"; Flags: deletekey uninsdeletevalue;
Root: HKCU; Subkey: "SOFTWARE\Microsoft\Office\Excel\AddIns\BOUtilsAddin.Connect\"; ValueType: string; ValueName: "Description"; ValueData: "BO-Utils"; Flags: uninsdeletevalue deletekey;
Root: HKCU; Subkey: "SOFTWARE\Microsoft\Office\Excel\AddIns\BOUtilsAddin.Connect\"; ValueType: string; ValueName: "FriendlyName"; ValueData: "BO-Utils"; Flags: uninsdeletevalue;
Root: HKCU; Subkey: "SOFTWARE\Microsoft\Office\Excel\AddIns\BOUtilsAddin.Connect\"; ValueType: dword; ValueName: "LoadBehavior"; ValueData: "3"; Flags: uninsdeletevalue;

;Fix for excel 2003 KB907417
Root: HKLM; Subkey: "SOFTWARE\Microsoft\.NETFramework\Policy\AppPatch\v2.0.50727.00000\excel.exe"; Flags: deletekey; Check: IsExcel2003;

[Run]
Filename: "{dotnet2032}\RegAsm.exe"; Parameters: {#MyDllName}.dll /codebase /tlb:{#MyDllName}.tlb; WorkingDir: {app}; StatusMsg: "Registering 32bit Excel COM Add-in"; Flags: 32bit runhidden waituntilterminated; Check: IsExcel32;
Filename: "{dotnet2064}\RegAsm.exe"; Parameters: {#MyDllName}.dll /codebase /tlb:{#MyDllName}.tlb; WorkingDir: {app}; StatusMsg: "Registering 64bit Excel COM Add-in"; Flags: 64bit runhidden waituntilterminated; Check: IsExcel64;

Filename: "{app}\BO-Utils.xlt"; Flags: shellexec postinstall; Description: "Launch Excel Template"; Check: IsExcel2003
Filename: "{app}\BO-Utils.xltx"; Flags: shellexec postinstall; Description: "Launch Excel Template"; Check: IsExcel2007orSup
                                                                                                                                                                                                  
[UninstallDelete]
Type: filesandordirs; Name: "{userappdata}\{#MyAppName}";
Type: filesandordirs; Name: "{app}";

[UninstallRun]                                                                                                                    
Filename: "{dotnet2032}\RegAsm.exe"; Parameters: {#MyDllName}.dll /unregister /tlb:{#MyDllName}.tlb; WorkingDir: {app}; StatusMsg: "Unregistering 32bit Excel COM Add-in"; Flags: 32bit runhidden waituntilterminated; Check: IsExcel32;
Filename: "{dotnet2064}\RegAsm.exe"; Parameters: {#MyDllName}.dll /unregister /tlb:{#MyDllName}.tlb; WorkingDir: {app}; StatusMsg: "Unregistering 64bit Excel COM Add-in"; Flags: 64bit runhidden waituntilterminated; Check: IsExcel64;

[Code]

var _AppDir: String;
var _Version: String;
var _IsWin32: Boolean;
var _IsExcel32: Boolean;
var _IsExcel64: Boolean;
var _IsExcel2003: Boolean;
var _IsExcel2007orSup: Boolean;

//---------------------------------------------------------------------------------------
// Excel functions
//--------------------------------------------------------------------------------------- 
function GetExcelVersionStr(): String;
  var lVersion: String; i: Integer;
  begin
    if _Version='' then begin
      if RegKeyExists(HKCR,'Excel.Application\CurVer') then begin
        RegQueryStringValue(HKCR,'Excel.Application\CurVer', '', lVersion);
      end else RaiseException( 'Failed to detect Excel version!' );
      for i := 1 to Length(lVersion) do
          if (lVersion[i] >= '0') and (lVersion[i] <= '9') then _Version := _Version + lVersion[i];
    end
    Result := _Version;
  end;

//---------------------------------------------------------------------------------------
// Status
//---------------------------------------------------------------------------------------
function IsWin32(): Boolean;
  begin
    if not _IsWin32 then _IsWin32 := Not IsWin64();
    Result := _IsWin32;
  end;

function IsExcel64(): Boolean;
  begin
    if not _IsExcel64 then _IsExcel64 := IsWin64() and RegKeyExists(HKLM64,'SOFTWARE\Microsoft\Office\' + GetExcelVersionStr() + '.0\Excel');
    Result := _IsExcel64;
  end;

function IsExcel32(): Boolean;
  begin
    if not _IsExcel32 then _IsExcel32 := Not IsExcel64();
    Result := _IsExcel32;
  end;

function IsExcel2003(): Boolean;
  begin
    if not _IsExcel2003 then _IsExcel2003 := StrToIntDef(GetExcelVersionStr(), 0) = 11;
    Result := _IsExcel2003;
  end;

function IsExcel2007orSup(): Boolean;
  begin
    if not _IsExcel2007orSup then _IsExcel2007orSup := StrToIntDef(GetExcelVersionStr(), 0) > 11;
    Result := _IsExcel2007orSup;
  end;
 
function AppDir(argument : String): String;
  begin
    if _AppDir = '' then begin
        if IsWin64() then _AppDir := ExpandConstant('{pf64}\{#MyAppName}') else _AppDir := ExpandConstant('{pf32}\{#MyAppName}');
    end
    Result := _AppDir;
  end;

//---------------------------------------------------------------------------------------
// NET Framework
//---------------------------------------------------------------------------------------
Function CheckDotNetFramework() : boolean;
  var
    iResultCode: Integer;
  Begin
    Result := RegKeyExists(HKLM32,'SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727');
    if not Result And IsWin64 then Result:= RegKeyExists(HKLM64,'SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727');
    If not Result Then Begin
      MsgBox(ExpandConstant('Microsoft .NET Framework 2.0 is required !  '+ CHR(13) + 'Please download and install it to continue the installaton.'), mbError, MB_OK);
      ShellExec('open', 'http://www.microsoft.com/en-us/download/details.aspx?id=1639','', '', SW_SHOW, ewNoWait, iResultCode);
    End;
  End;

//---------------------------------------------------------------------------------------
// Uninstall previous version
//---------------------------------------------------------------------------------------
function UnInstallPrevious(): boolean;
  var sUnInstallString: String; iResultCode: Integer;
  begin
    result:= RegQueryStringValue(HKLM32, ExpandConstant('SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppName}_is1'), 'UnInstallString', sUnInstallString);
    if not result and IsWin64 then result:= RegQueryStringValue(HKLM64, ExpandConstant('SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppName}_is1'), 'UnInstallString', sUnInstallString);
    if result then Begin
        Exec( RemoveQuotes(sUnInstallString), '/SILENT', '', SW_SHOW, ewWaitUntilTerminated, iResultCode);
        Sleep(1000);
    end;
    result := iResultCode <> 1;
  end;

//---------------------------------------------------------------------------------------
// Check on use
//---------------------------------------------------------------------------------------
Function IsOnUse(): boolean;
  var file_tlb: String; file_dll: String;
  Begin
    file_tlb := ExpandConstant('{app}\{#MyDllName}.tlb' );
    file_dll := ExpandConstant('{app}\{#MyDllName}.dll' );
    if FileExists( file_tlb ) and FileExists( file_dll ) then begin
       while not result and not( RenameFile( file_tlb, file_tlb ) and RenameFile( file_dll, file_dll )  )do
           result := IDCANCEL = MsgBox(ExpandConstant('Uninstallation of {#MyAppLongName} is not possible as a program is currently using it.'#13'Close all Office applications and try again.'), mbError, MB_RETRYCANCEL);
    end;
  End;

//---------------------------------------------------------------------------------------
// Workflow
//---------------------------------------------------------------------------------------
Function InitializeSetup() : boolean;
  Begin
    Result := CheckDotNetFramework();
  End;

procedure CurStepChanged(CurStep: TSetupStep);
  begin
    if CurStep = ssInstall  then begin
      if not UnInstallPrevious() then Abort;
    end else if CurStep = ssDone then begin

    end Else If CurStep = ssPostInstall then begin

    end;
  end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep); 
  begin
    if CurUninstallStep = usUninstall  then begin
        if IsOnUse() then Abort();
    end;
  end;



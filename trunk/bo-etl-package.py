import os, string, re, time, fileinput, sys, shutil
from datetime import datetime
from subprocess import Popen, PIPE

Project_name = 'Business Objects ETL';
Current_dir = os.getcwd() + '\\';
AssemblyInfo_path = Current_dir + r'bo-etl-lib\Properties\AssemblyInfo.cs';
VersionDll_path = Current_dir + r'bo-etl-lib\bin\Release\BusinessObjectsEtl.dll';

sevenzip_path = r"C:\Program Files\7-Zip\7zFM.exe";
innosetup_path = r"C:\Program Files\Inno Setup 5\ISCC.exe";
msbuild_path = r"C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe";

def CheckPaths():
	for path in dir():
		if( path.endswith('_path') and not os.path.isfile(eval(path)) ) :
			print('Missing ' + path + '=' + eval(path) );
		elif( path.endswith('_dir') and not os.path.isdir(eval(path)) ) :
			print('Missing ' + path + '=' + eval(path))

def ReplaceInFile(file_path, pattern, replacement):
    text = open(file_path, 'r').read();
    open(file_path, 'w').write( re.sub(pattern, replacement, text ) );
    return;

def DeleteFolder(folder_path):
	if(os.path.isdir(folder_path)) : shutil.rmtree(folder_path);
	return;

def RunCommand(arguments):
    proc = Popen(arguments, stdout=PIPE, stderr=PIPE, shell=False)
    proc.wait()
    if(proc.returncode != 0):
        print('\r\n  ERROR while executing command:\r\n\r\n' + ' '.join(arguments) + '\r\n')
        print('\r\n  ERROR details:\r\n')
        for line in proc.stdout: print(line.decode("utf-8").replace('\r\n', ''))
        for line in proc.stderr: print(line.decode("utf-8").replace('\r\n', ''))
        print('\r\n\r\n')
        return False;
    return True;

def GetVersion(version):
    new_version =""
    while (new_version == ""):
        try: res = raw_input("Digit to increment [w.x.y.z] or version [0.0.0.0] or skip [s] ? ");
        except NameError: res = input("Digit to increment [w.x.y.z] or version [0.0.0.0] or skip [s] ? ");
        if ( re.match(r"^s|z|y|x|w$", res)) :
            version_digit = version.split('.');
            new_version = {
                "s" : version,
                "z" : version_digit[0] + "." + version_digit[1] + "." + version_digit[2] + "." + str(int(version_digit[3])+1),
                "y" : version_digit[0] + "." + version_digit[1] + "." + str(int(version_digit[2])+1) + ".0",
                "x" : version_digit[0] + "." + str(int(version_digit[1]) + 1) + ".0.0",
                "w" : str(int(version_digit[0])+1) + ".0.0.0",
            }.get(res, '');
        elif ( re.match(r"^\d+\.\d+\.\d+\.\d+$", res) ):
            new_version = res;
    return new_version

def MsBuild(csproj):
	return RunCommand([ msbuild_path,'/v:quiet', '/t:build', '/p:Configuration=Release;TargetFrameworkVersion=v3.5;SignAssembly=true', csproj ]);

CheckPaths();
CurrentVersion = re.findall(r'Version\("([.\d]+)"\)', open(AssemblyInfo_path, 'r').read())[0];
LastModified = datetime.fromtimestamp(os.path.getmtime(VersionDll_path)) if os.path.isfile(VersionDll_path) else 0

print( "_______________________________________________________________________" )
print( "" )
print( "Project name     : " + Project_name )
print( "Current Version  : " + CurrentVersion )
print( "Last compilation : " + (LastModified.strftime("%Y-%m-%d %H:%M:%S") if LastModified != 0 else '') )
print( "_______________________________________________________________________\r\n" )

NewVersion = GetVersion(CurrentVersion)

print( "New version : " + NewVersion + "\n")
print( "** Update version in AssemblyInfo.cs ..." )
ReplaceInFile( AssemblyInfo_path, r'Version\("[.\d]+"\)', r'Version("' + NewVersion + '")' )

print( "** Clear previous compilations ...")
DeleteFolder(Current_dir + r'bo-etl-lib\bin' );
DeleteFolder(Current_dir + r'bo-etl-lib\obj' );
DeleteFolder(Current_dir + r'bo-etl-runner\bin' );
DeleteFolder(Current_dir + r'bo-etl-runner\obj' );

print( "** Compile main library ...")
if( not MsBuild( Current_dir + r'bo-etl-lib\bo-etl-lib.csproj' ) ): exit(1)

print( "** Compile runner ...")
if( not MsBuild( Current_dir + r'bo-etl-runner\bo-etl-runner.csproj' ) ): exit(1)

print( "** Build setup package ...")
if( not RunCommand([ innosetup_path, '/q', Current_dir + r'bo-etl-runner\bo-etl-job-package.iss' ])): exit(1)
if( not RunCommand([ innosetup_path, '/q', '/O'+Current_dir, Current_dir + r'bo-etl-package.iss' ])): exit(1)

print( "\r\nEnd")
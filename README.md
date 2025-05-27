# Prerequisite
1. ZackDictCore.zip: To be hacked
2. Install DB.Browser.for.SQLite. 
   - DB Browser (SQLCipher): Open encrypted SQLite DB using SQLCipher
   - DB Browser (SQLite): Open unencrypted SQLite DB
3. Install dnEditor: .NET assembly editor
4. ILSpy: .NET decompiler
5. [WinDBG](https://learn.microsoft.com/en-us/windows-hardware/drivers/debugger/): Debugger 

# Attempt 0
1. Open sqlite file using DB Browser (SQLite)
2. Open sqlite file using DB Browser (SQLCipher)
3. Check connection string.
4. Decompile using ILSpy.

# Attempt 1: WinDbg
1. Install WinDbg
2. Launch the debugged application and break.
3. Open View --> command
2. Load clr module(.Net Framework)

```
.loadby sos clr
```

3. Load clr module(.Net Core)

- Install sos

```
dotnet tool install -g dotnet-sos
dotnet sos install
```

- Load

```
.load C:\Users\{yourusername}\.dotnet\sos\sos.dll
```

4. Dump strings

```
!dumpheap -type System.String -strings
```

5. Search "Password"
6. Open db file using DB Browser (SQLite).

# Attempt 2: Edit dll

1. Use ILSpy to understand Microsoft.Data.Sqlite.dll, let's hack Microsoft.Data.Sqlite.SqliteConnection.ConnectionString
2. Regular way: add break point to set_ConnectionString
3. My way:

Use dnEditor to edit an assembly, and prepend the following IL instructions:

```
ldarg.1
ldc.i4.0
new obj System.Void Microsoft.Data.Sqlite.SqliteException::.ctor(System.String, System.Int32)
throw
```
4. Save
5. Run.

# Attempt 3:
1. Create a Windows Form application(.NET)
2. Add reference to Microsoft.Data.Sqlite.dll under the cracked application
3. 
```
var asmMain = Assembly.LoadFrom("ZackDictCore.dll");
Thread thread = new Thread(() => {
	MessageBox.Show("Wait");
	try
	{
		var form = Application.OpenForms[0];
		var fieldSqliteConnection = form.GetType().GetMembers(BindingFlags.Public | BindingFlags.NonPublic |
								BindingFlags.Instance | BindingFlags.Static |
								BindingFlags.DeclaredOnly)
								.Where(e => e.MemberType == MemberTypes.Field)
			 .Select(e => (FieldInfo)e).Where(e => e.FieldType.Name.Contains("SqliteConnection"))
								.FirstOrDefault();
		var sqliteConnection = (SqliteConnection)fieldSqliteConnection.GetValue(form);
		sqliteConnection.Open();
		SqliteConnection destConnection = new SqliteConnection("Data Source=decrypted.db");
		destConnection.Open();
		sqliteConnection.BackupDatabase(destConnection);
		destConnection.Close();
		MessageBox.Show("Done");
	}
	catch (Exception ex)
	{
		MessageBox.Show(ex.ToString());
	}
});
thread.Start();
asmMain.EntryPoint.Invoke(null, new object[0]);
```
4. Copy built into cracked application's dir
5. Run(Where I made it back then). Oh my god
6. Get table names
7. Get table fields
8. Run selected.

# How to prevent being hacked?

1. obfuscator.
2. Native AOT. How to hack?
3. This is a never-ending battle of attack and defense.
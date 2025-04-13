#Attempt 1: WinDbg
1. Install WinDbg
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
5. Search"Password"

#Attempt 2: Edit dll
1. Use ILSpy to understand Microsoft.Data.Sqlite.dll, let's hack Microsoft.Data.Sqlite.SqliteConnection.ConnectionString
2. Regular way: add break point to set_ConnectionString
3. My way:
```
ldarg.1
ldc.i4.0
new obj System.Void Microsoft.Data.Sqlite.SqliteException::.ctor(System.String, System.Int32)
```
4. Save
5. Run. 

#Attempt 3:
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
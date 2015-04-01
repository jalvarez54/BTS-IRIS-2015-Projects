===============================================
25/03/2015 BTS IRIS 2015 SWACF and WSC projects
=================================================================

////////////////////////
// TODO
//////////////////////////////////////////////////////////////
[JA]
- Continuous integration on CDF server: http://fr.wikipedia.org/wiki/Int%C3%A9gration_continue
	Distant: http://89.87.172.42/Cdf54SwacfSwc
	Local: http://192.168.107.253/Cdf54SwacfSwc
	Database:
		connectionString = DefaultConnection
		data source=192.168.107.232,
		initial catalog=Cdf54.Projet2015,
		User ID=cdf54projet
		Password=XXXXXXXXXXXXXXXX
- ADD: Web.Staging.config
	==>
- ADD: Dossier Technique
	==> done
-
-
[]
-
-
-
-
[]
-
-
-
-


////////////////////////
// Version 1.0.Alpha
//////////////////////////////////////////////////////////////
[]
-
-
-
-
[]
-
-
-
-


////////////////////////
// Version 0.0.Alpha
//////////////////////////////////////////////////////////////
[]
-
-
-
-
[]
-
-
-
-
[]
-
-
-
-
//////////////////////////////////////////////////////////////
[2015-03-31 - JA]
- ADD: Dossier Technique
- Commit on Codeplex (107295): https://cdf54swacfwsc.codeplex.com/ 
- ADD: elements to Dossier Technique
- Commit on Codeplex (107296): https://cdf54swacfwsc.codeplex.com/ 
- ADD: Cdf54.Projet2015.Modeling project
- Commit on Codeplex (?): https://cdf54swacfwsc.codeplex.com/ 



//////////////////////////////////////////////////////////////
[2015-03-26 - JA]
- Install-Package Microsoft.AspNet.Identity.Samples -Pre
	- http://www.codeproject.com/Articles/790720/ASP-NET-Identity-Customizing-Users-and-Roles
	- http://www.codeproject.com/Articles/762428/ASP-NET-MVC-and-Identity-Understanding-the-Basics
	- http://www.asp.net/identity/overview/features-api/account-confirmation-and-password-recovery-with-aspnet-identity
	- http://www.asp.net/identity/overview/features-api/two-factor-authentication-using-sms-and-email-with-aspnet-identity
		Please see http://go.microsoft.com/fwlink/?LinkID=301950 for more information on using ASP.NET Identity.
		About this sample
		------------------------------------------------------------
		This is a sample template which shows how you can do the most common scenarios in ASP.NET Identity such 
		as Local Logins, Social Logins, Account Confirmation, Password Reset, Two-Factor Authentication and more.
		For more information on how to configure this sample for these feature, please visit http://go.microsoft.com/fwlink/?LinkID=320973

		Running this sample in your ASP.NET application
		------------------------------------------------------------
		This is a sample template so please install this in an empty ASP.NET project only. Installing this in an 
		existing application will have some side effects as this sample configures OWIN middlewares in StartupAuth.cs 
		and creates a database for storing membership information.
- Change namespace IdentitySample to Cdf54.Mvc.SignalR.SWACF.WSC for the complete solution.
- ADD: If not exist App_Data folder.
- Seed some users and roles. See App_Start/IdentityConfig.cs
- Change connectionString.
- Launch application and login with for example: admin@cdf54.local/P@ssword2015
	This will create the data base Cdf54.Mvc.SWACF.mdf
	App_Start/IdentityConfig.cs/Seed will be executed.
	201503260505405_InitialCreate in _Migrations table
- Enable-Migrations
	Checking if the context targets an existing database...
	Detected database created with a database initializer.
	Scaffolded migration '201503251705174_InitialCreate' corresponding to existing database.
	To use an automatic migration instead, delete the Migrations folder and re-run Enable-Migrations specifying the -EnableAutomaticMigrations parameter.
	Code First Migrations enabled for project Cdf54.Projet2015.
- Delete the Migrations folder
- Enable-Migrations -EnableAutomaticMigrations (This will create Migrations/Configuration.cs)
	Checking if the context targets an existing database...
	Code First Migrations enabled for project Cdf54.Projet2015.
- Install-Package Microsoft.AspNet.SignalR
	Please see http://go.microsoft.com/fwlink/?LinkId=272764 for more information on using SignalR.

	Upgrading from 1.x to 2.0
	-------------------------
	Please see http://go.microsoft.com/fwlink/?LinkId=320578 for more information on how to 
	upgrade your SignalR 1.x application to 2.0.

	Mapping the Hubs connection
	----------------------------
	To enable SignalR in your application, create a class called Startup with the following:

	using Microsoft.Owin;
	using Owin;
	using MyWebApplication;

	namespace MyWebApplication
	{
		public class Startup
		{
			public void Configuration(IAppBuilder app)
			{
				app.MapSignalR();
			}
		}
	} 

	Getting Started
	---------------
	See http://www.asp.net/signalr/overview/getting-started for more information on how to get started.

	Why does ~/signalr/hubs return 404 or Why do I get a JavaScript error: 'myhub is undefined'?
	--------------------------------------------------------------------------------------------
	This issue is generally due to a missing or invalid script reference to the auto-generated Hub JavaScript proxy at '~/signalr/hubs'.
	Please make sure that the Hub route is registered before any other routes in your application.
 
	In ASP.NET MVC 4 you can do the following:
 
			<script src="~/signalr/hubs"></script>
 
	If you're writing an ASP.NET MVC 3 application, make sure that you are using Url.Content for your script references:
 
		<script src="@Url.Content("~/signalr/hubs")"></script>
 
	If you're writing a regular ASP.NET application use ResolveClientUrl for your script references or register them via the ScriptManager 
	using a app root relative path (starting with a '~/'):
 
		<script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
 
	If the above still doesn't work, you may have an issue with routing and extensionless URLs. To fix this, ensure you have the latest 
	patches installed for IIS and ASP.NET.
- ADD: app.MapSignalR(); in Startup.cs/Startup/Configuration(IAppBuilder app)
- UPDATE: Jquery 1.10.0 to 2.1.3
- Published on Codeplex (107269): https://cdf54swacfwsc.codeplex.com/ 

//////////////////////////////////////////////////////////////
[2015-03-25 - JA]
- Template: Empty web project
- ADD: ReadMe.txt
- UPDATE: AssemblyInfo.cs


////////////////////////
// SignalR Performances
//////////////////////////////////////////////////////////////
[]
-
-
-
-

////////////////////////
// NB
//////////////////////////////////////////////////////////////
[]
-
-
-
-

using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using System.Collections.Generic;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Win.Utils;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using Microsoft.EntityFrameworkCore;
using DevExpress.ExpressApp.EFCore;
using DevExpress.EntityFrameworkCore.Security;
using Pets.Module;
using Pets.Module.BusinessObjects;
using System.Data.Common;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;

namespace Pets.Win {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Win.WinApplication._members
    public partial class PetsWindowsFormsApplication : WinApplication {
        public PetsWindowsFormsApplication() {
			InitializeComponent();
			SplashScreen = new DXSplashScreen(typeof(XafSplashScreen), new DefaultOverlayFormOptions());
        }
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            AuditedDbContextFactory<DbContext, DbContext> dbContextFactory = AuditedDbContextFactory.CreateFactory(typeof(PetsEFCoreDbContext), args.ConnectionString,
                (builder, connectionString) => {
                    // Uncomment this code to use an in-memory database. This database is recreated each time the server starts. With the in-memory database, you don't need to make a migration when the data model is changed.
                    // Do not use this code in production environment to avoid data loss.
                    // We recommend that you refer to the following help topic before you use an in-memory database: https://docs.microsoft.com/en-us/ef/core/testing/in-memory
                    //builder.UseInMemoryDatabase("InMemory");
                    builder.UseSqlServer(connectionString);
                    builder.UseSecurity((ISelectDataSecurityProvider)Security);
                    builder.UseAudit();
                },
                typeof(PetsAuditingDbContext), args.ConnectionString,
                (builder, connectionString) => {
                    builder.UseSqlServer(connectionString);
                },
                (options) => {
                    options.AuditUserProvider = new AuditUserProvider(Security);
                });
            SecuredEFCoreObjectSpaceProvider efCoreObjectSpaceProvider = new SecuredEFCoreObjectSpaceProvider((ISelectDataSecurityProvider)Security, dbContextFactory, TypesInfo);
            args.ObjectSpaceProviders.Add(efCoreObjectSpaceProvider);
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }
        private void PetsWindowsFormsApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e) {
            string userLanguageName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            if(userLanguageName != "en-US" && e.Languages.IndexOf(userLanguageName) == -1) {
                e.Languages.Add(userLanguageName);
            }
        }
        private void PetsWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            if(System.Diagnostics.Debugger.IsAttached) {
                e.Updater.Update();
                e.Handled = true;
            }
            else {
				string message = "The application cannot connect to the specified database, " +
					"because the database doesn't exist, its version is older " +
					"than that of the application or its schema does not match " +
					"the ORM data model structure. To avoid this error, use one " +
					"of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

				if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
					message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
				}
				throw new InvalidOperationException(message);
            }
#endif
        }
    }
}

using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;

namespace Cdf54.Projet2015.Models
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole,string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> 
    {
        protected override void Seed(ApplicationDbContext context) {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db) {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name1 = "admin@cdf54.local";
            const string password1 = "P@ssword2015";
            const string roleName1 = "Admin";

            const string name2 = "canedit@cdf54.local";
            const string password2 = "P@ssword2015";
            const string roleName2 = "CanEdit";

            const string name3 = "chrome@cdf54.local";
            const string password3 = "P@ssword2015";
            const string roleName3 = "Member";

            const string name4 = "opera@cdf54.local";
            const string password4 = "P@ssword2015";

            const string name5 = "ie@cdf54.local";
            const string password5 = "P@ssword2015";

            const string name6 = "firefox@cdf54.local";
            const string password6 = "P@ssword2015";


            //Create Role Admin if it does not exist
            var role1 = roleManager.FindByName(roleName1);
            if (role1 == null)
            {
                role1 = new IdentityRole(roleName1);
                var roleresult = roleManager.Create(role1);
            }
            //Create Role CanEdit if it does not exist
            var role2 = roleManager.FindByName(roleName2);
            if (role2 == null)
            {
                role2 = new IdentityRole(roleName2);
                var roleresult = roleManager.Create(role2);
            }
            //Create Role Member if it does not exist
            var role3 = roleManager.FindByName(roleName3);
            if (role3 == null)
            {
                role3 = new IdentityRole(roleName3);
                var roleresult = roleManager.Create(role3);
            }


            // Create user admin@cdf54.local"
            var user1 = userManager.FindByName(name1);
            if (user1 == null)
            {
                user1 = new ApplicationUser { UserName = name1, Email = name1 };
                var result = userManager.Create(user1, password1);
                result = userManager.SetLockoutEnabled(user1.Id, false);
            }
            // Add user admin@cdf54.local" to Role Admin if not already added
            var rolesForUser1 = userManager.GetRoles(user1.Id);
            if (!rolesForUser1.Contains(role1.Name))
            {
                var result = userManager.AddToRole(user1.Id, role1.Name);
            }


            // Create user canedit@cdf54.local"
            var user2 = userManager.FindByName(name2);
            if (user2 == null)
            {
                user2 = new ApplicationUser { UserName = name2, Email = name2 };
                var result = userManager.Create(user2, password2);
                result = userManager.SetLockoutEnabled(user2.Id, false);
            }
            // Add user canedit@cdf54.local" to Role CanEdit if not already added
            var rolesForUser2 = userManager.GetRoles(user2.Id);
            if (!rolesForUser2.Contains(role2.Name))
            {
                var result = userManager.AddToRole(user2.Id, role2.Name);
            }


            // Create user chrome@cdf54.local"
            var user3 = userManager.FindByName(name3);
            if (user3 == null)
            {
                user3 = new ApplicationUser { UserName = name3, Email = name3 };
                var result = userManager.Create(user3, password3);
                result = userManager.SetLockoutEnabled(user3.Id, false);
            }
            // Add user chrome@cdf54.local" to Role Member if not already added
            var rolesForUser3 = userManager.GetRoles(user3.Id);
            if (!rolesForUser3.Contains(role3.Name))
            {
                var result = userManager.AddToRole(user3.Id, role3.Name);
            }


            // Create user opera@cdf54.local"
            var user4 = userManager.FindByName(name4);
            if (user4 == null)
            {
                user4 = new ApplicationUser { UserName = name4, Email = name4 };
                var result = userManager.Create(user4, password4);
                result = userManager.SetLockoutEnabled(user4.Id, false);
            }
            // Add user opera@cdf54.local" to Role Member if not already added
            var rolesForUser4 = userManager.GetRoles(user4.Id);
            if (!rolesForUser4.Contains(role3.Name))
            {
                var result = userManager.AddToRole(user4.Id, role3.Name);
            }


            // Create user ie@cdf54.local"
            var user5 = userManager.FindByName(name5);
            if (user5 == null)
            {
                user5 = new ApplicationUser { UserName = name5, Email = name5 };
                var result = userManager.Create(user5, password5);
                result = userManager.SetLockoutEnabled(user5.Id, false);
            }
            // Add user ie@cdf54.local" to Role Member if not already added
            var rolesForUser5 = userManager.GetRoles(user5.Id);
            if (!rolesForUser5.Contains(role3.Name))
            {
                var result = userManager.AddToRole(user5.Id, role3.Name);
            }

            // Create user firefox@cdf54.local"
            var user6 = userManager.FindByName(name6);
            if (user6 == null)
            {
                user6 = new ApplicationUser { UserName = name6, Email = name6 };
                var result = userManager.Create(user6, password6);
                result = userManager.SetLockoutEnabled(user6.Id, false);
            }
            // Add user firefox@cdf54.local" to Role Member if not already added
            var rolesForUser6 = userManager.GetRoles(user6.Id);
            if (!rolesForUser6.Contains(role3.Name))
            {
                var result = userManager.AddToRole(user6.Id, role3.Name);
            }
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
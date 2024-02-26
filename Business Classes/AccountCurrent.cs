﻿namespace TradeBlazorApp.Business_Classes
{

    //All of this code generated and pasted from ChatGTP Interaction 20 -- for the entire class!  Required major changes, based on later ChatGTP Interaction when starting UI migration (Login form)
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Data.SqlClient;
    using System;
    using TradeBlazorApp.Data_Classes;
    using System.Data;

    public interface IAccountService
    {
        Task<AccountProfile> LoginAsync(string userId, string password);  //Massive fixup from ChatGTP generated in business class migration/creation.  Changing to just make
        // Return type as AccountProfile, not a whole new entity class AccountCurrent.

        Task<AccountProfile> GetAccountDetailsAsync(string userId, string password);

        void UpdateAccountDetailsAsync(string userId, AccountProfile newProfile);
    }

    public class AccountCurrent : IAccountService   //Via ChatGTP Interaction 47:  I need to implement Blazor-Style Interfaces for services, and Async logic.  Added this line.
        //To create an Interface this inherits from, as expected  by Blazor when Program.cs requires "Add Services".
    {
        public string Password { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public decimal AccountID { get; set; }
        public string Salt { get; set; }

        // Assuming ACCOUNTDBEntities is your DbContext and ACCOUNTPROFILEs is a DbSet<AccountProfile>
        private readonly ACCOUNTDBEntities _accountContext;

        // Constructor injection for the DbContext
        public AccountCurrent(ACCOUNTDBEntities accountContext)
        {
            _accountContext = accountContext;
        }

        public async Task<AccountProfile> LoginAsync(string userId, string password)
        {
            //var theAccount = new AccountCurrent(_accountContext);      Commented out per CHatGTP Interaction 49:  this was "bad" practice to create new instance here.
            var accountProfile = await _accountContext.ACCOUNTPROFILE    //Replaced with this line, from ChatGTP Interaction 49
            .FirstOrDefaultAsync(p => p.UserId == userId);

            //All of this commented out, per ChatGTP interaction 49--even though generated in previous steps by ChatGTP 4.0, from VB.NET code.
            // Do not Use EF Core's method to execute SQL directly, instead use as a proper "Entity". Do ensure parameterization for security/prevent SQL Injection
            // var parameter = new SqlParameter("@userId", userId);  Commented out per ChatGTP INteraction 49, these two lines
            // var accountProfiles = _accountContext.ACCOUNTPROFILE.FromSqlRaw("SELECT * FROM dbo.ACCOUNTPROFILE WHERE USERID = @userId", parameter).ToList();
            // Manual Fixup of DBSet name here, required.  (All Caps, name generated no 's'
            // Execute the query and get the result
            //Now all commented out:  re do, from original ChatGTP migration: Once I got into UI Tier, ChatGTP explained, do not mix metaphores (business logic/DB Entities).
            //So starting again, using Data Class (_accountContext.ACCOUNTPROFILE): modelled from DB table directly, as what I need to use/re-factor right.  All
            //Corrections, from previous ChatGTP interactions/migrations, now that I am into UI tier.  Moral of story:  If using EntityFrameworkCore (8.0.2):  Start
            //By JUST bulding model classes in DB tier (Data Classes in my Project structure), as first step!  For all Databases used (I have 2, from VB.NET).
            //
            //          foreach (var profile in accountProfile)
            //        {
            //          theAccount.UserID = profile.UserId; // Manual Fixup of property name here, required.  ( from all Caps, as originally generated)
            //        theAccount.Password = profile.Password;  // Manual Fixup of property name here, required.  ( from all Caps, as originally generated)
            //      theAccount.AccountID = profile.AccountId; // Manual Fixup of property name here, required.  ( from all Caps, as originally generated)
            //    theAccount.Salt = profile.Salt;
            //  theAccount.Name = profile.FullName;
            // Continue mapping other properties as needed
            //}

            if (accountProfile == null)
            {
                // Assuming GlobalSettings is a static class you use for global settings
                GlobalSettings.LoggedIn = false;
            }
            else
            {
                // Assuming SaltedHash is a class you have for hashing and verifying passwords
                var verifier = SaltedHash.Create(accountProfile.Salt, accountProfile.Password); //I had to manually fixup this line of code generated by Interaction 20, to use a typename and not an instance (its a static)
                GlobalSettings.LoggedIn = verifier.Verify(password);                
            }
            return accountProfile;
        }
        public async Task<AccountProfile> GetAccountDetailsAsync(string userId, string password)
        {
            AccountProfile accountProfile = null;
            try
            {
                //var theAccount = new AccountCurrent(_accountContext);      Commented out per CHatGTP Interaction 49:  this was "bad" practice to create new instance here.
                accountProfile = await _accountContext.ACCOUNTPROFILE    //Replaced with this line, from ChatGTP Interaction 49
                .FirstOrDefaultAsync(p => p.UserId == userId);

                //All of this commented out, per ChatGTP interaction 49--even though generated in previous steps by ChatGTP 4.0, from VB.NET code.
                // Do not Use EF Core's method to execute SQL directly, instead use as a proper "Entity". Do ensure parameterization for security/prevent SQL Injection
                // var parameter = new SqlParameter("@userId", userId);  Commented out per ChatGTP INteraction 49, these two lines
                // var accountProfiles = _accountContext.ACCOUNTPROFILE.FromSqlRaw("SELECT * FROM dbo.ACCOUNTPROFILE WHERE USERID = @userId", parameter).ToList();
                // Manual Fixup of DBSet name here, required.  (All Caps, name generated no 's'
                // Execute the query and get the result
                //Now all commented out:  re do, from original ChatGTP migration: Once I got into UI Tier, ChatGTP explained, do not mix metaphores (business logic/DB Entities).
                //So starting again, using Data Class (_accountContext.ACCOUNTPROFILE): modelled from DB table directly, as what I need to use/re-factor right.  All
                //Corrections, from previous ChatGTP interactions/migrations, now that I am into UI tier.  Moral of story:  If using EntityFrameworkCore (8.0.2):  Start
                //By JUST bulding model classes in DB tier (Data Classes in my Project structure), as first step!  For all Databases used (I have 2, from VB.NET).
                //
                //          foreach (var profile in accountProfile)
                //        {
                //          theAccount.UserID = profile.UserId; // Manual Fixup of property name here, required.  ( from all Caps, as originally generated)
                //        theAccount.Password = profile.Password;  // Manual Fixup of property name here, required.  ( from all Caps, as originally generated)
                //      theAccount.AccountID = profile.AccountId; // Manual Fixup of property name here, required.  ( from all Caps, as originally generated)
                //    theAccount.Salt = profile.Salt;
                //  theAccount.Name = profile.FullName;
                // Continue mapping other properties as needed
                //}

                if (accountProfile == null)
                {
                    // Assuming GlobalSettings is a static class you use for global settings
                    GlobalSettings.LoggedIn = false;
                }
                else
                {
                    // Assuming SaltedHash is a class you have for hashing and verifying passwords
                    var verifier = SaltedHash.Create(accountProfile.Salt, accountProfile.Password); //I had to manually fixup this line of code generated by Interaction 20, to use a typename and not an instance (its a static)
                    GlobalSettings.LoggedIn = verifier.Verify(password);
                }
            }
            catch (Exception ex) 
            {
                throw;
            }
            return accountProfile;
        }

        public void UpdateAccountDetailsAsync(string userId, AccountProfile newProfile)
        {
            try
            {
                
                var theResult  =  _accountContext.SaveChanges();
                return;
            }
            catch (Exception ex) { throw; }
        }

    }

}

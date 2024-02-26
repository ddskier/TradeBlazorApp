

//This code was migrated directly from ChatGTP generated code from my Account.vb class.  Manual steps needed
//1. However, I need to manually add a reference to the Entity Framework.  I will ask ChatGTP to help me do.  Interaction 6.
//2.  I also copies the imports from my VB class, manually to here, chaging Import to Usings
//3.  Cannot resolve 'Using System.Data.Entity
//4  Cannot resolve Using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder
//


using System.Net.NetworkInformation;

namespace TradeBlazorApp.Business_Classes
{


    using System;
    using Microsoft.EntityFrameworkCore; //'Had to get advice from ChatGTP Interaction 6, on how to update this line from using System.Data.Entity
    using System.Linq.Expressions; //Suggested to add viaa Interaction 7 with ChatGTP
    using Microsoft.EntityFrameworkCore.Migrations;  //Suggested to add viaa Interaction 7 with ChatGTP

    // using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;   Commented out manually per ChatGTP Interaction 7
    // using System.Data.Entity.Migrations; Commented out manually per ChatGTP Interaction 7
    using Microsoft.Data.SqlClient;   //Per ChatGTP interaction 15, I added a using statement to the newly downloaded package from NuGet package manager in VS.
    using System.Runtime.ConstrainedExecution;


    // using System.Runtime.Remoting.Contexts;  I am removing this reference per CHatGTP interaction 8

    using TradeBlazorApp.Data_Classes;   //Added per my own thinking, as I separated Data Classes from Business Classes as part of migration, need this line.


    public class AccountCurrent
    {
        public string Password { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public decimal AccountID { get; set; }
        public string Salt { get; set; }

        /// <summary>
        /// Added the following per ChatGTP interaction 16
        /// </summary>
        private readonly ACCOUNTDBEntities _accountContext;


        /// <summary>
        /// Added the following per ChatGTP interaction 16
        /// </summary>
        public AccountCurrent(ACCOUNTDBEntities accountContext)
        {
            _accountContext = accountContext;
        }


        public AccountCurrent Login(string userid, string password)
        {
            var theAccount = new AccountCurrent(_accountContext);  //I needed to figure out, after ChatGTP interaction 16, to pass _accountContext here in constructor.

            using (_accountContext)    //I needed to manually change this line of code to use _accountContext, after reading ChatGTP interaction 16 (and pasting code at top here)
                                       //as before it read:  using (var accountContext = new ACCOUNTDBEntities()).  ChatGTP is having me use autocontext via dependency injecton instead
            {
                var parameter = new SqlParameter("@userId", userid);
                var result = _accountContext.ACCOUNTPROFILEs.SqlQuery("SELECT * FROM dbo.ACCOUNTPROFILE WHERE USERID = @userId", parameter); //

                foreach (var profile in result)
                {
                    theAccount.UserID = profile.USERID;
                    theAccount.Password = profile.PASSWORD;
                    theAccount.AccountID = profile.ACCOUNTID;
                    theAccount.Salt = profile.SALT;
                    theAccount.Name = profile.FULLNAME;
                    // Add more properties if needed
                }

                if (theAccount.Password == null)
                {
                    GlobalSettings.LoggedIn = false;
                }
                else
                {
                    var verifier = SaltedHash.Create(theAccount.Salt, theAccount.Password);
                    GlobalSettings.LoggedIn = verifier.Verify(password);
                }
            }

            return theAccount;
        }
    }

}

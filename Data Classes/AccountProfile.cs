//This is recommended Data Model Class, per ChatGPT generated code from ChatGPT Interaction 12
// I am using some of my brain here, to put into my Data Classes Folder, for structuring of the target Blazore App, and based on ChatGPT instructions from Interaction 1, 
// To get to a "better" structured project structure and factoring, from the source VB.NET WinForms app

namespace TradeBlazorApp.Data_Classes
{
    //The following is cute and paste, directly from ChatGPT interaction 25
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;




    [Table("ACCOUNTPROFILE", Schema = "dbo")]
    public class AccountProfile
    {
        [Column("ADDRESS", TypeName = "varchar(250)")]
        public string Address { get; set; }

        [Column("PASSWORD", TypeName = "varchar(50)")]
        public string Password { get; set; }

        // [Key]  This table has a composite key, and per ChatGPT Interaction 49, I need to remove all [Key] annotations and use OnModelCreate to create composite key
        [Column("USERID", TypeName = "varchar(50)", Order = 0)]
        [Required]
        public string UserId { get; set; }

        // [Key]  This table has a composite key, and per ChatGPT Interaction 49, I need to remove all [Key] annotations and use OnModelCreate to create composite key[Key]
        [Column("ACCOUNTID", TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Assuming ACCOUNTID is provided and not auto-generated
        public long AccountId { get; set; }

        [Column("EMAIL", TypeName = "varchar(250)")]
        public string Email { get; set; }

        [Column("CREDITCARD", TypeName = "varchar(250)")]
        public string CreditCard { get; set; }

        [Column("FULLNAME", TypeName = "varchar(250)")]
        public string FullName { get; set; }

        [Column("SALT", TypeName = "varchar(20)")]
        public string Salt { get; set; }


    }

}

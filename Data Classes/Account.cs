namespace TradeBlazorApp.Data_Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ACCOUNT", Schema = "dbo")]
    public class Account
    {
        [Column("CREATIONDATE", TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [Column("OPENBALANCE", TypeName = "decimal(12, 2)")]
        public decimal? OpenBalance { get; set; }

        [Column("LOGOUTCOUNT", TypeName = "int")]
        [Required]
        public int LogoutCount { get; set; }

        [Column("BALANCE", TypeName = "decimal(12, 2)")]
        public decimal? Balance { get; set; }

        //[Key]  Removed per ChatGPT Interaction 50 to avoid composite key error.  Instead using on ModelCreate override
        [Column("ACCOUNTID", TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Assuming ACCOUNTID is provided and not auto-generated
        public long AccountId { get; set; }

        [Column("LASTLOGIN", TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }

        [Column("LOGINCOUNT", TypeName = "int")]
        [Required]
        public int LoginCount { get; set; }

        //[Key]  Removed per ChatGPT Interaction 50 to avoid composite key error.  Instead using on ModelCreate override[Key]
        [Column("PROFILE_USERID", TypeName = "varchar(50)", Order = 0)]
        [Required]
        public string ProfileUserId { get; set; }

        // Navigation properties and any additional configuration can go here
    }

}

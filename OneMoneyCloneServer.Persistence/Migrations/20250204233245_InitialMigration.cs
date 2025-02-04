using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneMoneyCloneServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Decimals = table.Column<int>(type: "int", nullable: false),
                    Symbol = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    MainCurrencyId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Currencies_MainCurrencyId",
                        column: x => x.MainCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SavingsBudgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AmountInMainCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsBudgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsBudgets_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavingsBudgets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoryTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTags_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TagBudgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CategoryTagId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagBudgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagBudgets_CategoryTags_CategoryTagId",
                        column: x => x.CategoryTagId,
                        principalTable: "CategoryTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagBudgets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountInMainCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: true),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TransferAccountId = table.Column<Guid>(type: "char(36)", nullable: true),
                    AmountInAccountCurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryTagId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_TransferAccountId",
                        column: x => x.TransferAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_CategoryTags_CategoryTagId",
                        column: x => x.CategoryTagId,
                        principalTable: "CategoryTags",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedAt", "Decimals", "Name", "Symbol", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02a94805-cd8a-6362-c147-e79e4f88cba9"), "MKD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4821), 2, "Macedonian Denar", "den", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4821) },
                    { new Guid("030483f1-a13c-1859-73b9-752835a31c07"), "TZS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5985), 2, "Tanzanian Shilling", "TSh", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5985) },
                    { new Guid("0a4231a1-7e53-1a6d-2523-079b0e28f991"), "GIP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4064), 2, "Gibraltar Pound", "£", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4064) },
                    { new Guid("0c2207d4-a840-043c-a181-13629f23a763"), "GGP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4029), 2, "Guernsey Pound", "£", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4030) },
                    { new Guid("0d956a48-d79a-dea3-d9f6-fe8a13803a97"), "TTD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5932), 2, "Trinidad and Tobago Dollar", "TT$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5933) },
                    { new Guid("0dd3fce2-1222-e0e6-a029-704038803f37"), "SYP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5792), 2, "Syrian Pound", "LS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5792) },
                    { new Guid("1289187c-d210-cdae-27ae-a1e09562a989"), "UYU", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6054), 2, "Uruguayan Peso", "$U", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6055) },
                    { new Guid("15127fd9-5505-772c-09f4-a998ebe7d84e"), "ZMW", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6300), 2, "Zambian Kwacha", "ZK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6300) },
                    { new Guid("15656902-67e6-5096-baae-b843d97cafd7"), "PGK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5201), 2, "Papua New Guinean Kina", "K", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5201) },
                    { new Guid("19c11074-e05c-e42f-5957-2628e9510004"), "GEL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4011), 2, "Georgian Lari", "₾", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4012) },
                    { new Guid("1b522f66-c212-d240-c3c1-95f3df817b0c"), "IDR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4266), 2, "Indonesian Rupiah", "Rp", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4266) },
                    { new Guid("1bd8d6bb-55fc-36c3-03ed-6378bc630669"), "JOD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4427), 3, "Jordanian Dinar", "JD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4428) },
                    { new Guid("1c7010ea-6905-a818-1dc8-9906b9019c35"), "XPF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6248), 0, "CFP Franc (Franc Pacifique)", "₣", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6248) },
                    { new Guid("1d521a8c-1e10-4db2-139d-c9ddfa30002f"), "NPR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5114), 2, "Nepalese Rupee", "Rs.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5114) },
                    { new Guid("1fdc9b26-aab1-c5dc-b575-a68220158602"), "SAR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5438), 2, "Saudi Riyal", "SR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5438) },
                    { new Guid("20758c97-14c5-0a1a-f188-f86e764e90da"), "AZN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3145), 2, "Azerbaijani Manat", "ман", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3145) },
                    { new Guid("22d1a99d-f0fd-1d1b-b281-6592e00f28ad"), "NOK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5096), 2, "Norwegian Krone", "kr", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5097) },
                    { new Guid("2339ec2f-a504-3ac2-c138-da22847f9b7c"), "PHP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5218), 2, "Philippine Peso", "₱", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5219) },
                    { new Guid("23a6f372-126a-5fb7-033d-9a2529a3b875"), "AFN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(2746), 2, "Afghan Afghani", "Af", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(2747) },
                    { new Guid("2428a728-cc03-1770-c9e1-d5d3f5041bfd"), "GHS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4047), 2, "Ghanaian Cedi", "GH₵", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4047) },
                    { new Guid("264a68ea-3fe2-4a56-fb94-93fad725556e"), "ANG", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3048), 2, "Netherlands Antillean Guilder", "ƒ", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3049) },
                    { new Guid("285dfed9-f150-16ed-7451-b193e8bd0e0c"), "RON", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5344), 2, "Romanian Leu", "L", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5344) },
                    { new Guid("297a1d27-54c7-bdea-6a11-0781a1adbd2d"), "KWD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4609), 3, "Kuwaiti Dinar", "KD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4609) },
                    { new Guid("2a050d05-a326-9d10-0fb0-6176ee1db8e8"), "HKD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4152), 2, "Hong Kong Dollar", "HK$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4152) },
                    { new Guid("2a574ebe-f04e-cd45-c914-49b6c9435a8a"), "LAK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4662), 2, "Lao Kip", "₭N", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4662) },
                    { new Guid("2b0ea592-0b3e-5ba4-28ab-150a385bafcc"), "GMD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4082), 2, "Gambian Dalasi", "D", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4082) },
                    { new Guid("2b5655a0-59db-8bad-a9cc-680367308118"), "EUR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3922), 2, "Euro", "€", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3922) },
                    { new Guid("2d96115b-e8cb-e55d-5770-d22d3e5fb85a"), "CUP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3694), 2, "Cuban Peso", "$MN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3694) },
                    { new Guid("2e05c22f-45aa-9a73-9fd0-854d4ed60178"), "CHF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3545), 2, "Swiss Franc", "Fr.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3545) },
                    { new Guid("33e99e88-891f-9214-f89b-1e578fa377e0"), "CNY", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3619), 2, "Chinese Yuan", "CN¥", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3619) },
                    { new Guid("362ac415-3d05-4f89-ef1a-225ce99a3a2b"), "TMT", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5862), 2, "Turkmenistan Manat", "m.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5862) },
                    { new Guid("36a1cc65-7ef9-f628-ea8c-af95ba0be3d6"), "YER", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6265), 2, "Yemeni Rial", "YR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6265) },
                    { new Guid("38a3c1b4-829b-a079-ee13-5fb1f8368255"), "ETB", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3905), 2, "Ethiopian Birr", "Br", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3905) },
                    { new Guid("39bdf548-263b-b98c-f43a-86af1a4d9e8c"), "UAH", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6002), 2, "Ukrainian Hryvnia", "₴", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6002) },
                    { new Guid("3bad9f41-82f0-1748-27a2-d47adce883a8"), "CUC", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3676), 2, "Cuban convertible Peso", "CUC$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3676) },
                    { new Guid("3be039c5-b2e7-c869-a84f-85437bc8d298"), "BSD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3421), 2, "Bahamian Dollar", "$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3421) },
                    { new Guid("3e768d90-f1cf-0469-58ba-5863ae3b894f"), "PRB", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5289), 2, "Transnistrian Ruble", "р.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5289) },
                    { new Guid("3fb8df59-ac7c-3c4e-8ee9-1700ef2ad90d"), "TRY", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5915), 2, "Turkish Lira", "TL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5915) },
                    { new Guid("3fcdf238-6be6-8a7b-64b4-6bc06880d4b7"), "BWP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3458), 2, "Botswana Pula", "P", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3458) },
                    { new Guid("401229af-21e2-0ebb-94c2-f09ee87606cf"), "MOP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4876), 2, "Macanese Pataca", "MOP$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4876) },
                    { new Guid("40554325-f171-792b-a96a-c865112a53e0"), "HTG", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4230), 2, "Haitian Gourde", "G", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4231) },
                    { new Guid("4143af48-45f7-3f16-945f-a838eeabb062"), "AMD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3028), 2, "Armenian Dram", "֏", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3028) },
                    { new Guid("4164005b-94e6-45cb-a1af-078e58a66a87"), "DKK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3798), 2, "Danish Krone", "kr.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3799) },
                    { new Guid("4227f44f-52f9-693e-8b35-154f999f49a2"), "MNT", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4856), 2, "Mongolian Tögrög", "₮", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4857) },
                    { new Guid("43476567-32cc-eedf-bf2d-2d154db69cd8"), "RUB", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5403), 2, "Russian Ruble", "₽", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5403) },
                    { new Guid("44c6af00-1d9b-9ff3-464e-a2ca3e56af77"), "MMK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4839), 2, "Myanmar Kyat", "Ks", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4839) },
                    { new Guid("457a12d5-3622-804c-5de5-104bb5503310"), "DJF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3747), 2, "Djiboutian Franc", "Fdj", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3747) },
                    { new Guid("47321ae7-6977-c8ba-d129-a02cd467e3e6"), "LKR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4698), 2, "Sri Lankan Rupee", "Rs.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4699) },
                    { new Guid("48c67697-6737-dacd-e0a3-8b6149c08539"), "KGS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4480), 2, "Kyrgyzstani Som", "с", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4480) },
                    { new Guid("497cabbf-8f99-6358-fb8d-10c7f0ed8873"), "AUD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3107), 2, "Australian Dollar", "AU$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3108) },
                    { new Guid("4e6b6ab8-67b2-a95a-8b7a-63b568434502"), "SEK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5511), 2, "Swedish Krona", "kr", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5511) },
                    { new Guid("4e913f2e-5a32-a01c-cb82-a132af1002d3"), "NZD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5132), 2, "New Zealand Dollar", "NZ$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5132) },
                    { new Guid("4fde0da3-c7fc-d1ac-174a-05337056b552"), "KES", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4462), 2, "Kenyan Shilling", "KSh", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4463) },
                    { new Guid("5010968a-0037-6def-0d6c-1caf8f04ed9f"), "MVR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4930), 2, "Maldivian Rufiyaa", "MRf", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4930) },
                    { new Guid("508e79f7-53e5-34b2-27e7-df0a7a2652f5"), "CZK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3729), 2, "Czech Koruna", "Kč", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3729) },
                    { new Guid("50c1f0d5-899f-17ff-8497-1832af4e7670"), "SLS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5656), 2, "Somaliland Shilling", "Sl", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5656) },
                    { new Guid("53203a98-f729-bc7e-1712-be17806b8b0a"), "WST", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6177), 2, "Samoan Tala", "T", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6177) },
                    { new Guid("5409cbec-a9fc-00f2-5aea-084605df5ee9"), "CAD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3510), 2, "Canadian Dollar", "CA$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3511) },
                    { new Guid("5423cf5d-7420-563b-3642-2f69a2f7822c"), "VUV", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6159), 0, "Vanuatu Vatu", "VT", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6159) },
                    { new Guid("559286f0-9158-16e1-1c5a-ef5b2748d7cb"), "DOP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3817), 2, "Dominican Peso", "RD$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3817) },
                    { new Guid("55dcd9ca-ba10-12f0-abf9-02dfa6bd3ad0"), "SSP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5709), 2, "South Sudanese Pound", "SS£", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5709) },
                    { new Guid("55f9b15f-5eb4-e338-1789-286a1790398d"), "ALL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(2978), 2, "Albanian Lek", "L", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(2978) },
                    { new Guid("5a6da5a4-7482-44d7-b1ab-9678d60901bf"), "KID", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4515), 2, "Kiribati Dollar", "$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4515) },
                    { new Guid("5b568650-0456-1b07-2d45-d42afcb0d3e9"), "NAD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5043), 2, "Namibian Dollar", "N$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5043) },
                    { new Guid("5d29220d-29ba-8a8b-4831-a943545b0810"), "JPY", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4445), 2, "Japanese Yen", "¥", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4445) },
                    { new Guid("5e7281f1-c8b3-2546-bc1c-77fa4b39f47c"), "JMD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4410), 2, "Jamaican Dollar", "J$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4410) },
                    { new Guid("5ff7ec50-7710-d2e1-50a7-81764b89cbc2"), "SGD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5528), 2, "Singapore Dollar", "S$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5528) },
                    { new Guid("60c073b8-2a92-f667-4ac0-9d27d1232f3a"), "HUF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4248), 2, "Hungarian Forint", "Ft", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4248) },
                    { new Guid("67614275-c295-93eb-6397-1960a03be6d0"), "GTQ", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4117), 2, "Guatemalan Quetzal", "Q", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4117) },
                    { new Guid("678cf412-186c-e9ce-f424-d11554c49415"), "BZD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3493), 2, "Belize Dollar", "BZ$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3493) },
                    { new Guid("68f951a8-ddb8-06a6-535c-03efee304638"), "FJD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3939), 2, "Fijian Dollar", "FJ$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3940) },
                    { new Guid("6988531f-2c0f-c510-a68a-c0b28696fd8b"), "STN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5727), 2, "Sao Tome and Príncipe Dobra", "Db", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5727) },
                    { new Guid("6a767c32-79c8-096b-f63d-a407c9c8967b"), "TND", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5879), 3, "Tunisian Dinar", "DT", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5880) },
                    { new Guid("6cb14b53-b3e9-e872-099d-b6081da2f962"), "KZT", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4644), 2, "Kazakhstani Tenge", "₸", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4645) },
                    { new Guid("6e156d15-a487-437a-5879-313a5ef39da4"), "VED", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6090), 2, "Venezuelan bolívar digital", "Bs.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6090) },
                    { new Guid("6f821189-ba30-9c98-56aa-38112064db7d"), "ZWL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6336), 2, "Zimbabwean Dollar", "Z$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6337) },
                    { new Guid("7441bca5-d568-c3c8-7867-2f6bdd2e0c90"), "HNL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4169), 2, "Honduran Lempira", "L", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4170) },
                    { new Guid("744e6169-b041-9b1c-a6d4-974080d6d099"), "SDG", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5491), 2, "Sudanese Pound", "£SD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5491) },
                    { new Guid("74b8c512-dd0b-9dc2-a376-7cf7aa684995"), "IQD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4337), 3, "Iraqi Dinar", "د.ع.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4338) },
                    { new Guid("76e21711-52fc-c8e1-2ab6-7059d9ceca48"), "LYD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4750), 3, "Libyan Dinar", "LD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4751) },
                    { new Guid("770c05bb-8592-2f63-0e53-2eab4d629b1c"), "TWD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5968), 2, "New Taiwan Dollar", "NT$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5968) },
                    { new Guid("7b770567-2e71-11e8-e76f-b07162081d63"), "TOP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5897), 2, "Tongan Paʻanga", "T$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5897) },
                    { new Guid("7d2c2e91-b5f8-e9d7-63a9-cd82bf0f612f"), "CKD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3563), 2, "Cook Islands Dollar", "$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3563) },
                    { new Guid("7e312460-dd5b-62df-aa29-5395cbde54ab"), "SBD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5456), 2, "Solomon Islands Dollar", "SI$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5456) },
                    { new Guid("7eaaeee8-73e1-02b2-12e4-0babe414c5c0"), "ILS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4283), 2, "Israeli new Shekel", "₪", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4283) },
                    { new Guid("7f8a7b1a-7e17-4e02-1685-e780c47649c6"), "BAM", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3164), 2, "Bosnia and Herzegovina Convertible Mark", "KM", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3165) },
                    { new Guid("820e7293-9d3d-f29a-3230-95152cb82906"), "MAD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4768), 2, "Moroccan Dirham", "DH", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4768) },
                    { new Guid("8375f4dc-9f02-d679-4904-cf78daa360cb"), "PAB", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5166), 2, "Panamanian Balboa", "B/.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5166) },
                    { new Guid("845d4b1a-32a0-4a8c-33bd-669c608a34c3"), "CRC", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3656), 2, "Costa Rican Colon", "₡", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3656) },
                    { new Guid("8522dd3a-4f09-31dc-8690-2810080c1465"), "GBP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3993), 2, "Pound Sterling", "£", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3994) },
                    { new Guid("865e727c-1a56-f1f1-b941-5bf0ea0679c9"), "BGN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3221), 2, "Bulgarian Lev", "лв.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3222) },
                    { new Guid("86a6cb2d-72bf-6816-8c21-aaf78f409d11"), "MWK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4971), 2, "Malawian Kwacha", "MK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4971) },
                    { new Guid("8f676eb4-47c5-c84e-216c-5e3f4e9d327c"), "MYR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5007), 2, "Malaysian Ringgit", "RM", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5008) },
                    { new Guid("926eca77-9f15-2b68-db43-52af6058eb92"), "GNF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4099), 2, "Guinean Franc", "FG", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4099) },
                    { new Guid("94f81835-424d-2d21-d37d-affe097d216e"), "USD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6037), 2, "United States Dollar", "$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6037) },
                    { new Guid("98884324-53da-bf34-fffc-8ac71ad2bb4e"), "NGN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5060), 2, "Nigerian Naira", "₦", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5061) },
                    { new Guid("991de080-b526-e74f-2941-0d78954faada"), "BBD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3185), 2, "Barbadian Dollar", "BBD$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3185) },
                    { new Guid("9954e1d1-d339-c1bd-caa1-0f65876dba6c"), "MRU", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4894), 0, "Mauritanian Ouguiya", "UM", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4894) },
                    { new Guid("9c6da159-d466-bf88-850d-7fb1e36c4e38"), "BTN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3440), 2, "Bhutanese Ngultrum", "Nu.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3440) },
                    { new Guid("9cc1be6e-a3f0-09a6-354a-05acde9ca8af"), "IMP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4302), 2, "Manx Pound", "£", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4302) },
                    { new Guid("9cd2c5bf-a278-f366-3479-d3fbad222d43"), "MZN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5025), 2, "Mozambican Metical", "MTn", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5025) },
                    { new Guid("9ce1bd44-0ebc-0b83-caf0-54b5413dd39d"), "RSD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5386), 2, "Serbian Dinar", "din", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5386) },
                    { new Guid("9ec98535-c765-76fb-b3a0-76723dc90c5f"), "FKP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3957), 2, "Falkland Islands Pound", "FK£", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3957) },
                    { new Guid("9ecde9a9-ad81-da58-5b9a-608f70e1d7d9"), "XAF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6194), 2, "Central African CFA Franc BEAC", "Fr", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6195) },
                    { new Guid("9f39b2f0-bfd4-d113-d6a8-e7bf52b27483"), "MUR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4912), 2, "Mauritian Rupee", "Rs.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4913) },
                    { new Guid("a0093fc2-1d1b-f9d2-4308-1b0b6febaf99"), "KRW", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4591), 2, "South Korean Won", "₩", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4591) },
                    { new Guid("a03a80ff-17c5-da03-a2da-b2119613aa6f"), "ZAR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6283), 2, "South African Rand", "R", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6283) },
                    { new Guid("a10a44f7-44ba-740f-555d-4c313c9b7677"), "SHP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5620), 2, "Saint Helena Pound", "£", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5620) },
                    { new Guid("a34a0b1a-bb61-1553-e304-831a320f89b3"), "BRL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3403), 2, "Brazilian Real", "R$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3403) },
                    { new Guid("a41afad3-9f5b-6ee5-1fc1-b558d8ed6678"), "PEN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5183), 2, "Peruvian Sol", "S/.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5184) },
                    { new Guid("a47b9428-0b75-c0ac-947b-e464145e08b0"), "KYD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4627), 2, "Cayman Islands Dollar", "CI$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4627) },
                    { new Guid("a5da4d34-06e9-0e91-af8b-8df4656a8551"), "ZWB", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6317), 0, "RTGS Dollar", "", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6318) },
                    { new Guid("a8318d34-a02f-20f4-fc0c-de4a1d0d845d"), "MDL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4785), 2, "Moldovan Leu", "L", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4785) },
                    { new Guid("a83f0076-dba8-821c-36e0-ce931221b956"), "DZD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3834), 2, "Algerian Dinar", "DA", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3834) },
                    { new Guid("a8afda91-e019-0ea0-fed5-b683ec81b9b2"), "VES", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6108), 2, "Venezuelan Bolívar Soberano", "Bs.F", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6108) },
                    { new Guid("a97206d9-bbf4-6a2b-a4dc-96ed2b419af0"), "TVD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5950), 2, "Tuvaluan Dollar", "$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5950) },
                    { new Guid("ac3f818d-37c4-8127-2b29-79fc265e4cad"), "SVC", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5774), 2, "Salvadoran Colón", "₡", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5774) },
                    { new Guid("ae5c7dce-0da4-e7f9-59a2-c1e0ec747f69"), "JEP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4392), 2, "Jersey Pound", "£", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4392) },
                    { new Guid("af34431f-41e8-f7c3-6efb-f4f5504e9a0a"), "AOA", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3070), 2, "Angolan Kwanza", "Kz", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3070) },
                    { new Guid("affb8a7b-6a90-9670-01db-6e066a527dd1"), "UZS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6072), 2, "Uzbekistani Som", "сум", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6072) },
                    { new Guid("b11bc376-a47a-c585-8620-656a77c13b11"), "BND", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3299), 2, "Brunei Dollar", "B$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3299) },
                    { new Guid("b1507d3f-5e68-147b-f5bf-abf8b30c703a"), "ISK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4374), 2, "Icelandic Krona", "kr", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4375) },
                    { new Guid("b356e5fe-69d1-2ebd-a6fb-e8e71f0ade0a"), "ERN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3887), 2, "Eritrean Nakfa", "Nkf", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3887) },
                    { new Guid("b439a2fe-d174-b9a0-0401-6873d4f1ee24"), "TJS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5845), 2, "Tajikistani Somoni", "SM", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5845) },
                    { new Guid("b9f73528-6807-e1ac-225a-7821f5bcd131"), "THB", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5827), 2, "Thai Baht", "฿", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5827) },
                    { new Guid("bb221ac1-7c55-feae-8a0f-3535dbf6d201"), "HRK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4212), 2, "Croatian Kuna", "kn", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4212) },
                    { new Guid("bb3eb81a-8de5-8518-632b-175f762eb77a"), "BIF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3257), 2, "Burundian Franc", "FBu", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3257) },
                    { new Guid("bdcf2eae-d495-dd75-f088-76080d57e3d9"), "SLL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5638), 2, "Sierra Leonean Leone", "Le", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5639) },
                    { new Guid("bf3ae3b9-0846-74c4-1652-596350ea9718"), "QAR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5326), 2, "Qatari Riyal", "QR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5326) },
                    { new Guid("c04f60fd-b0da-9def-793c-9598ae881435"), "MXN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4990), 2, "Mexican Peso", "MX$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4990) },
                    { new Guid("c0dfd9b6-54fb-7327-21ce-bc0fff55df2f"), "NIO", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5078), 2, "Nicaraguan Córdoba", "C$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5078) },
                    { new Guid("c1c5af97-029a-4c01-fde1-c064281437c5"), "COP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3638), 2, "Colombian Peso", "CO$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3638) },
                    { new Guid("c38bddf4-a29d-6b76-7408-d47a540aae25"), "EHP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3869), 2, "Sahrawi Peseta", "Ptas.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3870) },
                    { new Guid("c8e8fa4f-bdc3-24a7-e6cc-853513870137"), "INR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4319), 2, "Indian Rupee", "Rs.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4320) },
                    { new Guid("cbb16792-48c6-0e0d-a037-217688b3a655"), "PKR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5236), 2, "Pakistani Rupee", "Rs.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5237) },
                    { new Guid("ce256ef1-ecc4-b3ca-e643-a66a8eccb1cb"), "VND", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6126), 2, "Vietnamese Dong", "₫", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6126) },
                    { new Guid("cf385935-b7e3-623a-4297-591972d27c01"), "BOB", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3383), 2, "Bolivian Boliviano", "Bs.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3383) },
                    { new Guid("cf6aa1ea-10a1-b24c-23a5-5fb03fdde12f"), "IRR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4356), 2, "Iranian Rial", "﷼", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4357) },
                    { new Guid("cfda8d44-5193-1202-7e2c-6374c945725d"), "XCD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6212), 2, "East Caribbean Dollar", "$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6213) },
                    { new Guid("d0319b6f-b5ec-f704-dcc8-690d7c7840e1"), "PND", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5271), 2, "Pitcairn Islands Dollar", "$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5272) },
                    { new Guid("d0b6ec83-0781-82a9-b9f7-495d3c265446"), "KPW", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4573), 2, "North Korean Won", "₩", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4574) },
                    { new Guid("d12a4f79-1e8c-bbd9-c158-1fe4589fba1b"), "BYN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3475), 2, "Belarusian Ruble", "Br", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3476) },
                    { new Guid("d261eb65-f310-f4ec-45f5-12103e765526"), "KHR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4497), 2, "Cambodian Riel", "៛", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4498) },
                    { new Guid("d3c63cb7-d3c1-f4fb-c49a-ea0b307498dd"), "CDF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3528), 2, "Congolese Franc", "FC", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3528) },
                    { new Guid("d41f5c78-f550-26b4-27e7-9c1890076425"), "OMR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5149), 3, "Omani Rial", "OR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5149) },
                    { new Guid("d59cc2b9-3cf8-5b53-0bca-f31343315bad"), "SCR", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5474), 2, "Seychellois Rupee", "Rs.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5474) },
                    { new Guid("d6d95096-73d6-1255-28bb-1042f482459f"), "FOK", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3975), 2, "Faroese Króna", "kr", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3975) },
                    { new Guid("d8eed51b-a077-453f-eeb9-e0d518e4834a"), "PYG", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5308), 2, "Paraguayan Guaraní", "₲", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5308) },
                    { new Guid("df7be16e-7d4a-06a2-068f-e02847a4aed5"), "CVE", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3712), 2, "Cabo Verdean Escudo", "CV$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3712) },
                    { new Guid("e185868b-8361-d093-0e8a-87328b75ddd6"), "GYD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4134), 2, "Guyanese Dollar", "G$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4134) },
                    { new Guid("e3366b73-b522-3659-97b4-927d6d9132ab"), "SZL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5809), 2, "Swazi Lilangeni", "L", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5809) },
                    { new Guid("e504b448-b390-35e4-ec21-9a6f1cec68b4"), "BMD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3280), 2, "Bermudian Dollar", "$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3280) },
                    { new Guid("e59274d8-5375-83dd-4ebe-968ab2cc8107"), "BDT", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3203), 2, "Bangladeshi Taka", "৳", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3204) },
                    { new Guid("e5bf28d5-c9f0-ba92-ffcc-8a7bef5cdcfb"), "LRD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4716), 2, "Liberian Dollar", "L$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4716) },
                    { new Guid("e7f7d728-50bb-6ab4-f38d-9d150256df4e"), "AED", new DateTime(2025, 2, 4, 23, 32, 45, 14, DateTimeKind.Utc).AddTicks(3176), 2, "United Arab Emirates Dirham", "د.إ.", new DateTime(2025, 2, 4, 23, 32, 45, 14, DateTimeKind.Utc).AddTicks(3177) },
                    { new Guid("e87ef008-3803-cfd2-4fd6-5e7bc1909085"), "KMF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4532), 2, "Comorian Franc", "CF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4532) },
                    { new Guid("ea876644-b12d-a7ad-5be5-ed053be77f59"), "PLN", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5253), 2, "Polish Zloty", "zł", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5254) },
                    { new Guid("eab80530-6fb9-df81-142d-787d501d0537"), "LSL", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4733), 2, "Lesotho Loti", "L", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4733) },
                    { new Guid("eb4e9cc2-372e-d597-e676-21f51f3aecc1"), "RWF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5421), 2, "Rwandan Franc", "FRw", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5421) },
                    { new Guid("ed4e06a4-e091-a871-d451-e0d09b480f78"), "SRD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5692), 2, "Surinamese Dollar", "Sr$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5692) },
                    { new Guid("ede1d560-b630-558d-e6a1-8004b2d17ad2"), "SOS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5674), 2, "Somali Shilling", "Sh.So.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(5674) },
                    { new Guid("ee86f9f3-a4ad-f71a-77ef-5911d96c51ac"), "LBP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4681), 2, "Lebanese Pound", "LL.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4681) },
                    { new Guid("f0f39460-5873-4369-5cdb-49c60235bffe"), "Abkhazia", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6354), 0, "Abkhazian Apsar", "", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6355) },
                    { new Guid("f293e3e4-f89a-c8aa-d614-354c3d5f3f4b"), "MGA", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4802), 0, "Malagasy Ariary", "Ar", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(4803) },
                    { new Guid("f36e5a06-b4d8-3dcf-1bde-04d9705bebcc"), "AWG", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3125), 2, "Aruban Florin", "ƒ", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3126) },
                    { new Guid("f667c2a3-5fac-b765-19c6-c65eb6d1c5a6"), "ARS", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3089), 2, "Argentine Peso", "AR$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3089) },
                    { new Guid("fa0c8d5a-d7ad-d6ef-c44c-000085157da7"), "CLP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3581), 0, "Chilean Peso", "CL$", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3581) },
                    { new Guid("fb14d36d-e4ae-ce2a-0874-5f9bbaf3da54"), "Artsakh", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6372), 2, "Artsakh Dram", "դր.", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6373) },
                    { new Guid("fca255c7-60b6-4f09-0d71-2c90fcd40753"), "BHD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3240), 3, "Bahraini Dinar", "BD", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3240) },
                    { new Guid("fd4cad0d-8381-fc1c-78ca-2aca02283588"), "XOF", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6230), 2, "West African CFA Franc BCEAO", "₣", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6230) },
                    { new Guid("fdaa9392-8e6e-d492-bb85-e72de96fd369"), "UGX", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6020), 2, "Ugandan Shilling", "USh", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(6020) },
                    { new Guid("ff1bede6-ec71-2ab0-bbf8-7ff7e45ea08d"), "EGP", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3852), 2, "Egyptian Pound", "E£", new DateTime(2025, 2, 4, 23, 32, 45, 16, DateTimeKind.Utc).AddTicks(3852) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyId",
                table: "Accounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_CategoryId",
                table: "Budgets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_UserId",
                table: "Budgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTags_CategoryId",
                table: "CategoryTags",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsBudgets_AccountId",
                table: "SavingsBudgets",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsBudgets_UserId",
                table: "SavingsBudgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagBudgets_CategoryTagId",
                table: "TagBudgets",
                column: "CategoryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagBudgets_UserId",
                table: "TagBudgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryTagId",
                table: "Transactions",
                column: "CategoryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrencyId",
                table: "Transactions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransferAccountId",
                table: "Transactions",
                column: "TransferAccountId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MainCurrencyId",
                table: "Users",
                column: "MainCurrencyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SavingsBudgets");

            migrationBuilder.DropTable(
                name: "TagBudgets");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CategoryTags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}

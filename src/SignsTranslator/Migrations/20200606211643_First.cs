using Microsoft.EntityFrameworkCore.Migrations;

namespace SignsTranslator.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllSigns",
                columns: table => new
                {
                    SignId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageID = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Text = table.Column<string>(nullable: true),
                    ApproverID = table.Column<int>(nullable: false),
                    Swedish = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    English = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Russian = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Arabic = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllSigns", x => x.SignId);
                });

            migrationBuilder.CreateTable(
                name: "DashBoard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashBoard", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SignsApprovers",
                columns: table => new
                {
                    ApproverID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignsApprovers", x => x.ApproverID);
                });

            migrationBuilder.CreateTable(
                name: "SignsLayouts",
                columns: table => new
                {
                    SignId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutId = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PDFDefinition = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImageThumbnail = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SignsSignId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignsLayouts", x => x.SignId);
                    table.ForeignKey(
                        name: "FK_SignsLayouts_AllSigns_SignsSignId",
                        column: x => x.SignsSignId,
                        principalTable: "AllSigns",
                        principalColumn: "SignId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SignsLayouts_SignsSignId",
                table: "SignsLayouts",
                column: "SignsSignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashBoard");

            migrationBuilder.DropTable(
                name: "SignsApprovers");

            migrationBuilder.DropTable(
                name: "SignsLayouts");

            migrationBuilder.DropTable(
                name: "AllSigns");
        }
    }
}

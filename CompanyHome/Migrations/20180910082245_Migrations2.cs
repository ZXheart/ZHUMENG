using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyHome.Migrations
{
    public partial class Migrations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Categories_GetCategoryID",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "GetCategoryID",
                table: "News",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_News_GetCategoryID",
                table: "News",
                newName: "IX_News_CategoryID");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Pages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Hobby",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pages",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Pages",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Admins",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JoinUs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinUs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PageEditModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identity = table.Column<string>(maxLength: 20, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    PageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageEditModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PageEditModel_Pages_PageID",
                        column: x => x.PageID,
                        principalTable: "Pages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageEditModel_PageID",
                table: "PageEditModel",
                column: "PageID");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Categories_CategoryID",
                table: "News",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Categories_CategoryID",
                table: "News");

            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "JoinUs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PageEditModel");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Hobby",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "News",
                newName: "GetCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_News_CategoryID",
                table: "News",
                newName: "IX_News_GetCategoryID");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Pages",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Admins",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Categories_GetCategoryID",
                table: "News",
                column: "GetCategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

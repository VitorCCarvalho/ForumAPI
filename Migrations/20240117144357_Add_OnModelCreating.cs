using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Migrations
{
    /// <inheritdoc />
    public partial class Add_OnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Threads_FThreadId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_FThreadId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FThreadId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Forums",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ThreadId",
                table: "Posts",
                column: "ThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Threads_ThreadId",
                table: "Posts",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Threads_ThreadId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ThreadId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Forums",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "FThreadId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FThreadId",
                table: "Posts",
                column: "FThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Threads_FThreadId",
                table: "Posts",
                column: "FThreadId",
                principalTable: "Threads",
                principalColumn: "Id");
        }
    }
}

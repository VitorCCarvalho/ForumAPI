using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Migrations
{
    /// <inheritdoc />
    public partial class Likes_Dislikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Threads_UserId1",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Threads");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "FThreadUser",
                columns: table => new
                {
                    LikedThreadsId = table.Column<int>(type: "int", nullable: false),
                    UserLikesId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FThreadUser", x => new { x.LikedThreadsId, x.UserLikesId });
                    table.ForeignKey(
                        name: "FK_FThreadUser_AspNetUsers_UserLikesId",
                        column: x => x.UserLikesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FThreadUser_Threads_LikedThreadsId",
                        column: x => x.LikedThreadsId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FThreadUser1",
                columns: table => new
                {
                    DislikedThreadsId = table.Column<int>(type: "int", nullable: false),
                    UserDislikesId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FThreadUser1", x => new { x.DislikedThreadsId, x.UserDislikesId });
                    table.ForeignKey(
                        name: "FK_FThreadUser1_AspNetUsers_UserDislikesId",
                        column: x => x.UserDislikesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FThreadUser1_Threads_DislikedThreadsId",
                        column: x => x.DislikedThreadsId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostUser",
                columns: table => new
                {
                    LikedPostsId = table.Column<int>(type: "int", nullable: false),
                    UserLikesId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUser", x => new { x.LikedPostsId, x.UserLikesId });
                    table.ForeignKey(
                        name: "FK_PostUser_AspNetUsers_UserLikesId",
                        column: x => x.UserLikesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUser_Posts_LikedPostsId",
                        column: x => x.LikedPostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostUser1",
                columns: table => new
                {
                    DislikedPostsId = table.Column<int>(type: "int", nullable: false),
                    UserDislikesId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUser1", x => new { x.DislikedPostsId, x.UserDislikesId });
                    table.ForeignKey(
                        name: "FK_PostUser1_AspNetUsers_UserDislikesId",
                        column: x => x.UserDislikesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUser1_Posts_DislikedPostsId",
                        column: x => x.DislikedPostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FThreadUser_UserLikesId",
                table: "FThreadUser",
                column: "UserLikesId");

            migrationBuilder.CreateIndex(
                name: "IX_FThreadUser1_UserDislikesId",
                table: "FThreadUser1",
                column: "UserDislikesId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUser_UserLikesId",
                table: "PostUser",
                column: "UserLikesId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUser1_UserDislikesId",
                table: "PostUser1",
                column: "UserDislikesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FThreadUser");

            migrationBuilder.DropTable(
                name: "FThreadUser1");

            migrationBuilder.DropTable(
                name: "PostUser");

            migrationBuilder.DropTable(
                name: "PostUser1");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Threads",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Posts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Threads_UserId1",
                table: "Threads",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId1",
                table: "Posts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId1",
                table: "Posts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_UserId1",
                table: "Threads",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

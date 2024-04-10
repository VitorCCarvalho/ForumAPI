using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Migrations
{
    /// <inheritdoc />
    public partial class FThread_Post_Reaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FThreadUser");

            migrationBuilder.DropTable(
                name: "FThreadUser1");

            migrationBuilder.DropTable(
                name: "PostUser");

            migrationBuilder.DropTable(
                name: "PostUser1");

            migrationBuilder.CreateTable(
                name: "FThreadReaction",
                columns: table => new
                {
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reaction = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FThreadReaction", x => new { x.ThreadId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FThreadReaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FThreadReaction_Threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostReaction",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reaction = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReaction", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostReaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReaction_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FThreadReaction_UserId",
                table: "FThreadReaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_UserId",
                table: "PostReaction",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FThreadReaction");

            migrationBuilder.DropTable(
                name: "PostReaction");

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
    }
}

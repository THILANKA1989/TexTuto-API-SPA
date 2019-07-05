using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TexTuto.API.Migrations
{
    public partial class completedatabasemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<int>(nullable: false),
                    is_enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstname = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password_hash = table.Column<byte[]>(nullable: true),
                    password_salt = table.Column<byte[]>(nullable: true),
                    job = table.Column<string>(nullable: true),
                    joined_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false),
                    is_activated = table.Column<bool>(nullable: false),
                    role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    updated_date = table.Column<DateTime>(nullable: false),
                    is_enabled = table.Column<bool>(nullable: false),
                    sub_category = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Articles_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    follower_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => new { x.user_id, x.follower_id });
                    table.ForeignKey(
                        name: "FK_Followers_Users_follower_id",
                        column: x => x.follower_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Followers_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    is_enabled = table.Column<bool>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    updated_date = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(nullable: false),
                    article_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_article_id",
                        column: x => x.article_id,
                        principalTable: "Articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowsArticles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(nullable: false),
                    article_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowsArticles", x => x.id);
                    table.ForeignKey(
                        name: "FK_FollowsArticles_Articles_article_id",
                        column: x => x.article_id,
                        principalTable: "Articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowsArticles_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(nullable: true),
                    rate = table.Column<float>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    updated_date = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    article_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rates_Articles_article_id",
                        column: x => x.article_id,
                        principalTable: "Articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rates_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    updated_date = table.Column<DateTime>(nullable: false),
                    is_enabled = table.Column<bool>(nullable: false),
                    article_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.id);
                    table.ForeignKey(
                        name: "FK_Steps_Articles_article_id",
                        column: x => x.article_id,
                        principalTable: "Articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    updated_date = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    comment_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Replies_Comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "Comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Replies_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_user_id",
                table: "Articles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_article_id",
                table: "Comments",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_user_id",
                table: "Comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_follower_id",
                table: "Followers",
                column: "follower_id");

            migrationBuilder.CreateIndex(
                name: "IX_FollowsArticles_article_id",
                table: "FollowsArticles",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_FollowsArticles_user_id",
                table: "FollowsArticles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_article_id",
                table: "Rates",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_user_id",
                table: "Rates",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_comment_id",
                table: "Replies",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_user_id",
                table: "Replies",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_article_id",
                table: "Steps",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_category_id",
                table: "SubCategories",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Followers");

            migrationBuilder.DropTable(
                name: "FollowsArticles");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

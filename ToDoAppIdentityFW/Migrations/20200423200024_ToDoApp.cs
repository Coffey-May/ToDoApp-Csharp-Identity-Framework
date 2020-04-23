using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoAppIdentityFW.Migrations
{
    public partial class ToDoApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_AspNetUsers_ApplicationUserId",
                table: "ToDoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_ToDoStatuses_ToDoStatusId",
                table: "ToDoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoStatuses",
                table: "ToDoStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems");

            migrationBuilder.RenameTable(
                name: "ToDoStatuses",
                newName: "ToDoStatus");

            migrationBuilder.RenameTable(
                name: "ToDoItems",
                newName: "ToDoItem");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItems_ToDoStatusId",
                table: "ToDoItem",
                newName: "IX_ToDoItem_ToDoStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItems_ApplicationUserId",
                table: "ToDoItem",
                newName: "IX_ToDoItem_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoStatus",
                table: "ToDoStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "146bf84d-e922-4870-99ec-37df1d6ccc53", "AQAAAAEAACcQAAAAEJiwGYSKECQcJDFPGPVMSdLzN3VpNghNB8qwYrJ80hAlqL446Kn7RVmAaw78YkqdlA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItem_AspNetUsers_ApplicationUserId",
                table: "ToDoItem",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItem_ToDoStatus_ToDoStatusId",
                table: "ToDoItem",
                column: "ToDoStatusId",
                principalTable: "ToDoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItem_AspNetUsers_ApplicationUserId",
                table: "ToDoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItem_ToDoStatus_ToDoStatusId",
                table: "ToDoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoStatus",
                table: "ToDoStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem");

            migrationBuilder.RenameTable(
                name: "ToDoStatus",
                newName: "ToDoStatuses");

            migrationBuilder.RenameTable(
                name: "ToDoItem",
                newName: "ToDoItems");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItem_ToDoStatusId",
                table: "ToDoItems",
                newName: "IX_ToDoItems_ToDoStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItem_ApplicationUserId",
                table: "ToDoItems",
                newName: "IX_ToDoItems_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoStatuses",
                table: "ToDoStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "920a3fc0-baa6-447a-a720-53e006af35b3", "AQAAAAEAACcQAAAAEGJFIFYxzdbt1Srhd52QWciQskRPWV4UHE2nXmYgORI9WCz7cgQDk9QzanWIG+oHVQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_AspNetUsers_ApplicationUserId",
                table: "ToDoItems",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_ToDoStatuses_ToDoStatusId",
                table: "ToDoItems",
                column: "ToDoStatusId",
                principalTable: "ToDoStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

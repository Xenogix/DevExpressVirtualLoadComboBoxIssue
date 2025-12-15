using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadComboboxFilterIssue.Shared.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyEntities", x => x.Id);
                });

            // Insert approximately 1GB of data
            // Strategy: 10,000 records × 100KB each = ~1GB
            const int recordCount = 10000;
            const int dataSizePerRecord = 100 * 1024; // 100KB

            // Use SQLite's randomblob() to generate BLOB content on the database side to avoid .NET memory pressure
            for (int i = 0; i < recordCount; i++)
            {
                var id = Guid.NewGuid();
                migrationBuilder.Sql($"INSERT INTO MyEntities (Id, Name, Data) VALUES ('{id}', 'Entity', randomblob({dataSizePerRecord}));");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyEntities");
        }
    }
}

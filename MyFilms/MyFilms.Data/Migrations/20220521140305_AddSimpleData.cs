using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFilms.Data.Migrations
{
    public partial class AddSimpleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "CreationYear", "Description", "Title" },
                values: new object[] { new Guid("2f471df9-5c78-4abc-90f1-2e2abfd11ff6"), 2021, "For the first time in the cinematic history of Spider-Man, our friendly neighborhood hero's identity is revealed, bringing his Super Hero responsibilities into conflict with his normal life and putting those he cares about most at risk. When he enlists Doctor Strange's help to restore his secret, the spell tears a hole in their world, releasing the most powerful villains who've ever fought a Spider-Man in any universe. Now, Peter will have to overcome his greatest challenge yet, which will not only forever alter his own future but the future of the Multiverse. ", "Spider-Man: No Way Home" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "CreationYear", "Description", "Title" },
                values: new object[] { new Guid("6c51ce9e-0673-4d82-af3f-4c168c789a8b"), 2009, "Seeking solace from his dark past, Logan (Hugh Jackman), better known as Wolverine, seems to have found love and contentment with Kayla Silverfox (Lynn Collins). Logan's peaceful existence is shattered when Victor Creed (Liev Schreiber), his vicious brother, brutally murders Kayla. Logan's thirst for revenge propels him into the Weapon X program, where he undergoes a painful procedure to bond his bones with adamantium, making him virtually indestructible and more than a match for Victor. ", "X-Men Origins: Wolverine" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "CreationYear", "Description", "Title" },
                values: new object[] { new Guid("da75d30b-8bb9-46c4-8eb7-e49f8ff19f7e"), 2019, "Adrift in space with no food or water, Tony Stark sends a message to Pepper Potts as his oxygen supply starts to dwindle. Meanwhile, the remaining Avengers -- Thor, Black Widow, Captain America and Bruce Banner -- must figure out a way to bring back their vanquished allies for an epic showdown with Thanos -- the evil demigod who decimated the planet and the universe. ", "Avengers: Endgame" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: new Guid("2f471df9-5c78-4abc-90f1-2e2abfd11ff6"));

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: new Guid("6c51ce9e-0673-4d82-af3f-4c168c789a8b"));

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: new Guid("da75d30b-8bb9-46c4-8eb7-e49f8ff19f7e"));
        }
    }
}

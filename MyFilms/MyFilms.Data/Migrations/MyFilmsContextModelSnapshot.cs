// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFilms.Data;

#nullable disable

namespace MyFilms.Data.Migrations
{
    [DbContext(typeof(MyFilmsContext))]
    partial class MyFilmsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyFilms.Data.Entities.Film", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CreationYear")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = new Guid("da75d30b-8bb9-46c4-8eb7-e49f8ff19f7e"),
                            CreationYear = 2019,
                            Description = "Adrift in space with no food or water, Tony Stark sends a message to Pepper Potts as his oxygen supply starts to dwindle. Meanwhile, the remaining Avengers -- Thor, Black Widow, Captain America and Bruce Banner -- must figure out a way to bring back their vanquished allies for an epic showdown with Thanos -- the evil demigod who decimated the planet and the universe. ",
                            Title = "Avengers: Endgame"
                        },
                        new
                        {
                            Id = new Guid("6c51ce9e-0673-4d82-af3f-4c168c789a8b"),
                            CreationYear = 2009,
                            Description = "Seeking solace from his dark past, Logan (Hugh Jackman), better known as Wolverine, seems to have found love and contentment with Kayla Silverfox (Lynn Collins). Logan's peaceful existence is shattered when Victor Creed (Liev Schreiber), his vicious brother, brutally murders Kayla. Logan's thirst for revenge propels him into the Weapon X program, where he undergoes a painful procedure to bond his bones with adamantium, making him virtually indestructible and more than a match for Victor. ",
                            Title = "X-Men Origins: Wolverine"
                        },
                        new
                        {
                            Id = new Guid("2f471df9-5c78-4abc-90f1-2e2abfd11ff6"),
                            CreationYear = 2021,
                            Description = "For the first time in the cinematic history of Spider-Man, our friendly neighborhood hero's identity is revealed, bringing his Super Hero responsibilities into conflict with his normal life and putting those he cares about most at risk. When he enlists Doctor Strange's help to restore his secret, the spell tears a hole in their world, releasing the most powerful villains who've ever fought a Spider-Man in any universe. Now, Peter will have to overcome his greatest challenge yet, which will not only forever alter his own future but the future of the Multiverse. ",
                            Title = "Spider-Man: No Way Home"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

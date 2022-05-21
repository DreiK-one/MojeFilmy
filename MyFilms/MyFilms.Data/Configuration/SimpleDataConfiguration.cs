using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFilms.Data.Entities;


namespace MyFilms.Data.Configuration
{
    //ONLY FOR CREATE MIGRATION WITH SIMPLE DATA
    public class SimpleDataConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasData(
                new Film
                {
                    Id = Guid.NewGuid(),
                    Title = "Avengers: Endgame",
                    Description = "Adrift in space with no food or water, Tony Stark sends a message to Pepper Potts as his oxygen supply starts to dwindle. Meanwhile, the remaining Avengers -- Thor, Black Widow, Captain America and Bruce Banner -- must figure out a way to bring back their vanquished allies for an epic showdown with Thanos -- the evil demigod who decimated the planet and the universe. ",
                    CreationYear = 2019
                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    Title = "X-Men Origins: Wolverine",
                    Description = "Seeking solace from his dark past, Logan (Hugh Jackman), better known as Wolverine, seems to have found love and contentment with Kayla Silverfox (Lynn Collins). Logan's peaceful existence is shattered when Victor Creed (Liev Schreiber), his vicious brother, brutally murders Kayla. Logan's thirst for revenge propels him into the Weapon X program, where he undergoes a painful procedure to bond his bones with adamantium, making him virtually indestructible and more than a match for Victor. ",
                    CreationYear = 2009
                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    Title = "Spider-Man: No Way Home",
                    Description = "For the first time in the cinematic history of Spider-Man, our friendly neighborhood hero's identity is revealed, bringing his Super Hero responsibilities into conflict with his normal life and putting those he cares about most at risk. When he enlists Doctor Strange's help to restore his secret, the spell tears a hole in their world, releasing the most powerful villains who've ever fought a Spider-Man in any universe. Now, Peter will have to overcome his greatest challenge yet, which will not only forever alter his own future but the future of the Multiverse. ",
                    CreationYear = 2021
                });
        }
    }
}

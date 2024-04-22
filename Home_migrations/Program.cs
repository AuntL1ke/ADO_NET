using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

    namespace Home_migrations
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                MusicDB context = new MusicDB();
                var artist1 = new Artist { FirstName = "John", LastName = "Doe", Country = "USA" };
                var artist2 = new Artist { FirstName = "Jane", LastName = "Smith", Country = "UK" };
                context.Artists.Add(artist1);
                context.Artists.Add(artist2);
              
               /* var album1 = new Album { Title = "Album 1", Artist = artist1, Year = 2020, Genre = "Rock" };
                var album2 = new Album { Title = "Album 2", Artist = artist2, Year = 2018, Genre = "Pop" };
                context.Albums.Add(album1);
                context.Albums.Add(album2);
             
                var track1 = new Track { Title = "Track 1", Album = album1, Duration = TimeSpan.FromMinutes(4) };
                var track2 = new Track { Title = "Track 2", Album = album2, Duration = TimeSpan.FromMinutes(3) };
                context.Tracks.Add(track1);
                context.Tracks.Add(track2);
               
    
                var playlist1 = new Playlist { Name = "Playlist 1", Category = "Rock" };
                playlist1.Tracks.Add(track1);
                var playlist2 = new Playlist { Name = "Playlist 2", Category = "Pop" };
                playlist2.Tracks.Add(track2);
                context.Playlists.Add(playlist1);
                context.Playlists.Add(playlist2);*/

                context.SaveChanges();
            }
        }

    
    }
    

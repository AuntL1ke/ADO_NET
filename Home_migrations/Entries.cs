using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home_migrations
{
    public class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public int ArtistId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }

    public class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        public int AlbumId { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public byte[] CoverPhoto { get; set; } // Додавання фото обкладинки

        public virtual Artist Artist { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }

    public class Track
    {
        public int TrackId { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        public TimeSpan Duration { get; set; }

        public virtual Album Album { get; set; }
    }

    public class Playlist
    {
        public int PlaylistId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }

        public byte[] CoverPhoto { get; set; } // Додавання фото обкладинки

        public virtual ICollection<Track> Tracks { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="SongsAlbum"/>.</para>
  /// </summary>
  public sealed class SongsAlbumTests : EntityUnitTests<SongsAlbum>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Comments", "DateCreated", "Image", "LastUpdated", "Name", "PublishedOn", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var album = new SongsAlbum();
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Tags"":[]}}".FormatSelf(album.DateCreated.ToString("o"), album.LastUpdated.ToString("o")), album.Json());

      album = new SongsAlbum("name");
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""name"",""Tags"":[]}}".FormatSelf(album.DateCreated.ToString("o"), album.LastUpdated.ToString("o")), album.Json());
      Assert.Equal(album, album.Json().Json<SongsAlbum>());

      var comment = new Comment("comment.name", "comment.text");
      album = new SongsAlbum("name", "text", "image", DateTime.MinValue) { Id = 1, Language = "language", Comments = new List<Comment> { comment }, Tags = new List<string> { "tag" } };
      Assert.Equal(@"{{""Id"":1,""Comments"":[{{""Id"":0,""DateCreated"":""{1}"",""LastUpdated"":""{2}"",""Name"":""comment.name"",""Text"":""comment.text""}}],""DateCreated"":""{3}"",""Image"":""image"",""Language"":""language"",""LastUpdated"":""{4}"",""Name"":""name"",""PublishedOn"":""{0}"",""Tags"":[""tag""],""Text"":""text""}}".FormatSelf(DateTime.MinValue.ToString("o"), comment.DateCreated.ToString("o"), comment.LastUpdated.ToString("o"), album.DateCreated.ToString("o"), album.LastUpdated.ToString("o")), album.Json());
      Assert.Equal(album, album.Json().Json<SongsAlbum>());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="SongsAlbum()"/>
    /// <seealso cref="SongsAlbum(string, string, string, DateTime?)"/>
    [Fact]
    public void Constructors()
    {
      var album = new SongsAlbum();
      Assert.False(album.Comments.Any());
      Assert.True(album.DateCreated >= DateTime.MinValue && album.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, album.Id);
      Assert.Null(album.Image);
      Assert.Null(album.Language);
      Assert.True(album.LastUpdated >= DateTime.MinValue && album.LastUpdated <= DateTime.UtcNow);
      Assert.Null(album.Name);
      Assert.Null(album.PublishedOn);
      Assert.False(album.Tags.Any());
      Assert.Null(album.Text);
      Assert.Equal(0, album.Version);

      Assert.Throws<ArgumentNullException>(() => new SongsAlbum(null));
      Assert.Throws<ArgumentException>(() => new SongsAlbum(string.Empty, "name"));
      album = new SongsAlbum("name", "text", "image", DateTime.MinValue);
      Assert.False(album.Comments.Any());
      Assert.True(album.DateCreated >= DateTime.MinValue && album.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, album.Id);
      Assert.Equal("image", album.Image);
      Assert.Null(album.Language);
      Assert.True(album.LastUpdated >= DateTime.MinValue && album.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", album.Name);
      Assert.Equal(DateTime.MinValue, album.PublishedOn);
      Assert.False(album.Tags.Any());
      Assert.Equal("text", album.Text);
      Assert.Equal(0, album.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="SongsAlbum.Image"/> property.</para>
    /// </summary>
    [Fact]
    public void Image_Property()
    {
      Assert.Equal("image", new SongsAlbum { Image = "image" }.Image);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="SongsAlbum.PublishedOn"/> property.</para>
    /// </summary>
    [Fact]
    public void PublishedOn_Property()
    {
      Assert.Equal(DateTime.MinValue, new SongsAlbum { PublishedOn = DateTime.MinValue }.PublishedOn);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="SongsAlbum.CompareTo(SongsAlbum)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }
  }
}
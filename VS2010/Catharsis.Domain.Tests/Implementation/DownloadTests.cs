﻿using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Download"/>.</para>
  /// </summary>
  public sealed class DownloadTests : EntityUnitTests<Download>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Category", "Comments", "DateCreated", "Downloads", "Language", "LastUpdated", "Name", "Tags", "Text", "Url");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var download = new Download();
      this.TestJson(download, new { Id = 0, Comments = new object[] {}, DateCreated = download.DateCreated.ISO8601(), Downloads = 0, LastUpdated = download.LastUpdated.ISO8601(), Tags = new object[] {} });

      download = new Download("name", "url");
      this.TestJson(download, new { Id = 0, Comments = new object[] {}, DateCreated = download.DateCreated.ISO8601(), Downloads = 0, LastUpdated = download.LastUpdated.ISO8601(), Name = "name", Tags = new object[] {}, Url = "url" });

      var comment = new Comment("comment.name", "comment.text");
      download = new Download("name", "url", new DownloadsCategory("category.name"), "text")
      {
        Id = 1,
        Language = "language",
        Downloads = 1,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(download, new { Id = 1, Category = new { Id = 0, Name = "category.name" }, Comments = new object[] { new { Id = 0, DateCreated = comment.DateCreated.ISO8601(), LastUpdated = comment.LastUpdated.ISO8601(), Name = "comment.name", Text = "comment.text" } }, DateCreated = download.DateCreated.ISO8601(), Downloads = 1, Language = "language", LastUpdated = download.LastUpdated.ISO8601(), Name = "name", Tags = new object[] { "tag" }, Text = "text", Url = "url" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var download = new Download();
      this.TestXml(download, new { Id = 0, DateCreated = download.DateCreated, Downloads = 0, LastUpdated = download.LastUpdated });

      download = new Download("name", "url");
      this.TestXml(download, new { Id = 0, DateCreated = download.DateCreated, Downloads = 0, LastUpdated = download.LastUpdated, Name = "name", Url = "url" });

      var comment = new Comment("comment.name", "comment.text");
      download = new Download("name", "url", new DownloadsCategory("category.name"), "text")
      {
        Id = 1,
        Language = "language",
        Downloads = 1,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(download, new { Id = 1, DateCreated = download.DateCreated, Downloads = 1, Language = "language", LastUpdated = download.LastUpdated, Name = "name", Text = "text", Url = "url" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Download()"/>
    /// <seealso cref="Download(string, string, DownloadsCategory, string)"/>
    [Fact]
    public void Constructors()
    {
      var download = new Download();
      Assert.Null(download.Category);
      Assert.False(download.Comments.Any());
      Assert.True(download.DateCreated >= DateTime.MinValue && download.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, download.Downloads);
      Assert.Equal(0, download.Id);
      Assert.Null(download.Language);
      Assert.True(download.LastUpdated >= DateTime.MinValue && download.LastUpdated <= DateTime.UtcNow);
      Assert.Null(download.Name);
      Assert.False(download.Tags.Any());
      Assert.Null(download.Text);
      Assert.Null(download.Url);
      Assert.Equal(0, download.Version);

      Assert.Throws<ArgumentNullException>(() => new Download(null, "url"));
      Assert.Throws<ArgumentNullException>(() => new Download("name", null));
      Assert.Throws<ArgumentException>(() => new Download(string.Empty, "url"));
      Assert.Throws<ArgumentException>(() => new Download("name", string.Empty));
      download = new Download("name", "url", new DownloadsCategory(), "text");
      Assert.NotNull(download.Category);
      Assert.False(download.Comments.Any());
      Assert.True(download.DateCreated >= DateTime.MinValue && download.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, download.Downloads);
      Assert.Equal(0, download.Id);
      Assert.Null(download.Language);
      Assert.True(download.LastUpdated >= DateTime.MinValue && download.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", download.Name);
      Assert.False(download.Tags.Any());
      Assert.Equal("text", download.Text);
      Assert.Equal("url", download.Url);
      Assert.Equal(0, download.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new DownloadsCategory();
      Assert.True(ReferenceEquals(new Download { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.Downloads"/> property.</para>
    /// </summary>
    [Fact]
    public void Downloads_Property()
    {
      Assert.Equal(1, new Download { Downloads = 1 }.Downloads);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.Url"/> property.</para>
    /// </summary>
    [Fact]
    public void Url_Property()
    {
      Assert.Equal("url", new Download { Url = "url" }.Url);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.CompareTo(Download)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Download.Equals(Download)"/></description></item>
    ///     <item><description><see cref="Download.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Category", new DownloadsCategory { Name = "first" }, new DownloadsCategory { Name = "second" });
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Category", new DownloadsCategory { Name = "first" }, new DownloadsCategory { Name = "second" });
    }
  }
}
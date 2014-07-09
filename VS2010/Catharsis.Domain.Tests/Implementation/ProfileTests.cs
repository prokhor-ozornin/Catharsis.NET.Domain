﻿using System;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Profile"/>.</para>
  /// </summary>
  public sealed class ProfileTests : EntityUnitTests<Profile>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Email", "Name", "Photo", "Type", "Url", "Username");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var profile = new Profile();
      this.TestJson(profile, new { Id = 0 });

      profile = new Profile("name", "username", "type", "url");
      this.TestJson(profile, new { Id = 0, Name = "name", Type = "type", Url = "url", Username = "username"} );

      profile = new Profile("name", "username", "type", "url", "email", "photo")
      {
        Id = 1 
      };
      this.TestJson(profile, new { Id = 1, Email = "email", Name = "name", Photo = "photo", Type = "type", Url = "url", Username = "username" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var profile = new Profile();
      this.TestXml(profile, new { Id = 0 });

      profile = new Profile("name", "username", "type", "url");
      this.TestXml(profile, new { Id = 0, Name = "name", Type = "type", Url = "url", Username = "username" });

      profile = new Profile("name", "username", "type", "url", "email", "photo")
      {
        Id = 1
      };
      this.TestXml(profile, new { Id = 1, Email = "email", Name = "name", Photo = "photo", Type = "type", Url = "url", Username = "username" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Profile()"/>
    /// <seealso cref="Profile(string, string, string, string, string, string)"/>
    [Fact]
    public void Constructors()
    {
      var profile = new Profile();
      Assert.Null(profile.Email);
      Assert.Equal(0, profile.Id);
      Assert.Null(profile.Name);
      Assert.Null(profile.Photo);
      Assert.Null(profile.Type);
      Assert.Null(profile.Url);
      Assert.Null(profile.Username);
      Assert.Equal(0, profile.Version);

      Assert.Throws<ArgumentNullException>(() => new Profile(null, "username", "type", "url"));
      Assert.Throws<ArgumentNullException>(() => new Profile("name", null, "type", "url"));
      Assert.Throws<ArgumentNullException>(() => new Profile("name", "username", null, "url"));
      Assert.Throws<ArgumentNullException>(() => new Profile("name", "username", "type", null));
      Assert.Throws<ArgumentException>(() => new Profile(string.Empty, "username", "type", "url"));
      Assert.Throws<ArgumentException>(() => new Profile("name", string.Empty, "type", "url"));
      Assert.Throws<ArgumentException>(() => new Profile("name", "username", string.Empty, "url"));
      Assert.Throws<ArgumentException>(() => new Profile("name", "username", "type", string.Empty));
      profile = new Profile("name", "username", "type", "url", "email", "photo");
      Assert.Equal("email", profile.Email);
      Assert.Equal(0, profile.Id);
      Assert.Equal("name", profile.Name);
      Assert.Equal("photo", profile.Photo);
      Assert.Equal("type", profile.Type);
      Assert.Equal("url", profile.Url);
      Assert.Equal("username", profile.Username);
      Assert.Equal(0, profile.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Profile.Email"/> property.</para>
    /// </summary>
    [Fact]
    public void Email_Property()
    {
      Assert.Equal("email", new Profile { Email = "email" }.Email);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Profile.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Profile { Name = null });
      Assert.Throws<ArgumentException>(() => new Profile { Name = string.Empty });

      Assert.Equal("name", new Profile { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Profile.Photo"/> property.</para>
    /// </summary>
    [Fact]
    public void Photo_Property()
    {
      Assert.Equal("photo", new Profile { Photo = "photo" }.Photo);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Profile.Type"/> property.</para>
    /// </summary>
    [Fact]
    public void Type_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Profile { Type = null });
      Assert.Throws<ArgumentException>(() => new Profile { Type = string.Empty });

      Assert.Equal("type", new Profile { Type = "type" }.Type);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Profile.Url"/> property.</para>
    /// </summary>
    [Fact]
    public void Url_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Profile { Url = null });
      Assert.Throws<ArgumentException>(() => new Profile { Url = string.Empty });

      Assert.Equal("url", new Profile { Url = "url" }.Url);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Profile.Username"/> property.</para>
    /// </summary>
    [Fact]
    public void Username_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Profile { Username = null });
      Assert.Throws<ArgumentException>(() => new Profile { Username = string.Empty });

      Assert.Equal("username", new Profile { Username = "username" }.Username);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Profile.CompareTo(Profile)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Username", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Profile.Equals(Profile)"/></description></item>
    ///     <item><description><see cref="Profile.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Type", "first", "second");
      this.TestEquality("Username", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Profile.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Type", "first", "second");
      this.TestHashCode("Username", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Profile.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Profile { Name = "name" }.ToString());
    }
  }
}
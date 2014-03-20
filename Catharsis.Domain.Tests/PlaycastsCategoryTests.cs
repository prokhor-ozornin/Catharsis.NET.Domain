﻿using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="PlaycastsCategory"/>.</para>
  /// </summary>
  public sealed class PlaycastsCategoryTests : CategoryUnitTestsBase<PlaycastsCategory>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Description", "Language", "Name", "Parent");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var category = new PlaycastsCategory();
      Assert.Equal(@"{""Id"":0}", category.Json());

      category = new PlaycastsCategory("name");
      Assert.Equal(@"{""Id"":0,""Name"":""name""}", category.Json());

      category = new PlaycastsCategory("name", new PlaycastsCategory("parent.name"), "description") { Id = 1, Language = "language" };
      Assert.Equal(@"{""Id"":1,""Description"":""description"",""Language"":""language"",""Name"":""name"",""Parent"":{""Id"":0,""Name"":""parent.name""}}", category.Json());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="PlaycastsCategory()"/>
    /// <seealso cref="PlaycastsCategory(string, PlaycastsCategory, string)"/>
    [Fact]
    public void Constructors()
    {
      var category = new PlaycastsCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new PlaycastsCategory();
      category = new PlaycastsCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PlaycastsCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new PlaycastsCategory();
      Assert.True(ReferenceEquals(new PlaycastsCategory { Parent = parent }.Parent, parent));
    }
  }
}
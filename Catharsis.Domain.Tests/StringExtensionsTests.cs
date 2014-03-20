﻿using System;
using System.Collections.Generic;
using Catharsis.Commons;
using Newtonsoft.Json;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="StringExtensions"/>.</para>
  /// </summary>
  public sealed class StringExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="ObjectExtensions.JsonSerializerSettings"/> property.</para>
    /// </summary>
    [Fact]
    public void JsonSerializerSettings_Property()
    {
      var settings = StringExtensions.JsonSerializerSettings;
      Assert.Equal(ConstructorHandling.AllowNonPublicDefaultConstructor, settings.ConstructorHandling);
      Assert.Equal(DateTimeZoneHandling.RoundtripKind, settings.DateTimeZoneHandling);
      Assert.Equal(NullValueHandling.Ignore, settings.NullValueHandling);
      Assert.Equal(ObjectCreationHandling.Auto, settings.ObjectCreationHandling);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="StringExtensions.Json{T}(string, JsonSerializerSettings)"/> method.</para>
    /// </summary>
    [Fact]
    public void Json_Method()
    {
      Assert.Throws<ArgumentNullException>(() => StringExtensions.Json<object>(null));
      Assert.Throws<ArgumentException>(() => string.Empty.Json<object>());

      Assert.Equal(string.Empty, string.Empty.Json().Json<string>());
      Assert.Throws<JsonReaderException>(() => "{}".Json<string>());
      
      var jsonArray = @"[""first"",""second""]";
      Assert.Equal(new [] { "first", "second" }, jsonArray.Json<string[]>());
      Assert.Equal(new List<string> { "first", "second" }, jsonArray.Json<IList<string>>());
      Assert.Equal(new List<string> { "first", "second" }, jsonArray.Json<ICollection<string>>());
      Assert.Equal(new List<string> { "first", "second" }, jsonArray.Json<IEnumerable<string>>());

      var subject = @"{""Id"":0}".Json<MockJsonObject>();
      Assert.Null(subject.Date);
      Assert.Equal(0, subject.Id);
      Assert.Null(subject.PublicField);
      Assert.Null(subject.PublicProperty);

      subject = @"{{""Id"":1,""Date"":""{0}"",""PublicField"":""field"",""PublicProperty"":""property""}}".FormatSelf(DateTime.MinValue.ToString()).Json<MockJsonObject>();
      Assert.Equal(DateTime.MinValue, subject.Date);
      Assert.Equal(1, subject.Id);
      Assert.Equal("field", subject.PublicField);
      Assert.Equal("property", subject.PublicProperty);
    }
  }
}
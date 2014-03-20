﻿using System;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="string"/>.</para>
  /// </summary>
  /// <seealso cref="string"/>
  public static class StringExtensions
  {
    private static JsonSerializerSettings jsonSerializerSettings;

    /// <summary>
    ///   <para>Default JSON serializer settings.</para>
    /// </summary>
    public static JsonSerializerSettings JsonSerializerSettings
    {
      get
      {
        return jsonSerializerSettings ?? (jsonSerializerSettings = new JsonSerializerSettings
        {
          ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
          DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
          NullValueHandling = NullValueHandling.Ignore,
          ObjectCreationHandling = ObjectCreationHandling.Auto
        });
      }
    }

    /// <summary>
    ///   <para>Deserializes object from JSON string.</para>
    /// </summary>
    /// <typeparam name="T">Type of object to be instantiated during deserialization.</typeparam>
    /// <param name="json">Serialized JSON object of type <typeparamref name="T"/>.</param>
    /// <param name="settings">Deserialization settings. If not specified, default settings set will be used.</param>
    /// <returns>Instance of <typeparamref name="T"/> type, deserialized from <paramref name="json"/> string.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="json"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="json"/> is <see cref="string.Empty"/> string.</exception>
    public static T Json<T>(this string json, JsonSerializerSettings settings = null)
    {
      Assertion.NotEmpty(json);

      return JsonConvert.DeserializeObject<T>(json, settings ?? JsonSerializerSettings);
    }
  }
}
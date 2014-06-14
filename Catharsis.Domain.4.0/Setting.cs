﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a named setting/option.</para>
  /// </summary>
  [Description("Represents a named setting/option")]
  public partial class Setting : IComparable<Setting>, IEquatable<Setting>, IEntity, INameable
  {
    private string name;

    /// <summary>
    ///   <para>Unique identifier of setting.</para>
    /// </summary>
    [Description("Unique identifier of setting")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current setting instance.</para>
    /// </summary>
    [Description("Version number of current setting instance")]
    [XmlIgnore]
    [JsonIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Name of setting.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Name of setting")]
    public virtual string Name
    {
      get { return this.name; }
      set
      {
        Assertion.NotEmpty(value);

        this.name = value;
      }
    }

    /// <summary>
    ///   <para>Value of setting.</para>
    /// </summary>
    [Description("Value of setting")]
    public virtual string Value { get; set; }

    /// <summary>
    ///   <para>Creates new setting.</para>
    /// </summary>
    public Setting()
    {
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="name">Name of setting.</param>
    /// <param name="value">Value of setting.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public Setting(string name, string value)
    {
      this.Name = name;
      this.Value = value;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Setting"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Setting"/> to compare with this instance.</param>
    public virtual int CompareTo(Setting other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="Setting"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Setting other)
    {
      return this.Equality(other, setting => setting.Name);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Setting);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(setting => setting.Name);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Setting"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Setting"/>.</returns>
    public override string ToString()
    {
      return this.Value;
    }
  }
}
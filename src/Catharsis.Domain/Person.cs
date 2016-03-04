﻿using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Персона</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Person : Entity, IComparable<Person>, IEquatable<Person>
  {
    /// <summary>
    ///   <para>Дата рождения</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentBirthDate)]
#endif
    [Column(Schema.ColumnNameBirthDate)]
    [Indexed(Name = "idx__people__birth_date")]
    public virtual DateTime? BirthDate { get; set; }

    /// <summary>
    ///   <para>Дата смерти</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentDeathDate)]
#endif
    [Column(Schema.ColumnNameDeathDate)]
    [Indexed(Name = "idx__people__death_date")]
    public virtual DateTime? DeathDate { get; set; }

    /// <summary>
    ///   <para>Имя</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentFirstName)]
#endif
    [Column(Schema.ColumnNameFirstName)]
    [NotNull]
    [Indexed(Name = "idx__people__first_name")]
    public virtual string FirstName { get; set; }

    /// <summary>
    ///   <para>Фамилия</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentLastName)]
#endif
    [Column(Schema.ColumnNameLastName)]
    [NotNull]
    [Indexed(Name = "idx__people__last_name")]
    public virtual string LastName { get; set; }

    /// <summary>
    ///   <para>Отчество</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentMiddleName)]
#endif
    [Column(Schema.ColumnNameMiddleName)]
    [Indexed(Name = "idx__people__middle_name")]
    public virtual string MiddleName { get; set; }

    public virtual int CompareTo(Person other)
    {
      return this.ToString().CompareTo(other.ToString());
    }

    public virtual bool Equals(Person other)
    {
      return this.Equality(other, it => it.BirthDate, it => it.DeathDate, it => it.FirstName, it => it.LastName, it => it.MiddleName);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Person);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => BirthDate, it => it.DeathDate, it => it.FirstName, it => it.LastName, it => it.MiddleName);
    }

    public override string ToString()
    {
      return $"{this.LastName ?? string.Empty} {this.FirstName ?? string.Empty} {this.MiddleName ?? string.Empty}".Trim();
    }

    public static class Schema
    {
      public const string TableName = "people";
      public const string TableComment = "Персоны";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления персоны";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего обновления персоны";

      public const string ColumnNameBirthDate = "birth_date";
      public const string ColumnCommentBirthDate = "Дата рождения";

      public const string ColumnNameDeathDate = "death_date";
      public const string ColumnCommentDeathDate = "Дата смерти";

      public const string ColumnNameFirstName = "first_name";
      public const string ColumnCommentFirstName = "Имя";

      public const string ColumnNameLastName = "last_name";
      public const string ColumnCommentLastName = "Фамилия";

      public const string ColumnNameMiddleName = "middle_name";
      public const string ColumnCommentMiddleName = "Отчество";
    }
  }
}
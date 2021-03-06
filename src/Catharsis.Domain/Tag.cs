﻿using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Ключевое слово</para>
  /// </summary>
  [Serializable]
  [Description("Ключевое слово")]
  [Table(Schema.TableName)]
  public class Tag : Entity, IComparable<Tag>, IEquatable<Tag>
  {
    /// <summary>
    ///   <para>Значение ключевого слова</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Unique(Name = "tag__name")]
    public virtual string Name { get; set; }

    public virtual int CompareTo(Tag other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public virtual bool Equals(Tag other)
    {
      return this.Equality(other, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Tag);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Name);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "tag";
      public const string TableComment = "Ключевые слова (теги)";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления ключевого слова";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения ключевого слова";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Значение ключевого слова";
    }
  }
}
﻿using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Программный скрипт</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Script : Entity, IComparable<Script>, IEquatable<Script>
  {
    /// <summary>
    ///   <para>Программный код скрипта</para>
    /// </summary>
    [Description(Schema.ColumnCommentCode)]
    [Column(Schema.ColumnNameCode)]
    [MaxLength(1048576)]
    public virtual string Code { get; set; }

    /// <summary>
    ///   <para>Длительность выполнения скрипта в миллисекундах</para>
    /// </summary>
    [Description(Schema.ColumnCommentDuration)]
    [Column(Schema.ColumnNameDuration)]
    public virtual long? Duration { get; set; }

    /// <summary>
    ///   <para>Признак того, был ли выполнен скрипт</para>
    /// </summary>
    [Description(Schema.ColumnCommentExecuted)]
    [Column(Schema.ColumnNameExecuted)]
    [NotNull]
    [Indexed(Name = "idx__script__executed")]
    public virtual bool? Executed { get; set; }

    /// <summary>
    ///   <para>Наименование скрипта</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Unique(Name = "script__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Путь к файлу скрипта</para>
    /// </summary>
    [Description(Schema.ColumnCommentPath)]
    [Column(Schema.ColumnNamePath)]
    public virtual string Path { get; set; }

    public virtual int CompareTo(Script other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public virtual bool Equals(Script other)
    {
      return this.Equality(other, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Script);
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
      public const string TableName = "script";
      public const string TableComment = "Программные скрипты";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время начала работы скрипта";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения скрипта";

      public const string ColumnNameCode = "code";
      public const string ColumnCommentCode = "Программный код скрипта";

      public const string ColumnNameDuration = "duration";
      public const string ColumnCommentDuration = "Длительность выполнения скрипта в миллисекундах";

      public const string ColumnNameExecuted = "executed";
      public const string ColumnCommentExecuted = "Признак того, был ли выполнен скрипт";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование скрипта";

      public const string ColumnNamePath = "path";
      public const string ColumnCommentPath = "Путь к файлу скрипта";
    }
  }
}
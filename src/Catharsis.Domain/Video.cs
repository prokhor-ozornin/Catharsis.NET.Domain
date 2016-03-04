﻿using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Видео</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Video : Media, IComparable<Video>, IEquatable<Video>
  {
    /// <summary>
    ///   <para>Файл, представляющий видео</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentFile)]
#endif
    [Column(Schema.ColumnNameFile)]
    [Indexed(Name = "idx__videos__file_id")]
    public virtual StorageFile File { get; set; }

    public virtual int CompareTo(Video other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public virtual bool Equals(Video other)
    {
      return this.Equality(other, it => it.File, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Video);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.File, it => it.Uri);
    }

    public static class Schema
    {
      public const string TableName = "videos";
      public const string TableComment = "Видео";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameFile = "file_id";
      public const string ColumnCommentFile = "Файл, представляющий видео";
    }
  }
}
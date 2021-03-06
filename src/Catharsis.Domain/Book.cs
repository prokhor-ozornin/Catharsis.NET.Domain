﻿using System;
using System.ComponentModel;
using Catharsis.Commons;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Литературное произведение</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Book : Entity, IComparable<Book>, IEquatable<Book>
  {
    /// <summary>
    ///   <para>Аннотация к произведению</para>
    /// </summary>
    [Description(Schema.ColumnCommentAnnotation)]
    [Column(Schema.ColumnNameAnnotation)]
    [MaxLength(1000)]
    public virtual string Annotation { get; set; }

    /// <summary>
    ///   <para>Автор произведения</para>
    /// </summary>
    [Description(Schema.ColumnCommentAuthor)]
    [Column(Schema.ColumnNameAuthor)]
    [NotNull]
    [Indexed(Name = "idx__book__author_id")]
    public virtual Person Author { get; set; }

    /// <summary>
    ///   <para>Текстовое содержимое произведения</para>
    /// </summary>
    [Description(Schema.ColumnCommentContents)]
    [Column(Schema.ColumnNameContents)]
    [NotNull]
    public virtual string Contents { get; set; }

    /// <summary>
    ///   <para>Изображение для обложки</para>
    /// </summary>
    [Description(Schema.ColumnCommentCover)]
    [Column(Schema.ColumnNameCover)]
    [Indexed(Name = "idx__book__cover_id")]
    public virtual Image Cover { get; set; }

    /// <summary>
    ///   <para>Уникальный ISBN идентификатор</para>
    /// </summary>
    [Description(Schema.ColumnCommentIsbn)]
    [Column(Schema.ColumnNameIsbn)]
    [Indexed(Name = "idx__book__isbn")]
    [MaxLength(13)]
    public virtual string Isbn { get; set; }

    /// <summary>
    ///   <para>Национальный язык написания</para>
    /// </summary>
    [Description(Schema.ColumnCommentLanguage)]
    [Column(Schema.ColumnNameLanguage)]
    [Indexed(Name = "idx__book__language")]
    [MaxLength(2)]
    public virtual string Language { get; set; }

    /// <summary>
    ///   <para>Примечания к произведению</para>
    /// </summary>
    [Description(Schema.ColumnCommentNotes)]
    [Column(Schema.ColumnNameNotes)]
    [MaxLength(1000)]
    public virtual string Notes { get; set; }

    /// <summary>
    ///   <para>Дата публикации</para>
    /// </summary>
    [Description(Schema.ColumnCommentPublishDate)]
    [Column(Schema.ColumnNamePublishDate)]
    [Indexed(Name = "idx__book__publish_date")]
    public virtual DateTime? PublishDate { get; set; }

    /// <summary>
    ///   <para>Наименование издательства-публикатора</para>
    /// </summary>
    [Description(Schema.ColumnCommentPublisher)]
    [Column(Schema.ColumnNamePublisher)]
    [Indexed(Name = "idx__book__publisher")]
    public virtual string Publisher { get; set; }

    /// <summary>
    ///   <para>Ключевые слова, описывающие содержимое произведения</para>
    /// </summary>
    [Description(Schema.ColumnCommentTags)]
    [Column(Schema.ColumnNameTags)]
    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    /// <summary>
    ///   <para>Наименование произведения</para>
    /// </summary>
    [Description(Schema.ColumnCommentTitle)]
    [Column(Schema.ColumnNameTitle)]
    [NotNull]
    [Indexed(Name = "idx__book__title")]
    public virtual string Title { get; set; }

    public virtual int CompareTo(Book other)
    {
      return this.Title.CompareTo(other.Title);
    }

    public virtual bool Equals(Book other)
    {
      return this.Equality(other, it => it.Isbn);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Book);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Isbn);
    }

    public override string ToString()
    {
      return this.Title?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "book";
      public const string TableComment = "Литературные произведения";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления литературного произведения";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего обновления литературного произведения";

      public const string ColumnNameAnnotation = "annotation";
      public const string ColumnCommentAnnotation = "Аннотация к произведению";

      public const string ColumnNameAuthor = "author";
      public const string ColumnCommentAuthor = "Автор произведения";

      public const string ColumnNameContents = "contents";
      public const string ColumnCommentContents = "Текстовое содержимое произведения";

      public const string ColumnNameCover = "cover_id";
      public const string ColumnCommentCover = "Изображение для обложки";

      public const string ColumnNameIsbn = "isbn";
      public const string ColumnCommentIsbn = "Уникальный ISBN идентификатор";

      public const string ColumnNameLanguage = "language";
      public const string ColumnCommentLanguage = "Национальный язык написания";

      public const string ColumnNameNotes = "notes";
      public const string ColumnCommentNotes = "Примечания к произведению";

      public const string ColumnNamePublishDate = "publish_date";
      public const string ColumnCommentPublishDate = "Дата публикации";

      public const string ColumnNamePublisher = "publisher";
      public const string ColumnCommentPublisher = "Наименование издательства-публикатора";

      public const string ColumnNameTags = "tags";
      public const string ColumnCommentTags = "Ключевые слова, описывающие содержимое произведения";

      public const string ColumnNameTitle = "title";
      public const string ColumnCommentTitle = "Наименование произведения";
    }
  }
}
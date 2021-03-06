﻿using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Web браузер</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class WebBrowser : Entity, IComparable<WebBrowser>, IEquatable<WebBrowser>
  {
    /// <summary>
    ///   <para>Описание браузера</para>
    /// </summary>
    [Description(Schema.ColumnCommentDescription)]
    [Column(Schema.ColumnNameDescription)]
    [MaxLength(1000)]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Наименование/код браузера</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Адрес сайта разработчиков</para>
    /// </summary>
    [Description(Schema.ColumnCommentUri)]
    [Column(Schema.ColumnNameUri)]
    [MaxLength(1000)]
    public virtual Uri Uri { get; set; }

    /// <summary>
    ///   <para>Значение HTTP заголовка User-Agent</para>
    /// </summary>
    [Description(Schema.ColumnCommentUserAgent)]
    [Column(Schema.ColumnNameUserAgent)]
    [NotNull]
    [MaxLength(1000)]
    [Unique(Name = "web_browser__user_agent")]
    public virtual string UserAgent { get; set; }

    public virtual int CompareTo(WebBrowser other)
    {
      return this.UserAgent.CompareTo(other.UserAgent);
    }

    public virtual bool Equals(WebBrowser other)
    {
      return this.Equality(other, it => it.UserAgent);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as WebBrowser);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.UserAgent);
    }

    public override string ToString()
    {
      return this.UserAgent?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "web_browser";
      public const string TableComment = "Web браузеры";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления web браузера";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения web браузера";

      public const string ColumnNameDescription = "description";
      public const string ColumnCommentDescription = "Описание браузера";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование/код браузера";

      public const string ColumnNameUri = "uri";
      public const string ColumnCommentUri = "Адрес сайта разработчиков";

      public const string ColumnNameUserAgent = "user_agent";
      public const string ColumnCommentUserAgent = "Значение HTTP заголовка User-Agent";
    }
  }
}
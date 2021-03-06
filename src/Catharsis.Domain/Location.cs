﻿using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Географическая точка</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Location : Entity, IEquatable<Location>
  {
    /// <summary>
    ///   <para>Широта (градусов) географической точки</para>
    /// </summary>
    [Description(Schema.ColumnCommentLatitude)]
    [Column(Schema.ColumnNameLatitude)]
    [NotNull]
    [Indexed(Name = "idx__location__latitude")]
    public virtual decimal? Latitude { get; set; }

    /// <summary>
    ///   <para>Долгота (градусов) географической точки</para>
    /// </summary>
    [Description(Schema.ColumnCommentLongitude)]
    [Column(Schema.ColumnNameLongitude)]
    [NotNull]
    [Indexed(Name = "idx__location__longitude")]
    public virtual decimal? Longitude { get; set; }

    /// <summary>
    ///   <para>Наименование связанной с географической точкой временной зоны</para>
    /// </summary>
    [Description(Schema.ColumnCommentTimezone)]
    [Column(Schema.ColumnNameTimezone)]
    [Indexed(Name = "idx__location__timezone")]
    public virtual string Timezone { get; set; }
    
    public virtual bool Equals(Location other)
    {
      return this.Equality(other, it => it.Latitude, it => it.Longitude);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Location);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Latitude, it => it.Longitude);
    }

    public override string ToString()
    {
      return this.Latitude != null && this.Longitude != null ? $"{this.Latitude.ToStringInvariant()},{this.Longitude.ToStringInvariant()}" : string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "location";
      public const string TableComment = "Географические точки с координатами";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления географической точки";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения географической точки";

      public const string ColumnNameLatitude = "latitude";
      public const string ColumnCommentLatitude = "Широта (градусов) географической точки";

      public const string ColumnNameLongitude = "longitude";
      public const string ColumnCommentLongitude = "Долгота (градусов) географической точки";

      public const string ColumnNameTimezone = "timezone";
      public const string ColumnCommentTimezone = "Наименование связанной с географической точкой временной зоны";
    }
  }
}
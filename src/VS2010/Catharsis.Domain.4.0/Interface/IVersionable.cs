﻿namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity which can be versioned.</para>
  /// </summary>
  public partial interface IVersionable
  {
    /// <summary>
    ///   <para>Numeric version number of entity.</para>
    /// </summary>
    long Version { get; }
  }
}
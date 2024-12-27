namespace OFX.SDK;

/// <summary>
/// Represents an OFX specification version.
/// </summary>
/// <remarks>Released versions of the OFX specifications:
/// <para>Version 1.0.2 (1997): Initial version supporting any or all version 1 message sets except Bill Presentment.</para>
/// <para>Version 1.0.3 (2005): Extends 1.0.2 by adding support for Multi-Factor Authentication (MFA).</para>
/// <para>Version 1.5.1 (1998): Includes Bill Presentment.</para>
/// <para>Version 1.6 (1999): Last version using SGML format.</para>
/// <para>Version 2.0.3 (2006): First version using XML, includes MFA.</para>
/// <para>Version 2.1.1 (2006): Equivalent to 2.1, includes MFA.</para>
/// <para>Version 2.2 (2017): Includes OAuth.</para>
/// <para>Version 2.2.1 (2019): Includes Tax information 2.0.</para>
/// <para>Version 2.3 (2020): Latest version.</para>
/// </remarks>
public enum OFXSpecification {
    /// <summary>
    /// Represents an unknown specification version.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Represents the specification version 1.0.2 (1997), the initial version.
    /// </summary>
    /// <remarks>
    /// <para>Version 1.0.2 supports any or all version 1.0 message sets except Bill Presentment. These message sets are
    /// defined by the OFX 1.0.2 Document Type Definition (DTD), which is used for parsing. Applications that
    /// conform to this version are referred to as 1.0.2 clients and 1.0.2 servers.</para>
    /// </remarks>
    Version102,

    /// <summary>
    /// Specification version 1.0.3 (2005), including MFA (multi-factor authentication).
    /// </summary>
    /// <remarks>Version 1.0.3 extends 1.0.2 by adding support for Muli-Factor Authentication.</remarks>
    Version103,

    /// <summary>
    /// Specification version 1.5.1 (1998), including Bill Presentment.
    /// </summary>
    /// <remarks>
    /// Version 1.5.1 supports all version 2 message sets, Bill Presentment, and all version 1 message sets.
    /// Because it supports all message sets, the OFX 1.5.1 DTD can be used to create and support OFX 1.0.2 and/
    /// or OFX 1.5.1 clients and servers.
    /// </remarks>
    Version151,

    /// <summary>
    /// Specification version 1.6 (1999), last version using SGML format.
    /// </summary>
    /// <remarks>
    /// Version 1.6 DTD supports all message sets available in the OFX 1.5.1 DTD. It adds specific enhancements
    /// to some of the aggregates. All of those enhancements are optional and should not be used by a client unless
    /// the server indicates support in its FI Profile. Applications that conform to this version are referred to as 1.6
    /// clients and 1.6 servers. The OFX 1.6 DTD fully incorporates the OFX 1.0.2 and 1.5.1 message sets, so it
    /// can be used to support both 1.0.2 and 1.5.1 applications.
    /// </remarks>
    Version160,

    /// <summary>
    /// Specification version 2.0.3 (2006), first version using XML including MFA (multi-factor authentication).
    /// </summary>
    /// <remarks>
    /// <para>Version 2.0 supports all V1 message sets available in the OFX 1.6 DTD. It adds support for 401(k)
    /// investment statement download. The Tax OFX addendum to OFX 2.0 adds support for 1099 and W2
    /// download. An important change for 2.0 is that it adds the requirement of XML compliance to OFX 2.0
    /// clients and servers.</para>
    /// <para>Version 2.0.1 extends 2.0 by adding support for investment transaction reversals, by adding the capability
    /// to include an arbitrary list of balances in statement and credit card statement downloads, and by adding the
    /// ability to specify bill publisher information in the payment message.</para>
    /// <para>Version 2.0.2 adds clarification to 2.0.1 as well as fixes some minor documentation bugs.</para>
    /// <para>Version 2.0.3, an extension of 2.0.2, adds Multi-Factor Authentication (MFA) to the Signon Message Set
    /// and changes to the Profile Message Set to support MFA.</para>
    /// </remarks>
    Version203,

    /// <summary>
    /// Specification version 2.1.1 (2006), equivalent to 2.1 including MFA (multi-factor authentication)
    /// </summary>
    /// <remarks>
    /// <para>Version 2.1 extends 2.0.2 by adding support for loans, as well as image download for banking, credit
    /// cards, investments and loans. Automatic 1-Way OFX is also new</para>
    /// <para>Version 2.1.1 adds Multi-Factor Authentication (MFA) to the Signon Message Set and changes to the
    /// Profile Message Set to support MFA. These are virtually the same MFA changes that are added to versions
    /// 1.0.3 and 2.0.3.</para>
    /// </remarks>
    Version211,

    /// <summary>
    /// Specification version 2.2 (2017), including OAuth.
    /// </summary>
    /// <remarks>
    /// Version 2.2.0 extends 2.1.1 by providing additional security options, multiple new data elements and
    /// aggregates to make OFX more viable for aggregation, and multiple new implementation methods for
    /// existing features to reduce complexity and coordination between providers and developers.Additionally
    /// the main OFX Schema and the OFX Tax Schema, which have diverged since the 2.1.1 release, were
    /// reconciled in the 2.2 release (up to the 2015 tax year).
    /// </remarks>
    Version220,

    /// <summary>
    /// Specification version 2.2.1 (2019), including Tax information 2.0
    /// </summary>
    /// <remarks>Includes the reconciliation of the main OFX Schema and the OFX Tax Schema, which have diverged since the 2.1.1 
    /// release, up to the 2017 tax year.</remarks>
    Version221,

    /// <summary>
    /// Specification version 2.3 (2020), latest version.
    /// </summary>
    /// <remarks>In Version 2.3 Tax was removed so it is no longer necessary to update the main OFX spec with tax changes
    /// every year.</remarks>
    Version230
}

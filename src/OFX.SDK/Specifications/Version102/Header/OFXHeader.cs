using OFX.SDK.Reflection;
using static OFX.SDK.Specifications.Version102.Constants;

namespace OFX.SDK.Specifications.Version102;

#region BSD-3 Copyright Information
/*
  Copyright (c) 2022, Eric Roberto Darruiz
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without
  modification, are permitted provided that the following conditions are met:
  
  1. Redistributions of source code must retain the above copyright notice, this
     list of conditions and the following disclaimer.
  
  2. Redistributions in binary form must reproduce the above copyright notice,
     this list of conditions and the following disclaimer in the documentation
     and/or other materials provided with the distribution.
  
  3. Neither the name of the copyright holder nor the names of its
     contributors may be used to endorse or promote products derived from
     this software without specific prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
  AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
  DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
  FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
  DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
  SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
  CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
  OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
  OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

/// <summary>
/// Represents the OFX 1.0.2 file header.
/// </summary>
/// <remarks>
/// <para>The contents of an Open Financial Exchange file consist of a simple set of headers followed by contents defined by that header.</para>
/// <para>The Open Financial Exchange headers are in a simple tag:value syntax and terminated by a blank line.
/// Open Financial Exchange always sends headers unencrypted, even if application-level encryption is used 
/// for the remaining contents.The language and character set used for the headers is the same as the 
/// preceding MIME headers.</para>
/// <para>The first entry will always be OFXHEADER with a version number. This entry identifies the contents as an Open Financial Exchange 
/// file and provides the version number of the Open Financial Exchange headers that follow(not the version number of the contents).
/// For example:</para>
/// <code>OFXHEADER:100</code>
/// <para>Open Financial Exchange headers can contain the following tags.</para>
/// <code>
/// DATA:OFXSGML
/// VERSION:102
/// SECURITY:
/// ENCODING:
/// CHARSET:
/// COMPRESSION:
/// OLDFILEUID:
/// NEWFILEUID:
/// </code>
/// <para>A blank line follows the last header. Then (for type OFXSGML), the SGML-readable data begins with the <c>&lt;OFX&gt;</c> tag.</para>
/// </remarks>
[OFXVersion(OFXSpecification.Version102)]
public record struct OFXHeader {
    #region Properties
    /// <summary>
    /// Gets the version number of the OFX headers.
    /// </summary>
    /// <remarks>
    /// <c>OFXHEADER</c> specifies the version number of the Open Financial Exchange headers.
    /// <para>The <c>OFXHEADER</c> value should change its major number only if an existing client is unable to process the
    /// new header.This can occur because of a complete syntax change in a header, or a significant change in the
    /// semantics of an existing tag—not the entire response.A server can add new tags as long as clients can
    /// function without understanding them.</para>
    /// <para>The current version of the Open Financial Exchange headers is version 1.0 (OFHEADER:100).</para>
    /// </remarks>
    [OFXTag(OFXSpecification.Version102, OFX_HEADER_TAG, true)]
    public static string OFXHEADER => OFX_HEADER_TAG_VALUE;

    /// <summary>
    /// Gets the content type of the OFX file.
    /// </summary>
    /// <remarks>
    /// <c>DATA</c> specifies the content type, in this case OFXSGML.
    /// <para>From documentation: You should add new values for a DATA tag only when you introduce an entirely new syntax. 
    /// In the case of OFXSGML, a new syntax would have to be non-SGML compliant to warrant a new DATA value. It is
    /// possible that there will be more than one syntax in use at the same time to meet different needs.</para>
    /// <para>For this version, only the value <c>OFXSGML</c> is valid.</para>
    /// </remarks>
    [OFXTag(OFXSpecification.Version102, OFX_DATA_TAG, true)]
    public static string DATA => OFX_DATA_TAG_VALUE;

    /// <summary>
    /// Gets the version of the DTD used to parse the OFX file contents.
    /// </summary>
    /// <remarks>
    /// <c>VERSION </c>specifies the version number of the Document Type Definition (DTD) used for parsing. The
    /// current version of the DTDs is version 1.0.2 (VERSION:102).
    /// <para>The VERSION tag identifies syntactic changes. In the case of OFXSGML, this corresponds to the DTD.
    /// Purely for identification purposes, each change increments the minor number of the version tag. If you
    /// introduce an incompatible change so that an older DTD can not parse the file, the major number should
    /// change.</para>
    /// </remarks>
    [OFXTag(OFXSpecification.Version102, OFX_VERSION_TAG, true)]
    public static string VERSION => OFX_VERSION_TAG_VALUE;

    /// <summary>
    /// Gets or sets the application-level security, if any, that is used for the <c>&lt;OFX&gt;</c> block.
    /// </summary>
    /// <remarks>
    /// <c>SECURITY</c>defines the type of application-level security, if any, that is used for the &lt;OFX&gt; block. 
    /// The values for SECURITY can be <c>NONE</c> or <c>TYPE1</c>.
    /// <para>Both values can be set with the values provided by the <see cref="OFXHeaderSecurity"/> enum.</para>
    /// </remarks>
    [OFXTag(OFXSpecification.Version102, OFX_SECURITY_TAG, true)]
    public OFXHeaderSecurity SECURITY { get; set; }

    /// <summary>
    /// Gets or sets the text encoding used for character data.
    /// </summary>
    /// <remarks>
    /// <para>Most of the content in Open Financial Exchange is language-neutral. However, some error messages,
    /// balance descriptions, and similar tags contain text meant to appear to the financial institution customers. 
    /// There are also cases, such as e-mail records, where customers need to send text in other languages. To 
    /// support world-wide languages, Open Financial Exchange must identify the basic text encoding, character set, and language.</para>
    /// <para>The Open Financial Exchange headers specify the encoding and character set. Current encoding values are 
    /// <c>USASCII</c> and <c>UNICODE</c>. For USASCII, character set values are code pages. UNICODE ignores the character 
    /// set per se although it still requires the syntax.Servers must respond with the encoding and character set requested by the client.</para>
    /// <para>Clients identify the language in the signon request. Open Financial Exchange specifies languages by three-letter 
    /// codes as defined in ISO-639. Servers report their supported languages in the profile. If a server cannot support 
    /// the language requested by the client, it must return an error and not process the rest of the transactions.</para>
    /// <para>Boths values can be set with the valies provided by the <see cref="OFXHeaderEncoding"/> enum.</para>
    /// </remarks>
    [OFXTag(OFXSpecification.Version102, OFX_ENCODING_TAG, true)]
    public OFXHeaderEncoding ENCODING { get; set; }

    /// <summary>
    /// Gets or sets the character set used for character data.
    /// </summary>
    /// <remarks>The default value of <c>CHARSET</c> header is 1252 (a.k.a ANSI).</remarks>
    [OFXTag(OFXSpecification.Version102, OFX_CHARSET_TAG, true)]
    public string CHARSET { get; set; } = OFX_CHARSET_TAG_VALUE;

    /// <summary>
    /// From documentation: "A future version of the specification will define compression.".
    /// </summary>
    /// <remarks>Unused attribute at this moment, for this version. This property will be used just for the OFX file header mapping.</remarks>
    [OFXTag(OFXSpecification.Version102, OFX_COMPRESSION_TAG, true)]
    public static string COMPRESSION => string.Empty;

    /// <summary>
    /// Gets or sets the UID of the last request and response that was successfully received and processed by the client.
    /// </summary>
    /// <remarks>
    /// The default value of <c>OLDFILEUID</c> is <c>NONE</c>.
    /// <para><c>NEWFILEUID</c> uniquely identifies this request file. The NEWFILEUID, which clients must send with every 
    /// request file and which servers must echo in the response, serves several purposes:
    /// <list type="bullet">
    ///   <item>
    ///     <description>Servers can use the NEWFILEUID to quickly identify duplicate request files.</description>
    ///   </item>
    ///   <item>
    ///     <description>Clients and servers can use NEWFILEUID in conjunction with OLDFILEUID for file-based error 
    ///     recovery. For more information about using file-based error recovery or lite synchronization, see
    ///     Chapter 6, "Data Synchronization." of documentation for the version 1.0.2.</description>
    ///   </item>
    ///   <item>
    ///     <description>Servers can use the NEWFILEUID to manage the session keys associated with Type 1 application-level
    ///     security. For more information about security, refer to Chapter 4, "Security." of documentation for the
    ///     version 1.0.2.</description>
    ///   </item>
    /// </list>
    /// </para>
    /// <para>OLDFILEUID is used together with NEWFILEUID only when the client and server support file-based 
    /// error recovery. OLDFILEUID identifies the last request and response that was received and processed by
    /// the client.</para>
    /// <para>For more information about data synchronization, refer to Chapter 6.10, "Synchronization Alternatives.", of  
    /// documentation for the version 1.0.2.</para>
    /// </remarks>
    [OFXTag(OFXSpecification.Version102, OFX_OLDFILEUID_TAG, true)]
    public string OLDFILEUID { get; set; } = OFX_OLDFILEUID_TAG_VALUE;

    /// <summary>
    /// Gets or sets the UID of the current file.
    /// </summary>
    /// <remarks>
    /// The default value of <c>NEWFILEUID</c> is <c>NONE</c>.
    /// <para><c>NEWFILEUID</c> uniquely identifies this request file. The NEWFILEUID, which clients must send with every 
    /// request file and which servers must echo in the response, serves several purposes:
    /// <list type="bullet">
    ///   <item>
    ///     <description>Servers can use the NEWFILEUID to quickly identify duplicate request files.</description>
    ///   </item>
    ///   <item>
    ///     <description>Clients and servers can use NEWFILEUID in conjunction with OLDFILEUID for file-based error 
    ///     recovery. For more information about using file-based error recovery or lite synchronization, see
    ///     Chapter 6, "Data Synchronization." of documentation for the version 1.0.2.</description>
    ///   </item>
    ///   <item>
    ///     <description>Servers can use the NEWFILEUID to manage the session keys associated with Type 1 application-level
    ///     security. For more information about security, refer to Chapter 4, "Security." of documentation for the
    ///     version 1.0.2.</description>
    ///   </item>
    /// </list>
    /// </para>
    /// <para>OLDFILEUID is used together with NEWFILEUID only when the client and server support file-based 
    /// error recovery. OLDFILEUID identifies the last request and response that was received and processed by
    /// the client.</para>
    /// <para>For more information about data synchronization, refer to Chapter 6.10, "Synchronization Alternatives.", of  
    /// documentation for the version 1.0.2.</para>
    /// </remarks>
    [OFXTag(OFXSpecification.Version102, OFX_NEWFILEUID_TAG, true)]
    public string NEWFILEUID { get; set; } = OFX_NEWFILEUID_TAG_VALUE;
    #endregion
}

using OFX.SDK.Reflection;

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
/// Represents the Signon Request message aggregate. 
/// Unlike other requests, the signon request <c>&lt;SONRQ&gt;</c> does not appear within a transaction wrapper.
/// </summary>
[OFXVersion(OFXSpecification.Version102)]
[OFXTag(OFXSpecification.Version102, "SONRQ")]
public sealed record class SignonRequestMessage : IMessageRequest {
    #region Properties
    /// <summary>
    /// Gets or sets the &lt;DTCLIENT&gt; tag value, representing the date and time of the request from the client computer
    /// </summary>
    [OFXTag(OFXSpecification.Version102, "DTCLIENT")]
    public DateTime DateTimeClient { get; set; }

    /// <summary>
    /// Gets or sets the &lt;USERID&gt; tag value, representing the user identification string. Limited to 32 characters.
    /// </summary>
    /// <remarks>User identification. Either <c>&lt;USERID&gt;</c> and <c>&lt;USERPASS&gt;</c> or 
    /// <c>&lt;USERKEY&gt;</c>, but not both.</remarks>
    [OFXTag(OFXSpecification.Version102, "USERID")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the &lt;USERPASS&gt; tag value, representing the user password on server. Limited to 32 or 171 characters, 
    /// depending on the &lt;SECURITY&gt; defined on header. 
    /// </summary>
    /// <remarks>
    /// User identification. Either <c>&lt;USERID&gt;</c> and <c>&lt;USERPASS&gt;</c> or  <c>&lt;USERKEY&gt;</c>, but not both.
    /// <para>When &lt;SECURITY&gt; is NONE, then the limit is 32 characters. When &lt;SECURITY&gt; is TYPE1, 
    /// then the limit is 171 characters.</para>
    /// </remarks>
    [OFXTag(OFXSpecification.Version102, "USERPASS")]
    public string UserPassword { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the &lt;USERKEY&gt; tag value, representing the log in using previously authenticated context. Limited to 64 characters.
    /// </summary>
    [OFXTag(OFXSpecification.Version102, "USERKEY")]
    public string UserKey { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the &lt;GENUSERKEY&gt; tag value, representing the request server to return a <c>USERKEY</c> for future use.
    /// </summary>
    [OFXTag(OFXSpecification.Version102, "GENUSERKEY")]
    public bool GenerateUserKey { get; set; } = false;

    /// <summary>
    /// Gets or sets the &lt;LANGUAGE&gt; tag value, representing the requested language for text responses.
    /// </summary>
    [OFXTag(OFXSpecification.Version102, "LANGUAGE")]
    public string Language { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the &lt;FI&gt; tag value, representing the financial institution aggregate.
    /// </summary>
    /// <remarks>The client will determine out-of-band whether a FI aggregate should be used and if so, the appropriate values for it.
    /// If the FI aggregate is to be used, then the client should send it in every request, and the server should return 
    /// it in every response.</remarks>
    [OFXTag(OFXSpecification.Version102, "FI")]
    public object? FinancialInstitution { get; set; } = null; //  TODO: Implement FI class

    /// <summary>
    /// Gets or sets the &lt;SESSCOOKIE&gt; tag value, representing the session cookie that the client should return on the next &lt;SONRQ&gt;.
    /// Limited to 1000 characters.
    /// </summary>
    [OFXTag(OFXSpecification.Version102, "SESSCOOKIE")]
    public string SessionCookie { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the &lt;APPID&gt; tag value, representing the ID of client application. Limited to 5 characters.
    /// </summary>
    [OFXTag(OFXSpecification.Version102, "APPID")]
    public string ApplicationId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets &lt;APPVER&gt; tag value, representing the version of client application, (6.00 encoded as 0600). Limited to 4 characters.
    /// </summary>
    [OFXTag(OFXSpecification.Version102, "APPVER")]
    public string ApplicationVersion { get; set; } = string.Empty;
    #endregion
}

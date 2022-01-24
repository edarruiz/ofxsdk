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
/// Represents the Signon message set.
/// </summary>
/// <remarks>
/// <para>The Signon message set includes the signon message, USERPASS change message, and challenge 
/// message, which must appear in that order. The <c>&lt;SIGNONMSGSRQV1&gt;</c> and <c>&lt;SIGNONMSGSRSV1&gt;</c> 
/// aggregates wrap the message.</para>
/// <para>The signon record identifies and authenticates a user to an FI. It also includes information about the 
/// application making the request, because some services might be appropriate only for certain clients. Every 
/// Open Financial Exchange request contains exactly one <c>&lt;SONRQ&gt;</c>. Every response must contain exactly 
/// one <c>&lt;SONRS&gt;</c> record. Use of Open Financial Exchange presumes that FIs authenticate each customer and 
/// then give the customer access to one or more accounts or services. If passwords are specific to individual 
/// services or accounts, a separate Open Financial Exchange request must be made for each user ID or 
/// password required. This will not necessarily be in a manner visible to the user. Note that some situations, 
/// such as joint accounts or business accounts, will have multiple user IDs and multiple passwords that can 
/// access the same account.</para>
/// <para>FIs assign user IDs for the customer. Although the user ID may be the customer’s social security number, 
/// the client must not make any assumptions about the syntax of the ID, add check-digits, or do similar 
/// processing. Servers must accept user IDs, with or without punctuation.</para>
/// <para>To improve server efficiency in handling a series of Open Financial Exchange request files sent over a 
/// short period of time, clients can request that a server return a <c>&lt;USERKEY&gt;</c> in the signon response. 
/// If the server provides a user key, clients will send the &lt;USERKEY&gt; instead of the user ID and password in 
/// subsequent sessions, until the &lt;USERKEY&gt; expires. This allows servers to authenticate subsequent requests more quickly.</para>
/// <para>The client returns <c>&lt;SESSCOOKIE&gt;</c> if the server sent one in a previous &lt;SONRS&gt;. Servers can use the 
/// value of &lt;SESSCOOKIE&gt; to track client usage but cannot assume that all requests come from a single 
/// client, nor can they deny service if they did not expect the returned cookie. Use of a backup file, for 
/// example, would lead to an unexpected &lt;SESSCOOKIE&gt; value that nevertheless should not stop a user from connecting.</para>
/// <para>Servers can request that a consumer change his or her password by returning status code 15000. Servers 
/// should keep in mind that only one status code can be returned. If the current signon response status should 
/// be 15500 (invalid ID or password), the request to change the password must wait until an otherwise successful signon is achieved.</para>
/// <para>If the server returns any signon error, it must respond to all other requests in the same &lt;OFX&gt; block with 
/// status code 15500. For example, if the server returns status code 15502 to the signon request, it must return 
/// status code 15500 to all other requests in the same &lt;OFX&gt; block. The server must return status code 15500 
/// to all requests; it cannot simply ignore the requests.</para>
/// </remarks>
[OFXVersion(OFXSpecification.Version102)]
public sealed record class SignonMessageSet : IMessageSet {
    #region Ctor

    #endregion

    #region Overrides
    /// <summary>
    /// Gets the Signon Request message aggregate.
    /// </summary>
    [OFXTag(OFXSpecification.Version102, "SIGNONMSGSRQV1")]
    public IMessageRequest Request => new SignonRequestMessage();

    /// <summary>
    /// Gets the Signon Response message aggregate.
    /// </summary>
    [OFXTag(OFXSpecification.Version102, "SIGNONMSGSRSV1")]
    public IMessageResponse Response => new SignonResponseMessage();
    #endregion
}

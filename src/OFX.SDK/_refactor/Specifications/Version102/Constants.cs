namespace OFX.SDK._refactor.Specifications.Version102;

#region BSD-3 Copyright Information
/*
  Copyright (c) 2022-2024, Eric Roberto Darruiz
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
/// Represents the specification version 1.0.2 constants.
/// </summary>
public static class Constants {
    #region OFX Header
    /// <summary>
    /// The OFX header <c>HEADER</c> tag.
    /// </summary>
    public const string OFX_HEADER_TAG = "OFXHEADER:";

    /// <summary>
    /// The OFX header <c>HEADER</c> tag value.
    /// </summary>
    public const string OFX_HEADER_TAG_VALUE = "100";

    /// <summary>
    /// The OFX header <c>DATA</c> tag.
    /// </summary>
    public const string OFX_DATA_TAG = "DATA:";

    /// <summary>
    /// The OFX header <c>DATA</c> tag value.
    /// </summary>
    public const string OFX_DATA_TAG_VALUE = "OFXSGML";

    /// <summary>
    /// The OFX header <c>VERSION</c> tag.
    /// </summary>
    public const string OFX_VERSION_TAG = "VERSION:";

    /// <summary>
    /// The OFX header <c>VERSION</c> tag value.
    /// </summary>
    public const string OFX_VERSION_TAG_VALUE = "102";

    /// <summary>
    /// The OFX header <c>SECURITY</c> tag.
    /// </summary>
    public const string OFX_SECURITY_TAG = "SECURITY:";

    /// <summary>
    /// The value to do not use any application-level security.
    /// </summary>
    public const string OFX_SECURITY_NONE = "NONE";

    /// <summary>
    /// The value to use Type 1 application-level security.
    /// </summary>
    public const string OFX_SECURITY_TYPE1 = "TYPE1";

    /// <summary>
    /// The OFX header <c>ENCODING</c> tag.
    /// </summary>
    public const string OFX_ENCODING_TAG = "ENCODING:";

    /// <summary>
    /// The value for Unicode text enconding.
    /// </summary>
    public const string OFX_ENCODING_UNICODE = "UNICODE";

    /// <summary>
    /// The value for US ASCII text encoding.
    /// </summary>
    public const string OFX_ENCODING_USASCII = "USASCII";

    /// <summary>
    /// The OFX header <c>CHARSET</c> tag.
    /// </summary>
    public const string OFX_CHARSET_TAG = "CHARSET:";

    /// <summary>
    /// The OFX header <c>CHARSET</c> tag value.
    /// </summary>
    public const string OFX_CHARSET_TAG_VALUE = "1252";

    /// <summary>
    /// The OFX header <c>COMPRESSION</c> tag.
    /// </summary>
    public const string OFX_COMPRESSION_TAG = "COMPRESSION:";

    /// <summary>
    /// The OFX header <c>OLDFILEUID</c> tag.
    /// </summary>
    public const string OFX_OLDFILEUID_TAG = "OLDFILEUID:";

    /// <summary>
    /// The OFX header <c>OLDFILEUID</c> tag value.
    /// </summary>
    public const string OFX_OLDFILEUID_TAG_VALUE = "NONE";

    /// <summary>
    /// The OFX header <c>NEWFILEUID</c> tag.
    /// </summary>
    public const string OFX_NEWFILEUID_TAG = "NEWFILEUID:";

    /// <summary>
    /// The OFX header <c>NEWFILEUID</c> tag value.
    /// </summary>
    public const string OFX_NEWFILEUID_TAG_VALUE = "NONE";
    #endregion

    #region Message Sets
    #region Signon Message Set
    /// <summary>
    /// The Signon request message aggregate.
    /// </summary>
    public const string SIGNON_MSG_SET_REQUEST_V1 = "SIGNONMSGSRQV1";

    /// <summary>
    /// The Signon response message aggregate .
    /// </summary>
    public const string SIGNON_MSG_SET_RESPONSE_V1 = "SIGNONMSGSRSV1";
    #endregion

    #region Signup Message Set
    #endregion

    #region Banking Message Set
    #endregion

    #region Credit Card Statements Message Set
    #endregion

    #region Investment Statements Message Set
    #endregion

    #region Interbank Funds Transfers Message Set
    #endregion

    #region Wire Funds Transfers Message Set
    #endregion

    #region Payments Message Set
    #endregion

    #region General E-mail Message Set
    #endregion

    #region Investment Security List Message Set
    #endregion

    #region Financial Institution Profile Message Set
    #endregion
    #endregion

    #region Request Message Aggregates
    #region Signon Request Message Aggregate
    #endregion

    #region Signup Request Message Aggregate
    #endregion

    #region Banking Request Message Aggregate
    #endregion

    #region Credit Card Statements Request Message Aggregate
    #endregion

    #region Investment Statements Request Message Aggregate
    #endregion

    #region Interbank Funds Transfers Request Message Aggregate
    #endregion

    #region Wire Funds Transfers Request Message Aggregate
    #endregion

    #region Payments Request Message Aggregate
    #endregion

    #region General E-mail Request Message Aggregate
    #endregion

    #region Investment Security List Request Message Aggregate
    #endregion

    #region Financial Institution Profile Request Message Aggregate
    #endregion
    #endregion

    #region Response Message Aggregates
    #region Signon Response Message Aggregate
    #endregion

    #region Signup Response Message Aggregate
    #endregion

    #region Banking Response Message Aggregate
    #endregion

    #region Credit Card Statements Response Message Aggregate
    #endregion

    #region Investment Statements Response Message Aggregate
    #endregion

    #region Interbank Funds Transfers Response Message Aggregate
    #endregion

    #region Wire Funds Transfers Response Message Aggregate
    #endregion

    #region Payments Response Message Aggregate
    #endregion

    #region General E-mail Response Message Aggregate
    #endregion

    #region Investment Security List Response Message Aggregate
    #endregion

    #region Financial Institution Profile Response Message Aggregate
    #endregion
    #endregion
}

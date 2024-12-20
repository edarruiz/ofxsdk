﻿namespace OFX.SDK.Specifications;

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
/// Represents an OFX specification version.
/// </summary>
public enum OFXSpecification {
    /// <summary>
    /// Unknown specification version.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Specification version 1.0.2, the initial version.
    /// </summary>
    /// <remarks>Version 1.0.2 (1997)</remarks>
    [OFXValue("1.0.2")]
    Version102 = 1,

    /// <summary>
    /// Specification version 1.0.3, including MFA (multi-factor authentication)
    /// </summary>
    /// <remarks>Version 1.0.3 (2005) + MFA</remarks>
    [OFXValue("1.0.3")]
    Version103 = 2,

    /// <summary>
    /// Specification version 1.6, last version using SGML format.
    /// </summary>
    /// <remarks>Version 1.6 (1999)</remarks>
    [OFXValue("1.6")]
    Version160 = 3,

    /// <summary>
    /// Specification version 2.0.3, first version using XML.
    /// </summary>
    /// <remarks>Version 2.0.3 (2006) = 2.0.2 + MFA</remarks>
    [OFXValue("2.0.3")]
    Version203 = 4,

    /// <summary>
    /// Specification version 2.1.1, equivalent to 2.1 including MFA (multi-factor authentication)
    /// </summary>
    /// <remarks>Version 2.1.1 (2006) = 2.1 + MFA</remarks>
    [OFXValue("2.1.1")]
    Version211 = 5,

    /// <summary>
    /// Specification version 2.2, including OAuth.
    /// </summary>
    /// <remarks>Version 2.2 (2017) + OAuth</remarks>
    [OFXValue("2.2")]
    Version220 = 6,

    /// <summary>
    /// Specification version 2.2.1, including Tax information 2.0
    /// </summary>
    /// <remarks>Version 2.2.1 (2019) + Tax 2.0</remarks>
    [OFXValue("2.2.1")]
    Version221 = 7,

    /// <summary>
    /// Specification version 2.3
    /// </summary>
    /// <remarks>Version 2.3 (2020)</remarks>
    [OFXValue("2.3")]
    Version230 = 8
}

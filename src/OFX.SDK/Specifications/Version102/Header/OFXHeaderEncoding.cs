namespace OFX.SDK.Specifications.Version102;

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
/// Represents the text encoding used for character data.
/// </summary>
/// <remarks>For more information about <c>ENCODING</c> and <c>CHARSET</c>, refer to Chapter 5, 
/// "International Support." of documentation for the version 1.0.2.</remarks>
[OFXVersion(OFXSpecification.Version102)]
public enum OFXHeaderEncoding {
    /// <summary>
    /// Unicode text enconding.
    /// </summary>
    [OFXValue(Constants.OFX_ENCODING_UNICODE)]
    UNICODE = 0,

    /// <summary>
    /// US ASCII text encoding.
    /// </summary>    
    [OFXValue(Constants.OFX_ENCODING_USASCII)]
    USASCII = 1
}
﻿using System.Reflection;

namespace OFX.SDK.Reflection;

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
/// Represents the reflection attributes reader for any kinds of objects.
/// </summary>
public static class ReflectionAttributeReader {
    #region Enum OFXValueAttribute Reader
    /// <summary>
    /// Gets the <see cref="OFXValueAttribute"/> value from any <see cref="Enum"/> field annotation.
    /// </summary>
    /// <typeparam name="TEnum"><see cref="Enum"/> reference.</typeparam>
    /// <param name="source"><see cref="Enum"/> reference.</param>
    /// <returns>Returns the value assigned to <see cref="OFXValueAttribute"/> annotation.</returns>
    public static string? GetOFXValueAttribute<TEnum>(this TEnum source) where TEnum : struct {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var type = source.GetType();
#pragma warning disable CS8604 // Possible null reference argument.
        FieldInfo? fi = type.GetField(source.ToString());
#pragma warning restore CS8604 // Possible null reference argument.
        if (fi is null) {
            return null;
        }
        var attribute = fi.GetCustomAttribute<OFXValueAttribute>(false);

        return (attribute is null) ? null : attribute.Value as string;
    }
    #endregion
}
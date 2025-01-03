namespace EDarruiz.OFX.SDK;

#region MIT License Information
/*
 *
 * MIT License
 *
 * Copyright (c) 2020-2025 Eric Roberto Darruiz
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 */
#endregion

/// <summary>
/// Represents the implementation interface for an OFX inquiry message.
/// <para>The inquiry OFX message has a name structure of &lt;xxxINQRQ&gt;/&lt;xxxINQRS&gt;. It is used to search for 
/// and/or gain information about about an existing instance of object xxx and it is encapsulated in a transaction wrapper.</para>
/// <para>Inquiry messages limit the response set to records matching the selection criteria used in the request.
/// Selection criterion elements in the request are generally repeating elements. Where more than one value is
/// given for a particular element, the query ORs those values. Where multiple different elements (matches for
/// different fields of the objects) are provided, the query ANDs those values. Where an element is absent
/// from the request, the query is not filtering on that element. If an element has a history associated with it,
/// only the most recent value is intended by the inquiry.</para>
/// </summary>
/// <remarks>A message is the unit of work in Open Financial Exchange. It refers to a request and response pair, and the
/// status codes associated with that response.</remarks>
public interface IInquiryMessage : IMessage {
}

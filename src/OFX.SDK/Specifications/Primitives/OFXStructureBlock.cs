namespace OFX.SDK;

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
/// Represents an OFX structure block.
/// </summary>
/// <remarks>
/// The Open Financial Exchange hierarchically organizes request and response by blocks:
/// <code>
/// Top Level &lt;OFX&gt;
///     Message Set and Version &lt;xxxMSGSVn&gt;
///         Synchronization Wrappers &lt;xxxSYNCRQ&gt;, &lt;xxxSYNCRS&gt;
///             Transaction Wrappers &lt;xxxTRNRQ&gt;, &lt;xxxTRNRS&gt;
///                 Specific requests and responses
/// </code>
/// <para>Each value of this <see langword="enum"/> represents a block in this structure</para>
/// </remarks>
internal enum OFXStructureBlock {
    /// <summary>
    /// Undefined or unknown block.
    /// </summary>
    Undefined = 0,

    /// <summary>
    /// The header block, containing metadata about the OFX file, such as version information, encoding and more.
    /// </summary>
    Header,

    /// <summary>
    /// Top level block, represented by the &lt;OFX&gt; tag.
    /// </summary>
    /// <remarks>A single file MUST contain only one OFX block.</remarks>
    TopLevel,

    /// <summary>
    /// The basic OFX message has a name structure of &lt;xxxRQ&gt; and &lt;xxxRS&gt;. It is used for read actions of a
    /// specific object and it is encapsulated in a transaction wrapper &lt;xxxTRNRQ&gt; or &lt;xxxTRNRS&gt;
    /// </summary>
    /// <remarks>A message is the unit of work in Open Financial Exchange. It refers to a request and response pair, and the
    /// status codes associated with that response.</remarks>
    BasicMessageSet,

    /// <summary>
    /// The add OFX message, like the Basic message, has a name structure of &lt;xxxRQ&gt; and &lt;xxxRS&gt;. 
    /// It is used to create a new instance of object of type xxx and it is encapsulated in a transaction wrapper.
    /// </summary>
    /// <remarks>A message is the unit of work in Open Financial Exchange. It refers to a request and response pair, and the
    /// status codes associated with that response.</remarks>
    AddMessageSet,

    /// <summary>
    /// The modify OFX message has a name structure of &lt;xxxMODRQ&gt; and &lt;xxxMODRS&gt;. It is used to modify an
    /// existing instance of object xxx and it is encapsulated in a transaction wrapper.
    /// </summary>
    /// <remarks>A message is the unit of work in Open Financial Exchange. It refers to a request and response pair, and the
    /// status codes associated with that response.
    /// <para>The &lt;xxxMODRQ&gt; request contains the complete replacement data for an existing object xxx. Therefore,
    /// both changed and unchanged elements must be included in the request.</para>
    /// </remarks>
    ModifyMessageSet,

    /// <summary>
    /// The delete OFX message has a name structure of &lt;xxxDELRQ&gt; and &lt;xxxDELRS&gt;. It is used to delete an
    /// existing instance of object xxx and it is encapsulated in a transaction wrapper.
    /// </summary>
    /// <remarks>A message is the unit of work in Open Financial Exchange. It refers to a request and response pair, and the
    /// status codes associated with that response.</remarks>
    DeleteMessageSet,

    /// <summary>
    /// The cancel OFX message has a name structure of &lt;xxxCANRQ&gt; and &lt;xxxCANRS&gt;. It is used to cancel an
    /// existing scheduled object xxx and it is encapsulated in a transaction wrapper.
    /// </summary>
    /// <remarks>A message is the unit of work in Open Financial Exchange. It refers to a request and response pair, and the
    /// status codes associated with that response.</remarks>
    CancelMessageSet,

    /// <summary>
    /// The inquiry OFX message has a name structure of &lt;xxxINQRQ&gt; and &lt;xxxINQRS&gt;. It is used to search for 
    /// and/or gain information about about an existing instance of object xxx and it is encapsulated in a transaction wrapper.
    /// </summary>
    /// <remarks>A message is the unit of work in Open Financial Exchange. It refers to a request and response pair, and the
    /// status codes associated with that response.
    /// <para>Inquiry messages limit the response set to records matching the selection criteria used in the request.
    /// Selection criterion elements in the request are generally repeating elements. Where more than one value is
    /// given for a particular element, the query ORs those values. Where multiple different elements (matches for
    /// different fields of the objects) are provided, the query ANDs those values. Where an element is absent
    /// from the request, the query is not filtering on that element. If an element has a history associated with it,
    /// only the most recent value is intended by the inquiry.</para>
    /// </remarks>
    InquiryMessageSet,
}

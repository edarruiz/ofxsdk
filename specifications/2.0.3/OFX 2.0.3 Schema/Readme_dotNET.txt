How to use the .NET tool wsdl.exe with the OFX schema
======================================================

To generate code that is more usable the file OFXWS.wsdl must be replace by the file 
OFXWS_dotNET.wsdl.  This file in turn includes OFXWS_Protocol_dotNET.xsd.  The file
OFXWS_Protocol_dotNET.xsd has a slightly different structure that the standard file 
OFXWS_Protocol.xsd in that the sequence of OFX message sets has been replaced by a choice
element.  This makes the generated C# code much simpler.

To generate C# code that can process OFX, place these two files in the same directory as the
rest of the OFX schema files and use the tool wsdl.exe.


Note on compliance
===================

The change described above makes the generated code easier to use but is not compliant to the
letter of the standard.  Therefore, the file OFXWS_dotNET.wsdl should not be used for validation
purposes.  Also, users should be sure in their code to only allow one one of each message set
type to be placed on the wire and should assure that the order specified in the OFX standard
be maintained.
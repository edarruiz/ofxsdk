using OFXConverter;

if (args.Length == 0) {
    Console.WriteLine("Please provide the path to the OFX file to convert to XML format.");
    return;
}

var ofxFilePath = args[0];
if (!File.Exists(ofxFilePath)) {
    Console.WriteLine($"The file '{ofxFilePath}' does not exist.");
    return;
}

if (!Path.GetExtension(ofxFilePath).Equals(".ofx", StringComparison.CurrentCultureIgnoreCase)) {
    Console.WriteLine("The provided file is not an OFX file.");
    return;
}

try {
    OFXFileReader reader = new(ofxFilePath);
    reader.ReadFile();
    Console.WriteLine(reader.ToXml());
    reader.ToXmlFile(Path.ChangeExtension(ofxFilePath, ".xml"));
    reader.ToJsonFile(Path.ChangeExtension(ofxFilePath, ".json"));
    Console.WriteLine("--------------------");
    Console.WriteLine(reader.ToJson());

} catch (Exception ex) {
    Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
}

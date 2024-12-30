namespace OFX.SDK.Tests.Primitives.Header;

[ExcludeFromCodeCoverage]
public class ConstantsHeaderTagValuesTests : IDisposable {
    #region Ctor and Dtor
    public ConstantsHeaderTagValuesTests() { }

    public void Dispose() => GC.SuppressFinalize(this);
    #endregion

    #region Tests
    [Fact(DisplayName = "DATA_OFXSGML tag value should be 'OFXSGML'")]
    [Trait("Header", "Tag Values")]
    internal void DATA_OFXSGML_tag_value_should_be_OFXSGML() {
        // Arrange
        var expected = "OFXSGML";
        var actual = Constants.Header.TagValues.DATA_OFXSGML;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "VERSION_102 tag value should be '102'")]
    [Trait("Header", "Tag Values")]
    internal void VERSION_102_tag_value_should_be_102() {
        // Arrange
        var expected = "102";
        var actual = Constants.Header.TagValues.VERSION_102;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "VERSION_103 tag value should be '103'")]
    [Trait("Header", "Tag Values")]
    internal void VERSION_103_tag_value_should_be_103() {
        // Arrange
        var expected = "103";
        var actual = Constants.Header.TagValues.VERSION_103;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "VERSION_151 tag value should be '151'")]
    [Trait("Header", "Tag Values")]
    internal void VERSION_151_tag_value_should_be_151() {
        // Arrange
        var expected = "151";
        var actual = Constants.Header.TagValues.VERSION_151;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "VERSION_160 tag value should be '160'")]
    [Trait("Header", "Tag Values")]
    internal void VERSION_160_tag_value_should_be_160() {
        // Arrange
        var expected = "160";
        var actual = Constants.Header.TagValues.VERSION_160;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "OLDFILEUID_NONE tag value should be 'NONE'")]
    [Trait("Header", "Tag Values")]
    internal void OLDFILEUID_NONE_tag_value_should_be_NONE() {
        // Arrange
        var expected = "NONE";
        var actual = Constants.Header.TagValues.OLDFILEUID_NONE;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "NEWFILEUID_NONE tag value should be 'NONE'")]
    [Trait("Header", "Tag Values")]
    internal void NEWFILEUID_NONE_tag_value_should_be_NONE() {
        // Arrange
        var expected = "NONE";
        var actual = Constants.Header.TagValues.NEWFILEUID_NONE;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }
    #endregion
}

using FluentAssertions;
using Notion.Client;

namespace Notion.UnitTests;

public static class HelperAsserts
{
    public static void IPageIconAsserts(IPageIcon icon)
    {
        icon.Should().NotBeNull();

        switch (icon)
        {
            case EmojiObject emoji:
                emoji.Emoji.Should().NotBeNull();

                break;
            case FileObject fileObject:
                FileObjectAsserts(fileObject);

                break;
        }
    }

    public static void FileObjectAsserts(FileObject fileObject)
    {
        fileObject.Should().NotBeNull();

        switch (fileObject)
        {
            case UploadedFile uploadedFile:
                uploadedFile.File.Should().NotBeNull();
                uploadedFile.File.Url.Should().NotBeNull();
                uploadedFile.File.ExpiryTime.Should().NotBeSameDateAs(default);

                break;
            case ExternalFile externalFile:
                externalFile.External.Should().NotBeNull();
                externalFile.External.Url.Should().NotBeNull();

                break;
        }
    }
}

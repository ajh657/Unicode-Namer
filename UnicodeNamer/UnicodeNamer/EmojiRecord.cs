namespace UnicodeNamer;

public record EmojiRecord
{
    public required string Emoji { get; init; }
    public required string Name { get; init; }
    public required string Shortname { get; init; }
    public required string Unicode { get; init; }
    public required string Html { get; init; }
    public required string Category { get; init; }
    public required string Order { get; init; }
}

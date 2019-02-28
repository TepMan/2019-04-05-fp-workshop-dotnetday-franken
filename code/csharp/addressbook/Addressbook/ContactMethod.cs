namespace Addressbook
{
    // C# does not have discriminated union :-(
    // 
    // Possible workarounds:
    //
    // - see https://www.reddit.com/r/csharp/comments/7ru4hj/discriminated_unions/
    // - OneOf NuGet package: https://github.com/mcintyre321/OneOf 
    // - DiscU NuGet package: https://github.com/DiscU/DiscU (fork of OneOf)
    // - type casting etc.
    //
    public interface ContactMethod
    {
    }

    public class EmailContact : ContactMethod
    {
    }
}
namespace dig.server;

public class RenderFactory
{
    public static string? Render(string storeId, object fileContents, string fileExtension, HttpRequest request)
    {
        var renderer = GetRendererForFileExtension(fileExtension);
        return renderer?.Render(storeId, fileContents, request);
    }

    private static IRenderer? GetRendererForFileExtension(string fileExtension)
    {
        // Example for selecting different renderers based on MIME type
        return fileExtension switch
        {
            ".offer" => new OfferRenderer(),
            // Add cases for other MIME types and their corresponding renderers
            _ => null,// or throw an exception, based on how you want to handle unsupported MIME types
        };
    }
}

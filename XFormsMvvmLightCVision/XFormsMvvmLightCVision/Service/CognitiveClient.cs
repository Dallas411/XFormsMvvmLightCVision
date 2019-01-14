using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace XFormsMvvmLightCVision.Service
{
    public class CognitiveClient : ICognitiveClient
    {
        public async Task<ImageAnalysis> GetImageDescription(Stream stream)
        {
            ComputerVisionClient visionClient = new ComputerVisionClient(new ApiKeyServiceClientCredentials("YourApiKey"))
            {
                Endpoint = "https://westcentralus.api.cognitive.microsoft.com/"
            };
            var features = new List<VisualFeatureTypes>() { VisualFeatureTypes.Tags, VisualFeatureTypes.Categories, VisualFeatureTypes.Description };
            return await visionClient.AnalyzeImageInStreamAsync(stream, features, null);

        }
    }
}

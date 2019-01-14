using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.IO;
using System.Threading.Tasks;

namespace XFormsMvvmLightCVision.Service
{
    public interface ICognitiveClient
    {
        Task<ImageAnalysis> GetImageDescription(Stream stream);
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Tesseract;

namespace PrimitiveOcr
{
    public class OcrProvider
    {
        private readonly string _tessDataPath;
        public OcrProvider(string tessDataPath)
        {
            _tessDataPath = tessDataPath;
        }

        public string GetText(string imagePath)
        {
            using (var engine = new TesseractEngine(_tessDataPath, "eng", EngineMode.Default))
            using (var img = Pix.LoadFromFile(imagePath))
            using (var page = engine.Process(img))
            {
                var text = page.GetText();
                var confidence = page.GetMeanConfidence();

                var result = $"Confidence: {confidence} {Environment.NewLine} {text}";
                return result;
            }
        }
    }
}
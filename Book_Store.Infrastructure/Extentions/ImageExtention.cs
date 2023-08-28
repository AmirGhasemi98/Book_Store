using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Infrastructure.Extentions
{
    public static class ImageExtention
    {
        public static string ToBase64(this byte[] imageBytes, int? thumbSize = null)
        {
            if (imageBytes is null || imageBytes.Length == 0)
                return "";

            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);

                if (image.Width == 0)
                    return "";

                ImageFormat format = image.RawFormat;

                Bitmap objbitmap = null;

                objbitmap = new Bitmap(image, new Size(image.Width, image.Height));

                image = (Image)objbitmap;

                using (var stream = new MemoryStream())
                {
                    ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);

                    image.Save(stream, format);
                    imageBytes = stream.ToArray();
                    return "data:" + codec.MimeType + ";base64," + Convert.ToBase64String(imageBytes);
                }
            }
        }

        public static string ContentType(this byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                MediaTypeHeaderValue mediaType = MediaTypeHeaderValue.Parse(MediaTypeNames.Application.Octet);
                try
                {
                    using (var content = new StreamContent(stream))
                    {
                        if (content.Headers.TryGetValues("Content-Type", out var values))
                        {
                            string contentType = values.FirstOrDefault();
                            if (!string.IsNullOrEmpty(contentType))
                            {
                                mediaType = MediaTypeHeaderValue.Parse(contentType);
                            }
                        }
                    }
                }
                catch { /* Parsing error, use default */ }

                return mediaType.MediaType;
            }
        }

        public static string FileName(this byte[] data)
        {
            try
            {
                MediaTypeHeaderValue mediaType = MediaTypeHeaderValue.Parse("application/octet-stream");

                using (var content = new ByteArrayContent(data))
                {
                    if (content.Headers.TryGetValues("Content-Disposition", out var values))
                    {
                        string headerValue = values.FirstOrDefault();
                        if (!string.IsNullOrEmpty(headerValue))
                        {
                            var dispositionHeader = ContentDispositionHeaderValue.Parse(headerValue);
                            if (!string.IsNullOrEmpty(dispositionHeader.FileName))
                            {
                                return dispositionHeader.FileName;
                            }
                        }
                    }
                }
            }
            catch { /* Parsing error or missing headers */ }

            return null;
        }
    }
}

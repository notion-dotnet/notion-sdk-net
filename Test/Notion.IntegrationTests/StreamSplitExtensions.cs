using System;
using System.Collections.Generic;
using System.IO;

namespace Notion.IntegrationTests
{
    public static class StreamSplitExtensions
    {
        public static IEnumerable<Stream> Split(Stream inputStream, int numberOfParts)
        {
            if (numberOfParts <= 0)
            {
                throw new ArgumentException("Number of parts must be greater than zero.", nameof(numberOfParts));
            }

            if (inputStream == null)
            {
                throw new ArgumentNullException(nameof(inputStream));
            }

            MemoryStream buffer = new();
            inputStream.CopyTo(buffer);

            buffer.Position = 0;

            long totalSize = buffer.Length;
            long baseSize = totalSize / numberOfParts;
            long remainder = totalSize % numberOfParts;

            for (int i = 0; i < numberOfParts; i++)
            {
                long currentPartSize = i == numberOfParts - 1 ? baseSize + remainder : baseSize;

                var partStream = new MemoryStream();
                CopyStream(buffer, partStream, currentPartSize);
                partStream.Position = 0;
                yield return partStream;
            }
        }

        private static void CopyStream(Stream buffer, MemoryStream partStream, long bytesToCopy)
        {
            byte[] tempBuffer = new byte[81920]; // 80 KB buffer

            while (bytesToCopy > 0)
            {
                int bytesToRead = (int)Math.Min(tempBuffer.Length, bytesToCopy);
                int bytesRead = buffer.Read(tempBuffer, 0, bytesToRead);
                if (bytesRead == 0)
                {
                    break; // End of stream
                }

                partStream.Write(tempBuffer, 0, bytesRead);
                bytesToCopy -= bytesRead;
            }
        }

        // enumerate with index
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int index = 0;
            foreach (var item in source)
            {
                yield return (item, index++);
            }
        }
    }
}
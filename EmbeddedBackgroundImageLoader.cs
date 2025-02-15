using System;
using System.Drawing;
using System.IO;
using System.Reflection;

public static class EmbeddedBackgroundImageLoader {
	public static Bitmap backgroundImageLoader (string imagePath) {
		var assembly = Assembly.GetExecutingAssembly();

		using (Stream stream = assembly.GetManifestResourceStream(imagePath)) {
			if (stream != null)
                	return new Bitmap(stream);

            		throw new Exception($"Resource '{imagePath}' not found.");

		}
	}
}
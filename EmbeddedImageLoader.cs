using System;
using System.Drawing;
using System.IO;
using System.Reflection;

public static class EmbeddedImageLoader {
	public static Image ImageLoader (string imageResource) {
		var assembly = Assembly.GetExecutingAssembly();

		using (Stream stream = assembly.GetManifestResourceStream(imageResource)) {
			if (stream != null) {
				return Image.FromStream(stream);
			} else {
				throw new Exception($"Resource '{imageResource}' not found!");
			}
		}
	}
}
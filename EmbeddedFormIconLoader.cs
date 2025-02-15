
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

public static class EmbeddedFormIconLoader {
	public static Icon LoadFormIcon (string iconName) {
		var assembly = Assembly.GetExecutingAssembly();

		using (Stream stream = assembly.GetManifestResourceStream(iconName)) {
			if (stream != null) {
				return new Icon(stream);
			}
			throw new Exception($"Resource '{iconName}' not found!");
		}
	}
}
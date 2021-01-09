using System.Collections.Generic;
using System.IO;
using System;
namespace JKExtensions
{
	public static class UltraContent
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00008D1C File Offset: 0x00006F1C
		public static Dictionary<string, T> LoadCunt<T>(Microsoft.Xna.Framework.Content.ContentManager contentManager, string contentFolder, string p_extension = ".*")
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(contentManager.RootDirectory + "/" + contentFolder);
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException();
			}
			Dictionary<string, T> dictionary = new Dictionary<string, T>();
			FileInfo[] files = directoryInfo.GetFiles("*" + p_extension);
			for (int i = 0; i < files.Length; i++)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i].Name);
				dictionary[fileNameWithoutExtension] = contentManager.Load<T>(contentFolder + "/" + fileNameWithoutExtension);
			}
			return dictionary;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000213C File Offset: 0x0000033C
		public static FileInfo[] GetFilesInFolder(Microsoft.Xna.Framework.Content.ContentManager contentManager, string contentFolder)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(contentManager.RootDirectory + "/" + contentFolder);
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException();
			}
			return directoryInfo.GetFiles("*.*");
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00008D9C File Offset: 0x00006F9C
		public static T[] LoadContentArr<T>(Microsoft.Xna.Framework.Content.ContentManager contentManager, string contentFolder)
		{
			Dictionary<string, T> dictionary = LoadCunt<T>(contentManager, contentFolder, ".*");
			T[] array = new T[dictionary.Count];
			int num = 0;
			foreach (string key in dictionary.Keys)
			{
				array[num++] = dictionary[key];
			}
			return array;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00008E18 File Offset: 0x00007018
		public static Dictionary<string, T> LoadXmlFiles<T>(Microsoft.Xna.Framework.Game p_game, string directory, string extension = ".xml")
		{
			directory = p_game.Content.RootDirectory + "/" + directory;
			DirectoryInfo directoryInfo = new DirectoryInfo(directory);
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException();
			}
			Dictionary<string, T> dictionary = new Dictionary<string, T>();
			foreach (FileInfo fileInfo in directoryInfo.GetFiles("*" + extension))
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.Name);
				dictionary[fileNameWithoutExtension] = XmlSerializerHelper.Deserialize<T>(directory + "/" + fileInfo.Name);
			}
			return dictionary;
		}
	}
}
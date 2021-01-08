using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using static JKPlusModManager.ParseData;

namespace JKPlusModManager
{
    public static class XmlSerializerHelper
    {
        public static void Serialize(string path, object p_object)
        {
            using (FileStream fileStream = File.Create(path))
            {
                new XmlSerializer(p_object.GetType()).Serialize(fileStream, p_object);
            }
        }

        public static void SerializeWithPath(string path, object p_object)
        {
            string path2 = path.Substring(0, path.LastIndexOf("/"));
            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }
            XmlSerializerHelper.Serialize(path, p_object);
        }

        public static T Deserialize<T>(string path)
        {
            T result;
            using (FileStream fileStream = File.OpenRead(path))
            {
                result = (T)((object)new XmlSerializer(typeof(T)).Deserialize(fileStream));
            }
            return result;
        }
    }


    public class ParseData
    {
        public struct Mod
        {
            public About About;
            public Fonts Fonts;
            public Ending Ending;
            public Credit[] EndingLines;
        }

        public struct About
        {
            public string title;
            public int ending_screen;
        }

        public struct Fonts
        {
            public string MenuFont;
            public string MenuFontSmall;
            public string StyleFont;
            public string OptimusUnderline;
            public string Tangerine;
            public string LocationFont;
            public string GargoyleFont;
        }

        public struct Ending
        {
            public string MainBabe;
            public string MainShoes;
        }

        public struct Credit
        {
            public string header;
            public string[] People;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }

        public static bool ModsFolder = false;
        public static bool CustomMod = false;
        public static Mod CurrentMod;
        public static Mod NewMod;
    }
}

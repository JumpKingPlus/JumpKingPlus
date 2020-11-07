using JumpKing.XnaWrappers;
using System.Collections.Generic;
using System.Linq;
using JumpKing;
using Microsoft.Xna.Framework.Content;
using System.IO;
using JumpKing.JKMemory.ManagedAssets.ThreadLube;
using JumpKing.JKMemory.ManagedAssets;
using JumpKing.MiscSystems;

namespace JumpKingPlus
{
    public class MusicPlayer
    {
		//music player
		public static Dictionary<string, JKContentManager.Audio.AmbienceSound> MusicAmbience = new Dictionary<string, JKContentManager.Audio.AmbienceSound>();

		//public Dictionary<string, AmbienceManager.AmbienceTrack> jk_ambience_sounds;
		public struct AmbienceSaveValues
		{
			public int RealLength
			{
				get
				{
					if (this._real_length != 0)
					{
						return this._real_length;
					}
					int num = 0;
					foreach (AmbienceManager.AmbienceSave ambienceSave in this.sections)
					{
						num += ambienceSave.screens;
					}
					this._real_length = num;
					return num;
				}
			}

			public AmbienceManager.AmbienceValues ToInstance()
			{
				AmbienceManager.AmbienceValues ambienceValues = new AmbienceManager.AmbienceValues();
				ambienceValues.sections = new AmbienceManager.AmbienceScreen[this.RealLength];
				ambienceValues.special_info = this.special_info;
				int i = 0;
				int num = 0;
				foreach (AmbienceManager.AmbienceSave ambienceSave in this.sections)
				{
					num += ambienceSave.screens;
					while (i < num)
					{
						(ambienceValues.sections[i++] = new AmbienceManager.AmbienceScreen()).ambience = ambienceSave.ambience;
					}
				}
				return ambienceValues;
			}
			public AmbienceManager.AmbienceInfo[] special_info;
			public AmbienceManager.AmbienceSave[] sections;
			private int _real_length;
		}

		public static AmbienceSaveValues ambienceSaveValues;

		public static int CountDictionary()
        {
			return MusicAmbience.Count;
        }

		public static void LoadAmbience(ContentManager p_loader)
		{
			ambienceSaveValues = XmlSerializerHelper.Deserialize<AmbienceSaveValues>(Game1.instance.Content.RootDirectory + "/audio/background/data/music.xml");
			if (ambienceSaveValues.special_info == null)
			{
				ambienceSaveValues.special_info = new AmbienceManager.AmbienceInfo[0];
			}
			string text = "audio/background";
			FileInfo[] filesInFolder = p_loader.GetFilesInFolder(text);
			for (int i = 0; i < filesInFolder.Length; i++)
			{
				string text2 = filesInFolder[i].Name;
				if (text2.Contains('.'))
				{
					text2 = text2.Substring(0, text2.IndexOf('.'));
				}
				SoundType p_type = SoundType.Ambience;
				float p_fade_out_time = 0f;
				float p_fade_in_time = 0f;
				foreach (AmbienceManager.AmbienceInfo ambienceInfo in ambienceSaveValues.special_info)
				{
					if (ambienceInfo.name == text2)
					{
						p_type = ambienceInfo.type;
						p_fade_out_time = ambienceInfo.fade_out_length;
						p_fade_in_time = ambienceInfo.fade_in_length;
					}
				}
				LubedSound lubedSound = Program.contentThread.CreateSound(new ManagedSound(text + "/" + text2, p_type));
				JKContentManager.Audio.AmbienceSound value = new JKContentManager.Audio.AmbienceSound
				{
					lube = lubedSound,
					volume_fade = new FadeAmbience(lubedSound, p_fade_out_time, p_fade_in_time)
				};
				MusicAmbience.Add(text2, value);
			}
		}
    }
}

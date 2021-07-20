using System;
using DiscordRPC;
using JumpKing.GameManager;
using JumpKing.MiscSystems.Achievements;
using JumpKing.Player;
using JumpKing.SaveThread.SaveComponents;
using Microsoft.Xna.Framework;
using JumpKing.MiscSystems.LocationText;
using LanguageJK;
using JumpKing;
using static JumpKingPlus.JKPlusData;

namespace JumpKingPlus
{

	public class DiscordLocations
	{
		public static DiscordLocationSettings _discordLocation = XmlSerializerHelper.Deserialize<DiscordLocationSettings>("Content/settings/discordLocations.xml");

		public struct DiscordLocationSettings
		{
			public Location[] locations;
		}

		public struct Location
		{
			public int start;
			public int end;
			public string name;
			public string imageKey;
			public int id;
		}
	}

	public class JKRichPresence
    {

		/// <summary>
		/// ClearUpdate() is the check for the toggle.
		/// BodyValues is an internal class.
		/// </summary>
        public String[] presets = new String[3] {
            "Babe+Location",
            "Location+Falls",
            "Session+Falls"
        };
        BodyValues body = new BodyValues(GameLoop.m_player);
        public DiscordRpcClient client;
        public bool process = true;
        private DateTime time1 = new DateTime();
        private DateTime time2 = new DateTime();
        private TimeSpan pause = new TimeSpan();
        private DateTime menuElapsed = new DateTime();
		public int preset;
        private string text;
        private string image;
        public string section;
        private string smallimage;
        private string smalltext;
		

		public static class Location
        {
            public static string name;
        }

		public JKRichPresence(int _preset)
        {
            switch (_preset)
            {
                case 1:
                case 2:
                case 3:
                    preset = _preset;
                    break;

                default:
                    preset = 1;
                    break;
            }
        }

		public void ClearUpdate(bool toggle)
		{
			if (toggle) { Run(); }
			else { this.client.ClearPresence(); }
		}

		public void Run()
		{
			if (process)
			{
				if (time1 == DateTime.MinValue)
				{
					time1 = DateTime.Now;
				}
				time2 = DateTime.Now;
				pause = time2.Subtract(time1);

				if (pause.TotalMilliseconds > 400)
				{
					time1 = DateTime.Now;
					BootsRing(FullRunSave.fullRunSave.wear_giant_boots, FullRunSave.fullRunSave.wear_snake_ring);
					Update();
				}
			}
		}

		public void Init()
		{
			client = new DiscordRpcClient("726077029195448430");
			client.RegisterUriScheme();
			this.client.Initialize();
		}

		public void Update()
		{
			if (AchievementManager.instance.m_in_game_loop)
			{
				if (Game1.jkdata.CustomGame)
                {
					PlayerStats currentStats = AchievementManager.instance.GetCurrentStats();
					this.client.SetPresence(new RichPresence
					{
						Details = ParseData._mod.About.title,
						State = Location.name,
						Timestamps = new Timestamps
						{
							Start = DateTime.UtcNow - currentStats.timeSpan
						},
						Assets = new Assets
						{
							LargeImageKey = ParseData.getImageKey(),
							LargeImageText = "",
							SmallImageKey = "jkpluslogo",
							SmallImageText = "JumpKingPlus v" + JKVersion.version.ToString()
						}
					});
				} else
                {
					if (menuElapsed != DateTime.MinValue)
					{
						menuElapsed = DateTime.MinValue;
					}
					body.GetValues(GameLoop.m_player);
					IngameRP(preset);
				}
			}
			else
			{
				if (menuElapsed == DateTime.MinValue)
					menuElapsed = DateTime.UtcNow;
				this.client.SetPresence(new RichPresence
				{
					Details = "Main Menu",
					State = "",
					Timestamps = new Timestamps
					{
						Start = menuElapsed
					},
					Assets = new Assets
					{
						LargeImageKey = "jklogo",
						LargeImageText = "",
						SmallImageKey = "jkplus",
						SmallImageText = "JumpKingPlus v" + JKVersion.version.ToString()
					}
				});
			}
		}

		public void GetLocation(int screen)
		{
			if (screen <= 43) { if (section != language.GAMETITLESCREEN_NEW_GAME) section = language.GAMETITLESCREEN_NEW_GAME; }
			else if (screen >= 44 && screen <= 100) { if (section != language.GAMETITLESCREEN_NEW_BABE_PLUS) section = language.GAMETITLESCREEN_NEW_BABE_PLUS; }
			else if (screen >= 101 && screen <= 163) { if (section != language.GAMETITLESCREEN_GHOST_OF_THE_BABE) section = language.GAMETITLESCREEN_GHOST_OF_THE_BABE; }

			DiscordLocations.Location[] locs = DiscordLocations._discordLocation.locations;
			foreach (DiscordLocations.Location loc in locs)
            {
				if (screen >= (loc.start - 1) && screen <= (loc.end - 1))
                {
					text = loc.name;
					if (language.ResourceManager.GetString(loc.name) != null)
                    {
						text = language.ResourceManager.GetString(loc.name);
                    }
					image = loc.imageKey;
					break;
                }
            }
		}

		public void BootsRing(bool _boots, bool _ring)
		{
			if (_boots == true && _ring == false)
			{
				smallimage = "shoes_iron";
				smalltext = language.ITEMNAMEUTIL_GIANT_BOOTS;
			}
			else if (_ring == true && _boots == false)
			{
				smallimage = "ring";
				smalltext = language.ITEMNAMEUTIL_SNAKERING;
			}
			else if (_boots == true && _ring == true)
			{
				smallimage = "shoes_and_ring";
				smalltext = language.ITEMNAMEUTIL_GIANT_BOOTS + " + " + language.ITEMNAMEUTIL_SNAKERING;
			}
			else if (_boots == false && _ring == false)
			{
				smallimage = "";
				smalltext = "";
			}
		}

		public void IngameRP(int _preset)
		{
			var gameTime = TimeSpan.FromSeconds((int)Math.Round((AchievementManager.instance.m_all_time_stats._ticks - AchievementManager.instance.m_snapshot._ticks) * 0.017f));
			var attempts = AchievementManager.instance.m_all_time_stats.attempts - AchievementManager.instance.m_snapshot.attempts;
			var sessions = (AchievementManager.instance.m_all_time_stats.session - AchievementManager.instance.m_snapshot.session) + 1;
			var falls = AchievementManager.instance.m_all_time_stats.falls - AchievementManager.instance.m_snapshot.falls;

			GetLocation(body.LastScreen);	
			switch (_preset)
			{
				//preset 1
				case 1:
					this.client.SetPresence(new RichPresence
					{
						Details = section,
						State = text,
						Timestamps = new Timestamps
						{
							Start = DateTime.UtcNow - gameTime
						},
						Assets = new Assets
						{
							LargeImageKey = image,
							LargeImageText = text,
							SmallImageKey = smallimage,
							SmallImageText = smalltext
						}
					});
					break;

				//preset 2
				case 2:
				this.client.SetPresence(new RichPresence
					{
						Details = text,
						State = falls + " falls",
						Timestamps = new Timestamps
						{
							Start = DateTime.UtcNow - gameTime
						},
						Assets = new Assets
						{
							LargeImageKey = image,
							LargeImageText = text,
							SmallImageKey = smallimage,
							SmallImageText = smalltext
						}
					});
					break;

				//preset 3
				case 3:
				this.client.SetPresence(new RichPresence
					{
						Details = "Attempt n.°" + sessions,
						State = falls + " falls",
						Timestamps = new Timestamps
						{
							Start = DateTime.UtcNow - gameTime
						},
						Assets = new Assets
						{
							LargeImageKey = image,
							LargeImageText = text,
							SmallImageKey = smallimage,
							SmallImageText = smalltext
						}
					});
					break;
			}
		}

		public void Stop()
		{
			process = false;
			client.Dispose();
		}

		internal class BodyValues
        {
            private Vector2 position;
            public Vector2 Position { get { return position; } set { position = value; } }
            // Token: 0x04000007 RID: 7
            private int time = 0;
            public int Time { get { return time; } set { time = value; } }
            // Token: 0x04000008 RID: 8
            private int lastScreen = 0;
            public int LastScreen { get { return lastScreen; } set { lastScreen = value; } }
            // Token: 0x04000009 RID: 9
            private int timeStamp = 0;
            public int TimeStamp { get { return timeStamp; } set { timeStamp = value; } }
            // Token: 0x0400000A RID: 10
            private bool windEnabled = false;
            public bool WindEnabled { get { return windEnabled; } set { windEnabled = value; } }

            public BodyValues(PlayerEntity player)
            {
                this.GetValues(player);
            }

            // Token: 0x0600000D RID: 13
            public void GetValues(PlayerEntity player)
            {
                if (player != null)
                {
                    BodyComp body = player.m_body;
                    this.WindEnabled = body.m_wind_enabled;
                    this.Position = body.position;
                    this.LastScreen = body.m_last_screen;
                    this.TimeStamp = player.m_time_stamp;
                }
                if (AchievementManager.instance != null)
                {
                    this.Time = AchievementManager.instance.m_all_time_stats._ticks;
                }
            }
        }
    }
}
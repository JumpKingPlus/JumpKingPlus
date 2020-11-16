using System;
using DiscordRPC;
using JumpKing.GameManager;
using JumpKing.MiscSystems.Achievements;
using JumpKing.Player;
using JumpKing.SaveThread.SaveComponents;
using Microsoft.Xna.Framework;
using LanguageJK;

namespace JumpKingPlus
{
		public class JKRichPresence
        {
		/// <summary>
		/// ClearUpdate() is the check for the toggle.
		/// BodyValues is an internal class.
		/// </summary>
			Version jkplusver = new Version("1.1.0");
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
				this.client.Initialize();
			}

			public void Update()
			{
				if (AchievementManager.instance.m_in_game_loop)
				{
					if (menuElapsed != DateTime.MinValue)
						menuElapsed = DateTime.MinValue;
					body.GetValues(GameLoop.m_player);
					IngameRP(preset);
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
							SmallImageText = "JumpKingPlus v" + jkplusver.ToString()
						}
					});
				}
			}

			public void GetLocation(int screen)
			{
				if (screen <= 43) { if (section != language.GAMETITLESCREEN_NEW_GAME) section = language.GAMETITLESCREEN_NEW_GAME; }
				else if (screen >= 44 && screen <= 100) { if (section != language.GAMETITLESCREEN_NEW_BABE_PLUS) section = language.GAMETITLESCREEN_NEW_BABE_PLUS; }
				else if (screen >= 101 && screen <= 163) { if (section != language.GAMETITLESCREEN_GHOST_OF_THE_BABE) section = language.GAMETITLESCREEN_GHOST_OF_THE_BABE; }
				switch (screen)
				{
					// main babe

					case int n when (n >= 0 && n <= 4):
						text = language.LOCATION_REDCROWN_WOODS; image = "redcrown_woods"; break;

					case int n when (n >= 5 && n <= 9):
						text = language.LOCATION_COLOSSAL_DRAIN; image = "colossal_drain"; break;

					case int n when (n >= 10 && n <= 13):
						text = language.LOCATION_FALSE_KINGS_KEEP; image = "falsekeep"; break;

					case int n when (n >= 14 && n <= 18):
						text = language.LOCATION_BARGAINBURG; image = "bargainburg"; break;

					case int n when (n >= 19 && n <= 24):
						text = language.LOCATION_GREAT_FRONTIER; image = "new_frontier"; break;

					case 25:
						text = language.LOCATION_WINDSWEPT_BLUFF; image = "windswept_bluff"; break;

					case int n when (n >= 26 && n <= 31):
						text = language.LOCATION_STORMWALL_PASS; image = "stormwall_pass"; break;

					case int n when (n >= 32 && n <= 35):
						text = language.LOCATION_CHAPEL_PERILOUS; image = "chapel"; break;

					case int n when (n >= 36 && n <= 38):
						text = language.LOCATION_BLUE_RUIN; image = "blue_ruin"; break;

					case int n when (n >= 39 && n <= 41):
						text = language.LOCATION_THE_TOWER; image = "maintower"; break;

					case 42:
						text = language.GAMETITLESCREEN_NEW_GAME+" Screen"; image = "mainbabe"; break;

					case 43:
						text = "Unknown"; image = "mainbabe"; break;

					// new babe+

					case int n when (n >= 44 && n <= 45):
						text = "Room of the Imp"; image = "improom"; break;

					case int n when (n >= 46 && n <= 51):
						text = language.LOCATION_BRIGHTCROWN_WOODS; image = "brightcrown"; break;

					case int n when (n >= 52 && n <= 58):
						text = language.LOCATION_COLOSSAL_DUNGEON; image = "colossal_dungeon"; break;

					case int n when (n >= 59 && n <= 62):
						text = language.LOCATION_FALSE_KINGS_CASTLE; image = "falsecastle"; break;

					case int n when (n >= 63 && n <= 69):
						text = language.LOCATION_UNDERBURG; image = "underburg"; break;

					case int n when (n >= 70 && n <= 76):
						text = language.LOCATION_LOST_FRONTIER; image = "lost_frontier"; break;

					case int n when (n >= 77 && n <= 82):
						text = language.LOCATION_HIDDEN_KINGDOM; image = "hiddenkingdom"; break;

					case int n when (n >= 83 && n <= 88):
						text = language.LOCATION_BLACK_SANCTUM; image = "black_sanctum"; break;

					case int n when (n >= 89 && n <= 93):
						text = language.LOCATION_DEEP_RUIN; image = "deep_ruin"; break;

					case int n when (n >= 94 && n <= 98):
						text = language.LOCATION_THE_DARK_TOWER; image = "dark_tower"; break;

					case 99:
						text = language.GAMETITLESCREEN_NEW_BABE_PLUS+" Screen"; image = "newbabe"; break;

					case 100:
						text = "Unknown"; image = "newbabe"; break;

					// gotb

					case int n when (n >= 101 && n <= 107):
						text = language.LOCATION_BOG; image = "bog"; break;

					case int n when (n >= 108 && n <= 115):
						text = language.LOCATION_MOULDING_MANOR; image = "manor"; break;

					case int n when (n >= 116 && n <= 122):
						text = language.LOCATION_BUGSTALK; image = "bugstalk"; break;

					case int n when (n >= 123 && n <= 129):
						text = language.LOCATION_HOUSE_OF_NINE_LIVES; image = "tower_of_nine_lives"; break;

					case int n when (n >= 130 && n <= 138):
						text = language.LOCATION_THE_PHANTOM_TOWER; image = "phantom_tower"; break;

					case int n when (n >= 139 && n <= 146):
						text = language.LOCATION_HALTED_RUIN; image = "halted_ruin"; break;

					case int n when (n >= 147 && n <= 152):
						text = language.LOCATION_THE_TOWER_OF_ANTUMBRA; image = "antumbra"; break;

					case 153:
						text = language.GAMETITLESCREEN_GHOST_OF_THE_BABE+" Screen"; image = "ghostbabe"; break;

					case 154:
						text = "Unknown"; image = "ghostbabe"; break;

					case int n when (n >= 155 && n <= 159):
						text = language.LOCATION_PHILOSOPHERS_FOREST; image = "philosopher"; break;

					case int n when (n >= 160 && n <= 163):
						text = "Hole"; image = "hole"; break;

					// default

					default:
						text = "Unknown"; image = "jklogo"; break;
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
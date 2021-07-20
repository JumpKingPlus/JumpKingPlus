using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using JumpKing.PlayerPreferences;
using JumpKing;
using JumpKing.XnaWrappers;
using Microsoft.Xna.Framework.Audio;
using JumpKing.Props;
using JumpKing.Props.RattmanText;
using JumpKing.Props.RaymanWall;
using JumpKing.JKMemory;
using JumpKing.Player.Skins;
using Microsoft.Xna.Framework;
using JumpKing.JKMemory.ManagedAssets.ThreadLube;
using JumpKing.JKMemory.ManagedAssets;
using JumpKing.Props.Achievents;
using JumpKing.MiscEntities.OldMan;
using JumpKing.MiscEntities.Merchant;
using JumpKing.MiscEntities;
using System.Linq;
using JumpKing.Particles;

namespace JumpKingPlus
{
    public class ParseData
    {
        public static Mod _mod = XmlSerializerHelper.Deserialize<Mod>("Content/mods/mod.xml");
        public static EarthquakeSettings _eqSettings = XmlSerializerHelper.Deserialize<EarthquakeSettings>("Content/mods/gui/earthquake_settings.xml");

        public static string getImageKey()
        {
            if (_mod.About.image_key != null && _mod.About.image_key != "")
            {
                return _mod.About.image_key;
            }
            return "unknown";
        }

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
            public string image_key;
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

        public struct EarthquakeSettings
        {
            public int[] screens;
        }
    }

    public class CustomLevel
    {
        /// <summary>
        /// CheckReadFile()     checks for files
        /// CustomMode()        sets the base mode
        /// LoadJKAssets()      loads correct assets
        /// EndingFix           fixes babe
        /// Load[...]()         loads [...] for LoadCustomAssets()
        /// </summary>
        /// <returns></returns>
        public static bool CheckReadFile(string dir)
        {
            if (File.Exists(dir+"/mods/mod.xml") && File.Exists(dir+"/mods/level.xnb"))
            {
                return true;
            }
            return false;
        }
        public static void CustomMode(string dir)
        {
            if (CheckReadFile(dir))
            {
                Game1.jkdata.cheats.AchievementAccess = false;
                Game1.jkdata.CustomGame = true;
            }
            else
            {
                Game1.jkdata.CustomGame = false;
            }
        }

        public static void LoadJKAssets(Game game)
        {
            if (Game1.jkdata.CustomGame)
            {
                LoadCustomAssets(game);
            }
            else
            {
                JKContentManager.LoadAssets(game);
            }
        }

        public static void LoadCustomAssets(Game p_game)
        {
            JKContentManager.LevelTexture = p_game.Content.Load<Texture2D>("mods/level");
            
            //default
            JKContentManager.TitleLogo = p_game.Content.Load<Texture2D>("title_logo");
            JKContentManager.NexileLogo = Sprite.CreateSprite(p_game.Content.Load<Texture2D>("JK_Nexile_Logo"));
            JKContentManager.NexileLogo.center = Vector2.One / 2f;
            JKContentManager.SlopeTexture = p_game.Content.Load<Texture2D>("slopes");
            JKContentManager.SlopeSprites.LoadSprites();
            JKContentManager.GUI.Load(p_game.Content);
            JKContentManager.Shaders.Mask = new MaskShader(p_game.Content.Load<Effect>("shaders/Mask"));
            JKContentManager.Shaders.test_mask = p_game.Content.Load<Texture2D>("shaders/test_mask");

            //custom screens
            JKContentManager.m_foregrounds = JKExtensions.UltraContent.LoadCunt<Texture2D>(p_game.Content, "mods/screens/foreground", ".*");
            JKContentManager.m_backgrounds = JKExtensions.UltraContent.LoadCunt<Texture2D>(p_game.Content, "mods/screens/midground", ".*");
            JKContentManager.m_backbackgrounds = JKExtensions.UltraContent.LoadCunt<Texture2D>(p_game.Content, "mods/screens/background", ".*");
            JKContentManager.ScrollingBackgrounds = JKExtensions.UltraContent.LoadCunt<Texture2D>(p_game.Content, "mods/screens/scrolling/textures", ".*");
            JKContentManager.m_weather_masks = JKExtensions.UltraContent.LoadCunt<Texture2D>(p_game.Content, "mods/screens/masks", ".*");
            JKContentManager.m_scrolling_bg_data = UltraContent.LoadXmlFiles<JumpKing.Level.Data.ScrollingBGdata>(p_game, "mods/screens/scrolling", ".xml");

            //modded
            NPCs.Load(p_game.Content);
            Raven.Load(p_game.Content);
            Particles.Load(p_game.Content);
            Music.Load(p_game.Content);
            Props.Load(p_game.Content);
            Fonts.Load(p_game.Content);
            Endings.Load(p_game.Content);
            King.Load(p_game.Content);
            JKContentManager.MiscSettings.CustomLoad(p_game.Content);
        }

        public static class NPCs
        {
            public static void Load(Microsoft.Xna.Framework.Content.ContentManager p_loader)
            {
                string str = "mods/props/textures/old_man/";
                Dictionary<string, OldManSettings> dictionary = UltraContent.LoadXmlFiles<OldManSettings>(Game1.instance, str + "lines/", ".xml");
                JKContentManager.OldMan._settings = new Dictionary<string, JKContentManager.OldMan.OldManData>();
                foreach (string key in dictionary.Keys)
                {
                    NPCs.AddSetting(p_loader, dictionary[key]);
                }
                JKContentManager.OldMan.spawn_names = new string[JKContentManager.OldMan._settings.Count];
                int num = 0;
                foreach (string text in JKContentManager.OldMan._settings.Keys)
                {
                    JKContentManager.OldMan.spawn_names[num++] = text;
                }
                NPCs.LoadMerchants(p_loader);
            }

            // Token: 0x060000D1 RID: 209 RVA: 0x0000AEFC File Offset: 0x000090FC
            private static void LoadMerchants(Microsoft.Xna.Framework.Content.ContentManager p_loader)
            {
                JKContentManager.OldMan.merchantSettings = new Dictionary<string, MerchantSettings>();
                string str = "mods/props/textures/old_man/";
                Dictionary<string, MerchantSettings> dictionary = UltraContent.LoadXmlFiles<MerchantSettings>(Game1.instance, str + "merchant/", ".xml");
                JKContentManager.OldMan.merchant_names = new string[dictionary.Count];
                int num = 0;
                foreach (string key in dictionary.Keys)
                {
                    NPCs.AddSetting(p_loader, dictionary[key].settings);
                    JKContentManager.OldMan.merchant_names[num++] = dictionary[key].settings.name;
                    JKContentManager.OldMan.merchantSettings.Add(dictionary[key].settings.name, dictionary[key]);
                }
            }

            // Token: 0x060000D2 RID: 210 RVA: 0x0000AFDC File Offset: 0x000091DC
            private static void AddSetting(Microsoft.Xna.Framework.Content.ContentManager p_loader, OldManSettings p_setting)
            {
                Sprite[] array = JKContentManager.Util.SpriteChopUtilGrid(p_loader.Load<Texture2D>("mods/props/textures/old_man/" + p_setting.name), p_setting.sprite_cells);
                Sprite[] array2 = new Sprite[p_setting.random_count];
                for (int i = 0; i < array.Length; i++)
                {
                    if (i < array2.Length)
                    {
                        array2[i] = array[i];
                    }
                    array[i].center = new Vector2(0.5f, 1f);
                }
                JKContentManager.OldMan._settings.Add(p_setting.name, new JKContentManager.OldMan.OldManData
                {
                    name = p_setting.name,
                    settings = p_setting,
                    all_sprites = array,
                    random = array2
                });
            }
        }

        public static class Raven
        {
            public static void Load(Microsoft.Xna.Framework.Content.ContentManager p_loader)
            {
                string directory = "mods/props/textures/raven/";
                JKContentManager.RavenSprites.GoldRing = Sprite.CreateSprite(p_loader.Load<Texture2D>("mods/props/textures/raven/gold_ring"));
                JKContentManager.RavenSprites.GoldRing.center = new Vector2(0.5f, 1f);
                JKContentManager.RavenSprites.Ruby = Sprite.CreateSprite(p_loader.Load<Texture2D>("mods/props/textures/raven/ruby"));
                JKContentManager.RavenSprites.Ruby.center = JKContentManager.RavenSprites.GoldRing.center;
                JKContentManager.RavenSprites.raven_settings = UltraContent.LoadXmlFiles<RavenSettings>(Game1.instance, directory, ".ravset");
                List<string> list = JKContentManager.RavenSprites.raven_settings.Keys.ToList<string>();
                for (int i = 0; i < list.Count; i++)
                {
                    string text = list[i];
                    RavenSettings value = JKContentManager.RavenSprites.raven_settings[text];
                    value.name = text;
                    JKContentManager.RavenSprites.raven_settings[text] = value;
                    JKContentManager.RavenSprites.raven_content.Add(text, new JKContentManager.RavenSprites.RavenContent(p_loader.Load<Texture2D>("mods/props/textures/raven/" + JKContentManager.RavenSprites.raven_settings[text].texture)));
                }
                Sprite[] array = JKContentManager.Util.SpriteChopUtilGrid(p_loader.Load<Texture2D>("mods/props/textures/raven/raven"), new Point(3, 2), new Rectangle(0, 64, 144, 64));
                JKContentManager.RavenSprites.FlyEnding = new Sprite[3];
                JKContentManager.RavenSprites.FlyEnding[0] = Sprite.CreateSprite(array[0].texture, array[0].source);
                JKContentManager.RavenSprites.FlyEnding[1] = Sprite.CreateSprite(array[1].texture, array[1].source);
                JKContentManager.RavenSprites.FlyEnding[2] = Sprite.CreateSprite(array[2].texture, array[2].source);
                Sprite[] array2 = JKContentManager.RavenSprites.FlyEnding;
                for (int j = 0; j < array2.Length; j++)
                {
                    array2[j].center = new Vector2(0.5f, 1f);
                }
                JKContentManager.RavenSprites.CarryCrown = JKContentManager.Util.SpriteChopUtilGrid(p_loader.Load<Texture2D>("mods/props/textures/raven/raven_crown"), new Point(3, 1));
                Vector2 center = Sprite.MakePixelCenter(new Vector2(0.5f, 1f), new Point(0, -16), JKContentManager.RavenSprites.CarryCrown[0].source.Size);
                array2 = JKContentManager.RavenSprites.CarryCrown;
                for (int j = 0; j < array2.Length; j++)
                {
                    array2[j].center = center;
                }
                JKContentManager.RavenSprites.OwlFlyingGargoyle = JKContentManager.Util.SpriteChopUtilGrid(p_loader.Load<Texture2D>("mods/ending/flying_gargoyle"), new Point(1, 3), new Vector2(0.5f, 0f));
            }
        }

        public static class Particles
        {
            public static void Load(Microsoft.Xna.Framework.Content.ContentManager p_loader)
            {
                JKContentManager.Particles._jump_particle = p_loader.Load<Texture2D>("particles/jump_particle");
                JKContentManager.Particles.JumpParticleSprites = JKContentManager.Util.SpriteChopUtilGrid(JKContentManager.Particles._jump_particle, new Point(JKContentManager.Particles._jump_particle.Width / JKContentManager.Particles._jump_particle.Height, 1), new Vector2(0.5f, 1f));
                Texture2D texture2D = p_loader.Load<Texture2D>("particles/jump_particle_water");
                JKContentManager.Particles.JumpParticleSpritesWater = JKContentManager.Util.SpriteChopUtilGrid(texture2D, new Point(texture2D.Width / texture2D.Height, 1), new Vector2(0.5f, 1f));
                Texture2D texture2D2 = p_loader.Load<Texture2D>("particles/water_splash");
                JKContentManager.Particles.WaterSplashSprites = JKContentManager.Util.SpriteChopUtilGrid(texture2D2, new Point(texture2D2.Width / texture2D2.Height, 1), new Vector2(0.5f, 0.5f));
                JKContentManager.Particles.SnowSettings = XmlSerializerHelper.Deserialize<SnowParticleEntity.SnowSettings>("Content/mods/particles/snow_settings.xml");
                JKContentManager.Particles._snow_particle = p_loader.Load<Texture2D>("particles/snow_jump_particle");
                Rectangle rectangle = new Rectangle(0, 0, 144, 108);
                for (int i = 0; i < JKContentManager.Particles._snow_particle.Height / rectangle.Height; i++)
                {
                    rectangle.Y = rectangle.Height * i;
                    JKContentManager.Particles.SnowSprites.Add(i, JKContentManager.Util.SpriteChopUtilGrid(JKContentManager.Particles._snow_particle, new Point(4, 3), new Vector2(0.5f, 1f), rectangle));
                }
                WeatherManager.WeatherEffect weatherEffect = XmlSerializerHelper.Deserialize<WeatherManager.WeatherEffect>(p_loader.RootDirectory + "/mods/particles/weather.xml");
                foreach (WeatherManager.Weather weather in weatherEffect.weathers)
                {
                    JKContentManager.Particles.WeatherSprites.Add(weather.name, JKExtensions.UltraContent.LoadContentArr<Texture2D>(p_loader, "particles/" + weather.name));
                }
                WeatherManager.Load(weatherEffect);
            }
        }
        
        public static class Music
        {
            public static void Load(Microsoft.Xna.Framework.Content.ContentManager p_loader)
            {
                // everything else
                JKContentManager.Audio.WaterSplashEnter = new JKSound(p_loader.Load<SoundEffect>("audio/water_splash_enter"), SoundType.SFX);
                JKContentManager.Audio.WaterSplashExit = new JKSound(p_loader.Load<SoundEffect>("audio/water_splash_exit"), SoundType.SFX);
                JKContentManager.Audio.Plink = new JKSound(p_loader.Load<SoundEffect>("audio/plink"), SoundType.SFX);
                JKContentManager.Audio.PressStart = new JKSound(p_loader.Load<SoundEffect>("audio/press_start"), SoundType.SFX);
                JKContentManager.Audio.NewLocation = new JKSound(p_loader.Load<SoundEffect>("audio/new_location"), SoundType.SFX);
                JKContentManager.Audio.Talking = new JKSound(p_loader.Load<SoundEffect>("audio/talking"), SoundType.SFX);
                JKContentManager.Audio.RaymanSFX = new JKSound(p_loader.Load<SoundEffect>("audio/illusion"), SoundType.SFX);
                JKContentManager.Audio.Player.Load(p_loader);
                JKContentManager.Audio.Menu.Load(p_loader);
                JKContentManager.Audio.Babe.Load(p_loader);

                // music only
                string text = "mods/audio/music/";
                if (File.Exists(Game1.instance.Content.RootDirectory + "/mods/audio/music/menu loop/menu_intro.xnb"))
                {
                    JKContentManager.Audio.Music.TitleScreen = new JKSound(p_loader.Load<SoundEffect>(text + "menu loop/menu_intro"), SoundType.Music);
                } else
                {
                    JKContentManager.Audio.Music.TitleScreen = new JKSound(p_loader.Load<SoundEffect>("audio/music/menu loop/menu_intro"), SoundType.Music);
                }   
                JKContentManager.Audio.Music.TitleScreen.IsLooped = true;
                JKContentManager.Audio.Music.Opening = new JKSound(p_loader.Load<SoundEffect>("audio/music/opening theme"), SoundType.Music);
                if (File.Exists(Game1.instance.Content.RootDirectory + "/mods/audio/music/ending.xnb"))
                {
                    JKContentManager.Audio.Music.Ending = new JKSound(p_loader.Load<SoundEffect>(text + "ending"), SoundType.Music);
                } else
                {
                    JKContentManager.Audio.Music.Ending = new JKSound(p_loader.Load<SoundEffect>("audio/music/ending"), SoundType.Music);
                }
                JKContentManager.Audio.Music.Ending2 = new JKSound(p_loader.Load<SoundEffect>("audio/music/ending2"), SoundType.Music);
                JKContentManager.Audio.Music.Ending3 = new JKSound(p_loader.Load<SoundEffect>("audio/music/ending3"), SoundType.Music);
                JKContentManager.Audio.Music.event_music = new Dictionary<string, JKSound>();
                Dictionary<string, SoundEffect> dictionary = JKExtensions.UltraContent.LoadCunt<SoundEffect>(p_loader, text + "event_music", ".xnb");
                foreach (string key in dictionary.Keys)
                {
                    JKContentManager.Audio.Music.event_music.Add(key, new JKSound(dictionary[key], SoundType.Music));
                }
                Dictionary<string, SoundEffect> dictionary2 = JKExtensions.UltraContent.LoadCunt<SoundEffect>(p_loader, "audio/event_sfx", ".xnb");
                foreach (string key2 in dictionary2.Keys)
                {
                    JKContentManager.Audio.Music.event_music.Add(key2, new JKSound(dictionary2[key2], SoundType.SFX));
                }
                JKContentManager.Audio.Music.JINGLE_SETTINGS = XmlSerializerHelper.Deserialize<JumpKing.MiscSystems.ScreenEvents.JingleEventSettings>("Content/" + text + "event_music/events.xml");

                // ambient
                JKContentManager.Audio.AmbienceSaveValues = XmlSerializerHelper.Deserialize<AmbienceManager.AmbienceSaveValues>(Game1.instance.Content.RootDirectory + "/mods/audio/background/data/values.xml");
                if (JKContentManager.Audio.AmbienceSaveValues.special_info == null)
                {
                    JKContentManager.Audio.AmbienceSaveValues.special_info = new AmbienceManager.AmbienceInfo[0];
                }
                text = "mods/audio/background";
                FileInfo[] filesInFolder = p_loader.GetFilesInFolder(text);
                for (int i = 0; i < filesInFolder.Length; i++)
                {
                    string text2 = filesInFolder[i].Name;
                    if (text2.Contains("."))
                    {
                        text2 = text2.Substring(0, text2.IndexOf('.'));
                    }
                    SoundType p_type = SoundType.Ambience;
                    float p_fade_out_time = 0f;
                    float p_fade_in_time = 0f;
                    foreach (AmbienceManager.AmbienceInfo ambienceInfo in JKContentManager.Audio.AmbienceSaveValues.special_info)
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
                        volume_fade = new JumpKing.MiscSystems.FadeAmbience(lubedSound, p_fade_out_time, p_fade_in_time)
                    };
                    JKContentManager.Audio.Ambience.Add(text2, value);
                }
            }
        }

        public static class Props
        {
            public static void Load(Microsoft.Xna.Framework.Content.ContentManager p_loader)
            {
                JKContentManager.Props.SilverCoin = JKContentManager.Props.LoadCustomWorldItem(p_loader, "silver_coin");
                JKContentManager.Props.GiantBootsWorldItem = JKContentManager.Props.LoadCustomWorldItem(p_loader, "shoes_iron");
                JKContentManager.Props.GnomeHatWorldItem = JKContentManager.Props.LoadCustomWorldItem(p_loader, "gnome_hat");
                JKContentManager.Props.TunicWorldItem = JKContentManager.Props.LoadCustomWorldItem(p_loader, "tunic");
                JKContentManager.Props.YellowShoesWorldItem = JKContentManager.Props.LoadCustomWorldItem(p_loader, "yellow_shoes");
                JKContentManager.Props.CapWorldItem = JKContentManager.Props.LoadCustomWorldItem(p_loader, "cap");
                JKContentManager.Props.ShroomWorldItem = JKContentManager.Props.LoadCustomWorldItem(p_loader, "shroom");
                JKContentManager.Props.GhostFragmentItem = JKContentManager.Props.LoadCustomWorldItem(p_loader, "ghost_fragment");
                JKContentManager.Props.BugNoteItem = JKContentManager.Props.LoadCustomWorldItem(p_loader, "bug_note");
                string str = "mods/props/textures/";
                JKContentManager.Props.PropScreens = UltraContent.LoadXmlFiles<PropCollection>(Game1.instance, "mods/props", ".xml");
                JKContentManager.Props.NBP_Only_Props = UltraContent.LoadXmlFiles<PropCollection>(Game1.instance, "mods/props/new babe plus props", ".xml");
                JKContentManager.Props.OWL_Only_Props = UltraContent.LoadXmlFiles<PropCollection>(Game1.instance, "mods/props/owl props", ".xml");
                JKContentManager.Props.RaymanOverlayProps = UltraContent.LoadXmlFiles<PropCollection>(Game1.instance, "mods/props/hidden wall props", ".xml");
                PropSettings propSettings = XmlSerializerHelper.Deserialize<PropSettings>(p_loader.RootDirectory + "/mods/props/textures/prop_settings.xml");
                PropManager.SetContentData(propSettings);
                foreach (PropSetting propSetting in propSettings.settings)
                {
                    Texture2D p_texture = p_loader.Load<Texture2D>(str + propSetting.name);
                    JKContentManager.Props.PropSprites.Add(propSetting.name, JKContentManager.Util.SpriteChopUtilGrid(p_texture, propSetting.sheet_cells));
                }
                JKContentManager.Props.RaymanScreens = UltraContent.LoadXmlFiles<RaymanCollection>(Game1.instance, "mods/props/hidden_walls", ".xml");
                Dictionary<string, Texture2D> dictionary = JKExtensions.UltraContent.LoadCunt<Texture2D>(Game1.instance.Content, "mods/props/hidden_walls/textures", ".*");
                JKContentManager.Props.RaymanSprites = new Dictionary<string, Sprite>();
                foreach (KeyValuePair<string, Texture2D> keyValuePair in dictionary)
                {
                    JKContentManager.Props.RaymanSprites.Add(keyValuePair.Key, Sprite.CreateSprite(keyValuePair.Value));
                }
                Dictionary<string, RattmanSettings> dictionary2 = UltraContent.LoadXmlFiles<RattmanSettings>(Game1.instance, "mods/props/messages", ".xml");
                JKContentManager.Props.RattmanSettings = new RattmanSettings[dictionary2.Keys.Count];
                int num = 0;
                foreach (string key in dictionary2.Keys)
                {
                    JKContentManager.Props.RattmanSettings[num++] = dictionary2[key];
                }
                JKContentManager.Props.AchievementHitboxes = UltraContent.LoadXmlFiles<AchievementHitbox>(Game1.instance, "props/achievements", ".xml");
                JKContentManager.Props.BabeGhostWorldItem = JKContentManager.Props.PropSprites["babeghost"][3];
            }
        }
        
        public static class Fonts
        {
            public static string[] fontsList = new string[]
        {
            "font/sf_litter_lover2_bold",
            "font/sf_small",
            "font/sf_pixolde",
            "font/sf_litter_lover2_bold",
            "font/sf_tangerine",
            "font/sf_pixolde_bold",
            "font/sf_double_homicide"
        };
            public static SpriteFont SmartLoadFonts(Microsoft.Xna.Framework.Content.ContentManager p_loader, string fileName, int i)
            {
                string dir = "mods/font/";
                if (File.Exists(p_loader.RootDirectory + "/" + dir + fileName + ".xnb") && fileName != null)
                {
                    return p_loader.Load<SpriteFont>(dir + fileName);
                }
                else
                {
                    return p_loader.Load<SpriteFont>(fontsList[i]);
                }
            }
            public static void Load(Microsoft.Xna.Framework.Content.ContentManager p_loader)
            {
                JKContentManager.Font.MenuFont = SmartLoadFonts(p_loader, ParseData._mod.Fonts.MenuFont, 0);
                //JKContentManager.Font.MenuFont = p_loader.Load<SpriteFont>("mods/font/sf_litter_lover2_bold");
                JKContentManager.Font.MenuFontSmall = SmartLoadFonts(p_loader, ParseData._mod.Fonts.MenuFontSmall, 1);
                JKContentManager.Font.StyleFont = SmartLoadFonts(p_loader, ParseData._mod.Fonts.StyleFont, 2);
                JKContentManager.Font.OptimusUnderline = SmartLoadFonts(p_loader, ParseData._mod.Fonts.OptimusUnderline, 3);
                JKContentManager.Font.Tangerine = SmartLoadFonts(p_loader, ParseData._mod.Fonts.Tangerine, 4);
                JKContentManager.Font.LocationFont = SmartLoadFonts(p_loader, ParseData._mod.Fonts.LocationFont, 5);
                JKContentManager.Font.GargoyleFont = SmartLoadFonts(p_loader, ParseData._mod.Fonts.GargoyleFont, 6);
            }
        }

        public static class Endings
        {
            public static void Load(Microsoft.Xna.Framework.Content.ContentManager p_loader)
            {
                JKContentManager.Ending.EndingImageCrown = Sprite.CreateSprite(p_loader.Load<Texture2D>("mods/ending/" + ParseData._mod.Ending.MainBabe));
                JKContentManager.Ending.EndingImageShoes = Sprite.CreateSprite(p_loader.Load<Texture2D>("mods/ending/" + ParseData._mod.Ending.MainShoes));
            }
        }

        public static class King
        {
            public static void Load(Microsoft.Xna.Framework.Content.ContentManager p_loader)
            {
                JKContentManager.PlayerTexture = p_loader.Load<Texture2D>("mods/king/base");
                JKContentManager.PlayerSprites._CurrentSprites = new LayeredKingSprites(JKContentManager.PlayerTexture);
                SkinSettings skinSettings = XmlSerializerHelper.Deserialize<SkinSettings>("Content/mods/king/skin_settings.xml");
                SkinManager.SetSettings(skinSettings);
                foreach (Skin skin in skinSettings.skins)
                {
                    Texture2D p_tex;
                    if (!File.Exists(p_loader.RootDirectory + "/mods/king/" +skin.texture +".xnb"))
                    {
                        p_tex = p_loader.Load<Texture2D>("king/" + skin.texture);
                    } else
                    {
                        p_tex = p_loader.Load<Texture2D>("mods/king/" + skin.texture);
                    }
                    SkinManager.AddSkinSprite(skin.item, new KingSprites(p_tex));
                }
            }
        }
    }
    public class EndingFix
    {
        public EndingFix()
        {
            main = 0;
            nbp = 0;
            owl = 0;
        }
        private int main;
        private int nbp;
        private int owl;

        public int Main { get { return main; } set { main = value; } }
        public int NBP { get { return nbp; } set { nbp = value; } }
        public int Owl { get { return owl; } set { owl = value; } }

        public void Default()
        {
            Main = 42;
            NBP = 99;
            Owl = 153;
        }

        public void InitPrefs(BabePrefs prefs)
        {
            Main = prefs.new_babe;
            NBP = prefs.new_babe_plus;
            Owl = prefs.owl_babe;

            if (Game1.jkdata.CustomGame)
            {
                Main = JumpKingPlus.ParseData._mod.About.ending_screen - 1;
            }

            if (prefs.new_babe == 0 && prefs.new_babe_plus == 0 && prefs.owl_babe == 0)
            {
                Default();
            }
        }
    }
}

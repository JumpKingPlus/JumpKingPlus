using LanguageJK;
using System;
using JumpKing;
using JumpKing.SaveThread;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace JumpKingPlus
{
    public class Cheats
    {
        // if cheats are checked then no achievements
        // jump%
        // no falls
        // teleport to location

        public Cheats()
        {
            achievementsAcc = true;
            jumpPerc = false;
            noFalls = false;
            tpOption = false;
        }

        public string[] location = { 
            //nb
            language.LOCATION_REDCROWN_WOODS,
            language.LOCATION_COLOSSAL_DRAIN,
            language.LOCATION_FALSE_KINGS_KEEP,
            language.LOCATION_BARGAINBURG,
            language.LOCATION_GREAT_FRONTIER,
            language.LOCATION_WINDSWEPT_BLUFF,
            language.LOCATION_STORMWALL_PASS,
            language.LOCATION_CHAPEL_PERILOUS,
            language.LOCATION_BLUE_RUIN,
            language.LOCATION_THE_TOWER,
            "Main Babe's Screen",
            //nbp
            "Room of the Imp",
            language.LOCATION_BRIGHTCROWN_WOODS,
            language.LOCATION_COLOSSAL_DUNGEON,
            language.LOCATION_FALSE_KINGS_CASTLE,
            language.LOCATION_UNDERBURG,
            language.LOCATION_LOST_FRONTIER,
            language.LOCATION_HIDDEN_KINGDOM,
            language.LOCATION_BLACK_SANCTUM,
            language.LOCATION_DEEP_RUIN,
            language.LOCATION_THE_DARK_TOWER,
            "New Babe Plus' Screen",
            //gotb
            language.LOCATION_PHILOSOPHERS_FOREST,
            "Hole",
            language.LOCATION_BOG,
            language.LOCATION_MOULDING_MANOR,
            language.LOCATION_BUGSTALK,
            language.LOCATION_HOUSE_OF_NINE_LIVES,
            language.LOCATION_THE_PHANTOM_TOWER,
            language.LOCATION_HALTED_RUIN,
            language.LOCATION_THE_TOWER_OF_ANTUMBRA,
            "Ghost of the Babe's Screen"
        };

        public Vector3 playerLocation;

        public void SetTeleport(Vector2 position, int screen)
        {
            playerLocation = new Vector3(position.X, position.Y, screen);
        }

        public void TeleportToSavedLocation()
        {
            if (playerLocation == Vector3.Zero)
            {
                return;
            }
            TeleportToLocation(playerLocation.X, playerLocation.Y, (int)playerLocation.Z);
            JumpKing.MusicManager.Play(JKContentManager.Audio.Menu.Select);
        }

        public static void TeleportToLocation(float pX, float pY, int locInt)
        {
            SaveManager.instance.m_player.m_body.position.X = pX;
            SaveManager.instance.m_player.m_body.position.Y = pY;
            SaveManager.instance.m_player.m_body.m_last_screen = locInt;
            SaveManager.instance.m_player.m_body.velocity = Vector2.Zero;
            Camera.UpdateCamera(SaveManager.instance.m_player.m_body.GetHitbox().Center);
        }

        //locs used for teleports
        public int[] locInt = { 
            0, 5, 10, 14, 19, 25, 26, 32, 36, 39, 42,
            44, 46, 52, 59, 63, 70, 77, 83, 89, 94, 99,
            155, 163, 101, 108, 116, 123, 130, 139, 147, 153
        };
        public int[] locX = {
            //nb
            231, 251, 340, 150, 222, 216, 223, 426, 410, 435, 150, 
            //nbp
            171, 377, 295, 105, 415, 242, 360, 210, 170, 288, 140,
            //gotb
            16, 32, 79, 183, 163, 329, 333, 204, 292, 302
        };
        public int[] locY = { 
            //nb
            302, -1498, -3282, -4738, -6594, -8714, -9074, -11202, -12658, -13722, -14802,
            //nbp
            -15570, -16274, -18426, -20922, -22362, -24898, -27402, -29578, -31786, -33554, -35314,
            //gotb
            -55714, -58434, -36074, -38602, -41442, -43970, -46530, -49794, -52626, -54770
        };

        private bool achievementsAcc;
        private bool jumpPerc;
        private bool noFalls;
        private bool tpOption;
        private int bestScreen = 0;
        private float jumpTimer = 0f;
        private int lastJump = 0;

        public bool AchievementAccess { get { return achievementsAcc; } set { achievementsAcc = value; ToggleCheatAction(); } }
        public bool JumpPercentage { get { return jumpPerc; } set { jumpPerc = value; } }
        public bool NoFalls { get { return noFalls; } set{ noFalls = value; } }
        public bool TeleportOption { get { return tpOption; } set { tpOption = value; } }
        public int BestScreen { get { return bestScreen; } set { bestScreen = value; } }
        public float JumpTimer { get { return jumpTimer; } set { jumpTimer = value; } }
        public int LastJump { get { return lastJump; } set { lastJump = value; } }

        public int RoundPercent(float currentjump, float jumptime)
        {
            var value = (currentjump / jumptime) * 100;
            value = (float)Math.Round(value);
            return Convert.ToInt32(value);
        }

        public List<int> splittedLocs(int skipAmount)
        {
            var currSkip = 0;
            var startingId = 1;
            List<int> locations = new List<int>() { };
            foreach (DiscordLocations.Location loc in DiscordLocations._discordLocation.locations)
            {
                if (loc.id == startingId)
                {
                    if (currSkip == skipAmount)
                    {
                        for (int i = loc.start - 1; i < loc.end; i++)
                        {
                            locations.Add(i);
                        }
                        startingId += 1;
                        continue;
                    }
                    currSkip += 1;
                }
            }
            return locations;
        }

        public List<int> customSplittedLocs()
        {
            List<int> locations = new List<int>() { };
            foreach (JumpKing.MiscSystems.LocationText.Location loc in JumpKing.MiscSystems.LocationText.LocationTextManager.SETTINGS.locations)
            {
                for (int i = loc.start - 1; i < loc.end; i++)
                {
                    locations.Add(i);
                }
            }
            return locations;
        }

        public string GamePercent(int currentScreen, bool customMap = false)
        {
            List<int> currentBabe = new List<int>();

            if (customMap)
            {
                currentBabe = customSplittedLocs();
                float value2 = (float)(currentScreen + 1) / (float)(currentBabe.Count);
                value2 *= 100f;
                return value2.ToString("0.00");
            }

            for (int i = 0; i < 3; i++)
            {
                if (splittedLocs(i).Contains(currentScreen))
                {
                    currentBabe = splittedLocs(i);
                    break;
                }
            }

            var current = currentBabe.IndexOf(currentScreen);
            float value = (float)(current + 1) / (float)(currentBabe.Count);
            value *= 100f;
            return value.ToString("0.00");
        }

        public void ToggleCheatAction()
        {
            if (AchievementAccess)
            {
                JumpPercentage = false;
                NoFalls = false;
                TeleportOption = false;
            }
        }
    }
}

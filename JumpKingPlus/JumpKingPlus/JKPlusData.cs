using System;

namespace JumpKingPlus
{
    public class JKPlusData
    {

        public static class JKVersion
        {
            public static Version version = new Version("1.6.0");
        }
        /// <summary>
        ///     recap on JKPlusData.
        ///     version         is the actual JKPlus version, change it here only
        ///     _restart        is used to display the Quick Restart
        ///     toggleRpc       does what it says
        ///     toggleCheats    does what it says
        ///     Cheats cheats   class with ingame cheats
        ///     jkpluslogo      JKPlus intro
        ///     toggleLocation  pewwww animation new area
        /// </summary>
        public Cheats cheats;
        public JKPlusData()
        {
            _restart = false;
            toggleCheats = false;
            cheats = new Cheats();
            jkpluslogo = false;
            toggleBuild = false;
            toggleLocation = true;
            customGame = false;
        }
        private bool _restart;
        private bool toggleBuild;
        private bool toggleRpc;
        private bool toggleCheats;
        private bool toggleNpcSpeech;
        private bool jkpluslogo;
        private bool toggleLocation;
        private bool togglePreciseTimer;
        private bool customGame;
        private bool _is_in_lowGrav;
        private bool toggleBuildHelper;
        private bool gameProgress;
        private bool boomerRestart;

        public bool ToggleBuild { get { return toggleBuild; } set { toggleBuild = value; if (toggleBuild) { toggleCheats = true; } } }
        public bool QuickRestart { get { return _restart; } set { _restart = value; } }
        public bool ToggleRPC { get { return toggleRpc; } set { toggleRpc = value; } }
        public bool ToggleCheats { get { return toggleCheats; } set { toggleCheats = value; cheats.AchievementAccess = !value; } }
        public bool ToggleNPC { get { return toggleNpcSpeech; } set { toggleNpcSpeech = value; } }
        public bool JKPlusScreen { get { return jkpluslogo; } set { jkpluslogo = value; } }
        public bool ToggleLocation { get { return toggleLocation; } set { toggleLocation = value; } }
        public bool ToggleTimer { get { return togglePreciseTimer; } set { togglePreciseTimer = value; } }

        public String[] timer = new String[2]
            {
                "Default",
                "Precise"
            };

        public bool CustomGame { get { return customGame; } set { customGame = value; } }
        public bool IsInLowGravity { get { return _is_in_lowGrav; } set { _is_in_lowGrav = value; } }
        public bool ToggleBuildHelper { get { return toggleBuildHelper; } set { toggleBuildHelper = value; } }
        public bool ToggleGameProgress { get { return gameProgress; } set { gameProgress = value; } }
        public bool ToggleBoomerRestart { get { return boomerRestart; } set { boomerRestart = value; } }
    }
}

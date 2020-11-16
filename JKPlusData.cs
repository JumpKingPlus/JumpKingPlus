using System;

namespace JumpKingPlus
{
    public class JKPlusData
    {
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
        public Version version = new Version("1.1.0");
        public Cheats cheats;
        public JKPlusData()
        {
            _restart = false;
            toggleCheats = false;
            cheats = new Cheats();
            jkpluslogo = false;
            toggleLocation = true;
        }
        private bool _restart;
        private bool toggleRpc;
        private bool toggleCheats;
        private bool toggleNpcSpeech;
        private bool jkpluslogo;
        private bool toggleLocation;
        private bool togglePreciseTimer;
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
    }
}

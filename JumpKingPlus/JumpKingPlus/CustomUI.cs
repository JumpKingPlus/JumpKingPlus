using JumpKing;
using JumpKing.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BehaviorTree;
using JumpKing.Player.Skins;
using JumpKing.MiscEntities.WorldItems;
using static JumpKingPlus.JKPlusData;

namespace JumpKingPlus
{
    public class CustomPauseNode : IBTnode
    {
        // Token: 0x06000858 RID: 2136 RVA: 0x0000821B File Offset: 0x0000641B
        public CustomPauseNode(float p_duration)
        {
            this.m_timer = new Timer(p_duration);
        }

        // Token: 0x06000859 RID: 2137 RVA: 0x0000822F File Offset: 0x0000642F
        protected override void OnNewRun()
        {
            this.m_timer.Reset();
        }

        // Token: 0x0600085A RID: 2138 RVA: 0x0000822F File Offset: 0x0000642F
        protected override void ResumeRun()
        {
            this.m_timer.Reset();
        }

        // Token: 0x0600085B RID: 2139 RVA: 0x0000823C File Offset: 0x0000643C
        protected override BTresult MyRun(TickData p_data)
        {
            if (this.m_timer.Update(p_data.delta_time) == Timer.Result.Done)
            {
                Game1.jkdata.JKPlusScreen = true;
                return BTresult.Success;
            }
            return BTresult.Running;
        }

        // Token: 0x04000724 RID: 1828
        private Timer m_timer;
    }

    public class CustomImageStart
    {
        public static Sprite JKPlusLogo;
        public static void LoadCustomAssets(Game game)
        {
            JKPlusLogo = Sprite.CreateSprite(game.Content.Load<Texture2D>("JK_Plus_Logo"));
            JKPlusLogo.center = Vector2.One / 2f;
        }
    }

    public class JKPlusOnTitleScreen
    {
        public static void LoadJKPlusText()
        {
            TextHelper.DrawString(JKContentManager.Font.MenuFont, "Using JumpKingPlus v" + JKVersion.version.ToString(), new Vector2(48f, 30f), Color.Gold, new Vector2(0f, -0.5f));
        }
    }

    public class CompletionEndingItems
    {
        public bool snake;
        public bool boots;
        public bool cheatedRun;
    }

    public class ToggleSnake
    {
        bool snake;
        public ToggleSnake()
        {
            snake = SkinManager.IsWearingSkin(Items.SnakeRing);
        }

        public void Toggle()
        {
            snake = !snake;
            SkinManager.SetSkinEnabled(Items.SnakeRing, snake);
        }
    }

    public class ToggleBoots
    {
        bool boots;
        public ToggleBoots()
        {
            boots = SkinManager.IsWearingSkin(Items.GiantBoots);
        }

        public void Toggle()
        {
            boots = !boots;
            SkinManager.SetSkinEnabled(Items.GiantBoots, boots);
        }
    }
}

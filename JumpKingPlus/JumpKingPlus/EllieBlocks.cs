using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JumpKing.Level;
using Microsoft.Xna.Framework;

namespace JumpKingPlus
{
    /// <summary>
    /// Since tools like "JumpKingManager" exist, memory slots can be changed in a second.
    /// Using the dynamic library should prevent that.
    /// Code wise, a bit of a mess; but at least jkmanager works still.
    /// </summary>
    public class EllieBlocks
    {
		public bool IsOnSmash
		{
			get
			{
				return _is_on_smash;
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00010360 File Offset: 0x0000E560
		public bool SmashIsWallY(LevelScreen.CollisionInfo info, Vector2 velocity)
		{
			if (info.smash_type == SmashType.Top)
			{
				return info.smash && !this.IsOnSmash && velocity.Y > 0f;
			}
			return info.smash_type == SmashType.Bottom && info.smash && !this.IsOnSmash && velocity.Y < 0f;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000103C8 File Offset: 0x0000E5C8
		public bool SmashIsWallX(LevelScreen.CollisionInfo info, Vector2 velocity)
		{
			if (info.smash_type == SmashType.Right)
			{
				return info.smash && !this.IsOnSmash && velocity.X > 0f;
			}
			return info.smash_type == SmashType.Left && info.smash && !this.IsOnSmash && velocity.X < 0f;
		}

		public bool _is_on_smash;
		public bool _is_in_smash;
		public bool _is_on_warp;
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using JumpKing;
using JumpKing.JKMemory;
using JumpKing.JKMemory.ManagedAssets.ThreadLube;
using JumpKing.Level.Data;
using JumpKing.MiscEntities;
using JumpKing.MiscEntities.Merchant;
using JumpKing.MiscEntities.OldMan;
using JumpKing.MiscSystems.ScreenEvents;
using JumpKing.Particles;
using JumpKing.Player.Skins;
using JumpKing.Props;
using JumpKing.Props.Achievents;
using JumpKing.Props.RattmanText;
using JumpKing.Props.RaymanWall;
using JumpKing.XnaWrappers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using JumpKing.MiscEntities.WorldItems;
using BehaviorTree;
using BehaviorTree.Util;
using JumpKing.PauseMenu;
using static JumpKingPlus.WardrobeItem;

namespace JumpKingPlus
{
	public class WardrobeItem
    {
		public WardrobeItem(string path)
        {
			_wItemSettings = XmlSerializerHelper.Deserialize<WardrobeSettings>(path);
		}

		public struct Reskin
        {
			public Items skin;
			public string name;
        }

		public struct Collection
        {
			public string name;
			public string description;
			public bool enabled;
			public Reskin[] Reskins;
        }

		public struct WardrobeSettings
        {
			public bool isCollection;
			public Items? skin;
			public string name;
			public string description;
			public bool? enabled;
			public Collection? collection;
        }

		public WardrobeSettings _wItemSettings;
    }



    public class Wardrobe
    {
		public static List<WardrobeItem> wardrobeItems;
		public static List<WardrobeItem> collectionItems;

		public static bool HasSkin(Reskin[] reskins, Items item)
        {
			foreach (Reskin reskin in reskins)
            {
				if (reskin.skin.Equals(item))
                {
					return true;
                }
            }
			return false;
        }

		public static Reskin GetSkinsEnabled(Collection collection, Items item)
        {
			Reskin skinEnabled = new Reskin();
			foreach (Reskin reskin in collection.Reskins)
            {
				if (reskin.skin.Equals(item))
				{
					skinEnabled = reskin;
				}
			}
			return skinEnabled;
        }

		public static void LoadSprites(ContentManager p_loader)
		{
			Wardrobe.wardrobeItems = new List<WardrobeItem>();
			Wardrobe.collectionItems = new List<WardrobeItem>();
			
			JKContentManager.PlayerTexture = p_loader.Load<Texture2D>("king/base");
			
			string[] files = Directory.GetFiles("Content/wardrobe", "*.xml");
			for (int i = 0; i < files.Length; i++)
			{
				WardrobeItem wardrobeItem = new WardrobeItem(files[i]);
				WardrobeItem.WardrobeSettings wItemSettings = wardrobeItem._wItemSettings;
				bool isCollection = wItemSettings.isCollection;
				if (isCollection)
				{
					Wardrobe.collectionItems.Add(wardrobeItem);
					WardrobeItem.Reskin? reskin = new WardrobeItem.Reskin?(Array.Find<WardrobeItem.Reskin>(wardrobeItem._wItemSettings.collection.Value.Reskins, (WardrobeItem.Reskin r) => r.skin.Equals(Items.NULL)));
					bool flag = reskin != null && reskin.Value.skin.Equals(Items.NULL);
					if (flag && wardrobeItem._wItemSettings.collection.Value.enabled)
					{
						JKContentManager.PlayerTexture = p_loader.Load<Texture2D>("wardrobe/" + reskin.Value.name);
					}
				}
				else
				{
					Wardrobe.wardrobeItems.Add(wardrobeItem);
					bool flag2 = wardrobeItem._wItemSettings.skin.Equals(Items.NULL) && wardrobeItem._wItemSettings.enabled != null;
					if (flag2)
					{
						JKContentManager.PlayerTexture = p_loader.Load<Texture2D>("wardrobe/" + wardrobeItem._wItemSettings.name);
					}
				}
			}
			
			JKContentManager.PlayerSprites._CurrentSprites = new LayeredKingSprites(JKContentManager.PlayerTexture);
			
			SkinSettings skinSettings = XmlSerializerHelper.Deserialize<SkinSettings>("Content/king/skin_settings.xml");
			SkinManager.SetSettings(skinSettings);
			
			Skin[] skins = skinSettings.skins;
			for (int j = 0; j < skins.Length; j++)
			{
				Skin skin = skins[j];
				WardrobeItem wardrobeItem2 = Wardrobe.collectionItems.Find((WardrobeItem c) => Wardrobe.HasSkin(c._wItemSettings.collection.Value.Reskins, skin.item) && c._wItemSettings.collection.Value.enabled);
				bool flag3 = wardrobeItem2 == null;
				if (flag3)
				{
					WardrobeItem wardrobeItem3 = Wardrobe.wardrobeItems.Find((WardrobeItem x) => x._wItemSettings.skin.Equals(skin.item) && x._wItemSettings.enabled.Value);
					bool flag4 = wardrobeItem3 == null;
					if (flag4)
					{
						Texture2D p_tex = p_loader.Load<Texture2D>("king/" + skin.texture);
						SkinManager.AddSkinSprite(skin.item, new KingSprites(p_tex));
					}
					else
					{
						Texture2D p_tex2 = p_loader.Load<Texture2D>("wardrobe/" + wardrobeItem3._wItemSettings.name);
						SkinManager.AddSkinSprite(wardrobeItem3._wItemSettings.skin.Value, new KingSprites(p_tex2));
					}
				}
				else
				{
					WardrobeItem.Reskin skinsEnabled = Wardrobe.GetSkinsEnabled(wardrobeItem2._wItemSettings.collection.Value, skin.item);
					Texture2D p_tex3 = p_loader.Load<Texture2D>("wardrobe/" + skinsEnabled.name);
					SkinManager.AddSkinSprite(skinsEnabled.skin, new KingSprites(p_tex3));
				}
			}
		}
	}
}
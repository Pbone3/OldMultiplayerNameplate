using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Localization;

namespace OldMultiplayerNameplate
{
    public class OneThreeMultiplayerClosePlayersOverlay : IMultiplayerClosePlayersOverlay
    {
        public void Draw()
        {
			PlayerInput.SetZoom_World();
			int screenWidth = Main.screenWidth;
			int screenHeight = Main.screenHeight;
			Vector2 screenPosition = Main.screenPosition;
			PlayerInput.SetZoom_UI();
			float uIScale = Main.UIScale;
			for (int i = 0; i < 255; i++)
			{
				Player query = Main.player[i];

				if (query.active && Main.myPlayer != i
					&& !query.dead && Main.LocalPlayer.team > 0 && Main.LocalPlayer.team == query.team)
				{
					string topLine = query.name;
					if (query.statLife < query.statLifeMax2)
						topLine += ": " + query.statLife + "/" + query.statLifeMax2;
                    
					Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(topLine);
					float num3 = 0f;
					if (query.chatOverhead.timeLeft > 0)
					{
						num3 = 0f - vector2.Y;
					}
					Vector2 vector3 = new(screenWidth / 2 + screenPosition.X, screenHeight / 2 + screenPosition.Y);
					Vector2 position = query.position;
					position += (position - vector3) * (Main.GameViewMatrix.Zoom - Vector2.One);
                    
					float num4 = 0f;
					float num5 = Main.mouseTextColor / 255f;
					Color color = new((byte)(Main.teamColor[query.team].R * num5), (byte)(Main.teamColor[query.team].G * num5), (byte)(Main.teamColor[query.team].B * num5), Main.mouseTextColor);
					
					float num6 = position.X + query.width / 2 - vector3.X;
					float num7 = position.Y - vector2.Y - 2f + num3 - vector3.Y;
					float num8 = (float)Math.Sqrt(num6 * num6 + num7 * num7);
					int num9 = screenHeight;
					if (screenHeight > screenWidth)
						num9 = screenWidth;
                    
					num9 = num9 / 2 - 30;
					if (num9 < 100)
						num9 = 100;
                    
					if (num8 < num9)
					{
						vector2.X = position.X + query.width / 2 - vector2.X / 2f - screenPosition.X;
						vector2.Y = position.Y - vector2.Y - 2f + num3 - screenPosition.Y;
					}
					else
					{
						num4 = num8;
						num8 = num9 / num8;
						vector2.X = screenWidth / 2 + num6 * num8 - vector2.X / 2f;
						vector2.Y = screenHeight / 2 + num7 * num8;
					}
                    
					if (Main.LocalPlayer.gravDir == -1f)
						vector2.Y = screenHeight - vector2.Y;

					vector2 *= 1f / uIScale;
					Vector2 vector4 = FontAssets.MouseText.Value.MeasureString(topLine);
					vector2 += vector4 * (1f - uIScale) / 4f;

					if (num4 > 0f)
					{
						string textValue = Language.GetTextValue("GameUI.PlayerDistance", (int)(num4 / 16f * 2f));
						Vector2 vector5 = FontAssets.MouseText.Value.MeasureString(textValue);
						vector5.X = vector2.X + vector4.X / 2f - vector5.X / 2f;
						vector5.Y = vector2.Y + vector4.Y / 2f - vector5.Y / 2f - 20f;
                        
						DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, textValue, new Vector2(vector5.X - 2f, vector5.Y), Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, textValue, new Vector2(vector5.X + 2f, vector5.Y), Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, textValue, new Vector2(vector5.X, vector5.Y - 2f), Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, textValue, new Vector2(vector5.X, vector5.Y + 2f), Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, textValue, vector5, color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
					}
                    
					DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, topLine, new Vector2(vector2.X - 2f, vector2.Y), Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
					DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, topLine, new Vector2(vector2.X + 2f, vector2.Y), Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
					DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, topLine, new Vector2(vector2.X, vector2.Y - 2f), Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
					DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, topLine, new Vector2(vector2.X, vector2.Y + 2f), Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
					DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, topLine, vector2, color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				}
			}
		}
    }
}

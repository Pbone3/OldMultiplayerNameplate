using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Localization;

namespace OldMultiplayerNameplate;

public class OneThreeMultiplayerClosePlayersOverlay : IMultiplayerClosePlayersOverlay {
    public void Draw() {
        PlayerInput.SetZoom_World();
        int screenWidth = Main.screenWidth;
        int screenHeight = Main.screenHeight;
        Vector2 screenPosition = Main.screenPosition;
        PlayerInput.SetZoom_UI();
        float uiScale = Main.UIScale;

        for (int i = 0; i < 255; i++) {
            Player player = Main.player[i];

            if (player.active && Main.myPlayer != i
                && !player.dead && Main.LocalPlayer.team > 0 && Main.LocalPlayer.team == player.team
            ) {
                string nameLineText = player.name;
                if (player.statLife < player.statLifeMax2) {
                    nameLineText += ": " + player.statLife + "/" + player.statLifeMax2;
                }

                Vector2 nameLineSize = FontAssets.MouseText.Value.MeasureString(nameLineText);
                float num3 = 0f;
                if (player.chatOverhead.timeLeft > 0) {
                    num3 = 0f - nameLineSize.Y;
                }

                Vector2 screenCenterWorld = new(screenWidth / 2 + screenPosition.X, screenHeight / 2 + screenPosition.Y);
                Vector2 playerPos = player.position;
                playerPos += (playerPos - screenCenterWorld) * (Main.GameViewMatrix.Zoom - Vector2.One);

                float num4 = 0f;
                Color color = Main.teamColor[player.team] * (Main.mouseTextColor / 255f);
                color.A = Main.mouseTextColor;

                float num6 = playerPos.X + player.width / 2 - screenCenterWorld.X;
                float num7 = playerPos.Y - nameLineSize.Y - 2f + num3 - screenCenterWorld.Y;
                float num8 = (float)Math.Sqrt(num6 * num6 + num7 * num7);
                int num9 = Math.Min(Main.screenWidth, Main.screenHeight);

                num9 = num9 / 2 - 30;
                if (num9 < 100) {
                    num9 = 100;
                }

                Vector2 nameLinePos;
                if (num8 < num9) {
                    nameLinePos.X = playerPos.X + player.width / 2 - nameLineSize.X / 2f - screenPosition.X;
                    nameLinePos.Y = playerPos.Y - nameLineSize.Y - 2f + num3 - screenPosition.Y;
                } else {
                    num4 = num8;
                    num8 = num9 / num8;
                    nameLinePos.X = screenWidth / 2 + num6 * num8 - nameLineSize.X / 2f;
                    nameLinePos.Y = screenHeight / 2 + num7 * num8;
                }

                if (Main.LocalPlayer.gravDir == -1f) {
                    nameLinePos.Y = screenHeight - nameLinePos.Y;
                }

                nameLinePos *= 1f / uiScale;
                Vector2 vector4 = FontAssets.MouseText.Value.MeasureString(nameLineText);
                nameLinePos += vector4 * (1f - uiScale) / 4f;

                if (num4 > 0f) {
                    string distLineText = Language.GetTextValue("GameUI.PlayerDistance", (int)(num4 / 16f * 2f));
                    Vector2 distLinePos = FontAssets.MouseText.Value.MeasureString(distLineText);
                    distLinePos.X = nameLinePos.X + vector4.X / 2f - distLinePos.X / 2f;
                    distLinePos.Y = nameLinePos.Y + vector4.Y / 2f - distLinePos.Y / 2f - 20f;

                    DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, distLineText, new Vector2(distLinePos.X - 2f, distLinePos.Y), Color.Black, 0f, default, 1f, SpriteEffects.None, 0f);
                    DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, distLineText, new Vector2(distLinePos.X + 2f, distLinePos.Y), Color.Black, 0f, default, 1f, SpriteEffects.None, 0f);
                    DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, distLineText, new Vector2(distLinePos.X, distLinePos.Y - 2f), Color.Black, 0f, default, 1f, SpriteEffects.None, 0f);
                    DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, distLineText, new Vector2(distLinePos.X, distLinePos.Y + 2f), Color.Black, 0f, default, 1f, SpriteEffects.None, 0f);
                    DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, distLineText, distLinePos, color, 0f, default, 1f, SpriteEffects.None, 0f);
                }

                DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, nameLineText, new Vector2(nameLinePos.X - 2f, nameLinePos.Y), Color.Black, 0f, default, 1f, SpriteEffects.None, 0f);
                DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, nameLineText, new Vector2(nameLinePos.X + 2f, nameLinePos.Y), Color.Black, 0f, default, 1f, SpriteEffects.None, 0f);
                DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, nameLineText, new Vector2(nameLinePos.X, nameLinePos.Y - 2f), Color.Black, 0f, default, 1f, SpriteEffects.None, 0f);
                DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, nameLineText, new Vector2(nameLinePos.X, nameLinePos.Y + 2f), Color.Black, 0f, default, 1f, SpriteEffects.None, 0f);
                DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, nameLineText, nameLinePos, color, 0f, default, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
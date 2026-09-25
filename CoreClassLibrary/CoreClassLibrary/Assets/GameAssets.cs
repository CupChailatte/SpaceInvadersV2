using System.Net.Mime;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics; 

namespace CoreClassLibrary.Assets; 

public class GameAssets
{
    public Texture2D PlayerSprite {get; private set; } 
    public Texture2D EnemySprite {get; private set; }
    public Texture2D MenuBackground {get; private set;}
    public Texture2D BulletTexture {get; private set; }
    public SpriteFont TextMenuStateTitle {get; private set;}
    public SpriteFont TextBattleStatus {get; private set; }

    public void LoadContent(ContentManager content) // laddar upp content i Game1 en gång. 
    {
        // --- ENTITIES--- 
        PlayerSprite = content.Load<Texture2D>("PlayerSprite/Ship01"); 
        EnemySprite = content.Load<Texture2D>("EnemySprite/alien01-01"); 

        // ---ENTITY ASSETS --- 
        BulletTexture = content.Load<Texture2D>("Bullet/bullet01"); 

        // ---TEXT----
        TextMenuStateTitle =content.Load<SpriteFont>("Fonts/TextTitle"); 
        TextBattleStatus = content.Load<SpriteFont>("Fonts/StatusText"); 

        // ---BACKGROUNDS----
        MenuBackground = content.Load<Texture2D>("Background/Stars1"); 
    }
}
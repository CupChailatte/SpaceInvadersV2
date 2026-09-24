using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics; 

namespace CoreClassLibrary.Assets; 

public class GameAssets
{
    public Texture2D PlayerSprite {get; private set; } 
    public Texture2D EnemySprite {get; private set; }

    public void LoadContent(ContentManager content) // laddar upp content i Game1 en gång. 
    {
        PlayerSprite = content.Load<Texture2D>("PlayerSprite/Ship01"); 
        EnemySprite = content.Load<Texture2D>("EnemySprite/alien01-01"); 
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Numerics;

namespace CoreClassLibrary.Managers; 

public class UIManager
{
    private Texture2D _heartTexture; // Texture för spelarens liv.  
    private SpriteFont _fontTitle;
    private SpriteFont _fontDefault;  

    public void LoadContent(ContentManager content)
    {
        _fontDefault = content.Load<SpriteFont>();
        _fontTitle = content.Load<SpriteFont>();
        _heartTexture = content.Load<Texture2D>(); 
    }
    public void DrawScore(SpriteBatch spriteBatch, int score, Vector2 position)
    {
        spriteBatch.DrawString(_fontDefault,$"SCORE {score:D4}", position, Color.White ); 
    }
}
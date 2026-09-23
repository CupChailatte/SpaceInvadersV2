using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CoreClassLibrary.Managers; 

public class UIManager
{
    private Texture2D _heartTexture; // Texture för spelarens liv.  
    public SpriteFont fontTitle;
    private SpriteFont _fontDefault;  

    public void LoadContent(ContentManager content)
    {
        //_fontDefault = content.Load<SpriteFont>();
        fontTitle = content.Load<SpriteFont>("Fonts/Text");
        //_heartTexture = content.Load<Texture2D>(); 
    }
    public void DrawScore(SpriteBatch spriteBatch, int score, Vector2 position)
    {
        spriteBatch.DrawString(_fontDefault,$"SCORE {score:D4}", position, Color.White ); 
    }

    public void DrawLives(SpriteBatch spritebatch, int health, Vector2 position)
    {
        spritebatch.DrawString(fontTitle, "Lives: ", position, Color.Red); 

        // TODO: Jag behöver en loop som ritar ut hjärt texturen. 
    }   

    public void DrawTitle(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.DrawString(fontTitle, "SPACE INVADERS", position, Color.Yellow); 
    }
}
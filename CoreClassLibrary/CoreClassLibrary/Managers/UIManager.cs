using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CoreClassLibrary.Managers; 

public class UIManager
{
    private Texture2D _playerTexture; // Texture för spelarens liv.  
    public SpriteFont fontTitle;
    private SpriteFont _fontDefault;  
    private ContentManager content; 

    public void LoadContent(ContentManager content)
    {
        //_fontDefault = content.Load<SpriteFont>();
        fontTitle = content.Load<SpriteFont>("Fonts/Text");
        _playerTexture = content.Load<Texture2D>("PlayerSprite/Ship01"); 
        //_heartTexture = content.Load<Texture2D>(); 
    }
    public void DrawScore(SpriteBatch spriteBatch, int score, Vector2 position)
    {
        spriteBatch.DrawString(_fontDefault,$"SCORE {score:D4}", position, Color.White ); 
    }

    public void DrawLives(SpriteBatch spritebatch, int health, Vector2 position)
    {
        spritebatch.DrawString(fontTitle, "LIVES: ", position, Color.Red); 

        // TODO: Jag behöver en loop som ritar ut hjärt texturen. 
    }   

    public void DrawTitle(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.DrawString(fontTitle, "SPACE INVADERS", position, Color.Yellow); 
    }

    public void DrawSprite(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(_playerTexture, position, Color.Wheat); 
    }

   
}
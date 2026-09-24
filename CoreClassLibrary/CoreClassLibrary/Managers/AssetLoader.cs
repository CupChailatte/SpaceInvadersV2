using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content; 
using System; 

namespace CoreClassLibrary.Managers; 

public static class AssetLoader
{

    protected Texture2D _backgroundTexture; 
    private static Texture2D _playerTexture; 
    public void Load(ContentManager content) 
    {
        _backgroundTexture = content.Load<Texture2D>("Background/Stars1"); 
        _playerTexture = content.Load<Texture2D>("Ship_01-1"); 
    }

    public void ChangeBackground(SpriteBatch spriteBatch)
    {
        // spriteBatch.Draw(_backgroundTexture); 
        
    }

}
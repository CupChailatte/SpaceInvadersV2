using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;


namespace CoreClassLibrary.Managers; 
public class DisplayManager
{
    private GraphicsDeviceManager _graphics; 

    public DisplayManager(GraphicsDeviceManager graphics )
    {
        _graphics = graphics; 
    }

    public void SetResolution(int width, int height)
    {
        _graphics.PreferredBackBufferWidth = width; 
        _graphics.PreferredBackBufferHeight = height; 
        _graphics.IsFullScreen = false; 
        _graphics.ApplyChanges(); 
        
    }

}
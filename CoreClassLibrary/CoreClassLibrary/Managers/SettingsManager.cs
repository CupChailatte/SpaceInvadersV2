using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;

namespace CoreClassLibrary.Managers; 

public class SettingsManager
{

    public int Width;
    public int Height;
    public bool IsFullScreen = false; //
    
    private readonly GraphicsDeviceManager _graphics; 
 

    public SettingsManager(GraphicsDeviceManager graphics, int width, int height, bool isFullScreen)
    {
     
        _graphics = graphics; 
        SetResolution(width, height);
    } 

    public void SetResolution(int width, int height) // ändrar storleken på fönstret 
    {
        Width = width; 
        Height = height;


        _graphics.PreferredBackBufferWidth = width; 
        _graphics.PreferredBackBufferHeight = height; 
        _graphics.IsFullScreen = IsFullScreen;
        _graphics.ApplyChanges(); 
        
    }
    
     
}
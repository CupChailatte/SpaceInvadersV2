using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input; 

namespace CoreClassLibrary.Managers; 

public class InputManager
{
    private KeyboardState _currentKeyState; 
    private KeyboardState _previousKeyState;

    private MouseState _currentMouseState; 
    private MouseState _previousMouseState; 

    public void Update()
    {
        _previousKeyState = _currentKeyState; 
        _previousMouseState = _currentMouseState;

        _currentKeyState = Keyboard.GetState(); 
        _currentMouseState = Mouse.GetState(); 

    }

    // ----- KEYBOARD/TANGENT HJÄLPARE -----
    public bool IsKeyDown(Keys key)
    {
        return _currentKeyState.IsKeyDown(key); 
        
    }

    public bool IsKeyPressed(Keys key)
    {
        return _currentKeyState.IsKeyDown(key) && _previousKeyState.IsKeyUp(key); 
    }

    // ---- MUS/MOUSE HJÄLPARE ----- 
    public bool IsLeftClick()
    {
        return 
        _currentMouseState.LeftButton == ButtonState.Pressed
         && 
        _previousMouseState.LeftButton == ButtonState.Released; 
    }
}


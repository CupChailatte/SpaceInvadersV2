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
        // Sparar det gamla läget först
        _previousKeyState = _currentKeyState; 
        _previousMouseState = _currentMouseState;

        // Hämtar det nya läget från enheterna. 
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

    public Vector2 GetMousePosition()
    {
        return new Vector2(_currentMouseState.X,_currentMouseState.Y ); 
    }

    public bool IsLeftClick()
    {
        return 
        _currentMouseState.LeftButton == ButtonState.Pressed
         && 
        _previousMouseState.LeftButton == ButtonState.Released; 
    }
}


using System.Diagnostics;
using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Managers; 

namespace CoreClassLibrary.Entities;

public class Player : Entity
{

    protected InputManager _input; 
    protected GraphicsDevice _display; 
    public Player(Texture2D sprite,
     Vector2 spritePosition,
      int health = 100,
       float speed = 500f,
        bool canShoot = true,
         bool isExpired = false,
          InputManager inputManager = null,
          GraphicsDevice display = null) : base(
    sprite,
    spritePosition,
    health,
    speed,
    canShoot,
    isExpired)
    {
     _input = inputManager; 
     _display = display;    
     
    }


    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime); 
        Vector2 MousePosition = _input.GetMousePosition(); // Hämtar musen position x och y 

        //input 
        switch (true)
        {
            
            case var _ when _input.IsKeyDown(Keys.Left) || _input.IsKeyDown(Keys.A): 
            _spritePosition.X -= _speed * _deltaTime; 
           // Console.WriteLine("MOVE LEFT FUNCTION CALL - PLAYER CLASS"); 
            break;
            case var _ when _input.IsKeyDown     (Keys.Right) ||_input.IsKeyDown(Keys.D): 
            _spritePosition.X += _speed * _deltaTime;  
            //Console.WriteLine("MOVE RIGHT FUNCTION CALL - PLAYER CLASS"); 
            break;
           

             
                  
        }

        switch (true)
        {
             // Körs bara om pilen är inne i fönstret
            case var _ when MousePosition.X >= 0 && MousePosition.X <= _display.Viewport.Width && 
            MousePosition.Y >= 0 && MousePosition.Y <= _display.Viewport.Height:
             // --- Musen kan bara flytta sprite i x-led Samt centrerar musen på spriten---
             _spritePosition.X = MousePosition.X - (_sprite.Width /2);
             break; 
        }

        switch (true)
        {
            case var _ when _input.IsKeyPressed(Keys.Space) ||  _input.IsLeftClick():
            // --- BULLET/BULLET MANAGER 
            Console.WriteLine("SHOOT FUNCTION CALLED - PLAYER CLASS ");
            break; 
        }

        _spritePosition.X = MathHelper.Clamp(_spritePosition.X, 0, _display.Viewport.Width - _sprite.Width);
        
    }

    public override void Draw(SpriteBatch spritebatch)
    {
        if(_sprite != null && !_isExpired)
        {
            spritebatch.Draw(_sprite, _spritePosition, Color.White); 
        }
    }


}
using System.Diagnostics;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Managers;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Assets;


namespace CoreClassLibrary.Entities;

public class Player : Entity
{

    protected InputManager _input;
    protected GraphicsDevice _graphics;
    protected int _score;
    protected BulletManager _bulletManager;
    public Player(Texture2D sprite,
     Vector2 spritePosition,
     int health,
     float speed,
     bool isExpired,  
     int score,
     InputManager inputManager,
     GraphicsDevice display,
     BulletManager bulletManager
     )
    : base(
    sprite,
    spritePosition,
    health,
    speed,
    isExpired)
    {
        _score = score;
        _graphics = display;
        _input = inputManager;
        _bulletManager = bulletManager; 
       
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
            case var _ when _input.IsKeyDown(Keys.Right) || _input.IsKeyDown(Keys.D):
                _spritePosition.X += _speed * _deltaTime;
                //Console.WriteLine("MOVE RIGHT FUNCTION CALL - PLAYER CLASS"); 
                break;

        }

        switch (true)
        {
            // Körs bara om pilen är inne i fönstret
            case var _ when MousePosition.X >= 0 && MousePosition.X <= _graphics.Viewport.Width &&
            MousePosition.Y >= 0 && MousePosition.Y <= _graphics.Viewport.Height:
                // --- Musen kan bara flytta sprite i x-led Samt centrerar musen på spriten---
                _spritePosition.X = MousePosition.X - (_sprite.Width / 2);
                break;

                
        }
        _spritePosition.X = MathHelper.Clamp(_spritePosition.X, 0, _graphics.Viewport.Width - _sprite.Width);

    }
    public void Shoot()
    {

        Vector2 bulletPosition = new Vector2(40,40); 
        float speed = 500f; 
        Vector2 direction = new Vector2(0,-1); 
        int damage = 10; 
        bool isExpired = false; 

        switch (true)
        {
            case var _ when _input.IsKeyPressed(Keys.Space) || _input.IsLeftClick():
                // --- BULLET/BULLET MANAGER 
                Console.WriteLine("SHOOT FUNCTION CALLED - PLAYER CLASS ");
                
                _bulletManager.SpawnBullet(bulletPosition, speed, direction, damage, isExpired); 

                break;
        }
        // _bulletManager.Update(gameTime); Ska vara i statens update() metod. 
    }


    public override void Draw(SpriteBatch spritebatch)
    {
        if (_sprite != null && !_isExpired)
        {
            spritebatch.Draw(_sprite, _spritePosition, Color.White);
        }
    }


}
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Managers; 

namespace CoreClassLibrary.Entities;

public class Player : Entity
{

    protected InputManager _input; 
    public Player(Texture2D sprite,
     Vector2 spritePosition,
      int health,
       float speed,
        bool canShoot,
         bool isExpired,
          InputManager inputManager) : base(
    sprite,
    spritePosition,
    health,
    speed,
    canShoot,
    isExpired)
    {
     _input = inputManager;    
    }


    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime); 
        //input
        switch (true)
        {
            case var _ when _input.IsKeyDown(Keys.Left) || _input.IsKeyDown(Keys.A): 
            _spritePosition.X -= _speed * _deltaTime; 
            break;
            case var _ when _input.IsKeyDown(Keys.Right) ||_input.IsKeyDown(Keys.D): 
            _spritePosition.X += _speed * _deltaTime;  
            Debug.WriteLine("Right");
            break;          
        }

        switch (true)
        {
            case var _ when _input.IsKeyPressed(Keys.Space):
            Debug.WriteLine("PEW PEW ");
            break; 
        }
    }

    public override void Draw(SpriteBatch spritebatch)
    {
        if(_sprite != null && !_isExpired)
        {
            spritebatch.Draw(_sprite, _spritePosition, Color.White); 
        }
    }


}
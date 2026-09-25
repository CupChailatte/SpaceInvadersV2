using System;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 

namespace CoreClassLibrary.Entities; 

public class Bullet
{
    protected Texture2D _bulletSprite; 
    protected Vector2 _bulletPosition; 
    protected float _speed; 
    protected Vector2 _direction; 
    protected int _damage; 
    public bool IsExpired {get; set;} = false; 


    public Bullet(Texture2D texture, Vector2 position, float speed, Vector2 direction, int damage, bool isExpired)
    {
        _bulletSprite = texture; 
        _bulletPosition = position; 
        _speed = speed; 
        _direction = direction; 
        _damage = damage; 
        IsExpired = isExpired; 
    }

    public void Update(GameTime gameTime)
    {
        float DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds; 
        _bulletPosition += _direction * _speed * DeltaTime; //Gör så att bullet kan röra på sig. _direction.X och _direction.Y

        // --- Bullet raderas om det är utanför skärmen 
        if (_bulletPosition.Y <= 0 && _bulletPosition.Y < -50)
        {
            IsExpired = true; 
        }

        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        //ritar ut bullet sprite, position och dens färg. 
        if (_bulletSprite != null && !IsExpired)
        {
        spriteBatch.Draw(_bulletSprite, _bulletPosition, Color.Red); 
            
        }
            Console.WriteLine("SpriteTexture is null"); 
    }




} 
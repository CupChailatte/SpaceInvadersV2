
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace CoreClassLibrary.Entities;

public class Entity
{
    //* Protected gör så att subklassen kan komma åt properties av basklassen.
    //* Klasser som inte är av typ Entity kan inte komma åt dens properties. 
    protected Texture2D _sprite;
    protected Vector2 _spritePosition;
    protected int _health;
    protected float _speed;
    protected bool _isExpired;

    protected float _deltaTime; 

    //*Constructor
    public Entity(
    Texture2D sprite,
    Vector2 spritePosition,
    int health,
    float speed,
    bool isExpired)
    {
        _sprite = sprite; 
        _spritePosition = spritePosition; 
        _health = health;
        _speed = speed; 
        _isExpired = isExpired; 

    }
    public virtual void TakeDamage(int damage)
    {
        _health-= damage; 
        if (_health <= 0)
        {
            _health = 0; //hälsa får inte negativt värde 
            _isExpired = true; 
        }

    }
    public virtual void Update(GameTime gameTime)
    {
        _deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds; 
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        if(_sprite != null && !_isExpired)
        {
            spriteBatch.Draw(_sprite, _spritePosition, Color.White); 
        }

    }

}
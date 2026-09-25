using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System; 
using CoreClassLibrary.Entities;
using CoreClassLibrary.Assets; 


using System.Collections.Generic; 

public class BulletManager
{
    protected GameAssets _gameAssets; 
    protected List<Bullet> _bulletList; 
   
    public BulletManager(ContentManager content)
    {
        _gameAssets = new GameAssets(); 
        _bulletList = new List<Bullet>(); 
    
    }

    public void SpawnBullet(Vector2 startPositon, float speed, Vector2 direction, int damage, bool isExpired)
    {
        //när Shoot() kallas, så läggs dens parameter till parametern av bullet instans.
        Bullet bullet = new Bullet(_gameAssets.BulletTexture ,startPositon, speed, direction, damage, isExpired);
        _bulletList.Add(bullet);  

    }

    public void Update(GameTime gameTime)
    {
        for(int i = _bulletList.Count - 1; i >= 0; i--)
        {
            _bulletList[i].Update(gameTime);

            if (_bulletList[i].IsExpired)
            {
                _bulletList.RemoveAt(i); 
            } 
        }
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var bullet in _bulletList)
        {
            bullet.Draw(spriteBatch); 
        }
        
    }
}
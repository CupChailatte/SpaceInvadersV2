using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content; 
using CoreClassLibrary.Managers;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Interface;

namespace CoreClassLibrary.Interface;

public class BattleState : IGameState
{   
    public int TargetWidth => 800;
    public int TargetHeight => 1200;      
    
    private GameStateManager _gameStateManager; 
    private UIManager _UIManager; 

    // note to self , glöm inte att kalla på construktorn! 
    public BattleState(GameStateManager gameStateManager,UIManager uIManager )
    {
        _gameStateManager = gameStateManager; 
        _UIManager = uIManager; 
    }

    public void Initialize(GraphicsDevice graphicsDevice){}
    public void LoadContent(ContentManager _content)
    {
        
    }
    public void UnloadContent(){}
    public void Update(GameTime gameTime){} 
    public void Draw(SpriteBatch spriteBatch)
    {
       _UIManager.DrawLives(spriteBatch, 5, new Vector2(50,50));
    } 
}
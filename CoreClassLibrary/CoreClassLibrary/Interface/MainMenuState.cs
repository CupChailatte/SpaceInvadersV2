using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content; 
using CoreClassLibrary.Managers;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Interface;
using System;
using System.Numerics;

namespace CoreClassLibrary.Interface;

public class MainMenuState : IGameState
{   
    // --- Storlek på fönstret --- 
    public int TargetWidth => 600;
    public int TargetHeight => 1000;  
    private Texture2D _mainMenuBackground;     
    private Texture2D texture;     
    
    private GameStateManager _gameStateManager; 
    private UIManager _UIManager; 
    private ContentManager Content; 

    // note to self , glöm inte att kalla på construktorn! 
    public MainMenuState(GameStateManager gameStateManager,UIManager uIManager)
    {
        _gameStateManager = gameStateManager; 
        _UIManager = uIManager; 
    }

    public void Initialize(GraphicsDevice graphicsDevice){}
    public void LoadContent(ContentManager content)
    {
        
        
    }
    public void UnloadContent(){}
    public void Update(GameTime gameTime){} 
    public void Draw(SpriteBatch spriteBatch)
    {
        _UIManager.DrawTitle(spriteBatch, new Vector2(50,50)); 
        spriteBatch(AssetLoader._playerSprite, new Vector2(40,60), Color.Red);
    } 
}
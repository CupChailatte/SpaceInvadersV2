using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content; 
using CoreClassLibrary.Managers;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Interface;
using CoreClassLibrary.Assets; 
using System;

namespace CoreClassLibrary.Interface;

public class MainMenuState : IGameState
{   
    // --- Storlek på fönstret --- 
    public int TargetWidth => 600;
    public int TargetHeight => 700;  
    private GameStateManager _gameStateManager; 
    // private UIManager _UIManager; 
    private GameAssets _assets; 
    private Player _player; 
    private GraphicsDevice _graphics; 
    private InputManager _input; 

    // note to self , glöm inte att kalla på construktorn! 
    public MainMenuState(GameStateManager gameStateManager, GameAssets assets, InputManager input)

    {
        _gameStateManager = gameStateManager; 
        _assets = assets;  
        _input = input; 
    }

    public void Initialize(GraphicsDevice graphicsDevice)
    {
        _graphics = graphicsDevice; 

        float startX = (TargetWidth / 2f - _assets.PlayerSprite.Width /2f); 
        float startY = (TargetHeight / 2f - _assets.PlayerSprite.Height /2f); 
        Vector2 _playerSpriteStartPosition = new Vector2(startX, startY); 
        _player = new Player(_assets.PlayerSprite,_playerSpriteStartPosition, 100, 600f, true, false, _input, _graphics); 

        
    }
    public void LoadContent(ContentManager content)
    {
        

    }
    public void UnloadContent(){}
    public void Update(GameTime gameTime)
    {
        _player.Update(gameTime); 
    } 
    public void Draw(SpriteBatch spriteBatch)
    {
        _player.Draw(spriteBatch);
        
        
    } 
}
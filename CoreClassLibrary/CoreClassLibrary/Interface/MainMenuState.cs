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
    public int TargetHeight => 1000;  
    private GameStateManager _gameStateManager; 
    // private UIManager _UIManager; 
    private GameAssets _gameAssets; 
    private Player _player; 
    private GraphicsDevice _graphics; 
    private InputManager _input; 
    private BulletManager _bulletManager; 
    private Vector2 titlePosition; 
    private Vector2 _screenCenter; 
    private Vector2 textSize; 
    public string titleText; 

    // note to self , glöm inte att kalla på construktorn! 
    public MainMenuState(GameStateManager gameStateManager, GameAssets assets, InputManager input, BulletManager bulletManager)

    {
        _gameStateManager = gameStateManager; 
        _gameAssets = assets;  
        _input = input; 
        _bulletManager = bulletManager; 
    }

    public void Initialize(GraphicsDevice graphicsDevice)
    {
        _graphics = graphicsDevice; 

        float startX = (TargetWidth / 2f - _gameAssets.PlayerSprite.Width / 2f);
        float startY = (TargetHeight - _gameAssets.PlayerSprite.Height);
        Vector2 startPosition = new Vector2(startX, startY);
        _player = new Player(_gameAssets.PlayerSprite, startPosition, 100, 600f, false, 10,  _input, _graphics, _bulletManager ); 

        
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
        titleText = "SPACEINVADERS V2"; 
        textSize = _gameAssets.TextMenuStateTitle.MeasureString(titleText); 
        _screenCenter = new Vector2(TargetWidth / 2f, TargetWidth / 2f); // hittar skärm center 
        titlePosition = new Vector2(_screenCenter.X - textSize.X / 2, _screenCenter.Y - textSize.Y / 2); // delar skärm center med textens storlek för att centrera texten  

       
        spriteBatch.Draw(_gameAssets.MenuBackground, Vector2.Zero, Color.White); 
        spriteBatch.DrawString(_gameAssets.TextMenuStateTitle, titleText, titlePosition, Color.Yellow); 
        _player.Draw(spriteBatch);
        
    } 
}
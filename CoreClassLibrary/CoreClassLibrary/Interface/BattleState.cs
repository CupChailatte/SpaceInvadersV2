using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CoreClassLibrary.Managers;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Interface;
using CoreClassLibrary.Assets;

namespace CoreClassLibrary.Interface;

public class BattleState : IGameState
{
    public int TargetWidth => 800;
    public int TargetHeight => 1200;
    public ContentManager Content;
    private GraphicsDevice _graphics;
    private GameStateManager _gameStateManager;
    public GameAssets _gameAssets;
    private InputManager _input;
    public BulletManager _bulletManager; 


    private Player _player;
    public Vector2 textStatusPosition;
    public string statusText;

    private int _playerHealth;
    private int score; 


    // note to self , glöm inte att kalla på construktorn! 
    public BattleState(GameStateManager gameStateManager, GameAssets gameAssets, InputManager input, BulletManager bulletManager)
    {
        _gameStateManager = gameStateManager;
        _gameAssets = gameAssets;
        _input = input;
        _bulletManager = bulletManager; 

    }

    public void Initialize(GraphicsDevice graphicsDevice)
    {
        _graphics = graphicsDevice;  
        _playerHealth = 100; 
        score = 0; 
    
        statusText = $"HEALTH: {_playerHealth} SCORE : {score}"; 
        textStatusPosition = new Vector2(10, 10);

        float startX = (TargetWidth / 2f - _gameAssets.PlayerSprite.Width / 2f);
        float startY = (TargetHeight - _gameAssets.PlayerSprite.Height);
        Vector2 startPosition = new Vector2(startX, startY);
        _player = new Player(_gameAssets.PlayerSprite, startPosition, _playerHealth, 500f, false, score, _input, _graphics, _bulletManager);

    }
    public void LoadContent(ContentManager content)
    {
        _bulletManager = new BulletManager(content); 
    }
    public void UnloadContent() { }
    public void Update(GameTime gameTime)
    {

        _player.Update(gameTime);

        _bulletManager.Update(gameTime); 
        _player.Shoot();

    }
    public void Draw(SpriteBatch spriteBatch)
    {
     
        spriteBatch.Draw(_gameAssets.MenuBackground, Vector2.Zero, Color.White);
        spriteBatch.DrawString(_gameAssets.TextBattleStatus, statusText, textStatusPosition, Color.Yellow);
        _player.Draw(spriteBatch);
        _bulletManager.Draw(spriteBatch); 
    }
}
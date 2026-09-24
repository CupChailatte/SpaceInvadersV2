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

    private GameStateManager _gameStateManager;
    public GameAssets _gameAssets;
    private InputManager _input;
    private GraphicsDevice _graphics;

    private Player _player;
    public Vector2 textStatusPosition;
    public string statusText;

    private int _playerHealth;


    // note to self , glöm inte att kalla på construktorn! 
    public BattleState(GameStateManager gameStateManager, GameAssets gameAssets, InputManager input)
    {
        _gameStateManager = gameStateManager;
        _gameAssets = gameAssets;
        _input = input;

    }

    public void Initialize(GraphicsDevice graphicsDevice)
    {

        _playerHealth = 100; 
        _graphics = graphicsDevice;
        float startX = (TargetWidth / 2f - _gameAssets.PlayerSprite.Width / 2f);
        float startY = (TargetHeight - _gameAssets.PlayerSprite.Height);
        Vector2 startPosition = new Vector2(startX, startY);
        _player = new Player(_gameAssets.PlayerSprite, startPosition, _playerHealth, 500f, true, false, _input, _graphics);

    }
    public void LoadContent(ContentManager _content)
    {
    }
    public void UnloadContent() { }
    public void Update(GameTime gameTime)
    {

        _player.Update(gameTime);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        statusText = $"HEALTH: {_playerHealth} SCORE : 0"; // UPDATE THIS LATER 
        textStatusPosition = new Vector2(10, 10);
        spriteBatch.Draw(_gameAssets.MenuBackground, Vector2.Zero, Color.White);
        spriteBatch.DrawString(_gameAssets.TextBattleStatus, statusText, textStatusPosition, Color.Yellow);
        _player.Draw(spriteBatch);
    }
}
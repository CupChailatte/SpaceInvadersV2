using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CoreClassLibrary.Managers;
using CoreClassLibrary.Entities;

namespace CoreClassLibrary.Interface;

public class BattleState : IGameState
{
    private GameStateManager _gameStateManager;
    private GraphicsDevice _display;
    private UIManager _UIManager;
    private InputManager _input;

    private Player _player;

    private int screenWidth; 
    private int screenHeight;

    public BattleState(GameStateManager gameStateManager, UIManager UIManager)
    {
        _gameStateManager = gameStateManager;
        _UIManager = UIManager;
    }

    public void Initialize(GraphicsDevice graphicsDevice)
    {
        _input = new InputManager();
        screenWidth = _display.Viewport.Width;
        screenHeight = _display.Viewport.Height;
    }

    public void LoadContent(ContentManager content)
    {
        Texture2D playerSprite = content.Load<Texture2D>("Ship_01-1");

        float startX = (screenWidth / 2f - playerSprite.Width / 2f);
        float startY = (screenHeight - playerSprite.Height - 20f);
        Vector2 playerStartPosition = new Vector2(startX, startY);
        _player = new Player(playerSprite, playerStartPosition, 100, 500f, true, false, _input, _display);
    }

    public void UnloadContent() { }

    public void Update(GameTime gameTime)
    {
        _player.Update(gameTime);
        _input.Update();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _player.Draw(spriteBatch);
    }



}
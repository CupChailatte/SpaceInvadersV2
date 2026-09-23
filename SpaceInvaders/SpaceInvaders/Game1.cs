using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Managers;
using CoreClassLibrary.Interface; 

namespace SpaceInvaders;

public class Game1 : Game
{
    //---- MANAGERS ----

    private GameStateManager _gameStateManager; 
    private UIManager _UIManager; 
    private GraphicsDeviceManager _graphics;
    private SettingsManager _display; 
    private InputManager _input; 
    private SpriteBatch _spriteBatch;
    private Player _player; 

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        _UIManager = new UIManager(); 
        _gameStateManager = new GameStateManager(); 
        //_display = new SettingsManager(_graphics, 750,1300, false);

        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here (Gör så att jag kan avända mina objekt)
        // _input = new InputManager(); 
        Window.Title = "SPACE INVADERSV2";

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        // ----PLAYER---- 
        // Texture2D _playerSprite = Content.Load<Texture2D>("Ship_01-1");
        _UIManager.LoadContent(Content); 
        _gameStateManager.AddState(GameStateType.MainMenu, new MainMenuState(_gameStateManager, _UIManager));
        _gameStateManager.AddState(GameStateType.BattleScreen, new BattleState(_gameStateManager, _UIManager));  
        _gameStateManager.ChangeState(GameStateType.MainMenu); 
        _gameStateManager.ChangeState(GameStateType.BattleScreen); 

        // float startX = (_display.Width / 2f - _playerSprite.Width /2f); 
        // float startY = (_display.Height - _playerSprite.Height -20f); 
        // Vector2 _playerSpriteStartPosition = new Vector2(startX, startY); 
        // _player = new Player(_playerSprite,_playerSpriteStartPosition, 100, 600f, true, false, _input, _display); 
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _gameStateManager.Update(gameTime); 
        // TODO: Add your update logic here
        // _input.Update(); 
        // _player.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(); 
        // _player.Draw(_spriteBatch);
        _gameStateManager.Draw(_spriteBatch);
        _spriteBatch.End(); 

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}

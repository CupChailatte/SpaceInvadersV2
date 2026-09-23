using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Managers;
using CoreClassLibrary.Interface; 
using System; 

namespace SpaceInvaders;

public class Game1 : Game
{
    //---- MANAGERS ----

    private GameStateManager _gameStateManager; 
    private UIManager _UIManager; 
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        _UIManager = new UIManager(); 
        //_display = new SettingsManager(_graphics, 750,1300, false);
        /*
        _graphics.PreferredBackBufferHeight = 1000;
        _graphics.PreferredBackBufferWidth = 600; 
        _graphics.ApplyChanges(); 
        */
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
 
        _gameStateManager = new GameStateManager(this, Content, _graphics ); 

        // TODO: use this.Content to load your game content here
        // ----PLAYER---- 
        // Texture2D _playerSprite = Content.Load<Texture2D>("Ship_01-1");
        _UIManager.LoadContent(Content); 
        _gameStateManager.AddState(GameStateType.MainMenuState, new MainMenuState(_gameStateManager, _UIManager));
        _gameStateManager.AddState(GameStateType.BattleState, new BattleState(_gameStateManager, _UIManager)); 
        _gameStateManager.ChangeState(GameStateType.BattleState); 

        

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

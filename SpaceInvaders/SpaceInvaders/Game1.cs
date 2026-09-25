using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Managers;
using CoreClassLibrary.Interface;
using CoreClassLibrary.Assets;
using System;
using System.Diagnostics;

namespace SpaceInvaders;

public class Game1 : Game
{
    //---- MANAGERS ----

    private GameStateManager _gameStateManager;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public InputManager input;
    private BulletManager _bulletManager;
    public Texture2D texture2D;
    public GameAssets gameAssets;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";


        gameAssets = new GameAssets();

        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here (Gör så att jag kan avända mina objekt)
        Window.Title = "SPACE INVADERSV2";
        input = new InputManager();
        _bulletManager = new BulletManager(Content);
        _gameStateManager = new GameStateManager(this, Content, _graphics);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);




        // TODO: use this.Content to load your game content here
        // ----PLAYER---- 
        //  Texture2D _playerSprite = Content.Load<Texture2D>(""");

        gameAssets.LoadContent(Content); // Laddar in alla mina assets! 


        _gameStateManager.AddState(GameStateType.MainMenuState, new MainMenuState(_gameStateManager, gameAssets, input, _bulletManager));
        _gameStateManager.AddState(GameStateType.BattleState, new BattleState(_gameStateManager, gameAssets, input, _bulletManager));
        _gameStateManager.ChangeState(GameStateType.MainMenuState);

        // float startX = (_display.Width / 2f - _playerSprite.Width /2f); 
        // float startY = (_display.Height - _playerSprite.Height -20f); 
        // Vector2 _playerSpriteStartPosition = new Vector2(startX, startY); 
        // _player = new Player(_playerSprite,_playerSpriteStartPosition, 100, 600f, true, false, _input, _display); 
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        input.Update();

        _gameStateManager.Update(gameTime);
        // TODO: Add your update logic here
        // _player.Update(gameTime);
        // Test 
        switch (true)
        {
            case var _ when input.IsKeyPressed(Keys.Enter):
                Console.WriteLine("Enter key called");
                _gameStateManager.ChangeState(GameStateType.BattleState);
                break;

            case var _ when input.IsKeyPressed(Keys.B):
                Console.WriteLine("B key called, returned to prevous screen");
                _gameStateManager.ChangeState(GameStateType.MainMenuState);
                break;


        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        // _player.Draw(_spriteBatch);
        _gameStateManager.Draw(_spriteBatch);
        _bulletManager.Draw(_spriteBatch);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}

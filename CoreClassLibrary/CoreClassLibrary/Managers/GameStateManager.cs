using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content; 
using System.Collections.Generic;
using CoreClassLibrary.Interface;
using CoreClassLibrary.Managers;
using System; 

namespace CoreClassLibrary.Managers;

public class GameStateManager
{
    private readonly Dictionary<GameStateType, IGameState> _states = new Dictionary<GameStateType, IGameState>();
    private IGameState _currentState;
    private ContentManager _content; 
    private GraphicsDevice _graphicsDevice;
    private GraphicsDeviceManager _graphicsDeviceManager;  
    private Game _game; 

    // Konstruktor! 
    public GameStateManager(Game game, ContentManager content, GraphicsDeviceManager graphicsDeviceManager)
    {
        _game = game; 
        _content = content; 
        _graphicsDeviceManager = graphicsDeviceManager; 
    }


    // Registerar key till value. T.ex Menu enum blir kopplad till MenuState skärmen. 
    public void AddState(GameStateType type, IGameState state)
    {
        _states[type] = state;
    }

    //---Ändrar gamestate genom enum värden 
    //---Jag lägger in i parametern en enum för att ändra fönstret- 
    public void ChangeState(GameStateType stateType) 
    {
        if (_states.TryGetValue(stateType, out var newState))
        {
            _currentState?.UnloadContent();
            _currentState = newState;
            _currentState.Initialize(_game.GraphicsDevice);

            //this does not work
            if(stateType == GameStateType.MainMenuState)
            {
                //Ändrar fönster storlek utifrån fönster storleken som finns i de olika fönster filerna t.ex MainMenu eller BattleState 
                _graphicsDeviceManager.PreferredBackBufferWidth = newState.TargetWidth; 
                _graphicsDeviceManager.PreferredBackBufferHeight = newState.TargetHeight;
            }

            switch (true)
            {
                case var _ when stateType == GameStateType.BattleState:
                _graphicsDeviceManager.PreferredBackBufferWidth = newState.TargetWidth; 
                _graphicsDeviceManager.PreferredBackBufferHeight = newState.TargetHeight;
                break; 
            }
            

            // applicerar ändringarna, jag glömmer detta hela tiden!! 
            _graphicsDeviceManager.ApplyChanges(); 

         
        }

    }

    public void Update(GameTime gameTime)
    {
        _currentState?.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _currentState?.Draw(spriteBatch);
    }
}


//* Dictionary har "key-value pair", nycklen leder till värdet i mitt fall GameStateType är Enums och IGameState är interface som är mina skärmar. 
/*
Dictionary<string, string> huvudstäder = new Dictionary<string,string>();
huvudstäder.Add("Sverige, Stockholm"); Key = "Sverige", Value/värde = "Stockholm"
huvudstäder.Add("Danmark, Köpenhamn");

---Loopa igenom min Dictionary
foreach (KeyValuePair<string, string> kvp in huvudstäder)
{
Console.WriteLine($"Land: {kvp.Key}, Huvudstad: {kvp.Value}")

}



*/ 
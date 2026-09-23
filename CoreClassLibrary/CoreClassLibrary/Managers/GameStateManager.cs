using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content; 
using System.Collections.Generic;
using CoreClassLibrary.Interface;

namespace CoreClassLibrary.Managers;

public class GameStateManager
{
    private readonly Dictionary<GameScreen, IGameState> _states = new Dictionary<GameScreen, IGameState>();
    private IGameState _currentState;
    private ContentManager _content; 


    // Registerar key till value. T.ex Menu enum blir kopplad till MenuState skärmen. 
    public void AddState(GameScreen type, IGameState state)
    {
        _states[type] = state;
    }

    //---Ändrar gamestate genom enum värden 
    //---Jag lägger in i parametern en enum för att ändra fönstret- 
    public void ChangeState(GameScreen stateType)
    {
        if (_states.TryGetValue(stateType, out var newState))
        {
            _currentState?.UnloadContent();

            _currentState = newState;
            _currentState.Initialize();
            _currentState.LoadContent(_content);
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
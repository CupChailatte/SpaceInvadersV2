using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using CoreClassLibrary.States; 
using System.Collections.Generic; 
using CoreClassLibrary.Interface; 

namespace CoreClassLibrary.Managers; 

public class GameStateManager
{
    private readonly Dictionary<GameStateType, IGameState> _states  = new Dictionary<GameStateType, IGameState>(); 
    private IGameState _currentState; 


    // Registerar key till value. T.ex Menu enum blir kopplad till MenuState skärmen. 
    public void AddState(GameStateType type, IGameState state)
    {
        _states[type] = state; 
    }
    
    //---Ändrar gamestate genom interface typen av IGameState 
    public void ChangeState(GameStateType stateType)
    {
        if (_states.TryGetValue(stateType, out var newState))
        {
             _currentState?.UnloadContent();

        _currentState = newState; 
        _currentState.Initialize(); 
        _currentState.LoadContent(); 
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
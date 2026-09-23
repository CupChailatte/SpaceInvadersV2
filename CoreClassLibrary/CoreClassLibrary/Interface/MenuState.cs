using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using CoreClassLibrary.Managers; 

namespace CoreClassLibrary.Interface; 

public class MenuState : IGameState
{
    private readonly GameStateManager  _stateManager; 
    private readonly UIManager _UIManager; 

    public MenuState(GameStateManager gameStateManager, UIManager uIManager)
    {
        _stateManager = gameStateManager; 
        _UIManager = uIManager; 
    }
    
}
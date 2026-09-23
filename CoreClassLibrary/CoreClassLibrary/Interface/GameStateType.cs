
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content; 
using System; 

namespace CoreClassLibrary.Interface; 
//* Interface/gränsnitt för att skapa mina skärmar

public enum GameStateType
{
    MainMenu, 
    BattleScreen, 
    PauseScreen, 
    GameOverScreen, 
    VictoryScreen, 
}
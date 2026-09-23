
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content; 

namespace CoreClassLibrary.Interface; 
//* Interface/gränsnitt för att skapa mina skärmar



public enum GameScreen
{
    MainMenu, 
    BattleScreen, 
    PauseScreen, 
    GameOverScreen, 
    VictoryScreen, 
}

public interface IGameState
{
    void Initialize(); 
    void LoadContent(ContentManager content);
    void UnloadContent(); 
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch); 

}
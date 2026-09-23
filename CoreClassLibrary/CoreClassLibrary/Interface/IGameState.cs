
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 

namespace CoreClassLibrary.Interface; 
//* Interface/gränsnitt för att skapa mina skärmar
public interface IGameState
{
    void Initialize(); 
    void LoadContent();
    void UnloadContent(); 
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch); 

}
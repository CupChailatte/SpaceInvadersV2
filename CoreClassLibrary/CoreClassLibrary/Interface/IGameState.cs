
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content; 

namespace CoreClassLibrary.Interface; 
//* Interface/gränsnitt för att skapa mina skärmar


public interface IGameState
{
    void Initialize(GraphicsDevice graphicsDevice); 
    void LoadContent(ContentManager content);
    void UnloadContent(); 
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch); 

}
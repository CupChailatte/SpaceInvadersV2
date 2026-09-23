using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Managers;
using System; 

namespace CoreClassLibrary.Entites;

public class UIButton
{
    private Texture2D _texture;
    private SpriteFont _font;
    private Vector2 _position;
    private string _text;
    private Rectangle _bounds;

    private InputManager _input; 
    public event Action OnClick; //? LEARN 

    public UIButton(Texture2D texture,
    SpriteFont font,
     Vector2 position,
      string text,
       Rectangle bounds,
        InputManager input)
    {
        _texture = texture;
        _font = font;
        _position = position;
        _text = text;
        // --- Ser till att den nya bounds håller sig till position och storlek av button entity
        _bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        _input = input; 
    }

    public void Update()
    {
        Vector2 mousePosition = _input.GetMousePosition(); 

        if (_bounds.Contains(mousePosition) && _input.IsLeftClick())
        {
            // Om spelaren trycker på kanppen 
            OnClick?.Invoke(); //? LEARN 
        }

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White); 
        //--- Centrerar texten i lådan av button 
        Vector2 textSize = _font.MeasureString(_text); 
        Vector2 textPosition = _position + new Vector2((_texture.Width - textSize.X) /2, (_texture.Height - textSize.Y) /2 );
        //Ritar up knapparna och dens text 
        spriteBatch.Draw(_texture, textPosition, _bounds, Color.Black); 

    }





}
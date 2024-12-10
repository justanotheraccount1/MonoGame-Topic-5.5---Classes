using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MonoGame_Topic_5._5___Classes
{
    public class Tribble
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;

        public Tribble(Texture2D texture, Rectangle rectangle, Vector2 speed)
        {
            _texture = texture;
            _rectangle = rectangle;
            _speed = speed;
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public Rectangle Rectangle
        {
            get { return _rectangle; }
        }
        public void Move(Rectangle window)
        {
            _rectangle.Offset(_speed);
            if (_rectangle.Right >= window.Right)
            {
                _rectangle.X = (window.Right - _rectangle.Width - 1);
                _speed.X *= -1;
            }
            if (_rectangle.Left <= 0)
            {
                _rectangle.X = 1;
                _speed.X *= -1;
            }
            if (_rectangle.Top <= 0)
            {
                _rectangle.Y = 1;
                _speed.Y *= -1;
            }
            
            if (_rectangle.Bottom >= window.Bottom)
            {
                _rectangle.Y = (window.Bottom - _rectangle.Height - 1);
                _speed.Y *= -1;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}

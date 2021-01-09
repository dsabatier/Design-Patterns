using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Flyweight reduces memory usage by reusing instrinsic properties,
/// fetching them on demand.  You do this by separating intrinsic and
/// extrinsic states
/// </summary>
namespace Design_Patterns.Flyweight
{
    public abstract class Sprite
    {
        // all sprites will have a position, color tint and texture2D
        protected string _name;
        protected int _x;
        protected int _y;
        protected SpriteProperties _spriteProperties;

        public Sprite(Color color, Texture2D texture)
        {
            _spriteProperties = new SpriteProperties(color, texture);
        }

        public void Draw()
        {
            Console.WriteLine($"Rendering a {_spriteProperties.Color.Name} {_spriteProperties.Color.Name} at ({_x}, {_y}!");
        }
    }

    public class StaticSprite : Sprite
    {
        public StaticSprite(Color color, Texture2D texture) : base(color, texture) { }
    }

    public class MovingSprite : Sprite
    {
        public MovingSprite(Color color, Texture2D texture) : base(color, texture) { }
    }

    public class SpriteProperties
    {
        public Color Color { get; private set; }
        public Texture2D Texture2D { get; private set; }

        public SpriteProperties(Color color, Texture2D texture2D)
        {
            Color = color;
            Texture2D = texture2D;
        }
    }

    public class SpriteFactory
    {
        Dictionary<string, Color> _colors = new Dictionary<string, Color>()
        {
            { "red", new Color() { Name = "red" } },
            { "blue", new Color() { Name = "blue" } }
        };

        Dictionary<string, Texture2D> _ghostTextures = new Dictionary<string, Texture2D>()
        {
            { "spooky", new Texture2D() { Name = "spooky" } },
            { "scary", new Texture2D() { Name = "scary" } }
        };


        public Sprite GetSprite(string color, string texture, bool moving)
        {
            if (moving)
                return new MovingSprite(_colors[color], _ghostTextures[texture]);
            else
                return new StaticSprite(_colors[color], _ghostTextures[texture]);
        }
    }

    public class Texture2D
    {
        public string Name;
    }

    public class Color
    {
        public string Name;
    }
}

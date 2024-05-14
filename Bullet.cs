using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RocketHero;

public class Bullet : KGameObject
{

    public Bullet(GraphicsDeviceManager g, Texture2D t, Vector2 p) : base(g, t, p) {

    }

    public Bullet(GraphicsDeviceManager g, Vector2 p) : base(g, p) {
        
    }

    public override void Update(GameTime gameTime)
    {
        collider.Y -= (int)(300 * gameTime.ElapsedGameTime.TotalSeconds);
        Console.WriteLine("Bullet updated: " + collider.Y);
        base.Update(gameTime);
    }

}

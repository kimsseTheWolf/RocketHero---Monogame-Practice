using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace RocketHero;

public class Rocket : KGameObject
{

    private float speed;
    private int health;
    public static float NORMAL_SPEED = 200;
    public static float FAST_SOEED = 400;

    public Rocket(GraphicsDeviceManager g, Texture2D t, Vector2 p) : base(g, t, p) {
        health = 100;
        speed = Rocket.NORMAL_SPEED;
    }

    public Rocket(GraphicsDeviceManager g, Vector2 p) : base(g, p) {
        health = 100;
        speed = Rocket.NORMAL_SPEED;
    }

    public override void Update(GameTime gameTime) {
        var key = Keyboard.GetState();

        if (key.IsKeyDown(Keys.W) || key.IsKeyDown(Keys.Up)) {
            collider.Y -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
        }

        if (key.IsKeyDown(Keys.S) || key.IsKeyDown(Keys.Down)) {
            collider.Y += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
        }

        if (key.IsKeyDown(Keys.D) || key.IsKeyDown(Keys.Right)) {
            collider.X += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
        }

        if (key.IsKeyDown(Keys.A) || key.IsKeyDown(Keys.Left)) {
            collider.X -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}

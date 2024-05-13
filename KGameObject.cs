using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RocketHero;

// The basic implementation for a game object with rectangular collision detection
public class KGameObject
{
    protected Texture2D texture;
    protected GraphicsDeviceManager graphics;
    protected Rectangle collider;

    public KGameObject(GraphicsDeviceManager g, Texture2D t, Vector2 p) {
        graphics = g;
        texture = t;

        // initialize the game object with collision
        collider = new Rectangle((int)p.X, (int)p.Y, texture.Width, texture.Height);
    }

    public KGameObject(GraphicsDeviceManager g, Vector2 p) {
        graphics = g;
        collider = new Rectangle((int)p.X, (int)p.Y, 1, 1);
    }

    public Texture2D GetTexture() {
        return texture;
    }

    public void SetTexture(Texture2D t) {
        texture = t;
        collider.Width = texture.Width;
        collider.Height = texture.Height;
    }

    public Vector2 GetPosition() {
        return new Vector2(collider.X, collider.Y);
    }

    public Rectangle GetCollider() {
        return collider;
    }

    public bool IsCollidingWith(KGameObject obj) {
        return collider.Intersects(obj.GetCollider());
    }

    public virtual void Update(GameTime gameTime) {
        return;
    }

    public virtual void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw(texture, collider, Color.White);
    }

}

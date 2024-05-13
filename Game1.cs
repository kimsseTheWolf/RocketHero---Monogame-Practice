using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RocketHero;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D rocketTexture;
    private Texture2D bulletTexture;

    Rocket rocket;
    List<Bullet> bullets;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        rocket = new Rocket(_graphics, new Vector2(0,0));
        bullets = new List<Bullet>();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        // load textures
        rocketTexture = Content.Load<Texture2D>("rocket");
        bulletTexture = Content.Load<Texture2D>("bullet");

        // apply textures
        rocket.SetTexture(rocketTexture);
    }

    protected override void Update(GameTime gameTime)
    {
        var kstate = Keyboard.GetState();
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        // global key binding
        if (kstate.IsKeyDown(Keys.Space)) {
            Console.WriteLine("Space pressed");
            bullets.Add(new Bullet(_graphics, bulletTexture, new Vector2(rocket.GetCollider().X + rocket.GetCollider().Width / 2, rocket.GetCollider().Y)));
        }

        // TODO: Add your update logic here
        // rocket updater
        rocket.Update(gameTime);

        // bullet updater
        for (var i = 0; i < bullets.Count; i++) {
            bullets[i].Update(gameTime);
            // collision detection
            if (bullets[i].GetCollider().Y <= 0) {
                // remove this element
                bullets.RemoveAt(i);
                i--;
                continue;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        rocket.Draw(_spriteBatch, 1f);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

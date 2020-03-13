using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CellularAutomaton.src.Worlds;
using CellularAutomaton.src.Worlds.common;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace CellularAutomaton
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		Dictionary<byte, Texture2D> GraphicsDict;

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		private Vector2 position;

		private int tileHeight;
		private int tileWidth;


		World World;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			this.IsFixedTimeStep = true;//false;

			double targetFPS = 30;

			this.TargetElapsedTime = TimeSpan.FromSeconds(1d / targetFPS);

			this.IsMouseVisible = true;
			//this.Window.AllowUserResizing = true;


		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();
			// TODO: Add your initialization logic here
			

			position = new Vector2(0, 0);

			int Width = 100;
			int Height = 40;
			byte Rule = 90;
			double percentInitiallyActive = 0.5;

			//int NumSeeds = Convert.ToInt32(Width * Height * percentInitiallyActive);

			//List<Coords> seeds = RandomCoordGenerator.GetCoords(Width, Height, percentInitiallyActive);
			List<Coords> seeds = new List<Coords>{ new Coords(Width / 2, 0) };

			World = new WolframWorld(Width,Height,Rule, seeds);



			//graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
			//graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
			//graphics.IsFullScreen = true;

			graphics.PreferredBackBufferWidth = 1600;
			graphics.PreferredBackBufferHeight = 800;
			graphics.ApplyChanges();


		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			GraphicsDict = new Dictionary<byte, Texture2D>
			{
				[1] = Content.Load<Texture2D>(@"Cells\LivingSprite-0001"),
				[0] = Content.Load<Texture2D>(@"Cells\deadSprite-0001")
			};

		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			
			// TODO: Add your update logic here


			World.Update();
			//World.PrintCellStates();

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			tileHeight = GraphicsDict[0].Height;
			tileWidth = GraphicsDict[0].Width;
			Rectangle sourceRectangle = new Rectangle(0, 0, tileHeight, tileWidth);
			Vector2 origin = new Vector2(0, 0);
			float rotation = 0;
			float scale = 0.5f;
			spriteBatch.Begin();

			

			for (int j = 0; j < World.GetHeight(); j++)
			{
				for (int i = 0; i < World.GetWidth(); i++)
				{
					position.X = i * tileWidth * scale;
					position.Y = j * tileHeight * scale;
					spriteBatch.Draw(GraphicsDict[World.GetState(i, j)], position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 1);
					
				}
			}




			spriteBatch.End();
			base.Draw(gameTime);
		}

	}
}

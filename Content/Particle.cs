using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleSystem
{
    class Particle
    {
        Vector2 position;
        Vector2 velocity;
        Vector2 acceleration;

        Texture2D _texture;

        public Particle(Vector2 givenPosition, Vector2 givenVelocity)
        {
            position = givenPosition;
            velocity = new Vector2(0, 0);
            acceleration = new Vector2(0, 1);

        }

        public Texture2D texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void update(long time)
        {
            
            position.X += (float) (velocity.X * time + .5 * acceleration.X * Math.Pow((double)time, 2.0f) );
            position.Y += (float) (velocity.Y * time + .5 * acceleration.Y * Math.Pow((double)time, 2.0f));

            velocity.X += (float) acceleration.X * time;
            velocity.Y += (float) acceleration.Y * time;
        }

        public Particle clone(Vector2 givenPosition)
        {
            Particle tempParticle = new Particle(givenPosition, velocity);
            tempParticle.texture = this.texture;
            return tempParticle;
        }
            
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleSystem
{
    class ParticleSystem
    {
        ArrayList emitters;


        long currentTime;
        long lastTime;
        long deltaTime;

        public ParticleSystem()
        {

            emitters = new ArrayList();
            lastTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public void tick(int gametime)
        {
            currentTime = gametime;
            deltaTime = lastTime - currentTime;

            foreach (Emitter emitter in emitters)
            {
                emitter.tick(deltaTime);
            }
        }

        public void draw(SpriteBatch batch)
        {
            batch.Begin();
            foreach (Emitter emitter in emitters)
            {
                foreach (Particle particle in emitter.particleArray)
                {
                    batch.Draw(particle.texture, particle.Position);
                }
            }
            batch.End();
        }

        public void addEmitter(Emitter emitter)
        {
            emitters.Add(emitter);
        }


    }
}

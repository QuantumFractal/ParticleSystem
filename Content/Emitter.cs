using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ParticleSystem
{
    class Emitter
    {
        ArrayList particles;
        
        int numParticles;
        Particle particleTemplate;
        Vector2 position;

        public Emitter(Vector2 givenPosition, int numParticles)
        {
            position = givenPosition;
            this.numParticles = numParticles;
            particles = new ArrayList();
        }

        public void emit(int numberOfParticles)
        {
            for (int x = 0; x < numberOfParticles; x++)
            {
                particles.Add(particleTemplate.clone(position));
            }
        }

        public ArrayList particleArray
        {
            get { return particles; }
            set { }
        }

        public Particle particletype
        {
            get { return particleTemplate; }
            set { particleTemplate = value; }
        }
        
        public void tick(long deltaTime)
        {
            foreach (Particle particle in particles)
            {
                particle.update(deltaTime);
            }
        }
    }
}

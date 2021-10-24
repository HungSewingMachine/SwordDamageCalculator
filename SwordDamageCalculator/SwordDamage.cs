using System;
using System.Collections.Generic;
using System.Text;

namespace DamageCalculation
{
    class SwordDamage
    {
        private const int BASE_DAMAGE = 3;  // Since these constants aren't going to be used
        private const int FLAME_DAMAGE = 2; // by other class, it makes sense to keep them private

        /// <summary>
        /// Contains the calculated damage
        /// </summary>
        public int Damage { get; private set; }

        private int roll;
        /// <summary>
        /// Sets or gets the 3d6 roll
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }

        private bool magic;
        /// <summary>
        /// True if the sword is magic, false otherwise
        /// </summary>
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        private bool flaming;
        /// <summary>
        /// True if the sword is flaming, false otherwise
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Calculate the damage based on the current properties
        /// </summary>
        private void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (magic) magicMultiplier = 1.75M;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (flaming) Damage += FLAME_DAMAGE;
        }
        /// <summary>
        /// The constructor calculates damage based on default Magic
        /// and Flaming value and a starting 3d6 roll
        /// </summary>
        /// <param name="startingRoll"></param>
        public SwordDamage(int startingRoll) // The constructor sets the backing field for the Roll property
        {                                    // then calls CalculateDamage to make sure the Damage propety is correct
            roll = startingRoll;
            CalculateDamage();
        }

    }
}

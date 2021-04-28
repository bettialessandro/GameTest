using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTest.Models
{
    public class PipeModel
    {
        public int DistanceFromLeft { get; set; } = 500;
        public int DistanceFromBottom { get; set; } = new Random().Next(0, 60);

        public int Speed { get; set; } = 2;

        public int Gap { get; set; } = 130;

        public int GapBottom => DistanceFromBottom + 300;

        public int GapTop => GapBottom + Gap;


        public bool IsOffScreen()
        {
            return DistanceFromLeft <= -60;

        }

        public void Move()
        {
            DistanceFromLeft -= Speed;

        }
        public bool IsCentered()
        {
            bool hasEnteredCenter = DistanceFromLeft <= (500 / 2) + (60 / 2);
            bool hasExitedCenter = DistanceFromLeft <= (500 / 2) - (60 / 2) - 60;

            // Trovo le coordinate e applico una logica AND per calcolare l'impatto 
            // 0 && 0 = 0
            // 0 && 1 = 0
            // 1 && 0 = 0
            // 1 && 1 = 1
            //
            return hasEnteredCenter && !hasExitedCenter;
        }
    }
}
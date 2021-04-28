using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTest.Models
{
    public class BirdModel
    {
        public int DistanceFromGround { get; set; } = 100;
        public int JumpStreanght { get; set; } = 50;

        public bool IsOnGround()
        {
            return DistanceFromGround <= 0;
        }

        public void Fall(int gravity)
        {
            DistanceFromGround -= Math.Min(gravity,DistanceFromGround);
        }

        public void Jump()
        {
            //Verifico che non passi fuori dallo schermo .
            if(DistanceFromGround <= 530)
                DistanceFromGround += JumpStreanght;
        }


    }
}

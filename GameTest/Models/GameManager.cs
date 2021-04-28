using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameTest.Models
{
    public class GameManager  
    {
        public BirdModel Bird { get; set; }
        public List<PipeModel> Pipes { get; set; }
        public bool IsRunning { get; set; } = false;

        public int score { get; set; }

        private readonly int _gravity = 2;

          public event EventHandler MainLoopCompleted;


        public GameManager()
        {
            Bird = new BirdModel();
            Pipes = new List<PipeModel>();
        }

        public async void MainLoop()
        {
            IsRunning = true;
            while(IsRunning)
            {

                MoveObjects();

                CheckForCollision();

                ManagePipes();
                
                

                score += 1;
                 
                //notifico che l'interfaccia è variata 
                MainLoopCompleted?.Invoke(this, EventArgs.Empty);

                
                
                await Task.Delay(20);
            }
        }

        public void StartGame()
        {
            if(!IsRunning)
            {
                Bird = new BirdModel();
                Pipes = new List<PipeModel>();
                MainLoop();
            }
            
        }

        public void GameOver()
        {
            IsRunning = false;
        }

        public void Jump()
        {
            if(IsRunning)
            {
                Bird.Jump();
            }
        }

        public void CheckForCollision()
        {
            //Verifico se l'oggetto ha ragiunto il terreno 
            if (Bird.IsOnGround())
                GameOver();

            var centeredPipe = Pipes.FirstOrDefault(p => p.IsCentered());

            if (centeredPipe != null)
            {
                bool hasCollidedwithBottom = Bird.DistanceFromGround < centeredPipe.GapBottom - 150;

                bool hasCollidedwithTop = Bird.DistanceFromGround + 45 > centeredPipe.GapTop - 150;

                if (hasCollidedwithBottom || hasCollidedwithTop)
                    GameOver();
            
            }
        }

        public void MoveObjects()
        {
            Bird.Fall(2);

            foreach (var pipe in Pipes)
            {
                pipe.Move();
            }
        }

        public void ManagePipes()
        {
            if (!Pipes.Any() || Pipes.Last().DistanceFromLeft <= 250)
                Pipes.Add(new PipeModel());

            if (Pipes.First().IsOffScreen())
                Pipes.Remove(Pipes.First());
        }

         

    }
}

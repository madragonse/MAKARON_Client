using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_lib
{
    class Player_Bomberman
    {
        public float posX, posY;
        private float speedX, speedY;
        private float accX, accY;
        private float acceleration, speed, mass;
        private float maxSpeed, maxAcceleration, maxForce, frictionX, frictionY;

        public Player_Bomberman(float posX, float posY)
        {
            this.posX = posX;
            this.posY = posY;

            this.speedX = 0;
            this.speedY = 0;
            this.accX = 0;
            this.accY = 0;
            this.acceleration = 0;
            this.speed = 0;
            this.mass = 1;
            this.maxSpeed = 9;
            this.maxAcceleration = 100;
            this.maxForce = 100;
            this.frictionX = 16f;
            this.frictionY = 16f;

        }


        /// <summary>
        /// deltatime in seconds
        /// </summary>
        /// <param name="deltaTime"></param>
        /// 
        public void update(float deltaTime, Dictionary<string, bool> buttons)
        {
            float xDir = 0, yDir = 0;
            if (buttons["W"])
            {
                yDir = -1;
            }

            if (buttons["S"])
            {
                yDir = 1;
            }

            if (buttons["A"])
            {
                xDir = -1;
            }

            if (buttons["D"])
            {
                xDir = 1;
            }

            this.update(deltaTime);


            this.SetAcceleration(xDir*25, yDir*25);
            //NOTE      odkomentuj to na dole aby ustawiać prędkość a nie przyspieszenie
            /*this.SetAcceleration(this.frictionX* xDir, this.frictionY* yDir);
            this.SetSpeed(2,xDir, yDir);*/
            
        }


        public void update(float deltaTime)
        {
            float aaX = 0;
            if (this.speedX > 0)
            {
                aaX = this.accX - this.frictionX;

            }
            else
            {
                aaX = this.accX + this.frictionX;

            }

            if ((Math.Abs(this.accX) < Math.Abs(this.frictionX)) && (Math.Abs(this.speedX) < Math.Abs(aaX * deltaTime)))
            {
                this.speedX = 0;
            }
            else
            {
                this.speedX += aaX * deltaTime;
            }

            float aaY = 0;
            if (this.speedY > 0)
            {
                aaY = this.accY - this.frictionY;

            }
            else
            {
                aaY = this.accY + this.frictionY;

            }

            if ((Math.Abs(this.accY) < Math.Abs(this.frictionY)) && (Math.Abs(this.speedY) < Math.Abs(aaY * deltaTime)))
            {
                this.speedY = 0;
            }
            else
            {
                this.speedY += aaY * deltaTime;
            }

            this.speed = (float)Math.Pow(Math.Pow(this.speedX, 2) + Math.Pow(this.speedY, 2), 0.5); 

            if (this.speed > this.maxSpeed)
            {
                this.SetSpeed(this.maxSpeed*0.99f, this.speedX, this.speedY);
                
            }

            this.posX += this.speedX * deltaTime;
            this.posY += this.speedY * deltaTime;

            /*float avX = this.speedX + this.accX * deltaTime / 2;
            if (Math.Abs(avX) < Math.Abs(this.frictionX * deltaTime * deltaTime / 2))
            {
                avX = 0;
            }
            else if (avX > 0)
            {
                avX -= this.frictionX * deltaTime;
            }
            else
            {
                avX += this.frictionX * deltaTime;
            }

            float avY = this.speedY + this.accY * deltaTime / 2;
            if (Math.Abs(avY) < Math.Abs(this.frictionY * deltaTime * deltaTime / 2))
            {
                avY = 0;
            }
            else if (avX > 0)
            {
                avY -= this.frictionY * deltaTime;
            }
            else
            {
                avY += this.frictionY * deltaTime;
            }*/

            /*this.posX += avX * deltaTime;
            this.posY += avY * deltaTime;
            this.speedX += this.accX * deltaTime;
            this.speedY += this.accY * deltaTime;
            this.speed = (float)Math.Pow(Math.Pow(this.speedX, 2) + Math.Pow(this.speedY, 2), 0.5);*/

            /*if (this.speed > this.maxSpeed)
            {
                this.SetSpeed(this.maxSpeed, this.speedX, this.speedX);
            }*/

            /*this.posX += this.speedX * deltaTime;
            this.posY += this.speedY * deltaTime;*/
        }



        public void SetSpeed(float xDir, float yDir)
        {
            this.speedX = xDir;
            this.speedY = yDir;

        }

        public void SetSpeed(float newSpeed, float xDir, float yDir)
        {
            float a = (float)( Math.Pow((Math.Pow(xDir, 2) + Math.Pow(yDir, 2)), 0.5)/ newSpeed) + 0.00000000001f;

            this.speedX = xDir/a;
            this.speedY = yDir/a;
        }

        public void SetAcceleration(float xDir, float yDir)
        {
            this.accX = xDir;
            this.accY = yDir;

        }

        public void SetAcceleration(float accelaration, float xDir, float yDir)
        {
            float a = (float)(Math.Pow(Math.Pow(accelaration, 2) / (Math.Pow(xDir, 2) + Math.Pow(yDir, 2)), 0.5));

            this.accX = a*xDir;
            this.accY = a*yDir;

        }



        public override string ToString()
        {
            return "Gracz:\nDirection X/Y: "+ this.speedX + " / "+ this.speedY + "Acceleration X / Y: " + this.accX + " / " + this.accY + "\nPosition X/Y: "+this.posX+" / "+this.posY;
        }



    }
}

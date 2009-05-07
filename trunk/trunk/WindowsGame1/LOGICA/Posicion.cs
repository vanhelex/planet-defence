using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1.LOGICA
{
    class Posicion
    {
        Vector3 pos;
        public Posicion()
        {
            pos.X = 0.0f;
            pos.Y = 0.0f;
            pos.Z = 0.0f;
        }
        public Posicion(float ang_theta,float ang_phi,float radio)
        {
            pos.X = ang_theta;
            pos.Y = ang_phi;
            pos.Z = radio;
        }
     
    #region accesores
        public Vector3 getPos
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }
        public float Theta 
        {
            get
            {
                return pos.X; 
            }
            set
            {
                pos.X = value;
            }
        }

        public float Phi
        {
            get
            {
                return pos.Y;
            }
            set
            {
                pos.Y = value;
            }
        }

        public float R
        {
            get
            {
                return pos.Z;
            }
            set
            {
                pos.Z = value;
            }
        }

#endregion

    }
}

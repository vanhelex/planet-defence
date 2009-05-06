using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.LOGICA
{
    class Posicion
    {
        float theta;
        float phi;
        float r;
        public Posicion()
        {
            theta = 0.0f;
            phi = 0.0f;
            r = 0.0f;
        }
        public Posicion(float ang_theta,float ang_phi,float radio)
        {
            theta = ang_theta;
            phi = ang_phi;
            r = radio;
        }

    #region accesores
        public float Theta 
        {
            get
            {
                return theta; 
            }
            set
            {
                theta = value;
            }
        }

        public float Phi
        {
            get
            {
                return phi;
            }
            set
            {
                phi = value;
            }
        }

        public float R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }

#endregion

    }
}

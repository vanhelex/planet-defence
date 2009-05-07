using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1.LOGICA
{
    abstract class Dibujable 
    {
        public Model Modelo;
        public Posicion pos;
        public float escala;
        public Vector3 rotacion;
        abstract public void paint(GraphicsDeviceManager g);
    }
}

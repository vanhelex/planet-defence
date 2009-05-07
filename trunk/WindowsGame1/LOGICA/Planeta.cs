using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;


namespace WindowsGame1.LOGICA
{

    class Planeta:Dibujable
    {
        Posicion[][] posiblesRutas;


        public Planeta(Model m)
        {
            Modelo = m;
            pos = new Posicion(0.0f, 0.0f, 0.0f);
            escala = 0.9f;
            rotacion = new Vector3(0.0f, 0.0f, 0.0f);
            

        }

        override public void paint(GraphicsDeviceManager g)
        {
            float aspectRatio = (float)g.GraphicsDevice.Viewport.Width / g.GraphicsDevice.Viewport.Height;

            foreach (ModelMesh mesh in Modelo.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = Matrix.CreateScale(escala);
                    effect.World *= Matrix.CreateTranslation(pos.getPos);
                    effect.World *= Matrix.CreateRotationX(rotacion.X);
                    effect.World *= Matrix.CreateRotationY(rotacion.Y);
                    effect.World *= Matrix.CreateRotationZ(rotacion.Z);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                               MathHelper.ToRadians(45.0f),
                              aspectRatio, 1.0f, 10.0f);
                    effect.View = Matrix.CreateLookAt(new Vector3(0.0f, 0.0f, 3.0f), Vector3.Zero,
                                Vector3.Up);
                    effect.EnableDefaultLighting();
                }
                mesh.Draw();
            }
        }
    }
    
}

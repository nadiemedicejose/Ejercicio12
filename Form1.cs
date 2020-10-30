using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graphics3DS;

namespace Ejercicio12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        Graphics3D g3;

        int escala = 5;
        int traslacion = 5;

        Point3DF[] puntos = new Point3DF[8];

        private void Whiteboard_Click(object sender, EventArgs e)
        {

        }

        private void Whiteboard_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g3 = new Graphics3D(g);
            e.Graphics.TranslateTransform(Whiteboard.Width / 2, Whiteboard.Height /2);
            Pen pluma = new Pen(Color.Fuchsia, 4);
            g3.DrawLine3D(pluma, puntos[0], puntos[1]);
            g3.DrawLine3D(pluma, puntos[1], puntos[2]);
            g3.DrawLine3D(pluma, puntos[2], puntos[3]);
            g3.DrawLine3D(pluma, puntos[3], puntos[0]);
            g3.DrawLine3D(pluma, puntos[4], puntos[5]);
            g3.DrawLine3D(pluma, puntos[5], puntos[6]);
            g3.DrawLine3D(pluma, puntos[6], puntos[7]);
            g3.DrawLine3D(pluma, puntos[7], puntos[4]);
            g3.DrawLine3D(pluma, puntos[0], puntos[4]);
            g3.DrawLine3D(pluma, puntos[1], puntos[5]);
            g3.DrawLine3D(pluma, puntos[2], puntos[6]);
            g3.DrawLine3D(pluma, puntos[3], puntos[7]);

            for (int i = 0; i < puntos.Length; i++)
            {
                PointF p = new PointF()
                {
                    // Calcular las esquinas del cubo en el plano X, Y, y Z
                    X = puntos[i].Z * (float)(Math.Cos(45 * Math.PI / 180) + puntos[i].X) - 3,
                    Y = puntos[i].Z * (float)(Math.Cos(45 * Math.PI / 180) + puntos[i].X) - 3
                };
                // Dibujar los puntos del cubo
                g.FillEllipse(new SolidBrush(Color.Yellow), new RectangleF(p, new SizeF(5F, 5F)));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Dibujar los 8 puntos del cubo
            puntos[0] = new Point3DF(-50, -50, -50);
            puntos[1] = new Point3DF(-50, -50, 50);
            puntos[2] = new Point3DF(-50, 50, 50);
            puntos[3] = new Point3DF(-50, 50, -50);
            puntos[4] = new Point3DF(50, -50, -50);
            puntos[5] = new Point3DF(50, -50, 50);
            puntos[6] = new Point3DF(50, 50, 50);
            puntos[7] = new Point3DF(50, 50, -50);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // Flecha derecha o izquierda, escalar X
                case Keys.Left:
                    EscalarX(false);
                    break;
                case Keys.Right:
                    EscalarX(true);
                    break;
                // Flecha arriba y abajo, escalar Y
                case Keys.Up:
                    EscalarY(true);
                    break;
                case Keys.Down:
                    EscalarY(false);
                    break;
                // Tecla Q y W, escalar en Z
                case Keys.Q:
                    EscalarZ(true);
                    break;
                case Keys.W:
                    EscalarZ(false);
                    break;
                // Tecla A y S, Trasladar en X
                case Keys.A:
                    TrasladarX(true);
                    break;
                case Keys.S:
                    TrasladarX(false);
                    break;
                // Tecla D y F, Trasladar en Y
                case Keys.D:
                    TrasladarY(true);
                    break;
                case Keys.F:
                    TrasladarY(false);
                    break;
            }
        }

        // Aplicar efectos de Escala X, Y, Z
        // Crear el método para hacer escala en el eje de las X --> 4, 5, 6, y 7
        private void EscalarX(bool aumentar_disminuir)
        {
            if (aumentar_disminuir)
            {
                // Aumenta tamaño cuando presiona Flecha Derecha - TRUE
                for(int i = 4; i < puntos.Length; i++)
                {
                    puntos[i].X += escala;
                }
            }
            else
            {
                // Disminuye tamaño cuando presiona Flecha Izquierda - FALSE
                for (int i = 4; i < puntos.Length; i++)
                {
                    puntos[i].X -= escala;
                }
            }
            Whiteboard.Refresh(); //Volver a los valores originales 
        }

        // Crear el método para hacer escala en el eje de las Y --> 2, 3, 6, y 7
        private void EscalarY(bool aumentar_disminuir)
        {
            if (aumentar_disminuir)
            {
                // Aumenta tamaño cuando presiona Flecha Arriba - TRUE
                puntos[2].Y += escala;
                puntos[3].Y += escala;
                puntos[6].Y += escala;
                puntos[7].Y += escala;
            }
            else
            {
                // Disminuye tamaño cuando presiona Flecha Abajo - FALSE
                puntos[2].Y -= escala;
                puntos[3].Y -= escala;
                puntos[6].Y -= escala;
                puntos[7].Y -= escala;
            }
            Whiteboard.Refresh(); //Volver a los valores originales 
        }

        // Crear el método para hacer escala en el eje de las Z --> 1, 2, 5, y 6
        private void EscalarZ(bool aumentar_disminuir)
        {
            if (aumentar_disminuir)
            {
                // Aumenta tamaño cuando presiona Q - TRUE
                puntos[1].Z += escala;
                puntos[2].Z += escala;
                puntos[5].Z += escala;
                puntos[6].Z += escala;
            }
            else
            {
                // Disminuye tamaño cuando presiona W - FALSE
                puntos[1].Z -= escala;
                puntos[2].Z -= escala;
                puntos[5].Z -= escala;
                puntos[6].Z -= escala;
            }
            Whiteboard.Refresh(); //Volver a los valores originales 
        }

        // Aplicar efectos de Traslación X, Y
        // Crear el método para trasladar en el eje de las X
        private void TrasladarX(bool der_izq)
        {
            if(der_izq)
            {
                // Mover la figura X unidades hacia la derecha
                for (int i = 0; i<puntos.Length; i++)
                {
                    puntos[i].X += traslacion;
                }
            } else
            {
                // Mover la figura X unidades hacia la izquierda
                for (int i = 0; i < puntos.Length; i++)
                {
                    puntos[i].X -= traslacion;
                }
            }
            Whiteboard.Refresh();
        }

        // Crear el método para trasladar en el eje de las X
        private void TrasladarY(bool arriba_abajo)
        {
            if (arriba_abajo)
            {
                // Mover la figura Y unidades hacia arriba
                for (int i = 0; i < puntos.Length; i++)
                {
                    puntos[i].Y += traslacion;
                }
            }
            else
            {
                // Mover la figura Y unidades hacia abajo
                for (int i = 0; i < puntos.Length; i++)
                {
                    puntos[i].Y -= traslacion;
                }
            }
            Whiteboard.Refresh();
        }

    }
}

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

        // ROTACION
        // Variables que determinan los ángulos en los cuales voy a rotar X y Y
        int angle_x = 0;
        int angle_y = 0;
        // Punto para saber en qué posición se encuentra el mouse para empezar a rotar
        Point posMouse;
        // Variable para determinar si se está moviendo o no el objeto
        bool movimiento;

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
            // Dibujar las líneas del eje X, Y y Z
            Pen pluma2 = new Pen(Color.LightPink, 2);
            g3.DrawLine3D(pluma2, -800, 0, 0, 800, 0, 0); // Eje X
            g3.DrawLine3D(pluma2, 0, -400, 0, 0, 400, 0); // Eje Y
            g3.DrawLine3D(pluma2, 0, 0, -600, 0, 0, 600); // Eje Z
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

            // Determinar el punto donde se encuentra el mouse al momento de rotar
            posMouse = new Point(0, 0);
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

        private void Whiteboard_MouseDown(object sender, MouseEventArgs e)
        {
            // Guardar puntos en los que se mueve el mouse
            posMouse = e.Location;
            // Accionar la variable de movimiento
            movimiento = true;
        }

        private void Whiteboard_MouseMove(object sender, MouseEventArgs e)
        {
            // Se activa cuando el mouse está en movimiento sobre la pantalla
            if (movimiento)
            {
                // Determino en qué ángulo me encuetro en X y Y
                angle_x = e.Location.X + posMouse.X;
                angle_y = e.Location.Y + posMouse.Y;

                if (angle_x > 0)
                {
                    angle_x = 1; // Rotando hacia la derecha
                } else if (angle_x < 0)
                {
                    angle_x = -1; // Rotando hacia la izq
                }

                if (angle_y > 0)
                {
                    angle_y = -1; // Rotando hacia abajo
                } else if (angle_y < 0)
                {
                    angle_y = 1; // rotando hacia arriba
                }

                puntos = Rotar(puntos, angle_x, angle_y);
                Whiteboard.Refresh();
            }
        }

        private void Whiteboard_MouseUp(object sender, MouseEventArgs e)
        {
            // Confirmar que ya no hay movimiento del mouse
            movimiento = false;
        }

        // Método que activa la Rotación del Objeto
        private Point3DF[] Rotar(Point3DF[] puntitos, double AnguloX, double AnguloY)
        {
            // Variable auxiliar que determina la rotación
            Point3DF aux = new Point3DF();
            // Convertir de grados a radianes
            double gradosX = (AnguloX * Math.PI) / 180;
            double gradosY = (AnguloY * Math.PI) / 180;

            // Recorremos todos los puntos para hacer la rotación
            for (int i = 0; i < puntos.Length; i++)
            {
                // Rotar eje Y
                aux.X = Convert.ToSingle(puntitos[i].X * Math.Cos(gradosX) - puntitos[i].Z * Math.Sin(gradosX));
                aux.Y = puntitos[i].Y;
                aux.Z = Convert.ToSingle(puntitos[i].Z * Math.Cos(gradosX) + puntitos[i].X * Math.Sin(gradosX));
                // Rotar eje X
                puntitos[i].X = aux.X;
                puntitos[i].Y = Convert.ToSingle(aux.Y * Math.Cos(gradosY) - aux.Z * Math.Sin(gradosY));
                puntitos[i].Z = Convert.ToSingle(aux.Z * Math.Cos(gradosY) + aux.Y * Math.Sin(gradosY));
            }

            return puntitos;
        }
    }
}

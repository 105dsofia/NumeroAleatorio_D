using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumeroAleatorio_D
{
    public partial class Form1 : Form
    { 
        int intentos =  0; //Inicilizar la variable de intentos 
        Random rand= new Random(); //Crear el objeto rand con la funcion Random
        int aleatoria = 0;
  
    
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            intentos = 5; //Cantidad de intentos
            textIntentos.Text = intentos.ToString();
            aleatoria = rand.Next(1, 100);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textnumeros.Text, out int num))
            {
                if (num == aleatoria)
                {
                    MessageBox.Show($"Ha ganado el juego, el numero es { aleatoria}" );
                    DialogResult resultado = MessageBox.Show("¿Quiere volver a jugar?", "Reintentar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.No)
                    {
                        MessageBox.Show("Gracias por jugar :)");
                        Application.Exit();
                    }
                    else
                    {
                        intentos = 5;
                        textIntentos.Text = intentos.ToString();
                        aleatoria = rand.Next(1, 100);
                    }
                }

                if(num > aleatoria)
                {
                    MessageBox.Show($"{num} es mayor al numero");
                    intentos = intentos - 1;
                    textIntentos.Text = intentos.ToString();

                }

                if (num < aleatoria)
                {
                    MessageBox.Show($"{num} es menor al numero");
                    intentos = intentos - 1;
                    textIntentos.Text = intentos.ToString();
                }

                if(intentos==0)
                {
                    DialogResult resultado = MessageBox.Show("Se acabaron los intento. ¿Quieres volver a intentarlo?", "Derrota :(", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (resultado == DialogResult.No)
                    {
                        MessageBox.Show("Suerte para la proxima");
                        Application.Exit();
                    }
                    else
                    {
                        intentos = 5;
                        textIntentos.Text = intentos.ToString();
                        aleatoria = rand.Next(1, 100);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese un numero valido");
            }
        }
    }
}

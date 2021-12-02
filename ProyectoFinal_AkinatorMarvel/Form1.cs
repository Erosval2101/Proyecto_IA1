using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

// Universidad de Guadalajara - CUCEI
// Inteligencia Artificial 1 - I7038 - D04
// Profesor: Ramiro Lupercio Coronel
// Proyecto Final: Akinator Edición Marvel con Perceptrón Multicapa

// Integrantes:
// Bañuelos Flores Erick Osvaldo - 214594531
// Muñoz Vazquez Yordi - 213436908


namespace ProyectoFinal_AkinatorMarvel
{
    public partial class Form1 : Form
    {
        string connectionString;
        int num_clas;
        int num_pregunta;
        int id;
        int tipo_personaje;
        String[] datosClasificacion;
        String[] preguntas;
        public Form1()
        {
            InitializeComponent();
            num_clas = 0;
            num_pregunta = 0;
            id = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conectar();
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void conectar()
        {
            connectionString = "server=127.0.0.1; database=akinator; Uid=root; Pwd=; port=3306; SslMode = none";
            MySqlConnection conexion = new MySqlConnection(connectionString);

            conexion.Open();
            MySqlDataReader reader = null;
            MySqlCommand cmd = new MySqlCommand("SHOW DATABASES;", conexion);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Base de datos conectada");
            }
            else
            {
                MessageBox.Show("No se pudo conectar a la base de datos");
            }
            conexion.Close();

        }

        public String[] obtenerClasificacion()
        {
            String[] datos = new string[5];
            int i = 0;
            connectionString = "server=127.0.0.1; database=akinator; Uid=root; Pwd=; port=3306; SslMode = none";
            MySqlConnection conexion = new MySqlConnection(connectionString);

            try
            {
                conexion.Open();
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM clasificacion;", conexion);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    datos[i] += reader.GetString(1);
                    i++;
                }
                conexion.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error con la base de datos. Excepción: " + ex.ToString());
            }
            return datos;
        }
        public String[] obtenerPregunta()
        {
            String[] datos = new string[28];
            int i = 0;
            connectionString = "server=127.0.0.1; database=akinator; Uid=root; Pwd=; port=3306; SslMode = none";
            MySqlConnection conexion = new MySqlConnection(connectionString);

            try
            {
                conexion.Open();
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM preguntas;", conexion);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    datos[i] += reader.GetString(1);
                    i++;
                }
                conexion.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error con la base de datos. Excepción: " + ex.ToString());
            }
            return datos;
        }

        // Botón Heroe = Opción 1
        private void btnHeroe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                    Vaya, vaya es Héroe... ok \n     Pasa a la parte centroal para que pueda\n \t   adivinar tu personaje, ", "Héroe");
            
            datosClasificacion = obtenerClasificacion();
            preguntas = obtenerPregunta();

            desactivarPanelInicio();
            activarPanelPreguntas();
            txtBoxPregunta.Text = "Tu personaje es: " + datosClasificacion[0] + "?";
            num_clas++;
            id = 1;
            tipo_personaje = 1;
        }

        // Botón Villano = Opción 2
        private void btnVillano_Click(object sender, EventArgs e)
        {
            datosClasificacion = obtenerClasificacion();
            preguntas = obtenerPregunta();

            desactivarPanelInicio();
            activarPanelPreguntas();
            txtBoxPregunta.Text = "Tu personaje es: " + datosClasificacion[0] + "?";
            num_clas++;
            id = 2;
            tipo_personaje = 2;
        }

        // Botón SI = Opción 1
        private void btnSi_Click(object sender, EventArgs e)
        {
            if (id == 1)
            {
                id = 3;
                txtBoxPregunta.Text = preguntas[num_pregunta];
                num_pregunta++;
            }
            if (id == 2)
            {
                id = 3;
                txtBoxPregunta.Text = preguntas[num_pregunta];
                num_pregunta++;
            }
            else if (id == 3)
            {
                id = 4;
                txtBoxPregunta.Text = preguntas[num_pregunta];
                num_pregunta++;
            }
            else if (id == 4)
            {
                id = 5;
                txtBoxPregunta.Text = preguntas[num_pregunta];
                num_pregunta++;
            }
            else if (id == 5)
            {
                verificarJuego();
            }
        }

        // Botón NO = Opción 2
        private void btnNo_Click(object sender, EventArgs e)
        {
            switch (id)
            {
                case 1:
                    if (num_clas == 5) //Si no adivina
                    {
                        desactivarPanelPreguntas();
                        MessageBox.Show("No adiviné cual era tu personaje !!!", "Me rindo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        txtBoxPregunta.Text = "Tu personaje es " + datosClasificacion[num_clas] + "?";
                        num_clas++;
                    }
                    break;
                case 2:
                    if (num_clas == 5) //Si no adivina
                    {
                        desactivarPanelPreguntas();
                        MessageBox.Show("No adiviné cual era tu personaje !!!", "Me rindo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        txtBoxPregunta.Text = "Tu personaje es " + datosClasificacion[num_clas] + "?";
                        num_clas++;
                    }
                    break;
                case 3:
                    if (num_pregunta == 28) //Si no adivina
                    {
                        desactivarPanelPreguntas();
                        MessageBox.Show("No adiviné cual era tu personaje !!!", "Me rindo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        txtBoxPregunta.Text = preguntas[num_pregunta];
                        num_pregunta++;
                    }
                    break;
                case 4:
                    if (num_pregunta == 28) //Si no adivina
                    {
                        desactivarPanelPreguntas();
                        MessageBox.Show("No adiviné cual era tu personaje !!!", "Me rindo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        txtBoxPregunta.Text = preguntas[num_pregunta];
                        num_pregunta++;
                    }
                    break;
                case 5:
                    if (num_pregunta == 28) //Si no adivina
                    {
                        desactivarPanelPreguntas();
                        MessageBox.Show("No adiviné cual era tu personaje !!!", "Me rindo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        txtBoxPregunta.Text = preguntas[num_pregunta];
                        num_pregunta++;
                    }
                    break;
                default:
                    break;
            }
        }

        public void verificarJuego()
        {
            //Inicia sesión en la base de datos
            connectionString = "server=127.0.0.1; database=akinator; Uid=root; Pwd=; port=3306; SslMode = none";
            MySqlConnection conexion = new MySqlConnection(connectionString);

            try
            {
                conexion.Open();
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("SELECT nombreAprendizaje FROM salida WHERE idEntrada= '"
                    + tipo_personaje + "' and idClasificacion= '" + num_clas + "' and idPregunta= '" + num_pregunta + "';", conexion);
                reader = cmd.ExecuteReader();
                if (reader.Read()) //Adivina el personaje
                {
                    lblRespuesta.Text = reader.GetString(0);
                    desactivarPanelPreguntas();
                    MessageBox.Show("Tu personaje es -->", "Ya lo Adiviné !!! ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else //Si no lo adivina
                {
                    desactivarPanelPreguntas();
                    MessageBox.Show("No adiviné cual era tu personaje !!!", "Me rindo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conexion.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error con la base de datos. Excepción: " + ex.ToString());
            }
        }

        // Iniciar de Nuevo = Borrar todo o reiniciar el juego
        private void btnVolverIntentar_Click(object sender, EventArgs e)
        {
            activarPanelInicio();
            MessageBox.Show("Selecciona si tu personaje es \n           Héroe o Villano", "Vamos de nuevo !!! ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            lblRespuesta.Text = "Personaje";        // Limpieza de respuesta
            txtBoxPregunta.Text = "";       // Limpieza de Preguntas
            id = 0;
            num_clas = 0;
            num_pregunta = 0;
            tipo_personaje = 0;
        }

        // Terminar Juego
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Deseas cerrar el juego?", "Terminar", MessageBoxButtons.OK, MessageBoxIcon.Question);  // Confirmación del cierre del juego
            MessageBox.Show(" Gracias por Jugar Akinator Edición Marvel !!! ");
            this.Close();       // Fin del Juego | Cerrar Programa

        }

        public void activarPanelInicio()
        {
            lblInicio.Visible = true;
            lblPregunta1.Visible = true;
            lblPersonaje1.Visible = true;
            label13.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            btnHeroe.Visible = true;
            btnVillano.Visible = true;
        }

        public void desactivarPanelInicio()
        {
            lblInicio.Visible = false;
            lblPregunta1.Visible = false;
            lblPersonaje1.Visible = false;
            label13.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            btnHeroe.Visible = false;
            btnVillano.Visible = false;
        }

        public void activarPanelPreguntas()
        {
            btnSi.Visible = true;
            btnNo.Visible = true;
            txtBoxPregunta.Visible = true;
            lblPregunta2.Visible = true;
        }

        public void desactivarPanelPreguntas()
        {
            btnSi.Visible = false;
            btnNo.Visible = false;
            txtBoxPregunta.Visible = false;
            lblPregunta2.Visible = false;
        }

        // Caja de Texto de 
        private void txtBoxPregunta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

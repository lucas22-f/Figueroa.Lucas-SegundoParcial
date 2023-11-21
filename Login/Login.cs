using App;
using Sistema_Tienda;
using Sistema_Tienda.Exepciones;
using System;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        private Usuario usuario;
        public delegate void LoginPosibleError(string mensaje);
        public string TxtBoxCorreo
        {
            get { return this.txtboxCorreo.Text; }
            set { this.txtboxCorreo.Text = value; }
        }
        public string TxtBoxClave
        {
            get { return this.txtBoxClave.Text; }
            set { this.txtBoxClave.Text = value; }
        }
        public Login()
        {
            InitializeComponent();
            this.usuario = new Usuario();
            this.progresBarLogin.Visible = false;
            this.lblProgressBar.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Seguro ? ", "Atencion! Cerrar sistema ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }

        }



        private async void button1_Click(object sender, EventArgs e)
        {

            this.MostrarIndicadorCarga();

            try
            {
                // en esta parte quise crear una barra de carga para simular el ingreso al sistema por lo que tuve que investigar 
                //el funcionamiento de la clase Progress. 

                // primero instanciamos la clase generica con el tipo int que vamos a usar para rellenar la barra de progreso. 
                // y guardamos la instancia en la variable progress. 

                // luego le pasamos al constructor el delegado por que es un Action: la funcion lambda para actualizar el valor de la barra



                var progress = new Progress<int>(valor => { progresBarLogin.Value = valor; });

                // Simula el inicio de sesión de forma asincrónica
                // en esta parte llamamos a la funcion que ejecuta el task  " SimularInicioSesion" con su parametro progress. de tipo Progress<int>.  
                await Task.Run(async () =>
                {
                    await SimularInicioSesion(progress);
                });
                if (progresBarLogin.Value == 100)
                {
                    this.OcultarIndicadorCarga();
                }

                List<Usuario> usersEntrada = DeserializarUsuarios();
                if (verificarUsuario(usersEntrada))
                {
                    PantallaPrincipal pantalla = new PantallaPrincipal(this.usuario, this);
                    pantalla.StartPosition = FormStartPosition.CenterScreen;
                    pantalla.Show();
                    this.Hide();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OcultarIndicadorCarga();
            }


        }


        private bool verificarUsuario(List<Usuario> usuarios)
        {
            Usuario? res = null;
            bool rta = false;
            string correoEntrada = this.txtboxCorreo.Text;
            string claveEntrada = this.txtBoxClave.Text;

            ErrorLoginExepcion err = new("Error al ingresar Correo / Contraseña");


            LoginPosibleError delegadoLoginErr = null;


            delegadoLoginErr += err.LanzarError;



            foreach (Usuario usuario in usuarios)
            {
                if (usuario.correo == correoEntrada && usuario.clave == claveEntrada)
                {

                    this.usuario = usuario;
                    res = usuario;
                    rta = true;
                    break;
                }


            }

            try
            {
                if (res == null)
                {
                    delegadoLoginErr.Invoke(err.Message);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            return rta;


        }


        private List<Usuario> DeserializarUsuarios()
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("../../../Data/MOCK_DATA.json"))
                {
                    string json_str = sr.ReadToEnd();

                    List<Usuario> listaUsers = (List<Usuario>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Usuario>));

                    return listaUsers;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return new List<Usuario>();
            }
        }

        private async Task SimularInicioSesion(IProgress<int> progress)
        {
            /*La interfaz IProgress<T> es una interfaz que Progress<T> implementa. En términos más simples, Progress<T> 
             * es una implementación concreta de IProgress<T>. Entonces, cuando recibes un parámetro del tipo IProgress<int> progress, 
             * puedes pasarle una instancia de Progress<int> sin problemas, ya que Progress<int> es compatible con la interfaz IProgress<int>*/


            //definimos un tope de 100 para la barra. y creamos el for que va de 0 a 100
            int pasos = 100;
            this.lblProgressBar.Visible = true;
            for (int i = 0; i < pasos; i++)
            {
                // Ponemos el delay. 
                await Task.Delay(10);

                //Ejecutamos el la funcion Report de la interfaz Iprogress pasandole el porcentaje : 
                progress.Report((i + 1) * 100 / pasos);

                await this.ActualizarLabelProgreso($"Cargando... {i + 1}%");
            }
        }

        private async Task ActualizarLabelProgreso(string mensaje)
        {
            lblProgressBar.Text = mensaje;
            await Task.Delay(5);
        }

        private void MostrarIndicadorCarga()
        {
            progresBarLogin.Visible = true;
            this.lblProgressBar.Visible = true;

        }

        private void OcultarIndicadorCarga()
        {
            this.progresBarLogin.Visible = false;
            this.lblProgressBar.Visible = false;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7_CLopez.Modelos;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7_CLopez
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSel;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> borrar;
        IEnumerable<Estudiante> actualizar;

        public Elemento(int id)
        {
            InitializeComponent();
            idSel = id;
            con = DependencyService.Get<DataBase>().GetConnection();

        }

        public static IEnumerable<Estudiante> borrar1(SQLiteConnection db, int id) 
        {
            return db.Query<Estudiante>("Delete from Estudiante Where id = ?", id);
        }

        public static IEnumerable<Estudiante> actualizar1(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("Update Estudiante set Nombre = ?, Usuario=?, Contrasena=?, id=?", nombre, usuario, contrasena, id);
        }


        private void btnActualiza_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                actualizar = actualizar1(db, idSel, txtNombre.Text, txtUsuario.Text, txtContrasena.Text);
                DisplayAlert("Alerta", "Actualizado", "OK");

            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                borrar = borrar1(db, idSel);
                DisplayAlert("Alerta", "Eliminado Correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }
    }
}
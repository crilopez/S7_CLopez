using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ConsultaRegistro : ContentPage
    {

        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;


        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            Datos();

        }

        public async void Datos() 
        {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(Resultado);
            ListaEstudiantes.ItemsSource = tablaEstudiante;

        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.id.ToString();
            var IdSeleccionado = Convert.ToInt32(item);

            try
            {
                Navigation.PushAsync(new Elemento(IdSeleccionado));
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }
    }
}
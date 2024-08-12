namespace Suma1925597
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _localDBService;
        private int _editResultadoId;
        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _localDBService = dbService;
            Task.Run(async () => listview.ItemsSource = await _localDBService.GetResultados());
        }

        

        private async void sumarBtn_Clicked(object sender, EventArgs e)
        {
            var suma = (Convert.ToDouble(entryN1.Text) + Convert.ToDouble(entryN2.Text)).ToString();
            if (_editResultadoId == 0)
            {
                
                //Agrega resultado
                await _localDBService.Create(new Resultado
                {
                    Numero1 = entryN1.Text,
                    Numero2 = entryN2.Text,
                    Suma = suma
                });
            }
            else
            {
                //Edita resultado
                await _localDBService.Update(new Resultado
                {
                    Id = _editResultadoId,
                    Numero1 = entryN1.Text,
                    Numero2 = entryN2.Text,
                    Suma = suma
                });
                _editResultadoId = 0;
            }

            entryN1.Text = string.Empty;
            entryN2.Text = string.Empty;
            labelResultado.Text = string.Empty;
            listview.ItemsSource = await _localDBService.GetResultados();
        }

        private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var resultado = (Resultado)e.Item;
            var action = await DisplayActionSheet("Acciones", "Cancelar", null, "Editar", "Eliminar");

            switch (action)
            {
                case "Editar":
                    _editResultadoId = resultado.Id;
                    entryN1.Text = resultado.Numero1;
                    entryN2.Text = resultado.Numero2;
                    labelResultado.Text = resultado.Suma;
                    break;

                case "Eliminar":
                    await _localDBService.Delete(resultado);
                    listview.ItemsSource = await _localDBService.GetResultados();
                    break;
            }
        }
    }

}

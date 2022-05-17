using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImagenesXamarin
{
    public partial class MainPage : ContentPage
    {
        //Constructor de la main page o pagina principal.
        public MainPage()
        {
            InitializeComponent();

            //Cargar dinamicamente imagen desde Code Behind..
            LogoEmpresa.Source = FileImageSource.FromFile("logomain.png");
            //LoogEmpresa es el nombre del objeto de tipo image que tenemos en el code XAML
            //< Image  x: Name = "LogoEmpresa" ></ Image >

            //Esto para setear el alto de la imagen.
            LogoEmpresa.HeightRequest = 30;
            //Esto para desplegar la imagen al centro, si se necesita realizar desde code behind
            LogoEmpresa.HorizontalOptions = LayoutOptions.Center;


            //esto equivale a hacer esto en xaml
            //<Image Source="logomain.png"></Image>


            //Esto es para cargar completamente la imagen desde 0, creando el objeto desdel code behind o codigo c#
            var imagen = new Image() { Source = "logomain.png" };
            //Agregamos la imagen dinamicamente al contenido de nuestra pagina.

            //agregar la imagen al stack layout
            contenido.Children.Add(imagen);
            //Seteamos el contenido o la imagen al centro
            imagen.HorizontalOptions = LayoutOptions.Center;
            //el alto de la imagen lo seteamos a 30px
            imagen.HeightRequest = 30;


            //agregar una imagen desde un directorio o server remoto, 
            //primero creamos un objeto de tipo UriImageSource y seteamos la propiedad Uri con una instancia que recibe un string con la ruta de la imagen
            //segundo seteamos si estará habilitada la opción de la memoria caché
            var origen = new UriImageSource()
            {
                Uri = new Uri("https://images.unsplash.com/photo-1545670723-196ed0954986?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=873&q=80"),
                CachingEnabled = true
            };

            //creamos la imagen dinamicamente y asignamos el origen o objeto de tipo UriImageSource que creamos previamente
            var imagenDinamica = new Image() { Source = origen };
            //Luego seteamos el alto de la imagen en 100
            imagenDinamica.HeightRequest = 100;
            //Luego centramos
            imagenDinamica.HorizontalOptions = LayoutOptions.Center;

            //Agregamos al contenido de nuestra pagina.
            contenido.Children.Add(imagenDinamica);

            //Debemos crear un objeto o instancia de tipo ActivityIndicator la cual le seteamos la propiedad de Color.
            var indicador = new ActivityIndicator { Color = new Color(.5) };
            //luego seteamos el binding o activity Property el momento en que se mostrará, y es cuando se este cargando
            indicador.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
            //y el bindingcontext será nuestro objeto de image que hayamos creado en este caso es imagenDinamica.
            indicador.BindingContext = imagenDinamica;
            //finalmente el objeto de tipo ActivityIndicator lo agregamos, utilizando el identificador que usamos en este caso que
            //es indicador.
            contenido.Children.Add(indicador);

            

            //Creamos el origen de una imagen Con un objeto de tipo UriImageSource
            UriImageSource OrigenImagen2 = new UriImageSource()
            {
                Uri = new Uri("https://images.unsplash.com/photo-1504805572947-34fad45aed93?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"),
                CachingEnabled = true
            };

            //Creamos la imagen dinamicamente 
            var ImagenDinamica2 = new Image() { Source = OrigenImagen2 };

            ImagenDinamica2.HorizontalOptions = LayoutOptions.Center;
            ImagenDinamica2.HeightRequest = 100;

            ActivityIndicator ActivityIndicador = new ActivityIndicator() { Color = new Color(.5)};
            ActivityIndicador.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
            ActivityIndicador.BindingContext = ImagenDinamica2;

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.Children.Add(ImagenDinamica2);
            grid.Children.Add(ActivityIndicador);

            contenido.Children.Add(grid);

            //otra forma de setear contenido es con la propiedad content
            //Content = grid;

        }
    }
}

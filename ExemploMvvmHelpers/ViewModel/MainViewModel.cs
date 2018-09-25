using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ExemploMvvmHelpers.Model;
using MvvmHelpers;
using Xamarin.Forms;
using ExemploMvvmHelpers.Services;
using System.Linq;

namespace ExemploMvvmHelpers.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Usuario> Usuarios { get;}
        public ObservableRangeCollection<Grouping<string, Usuario>> UsuariosAgrupados { get;}
        public Command ObterUsuariosCommand { get; }
        UsuarioService _Service;

        public MainViewModel()
        {
            this.Title = "Usuarios";
            Usuarios = new ObservableRangeCollection<Usuario>();
            UsuariosAgrupados = new ObservableRangeCollection<Grouping<string, Usuario>>();

            _Service = new UsuarioService();

            ObterUsuariosCommand = new Command(async () => await ObterUsuarios());
        }

        public async Task ObterUsuarios()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var usuarios = _Service.ObterUsuarios();

                if (!Usuarios.Any())
                    Usuarios.AddRange(usuarios);

                Agrupar();

                this.Title = $"Usuarios {Usuarios.Count}";
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro ao carregar", ex.Message,"Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void Agrupar()
        {
            var agrupado = from usuario in Usuarios
                           orderby usuario.Nome
                           group usuario by usuario.NomeAgrupado into usuarioAgrupado
                           select new Grouping<string, Usuario>(usuarioAgrupado.Key, usuarioAgrupado);

            if (!UsuariosAgrupados.Any())
                UsuariosAgrupados.AddRange(agrupado);
        }
    }
}

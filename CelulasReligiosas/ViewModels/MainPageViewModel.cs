using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CelulasReligiosas.model;
using Firebase.Database;
using Firebase.Database.Streaming;
using Xamarin.Forms;
namespace CelulasReligiosas.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly string ENDERECO_FIREBASE = "https://celula-religiosa.firebaseio.com/";
        private readonly FirebaseClient _firebaseClient;

        private ObservableCollection<Celula> _celulas;

        public ObservableCollection<Celula> Celulas
        {
            get { return _celulas; }
            set { _celulas = value; OnPropertyChanged(); }
        }

        public Celula CelulaSelecionada;

        public ICommand AceitarCelulaCmd { get; set; }

        public MainPageViewModel()
        {
            _firebaseClient = new FirebaseClient(ENDERECO_FIREBASE);
            Celulas = new ObservableCollection<Celula>();
            AceitarCelulaCmd = new Command(() => AceitarCelula());
            ListenerCelulas();
        }

        private void AceitarCelula()
        {
            CelulaSelecionada.Key = "";
            _firebaseClient
                .Child("Celulas");
                //.Child(CelulaSelecionada.Key)
                //.PutAsync(CelulaSelecionada);
        }

        private void ListenerCelulas()
        {
            _firebaseClient
                .Child("Celulas")
                .AsObservable<Celula>()
                .Subscribe(d =>
                {
                    if (d.EventType == FirebaseEventType.InsertOrUpdate)
                    {
                        //if (d.Object.Key == "")
                            AdicionarCelula(d.Key, d.Object);
                        //else
                            //RemoverCelula(d.Key);
                    }
                    else if (d.EventType == FirebaseEventType.Delete)
                    {
                        RemoverCelula(d.Key);
                    }
                });
        }

        private void AdicionarCelula(string key, Celula celula)
        {
            Celulas.Add(new Celula()
            {
                Key = key,
                Nome = celula.Nome,
                Descricao = celula.Descricao,
                Endereco = celula.Endereco
            });
        }

        private void RemoverCelula(string key)
        {
            var celula = Celulas.FirstOrDefault(x => x.Key == key);
            Celulas.Remove(celula);
        }
    }
}

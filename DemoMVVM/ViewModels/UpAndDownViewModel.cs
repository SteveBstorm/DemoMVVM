using DemoMVVM.Models;
using DemoMVVM.Tools;
using DemoMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace DemoMVVM.ViewModels
{
    public class UpAndDownViewModel : ViewModelBase
    {
		private int _nombre;

		public int Nombre
		{
			get { return _nombre; }
			set { 
				if(_nombre != value)
				{
					_nombre = value;
					RaisePropertyChanged(nameof(Nombre));
				}
			}
		}

		private ObservableCollection<int> _listeValeur;

		public ObservableCollection<int> ListeValeur
		{
			get { return _listeValeur; }
			set { _listeValeur = value; }
		}

		private ObservableCollection<Nombre> _listeNombre;

		public ObservableCollection<Nombre> ListeNombre
		{
			get { return _listeNombre; }
			set { _listeNombre = value; }
		}



		private ICommand _increment, _decrement, _addNumber, _openWindow;

		public ICommand OpenWindow
		{
			get { return _openWindow ?? (_openWindow = new RelayCommand(() => {
				MaFenetre maFenetre = new MaFenetre();
				maFenetre.Show();
				App.Current.MainWindow.Hide();
			
			})); }
		}

		public ICommand Increment
		{
			get { return _increment ?? (_increment = new RelayCommand(Ajouter)); }
		}

		public ICommand Decrement
		{
			get { return _decrement ?? (_decrement = new RelayCommand(Retirer)); }
		}

		public ICommand AddNumber
		{
			get { return _addNumber ?? (_addNumber = new RelayCommand(AjouterListe)); }
		}

		public UpAndDownViewModel()
		{
			Nombre = 5;
			ListeValeur = new ObservableCollection<int>();
			ListeNombre = new ObservableCollection<Nombre>();
		}

		public bool CanDecrement()
		{
			return Nombre > 0;
		}

		public void Ajouter()
		{
			Nombre++;
		}

		public void Retirer()
		{
			Nombre--;
		}

		public void AjouterListe()
		{
			ListeValeur.Add(Nombre);
			ListeNombre.Add(new Nombre { Positif = Nombre, Negatif = -Nombre });
		}

	}
}

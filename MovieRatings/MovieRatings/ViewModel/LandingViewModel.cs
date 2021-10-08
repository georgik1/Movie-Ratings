using MovieRatings.Model;
using MovieRatings.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieRatings.ViewModel
{
   public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            movies = GetMovies();
        }

        ObservableCollection<Movie> movies;

        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
                OnPropertyChanged();
            }
        }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayMovie);

        private void DisplayMovie()
        {
           if(selectedMovie != null)
            {
                var viewModel = new DetailsViewModel { SelectedMovie = selectedMovie, Movies = movies, Position = movies.IndexOf(selectedMovie) };
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Movie> GetMovies()
        {
            //I know that in the real world we would have a database for this:
            return new ObservableCollection<Movie>
            {
                new Movie{Name = "The Shawshank Redemption", Rating = "5/5", Image ="shawshankRedemption.jpg", Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."},
                new Movie{Name = "The Godfather", Rating = "4.9/5", Image ="Godfather.jpg", Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son."},
                new Movie{Name = "Pulp Fiction", Rating = "4.5/5", Image ="PulpFiction.jpg", Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption."},
                new Movie{Name = "Star Wars: Episode V - The Empire Strikes Back", Rating = "4.4/5", Image ="StarWars.jpg", Description = "After the Rebels are brutally overpowered by the Empire on the ice planet Hoth, Luke Skywalker begins Jedi training with Yoda,  while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett."},
                new Movie{Name = "Gladiator", Rating = "4.1/5", Image ="Gladiator.jpg", Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery."}
          
            };
        } 
   }
}

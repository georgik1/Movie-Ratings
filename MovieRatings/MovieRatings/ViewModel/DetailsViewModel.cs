using MovieRatings.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieRatings.ViewModel
{
    class DetailsViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> movies;

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

        private int position;

        public int Position
        {
            get
            {
                if(position != movies.IndexOf(selectedMovie))
                {
                    return movies.IndexOf(selectedMovie);
                }
                return position;
            }
            set
            {
                position = value;
                selectedMovie = movies[position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        public ICommand ChangePositionComand => new Command(ChangePosition);

        private void ChangePosition(object obj)
        {
          string direction = (string)obj;

            if(direction == "L")
            {
                if(position == 0)
                {
                    Position = movies.Count - 1;
                    return;
                }
                Position -= 1;
            }
            else if(direction == "R")
            {
                if(position == movies.Count - 1)
                {
                    Position = 0;
                    return;
                }
                Position += 1;
            }
        }
    }
}

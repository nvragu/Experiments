﻿using System.ComponentModel;

namespace CaliburnMicroWithNoBaseClass.Views
{
	public partial class PersonView
	{
		public PersonView()
		{
            InitializeComponent();
            Activated += PersonView_Activated;
		}

        void PersonView_Activated(object sender, System.EventArgs e)
        {
            var personViewModel = (INotifyPropertyChanged)DataContext;
            personViewModel.PropertyChanged += PropertyChanged;
        }
        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var value = sender.GetType().GetProperty(e.PropertyName).GetValue(sender, null);
            eventsTextBox.Text = string.Format("PropertyChanged fired. \r\n\tPropertyName='{0}'\r\n\tPropertyValue='{1}'\r\n", e.PropertyName, value) + eventsTextBox.Text;
        }
	}
}

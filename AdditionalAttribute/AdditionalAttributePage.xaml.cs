using System;
using System.Collections;
using System.Collections.ObjectModel;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace AdditionalAttribute
{
	public partial class AdditionalAttributePage : ContentPage
	{
		private int indexOfAppointment = 0;
		private bool isNewAppointment = false;

		public AdditionalAttributePage()
		{
			InitializeComponent();
			schedule.CellTapped += CellTappedEventHandler;

			(editorLayout.BindingContext as EditorLayoutViewModel).AppointmentModified += EditorLayout_AppointmentModified;
		}

		#region EditorLayout_AppointmentModified
		private void EditorLayout_AppointmentModified(object sender, ScheduleAppointmentModifiedEventArgs e)
		{
			schedule.IsVisible = true;

			if (e.IsModified)
			{
				if (isNewAppointment)
				{
					(schedule.DataSource as ObservableCollection<Meeting>).Add(e.Appointment);
				}
				else
				{
					(schedule.DataSource as ObservableCollection<Meeting>).RemoveAt(indexOfAppointment);
					(schedule.DataSource as ObservableCollection<Meeting>).Insert(indexOfAppointment, e.Appointment);
				}
			}
		}
		#endregion

		void CellTappedEventHandler(object sender, CellTappedEventArgs e)
		{
			schedule.IsVisible = false;
			editorLayout.IsVisible = true;
			if (schedule.ScheduleView == ScheduleView.MonthView)
			{
				//create Apppointment
				editorLayout.OpenEditor(null, e.Datetime);
				isNewAppointment = true;
			}
			else
			{
				if (e.Appointment != null)
				{
					ObservableCollection<Meeting> appointment = new ObservableCollection<Meeting>();
					appointment = (ObservableCollection<Meeting>)schedule.DataSource;
					indexOfAppointment = appointment.IndexOf((Meeting)e.Appointment);
					editorLayout.OpenEditor((Meeting)e.Appointment, e.Datetime);
					isNewAppointment = false;
				}
				else
				{
					//create Apppointment
					editorLayout.OpenEditor(null, e.Datetime);
					isNewAppointment = true;
				}
			}
		}
	}
}

using System;

using Xamarin.Forms;

namespace AdditionalAttribute
{
	public class EditorLayoutViewModel : ContentPage
	{
		public virtual void OnAppointmentModified(ScheduleAppointmentModifiedEventArgs e)
		{
			EventHandler<ScheduleAppointmentModifiedEventArgs> handler = AppointmentModified;
			if (handler != null)
			{
				handler(this, e);
			}

		}
		public event EventHandler<ScheduleAppointmentModifiedEventArgs> AppointmentModified;
	}
	public class ScheduleAppointmentModifiedEventArgs : EventArgs
	{
		public Meeting Appointment { get; set; }
		public bool IsModified { get; set; }
	}
}


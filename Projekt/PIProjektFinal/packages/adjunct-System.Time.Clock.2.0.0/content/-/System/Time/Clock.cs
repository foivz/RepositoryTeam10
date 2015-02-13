namespace System.Time
{
	internal static class Clock {
		static Clock()
		{
			ResetNow();
			UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		}

		/// <summary>
		/// Gets or sets the <see cref="Func{DateTime}"/> that returns 'now'.
		/// </summary>
		/// <value>The now.</value>
		public static Func<DateTime> Now { get; set; }

		/// <summary>
		/// Gets the clocks date.
		/// </summary>
		public static DateTime Today
		{
			get { return Now().Date; }
		}
		/// <summary>
		/// Converts a UNIX time value to a <see cref="DateTime"/> value
		/// </summary>
		public static DateTime FromUnixTime(uint unixTime)
		{
			return UnixEpoch.AddSeconds(unixTime);
		}
		/// <summary>
		/// Converts a <see cref="DateTime"/> value to a UNIX time value
		/// </summary>
		public static uint ToUnixTime(DateTime dateTime)
		{
			// Create TimeSpan by subtracting the value provided from the Unix Epoch
			TimeSpan span = dateTime - UnixEpoch;

			// Return the total seconds (which is a UNIX timestamp)
			return (uint)span.TotalSeconds;
		}

		/// <summary>
		/// Gets the Unix epoch.
		/// </summary>
		/// <value>The Unix epoch.</value>
		public static DateTime UnixEpoch { get; private set; }

		public static void StopTime()
		{
			DateTime stoppedTime = DateTime.Now;
			Now = () => stoppedTime;
		}

		public static void ResetNow()
		{
			Now = () => DateTime.Now;
		}
	}
}
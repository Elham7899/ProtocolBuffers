namespace User.Host.MyUtilities
{
	public static class Utilities
	{
		private static string _filePath = "E:\\exercise\\SampleProject\\Sample\\Sample\\Logs\\Log.txt";

		public static string WriteLogs(Exception ex)
		{
			File.AppendAllText(_filePath, $"\n{ex.Message}-{DateTime.Now}");
			File.AppendAllText(_filePath, "\n-----------------------------------------------");

			return "Internal Server Error!";
		}
	}
}
namespace CharacterCreator.Controllers.Utility
{
	public class Utilities
	{
		public static bool AnyEqual(string x, string y, string z)
		{
			if (x.ToLower() == y.ToLower() || x.ToLower() == z.ToLower() || y.ToLower() == z.ToLower()) return true;

			return false;
		}

		public static bool AnyNull(string[] strings)
		{
			foreach (string s in strings)
			{
				if (string.IsNullOrEmpty(s)) return true;
			}

			return false;
		}
	}
}

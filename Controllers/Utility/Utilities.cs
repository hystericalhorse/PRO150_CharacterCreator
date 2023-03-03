namespace CharacterCreator.Controllers.Utility
{
	public class Utilities
	{
		public static bool AnyEqual(string x, string y, string z)
		{
			if (x.ToLower() == y.ToLower() || x.ToLower() == z.ToLower() || y.ToLower() == z.ToLower()) return true;

			return false;
		}

		public static bool AnyNull(string x, string y, string z)
		{
			if (string.IsNullOrEmpty(x)) return true;
			if (string.IsNullOrEmpty(y)) return true;
			if (string.IsNullOrEmpty(z)) return true;

			return false;
		}
	}
}

using CharacterCreator.Models;

namespace CharacterCreator
{
	public class CharacterManager
	{
		public static Character? character { get; private set; } = new();

		public static bool Load(Character ch)
		{
			character = ch;

			return true;
		}

		public static bool Unloaded()
		{
			character = null;

			return true;
		}

	}
}

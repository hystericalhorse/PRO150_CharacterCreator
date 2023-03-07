using CharacterCreator.Models;
namespace CharacterCreator.Interfaces {
	public interface IDataAccessLayer {

		public Accounts getAccount(int id);
		public Accounts getAccount(string Title);
		public IEnumerable<Accounts> getAccounts();
		public void editAccount(Accounts account);
		public void addAccount(Accounts account);
		public void deleteAccount(int id);
		public bool IsAccountLogin(string username, string password);

		public Character getCharacter(int id);
		public Character getCharacter(string name);
		public IEnumerable<Character> getCharacters();
		public void editCharacter(Character character);
		public void addCharacter(Character character);
		public void deleteCharacter(int id);
		public void deleteCharacters();

	}
}
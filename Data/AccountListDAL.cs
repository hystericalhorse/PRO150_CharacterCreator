using CharacterCreator.Interfaces;
using CharacterCreator.Models;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace CharacterCreator.Data {
	public class AccountListDAL : IDataAccessLayer {
		private AppDbContext DB;
		public AccountListDAL(AppDbContext indb) {
			DB = indb;
		}

		// Account
		public void addAccount(Accounts account)
		{
			DB.Accounts.Add(account);
			DB.SaveChanges();
		}


		public void deleteAccount(int id)
		{
			Accounts foundAccount = getAccount(id);
			DB.Accounts.Remove(foundAccount);
			DB.SaveChanges();
		}


		public void editAccount(Accounts account)
		{
			DB.Accounts.Update(account);
			DB.SaveChanges();
		}

        public bool isAccountLogin(string username, string password)
		{
			//Accounts account = DB.Accounts.Where(a => a.Username.ToLower().Equals(password.ToLower())).FirstOrDefault();
			//if (account == null) return true;
			return false;
		}

        public Accounts getAccount(int id)
		{
			return DB.Accounts.Where(a => a.ID == id).FirstOrDefault();
		}

		public Accounts getAccount(string Title)
		{
			return (Accounts)DB.Accounts.Where(c => c.Title.ToLower().Contains(Title.ToLower()));
		}

		public IEnumerable<Accounts> getAccounts()
		{
			return DB.Accounts.ToList();
		}

		public IEnumerable<Accounts> GetMyAccounts(string ID) {
			return DB.Accounts.Where(Presets => Presets.UserID == ID);
		}

        // Character

        public void addCharacter(Character character)
		{
			DB.Characters.Add(character);
			DB.SaveChanges();
		}
		public void deleteCharacter(int id)
		{
			Character foundCharacter = getCharacter(id);
			DB.Characters.Remove(foundCharacter);
			DB.SaveChanges();
		}
		public void editCharacter(Character character)
		{
			DB.Characters.Update(character);
			DB.SaveChanges();
		}
		public Character getCharacter(int id)
		{
			return DB.Characters.Where(c => c.CharacterID == id).FirstOrDefault();
		}
		public Character getCharacter(string name)
		{
			// not 100% sure this works
			return (Character)DB.Characters.Where(c => c.Name.ToLower().Contains(name.ToLower()));
		}
		public IEnumerable<Character> getCharacters()
		{
			return DB.Characters.ToList();
		}

		// future idea of removing all characters tied to accounts
		public void deleteCharacters()
		{
			// gets all characters tied to account
			IEnumerable<Character> characterList = getCharacters();

			foreach (Character character in characterList)
			{
				//DB.Characters.Remove(character);
			}
			DB.SaveChanges();

		}

		public IEnumerable<Character> getCharacters(string account)
		{
			return DB.Characters.Where(c => c.UserID == account.ToString()).ToList();
		}
	}
}